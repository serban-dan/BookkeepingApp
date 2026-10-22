using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookkeepingApp.Interfaces;
using BookkeepingApp.Models;

namespace BookkeepingApp
{
    public partial class MainForm : Form
    {
        private readonly IBookRepository _bookRepo;
        private readonly IRentalRepository _rentalRepo;
        private string _selectedCoverPath = string.Empty;

        // Constructor Injection
        public MainForm(IBookRepository bookRepo, IRentalRepository rentalRepo)
        {
            InitializeComponent();
            _bookRepo = bookRepo;
            _rentalRepo = rentalRepo;

            // Wire up event handlers
            this.Load += MainForm_Load;
            btnSearch.Click += BtnSearch_Click;
            btnSelectCover.Click += BtnSelectCover_Click;
            btnAddBook.Click += BtnAddBook_Click;
            btnOrderMissing.Click += BtnOrderMissing_Click;
            btnRent.Click += BtnRent_Click;
            btnReturn.Click += BtnReturn_Click;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await RefreshBookGridAsync();
            await RefreshRentalsGridAsync();
        }

        private async Task RefreshRentalsGridAsync()
        {
            var rentals = await _rentalRepo.GetActiveRentalsAsync();
            dgvRentals.DataSource = rentals;
        }

        private async Task RefreshBookGridAsync()
        {
            var books = await _bookRepo.GetAllBooksAsync();
            dgvBooks.DataSource = books;
            btnOrderMissing.Enabled = false; // Reset order button
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            var results = await _bookRepo.SearchBooksAsync(query);

            dgvBooks.DataSource = results;

            // Enable the Order button if search yields no results and query isn't empty
            if (results.Count == 0 && !string.IsNullOrEmpty(query))
            {
                btnOrderMissing.Enabled = true;
            }
            else
            {
                btnOrderMissing.Enabled = false;
            }
        }

