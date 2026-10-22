namespace BookkeepingApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        grpInventory = new GroupBox();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        dgvBooks = new DataGridView();
        btnOrderMissing = new Button();

        grpAddBook = new GroupBox();
        lblNewTitle = new Label();
        txtNewBookTitle = new TextBox();
        lblCoverPreview = new Label();
        pbCoverPreview = new PictureBox();
        btnSelectCover = new Button();
        btnAddBook = new Button();

        grpRentals = new GroupBox();
        lblCustomerName = new Label();
        txtCustomerName = new TextBox();
        lblRentDays = new Label();
        nudRentDays = new NumericUpDown();
        btnRent = new Button();
        dgvRentals = new DataGridView();
        btnReturn = new Button();

        grpInventory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
        grpAddBook.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbCoverPreview).BeginInit();
        grpRentals.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudRentDays).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
        SuspendLayout();

        // 
        // grpInventory
        // 
        grpInventory.Controls.Add(lblSearch);
        grpInventory.Controls.Add(txtSearch);
        grpInventory.Controls.Add(btnSearch);
        grpInventory.Controls.Add(dgvBooks);
        grpInventory.Controls.Add(btnOrderMissing);
        grpInventory.Location = new Point(12, 12);
        grpInventory.Name = "grpInventory";
        grpInventory.Size = new Size(520, 350);
        grpInventory.TabIndex = 0;
        grpInventory.TabStop = false;
        grpInventory.Text = "1. Inventory Management (Select a book to rent)";
        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(15, 30);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(75, 15);
        lblSearch.TabIndex = 4;
        lblSearch.Text = "Search Book:";
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(15, 50);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(395, 23);
        txtSearch.TabIndex = 0;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(420, 49);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(85, 25);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = true;
        // 
        // dgvBooks
        // 
        dgvBooks.AllowUserToAddRows = false;
        dgvBooks.AllowUserToDeleteRows = false;
        dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBooks.Location = new Point(15, 85);
        dgvBooks.Name = "dgvBooks";
        dgvBooks.ReadOnly = true;
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.Size = new Size(490, 205);
        dgvBooks.TabIndex = 3;
        // 
        // btnOrderMissing
        // 
        btnOrderMissing.Enabled = false;
        btnOrderMissing.Location = new Point(15, 300);
        btnOrderMissing.Name = "btnOrderMissing";
        btnOrderMissing.Size = new Size(160, 35);
        btnOrderMissing.TabIndex = 2;
        btnOrderMissing.Text = "Order Missing Book";
        btnOrderMissing.UseVisualStyleBackColor = true;
        // 
        // grpAddBook
        // 
        grpAddBook.Controls.Add(lblNewTitle);
        grpAddBook.Controls.Add(txtNewBookTitle);
        grpAddBook.Controls.Add(lblCoverPreview);
        grpAddBook.Controls.Add(pbCoverPreview);
        grpAddBook.Controls.Add(btnSelectCover);
        grpAddBook.Controls.Add(btnAddBook);
        grpAddBook.Location = new Point(545, 12);
        grpAddBook.Name = "grpAddBook";
        grpAddBook.Size = new Size(325, 350);
        grpAddBook.TabIndex = 1;
        grpAddBook.TabStop = false;
        grpAddBook.Text = "Add New Book";
        // 
        // lblNewTitle
        // 
        lblNewTitle.AutoSize = true;
        lblNewTitle.Location = new Point(20, 30);
        lblNewTitle.Name = "lblNewTitle";
        lblNewTitle.Size = new Size(62, 15);
        lblNewTitle.TabIndex = 8;
        lblNewTitle.Text = "Book Title:";
        // 
        // txtNewBookTitle
        // 
        txtNewBookTitle.Location = new Point(20, 50);
        txtNewBookTitle.Name = "txtNewBookTitle";
        txtNewBookTitle.Size = new Size(285, 23);
        txtNewBookTitle.TabIndex = 4;
        // 
        // lblCoverPreview
        // 
        lblCoverPreview.AutoSize = true;
        lblCoverPreview.Location = new Point(20, 85);
        lblCoverPreview.Name = "lblCoverPreview";
        lblCoverPreview.Size = new Size(86, 15);
        lblCoverPreview.TabIndex = 9;
        lblCoverPreview.Text = "Cover Preview:";
        // 
        // pbCoverPreview
        // 
        pbCoverPreview.BorderStyle = BorderStyle.FixedSingle;
        pbCoverPreview.Location = new Point(20, 105);
        pbCoverPreview.Name = "pbCoverPreview";
        pbCoverPreview.Size = new Size(285, 145);
        pbCoverPreview.SizeMode = PictureBoxSizeMode.Zoom;
        pbCoverPreview.TabIndex = 6;
        pbCoverPreview.TabStop = false;
        // 
        // btnSelectCover
        // 
        btnSelectCover.Location = new Point(20, 260);
        btnSelectCover.Name = "btnSelectCover";
        btnSelectCover.Size = new Size(285, 30);
        btnSelectCover.TabIndex = 5;
        btnSelectCover.Text = "Select Cover Image ...";
        btnSelectCover.UseVisualStyleBackColor = true;
        // 
        // btnAddBook
        // 
        btnAddBook.Location = new Point(20, 300);
        btnAddBook.Name = "btnAddBook";
        btnAddBook.Size = new Size(285, 35);
        btnAddBook.TabIndex = 7;
        btnAddBook.Text = "Add Book";
        btnAddBook.UseVisualStyleBackColor = true;
        // 
        // grpRentals
        // 
        grpRentals.Controls.Add(lblCustomerName);
        grpRentals.Controls.Add(txtCustomerName);
        grpRentals.Controls.Add(lblRentDays);
        grpRentals.Controls.Add(nudRentDays);
        grpRentals.Controls.Add(btnRent);
        grpRentals.Controls.Add(dgvRentals);
        grpRentals.Controls.Add(btnReturn);
        grpRentals.Location = new Point(12, 375);
        grpRentals.Name = "grpRentals";
        grpRentals.Size = new Size(858, 275);
        grpRentals.TabIndex = 2;
        grpRentals.TabStop = false;
        grpRentals.Text = "2. Rental Desk (Select from Inventory to Rent, or from below to Return)";
        // 
        // lblCustomerName
        // 
        lblCustomerName.AutoSize = true;
        lblCustomerName.Location = new Point(15, 35);
        lblCustomerName.Name = "lblCustomerName";
        lblCustomerName.Size = new Size(97, 15);
        lblCustomerName.TabIndex = 0;
        lblCustomerName.Text = "Customer Name:";
        // 
        // txtCustomerName
        // 
        txtCustomerName.Location = new Point(115, 32);
        txtCustomerName.Name = "txtCustomerName";
        txtCustomerName.Size = new Size(150, 23);
        txtCustomerName.TabIndex = 1;
        // 
        // lblRentDays
        // 
        lblRentDays.AutoSize = true;
        lblRentDays.Location = new Point(285, 35);
        lblRentDays.Name = "lblRentDays";
        lblRentDays.Size = new Size(82, 15);
        lblRentDays.TabIndex = 2;
        lblRentDays.Text = "Days To Rent:";
        // 
        // nudRentDays
        // 
        nudRentDays.Location = new Point(370, 32);
        nudRentDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudRentDays.Name = "nudRentDays";
        nudRentDays.Size = new Size(60, 23);
        nudRentDays.TabIndex = 3;
        nudRentDays.Value = new decimal(new int[] { 7, 0, 0, 0 });
        // 
        // btnRent
        // 
        btnRent.Location = new Point(450, 30);
        btnRent.Name = "btnRent";
        btnRent.Size = new Size(120, 28);
        btnRent.TabIndex = 4;
        btnRent.Text = "Rent Selected Book";
        btnRent.UseVisualStyleBackColor = true;
        // 
        // dgvRentals
        // 
        dgvRentals.AllowUserToAddRows = false;
        dgvRentals.AllowUserToDeleteRows = false;
        dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRentals.Location = new Point(15, 75);
        dgvRentals.Name = "dgvRentals";
        dgvRentals.ReadOnly = true;
        dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRentals.Size = new Size(690, 185);
        dgvRentals.TabIndex = 5;
        // 
        // btnReturn
        // 
        btnReturn.Location = new Point(720, 75);
        btnReturn.Name = "btnReturn";
        btnReturn.Size = new Size(120, 45);
        btnReturn.TabIndex = 6;
        btnReturn.Text = "Return Selected";
        btnReturn.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 661);
        Controls.Add(grpRentals);
        Controls.Add(grpAddBook);
        Controls.Add(grpInventory);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Admin Panel - Bookkeeping";

        grpInventory.ResumeLayout(false);
        grpInventory.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
        grpAddBook.ResumeLayout(false);
        grpAddBook.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pbCoverPreview).EndInit();
        grpRentals.ResumeLayout(false);
        grpRentals.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudRentDays).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpInventory;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnSearch;
    private DataGridView dgvBooks;
    private Button btnOrderMissing;

    private GroupBox grpAddBook;
    private Label lblNewTitle;
    private TextBox txtNewBookTitle;
    private Label lblCoverPreview;
    private PictureBox pbCoverPreview;
    private Button btnSelectCover;
    private Button btnAddBook;

    private GroupBox grpRentals;
    private Label lblCustomerName;
    private TextBox txtCustomerName;
    private Label lblRentDays;
    private NumericUpDown nudRentDays;
    private Button btnRent;
    private DataGridView dgvRentals;
    private Button btnReturn;
}