        private void BtnSelectCover_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedCoverPath = ofd.FileName;
                    pbCoverPreview.ImageLocation = _selectedCoverPath;
                }
            }
        }

        private async void BtnAddBook_Click(object sender, EventArgs e)
        {
            string newTitle = txtNewBookTitle.Text.Trim();

            if (string.IsNullOrWhiteSpace(newTitle))
            {
                MessageBox.Show("Please enter a book title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DUPLICATE CHECKING
            var existingBook = await _bookRepo.GetBookByTitleAsync(newTitle);

            if (existingBook != null)
            {
                // Prompt the clerk to just add a copy instead of creating a new database entry
                var result = MessageBox.Show($"'{newTitle}' is already in the inventory (Total Copies: {existingBook.TotalCopies}).\n\nWould you like to add 1 more copy to the existing stock?",
                    "Duplicate Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _bookRepo.AddCopiesAsync(existingBook.Id, 1);
                    await RefreshBookGridAsync();
                    MessageBox.Show("1 copy added to existing inventory.", "Stock Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            // If it's not a duplicate, add it normally
            var newBook = new Book
            {
                Title = newTitle,
                CoverImagePath = _selectedCoverPath,
                TotalCopies = 1,
                AvailableCopies = 1
            };

            await _bookRepo.AddBookAsync(newBook);

            txtNewBookTitle.Clear();
            _selectedCoverPath = string.Empty;
            pbCoverPreview.ImageLocation = null;

            await RefreshBookGridAsync();
            MessageBox.Show("New book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnOrderMissing_Click(object sender, EventArgs e)
        {
            string missingTitle = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(missingTitle))
            {
                MessageBox.Show("Please type the name of the missing book in the search box first.",
                    "Missing Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable button to prevent double-clicks
            btnOrderMissing.Enabled = false;

            try
            {
                // Place the order
                var order = await _bookRepo.OrderMissingBookAsync(missingTitle);

                MessageBox.Show($"Successfully ordered: '{order.BookTitle}'\n\nEstimated Arrival: {order.EstimatedArrival.ToShortDateString()}",
                                "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clean up UI
                txtSearch.Clear();
                await RefreshBookGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to order book: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOrderMissing.Enabled = true; // Re-enable if it failed
            }
        }

        private async void BtnRent_Click(object sender, EventArgs e)
        {
            // 1. Validate inputs
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter the customer's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book from the Inventory grid first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Extract the selected Book
            var selectedRow = dgvBooks.SelectedRows[0];
            var bookId = selectedRow.Cells["Id"].Value.ToString();
            var isAvailable = (bool)selectedRow.Cells["IsAvailable"].Value;

            if (!isAvailable)
            {
                MessageBox.Show("This book is already rented out!", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Create and save the Rental
            int days = (int)nudRentDays.Value;
            var rental = new Rental
            {
                RentalId = Guid.NewGuid().ToString(),
                BookId = bookId,
                CustomerName = txtCustomerName.Text.Trim(),
                RentDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(days),
                IsReturned = false
            };

            await _rentalRepo.RentBookAsync(rental);

            // 4. Clean up UI and refresh
            txtCustomerName.Clear();
            nudRentDays.Value = 7;
            await RefreshBookGridAsync();
            await RefreshRentalsGridAsync();

            MessageBox.Show("Book successfully rented!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnReturn_Click(object sender, EventArgs e)
        {
            // 1. Validate selection
            if (dgvRentals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rental record from the Active Rentals grid.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Process Return
            var selectedRow = dgvRentals.SelectedRows[0];
            var rentalId = selectedRow.Cells["RentalId"].Value.ToString();
            var customer = selectedRow.Cells["CustomerName"].Value.ToString();

            decimal lateFee = await _rentalRepo.ReturnBookAsync(rentalId);

            // 3. Handle late fees
            if (lateFee > 0)
            {
                MessageBox.Show($"Book returned by {customer}.\n\nWARNING: The book was overdue.\nLate Fee to Collect: ${lateFee:0.00}",
                                "Late Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Book returned successfully by {customer} on time. No fees due.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 4. Refresh Grids
            await RefreshBookGridAsync();
            await RefreshRentalsGridAsync();
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            new StatisticsForm().ShowDialog();
        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            ApplyTheme(chkDarkMode.Checked);
        }

        private void ApplyTheme(bool isDark)
        {
            // Define our color palettes
            Color backColor = isDark ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            Color foreColor = isDark ? Color.White : SystemColors.ControlText;
            Color inputBackColor = isDark ? Color.FromArgb(60, 60, 60) : SystemColors.Window;
            Color gridBackColor = isDark ? Color.FromArgb(30, 30, 30) : SystemColors.AppWorkspace;

            // Apply to the main form itself
            this.BackColor = backColor;
            this.ForeColor = foreColor;

            // Apply to all nested controls
            UpdateControlColors(this.Controls, backColor, foreColor, inputBackColor, gridBackColor, isDark);
        }

        private void UpdateControlColors(Control.ControlCollection controls, Color back, Color fore, Color inputBack, Color gridBack, bool isDark)
        {
            foreach (Control c in controls)
            {
                // Recursively update nested controls (like things inside GroupBoxes)
                if (c.HasChildren)
                {
                    UpdateControlColors(c.Controls, back, fore, inputBack, gridBack, isDark);
                }

                // Apply specific styles based on the control type
                if (c is Button b)
                {
                    b.FlatStyle = isDark ? FlatStyle.Flat : FlatStyle.Standard;
                    b.BackColor = inputBack;
                    b.ForeColor = fore;
                    if (isDark) b.FlatAppearance.BorderColor = Color.Gray;
                }
                else if (c is TextBox t)
                {
                    t.BackColor = inputBack;
                    t.ForeColor = fore;
                    t.BorderStyle = isDark ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
                }
                else if (c is NumericUpDown n)
                {
                    n.BackColor = inputBack;
                    n.ForeColor = fore;
                }
                else if (c is DataGridView dgv)
                {
                    // Grid requires specific cell-level styling
                    dgv.BackgroundColor = gridBack;
                    dgv.DefaultCellStyle.BackColor = inputBack;
                    dgv.DefaultCellStyle.ForeColor = fore;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = back;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = fore;
                    dgv.RowHeadersDefaultCellStyle.BackColor = back;

                    // WinForms requires disabling visual styles to custom-paint grid headers
                    dgv.EnableHeadersVisualStyles = !isDark;
                }
                else if (c is GroupBox g)
                {
                    g.ForeColor = fore;
                }
            }
        }
    }
}