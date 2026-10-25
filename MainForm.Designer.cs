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
        btnViewStats = new Button();
        lblCustomerName = new Label();
        txtCustomerName = new TextBox();
        lblRentDays = new Label();
        nudRentDays = new NumericUpDown();
        btnRent = new Button();
        dgvRentals = new DataGridView();
        btnReturn = new Button();
        chkDarkMode = new CheckBox();
        ChkSimulateTime = new CheckBox();
        DtpSimulateTime = new DateTimePicker();
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
        grpInventory.Location = new Point(14, 56);
        grpInventory.Margin = new Padding(3, 4, 3, 4);
        grpInventory.Name = "grpInventory";
        grpInventory.Padding = new Padding(3, 4, 3, 4);
        grpInventory.Size = new Size(594, 467);
        grpInventory.TabIndex = 0;
        grpInventory.TabStop = false;
        grpInventory.Text = "1. Inventory Management (Select a book to rent)";
        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(17, 40);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(94, 20);
        lblSearch.TabIndex = 4;
        lblSearch.Text = "Search Book:";
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(17, 67);
        txtSearch.Margin = new Padding(3, 4, 3, 4);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(451, 27);
        txtSearch.TabIndex = 0;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(480, 65);
        btnSearch.Margin = new Padding(3, 4, 3, 4);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(97, 33);
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
        dgvBooks.Location = new Point(17, 113);
        dgvBooks.Margin = new Padding(3, 4, 3, 4);
        dgvBooks.Name = "dgvBooks";
        dgvBooks.ReadOnly = true;
        dgvBooks.RowHeadersWidth = 51;
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.Size = new Size(560, 273);
        dgvBooks.TabIndex = 3;
        // 
        // btnOrderMissing
        // 
        btnOrderMissing.Enabled = false;
        btnOrderMissing.Location = new Point(17, 400);
        btnOrderMissing.Margin = new Padding(3, 4, 3, 4);
        btnOrderMissing.Name = "btnOrderMissing";
        btnOrderMissing.Size = new Size(183, 47);
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
        grpAddBook.Location = new Point(625, 56);
        grpAddBook.Margin = new Padding(3, 4, 3, 4);
        grpAddBook.Name = "grpAddBook";
        grpAddBook.Padding = new Padding(3, 4, 3, 4);
        grpAddBook.Size = new Size(371, 467);
        grpAddBook.TabIndex = 1;
        grpAddBook.TabStop = false;
        grpAddBook.Text = "Add New Book";
        // 
        // lblNewTitle
        // 
        lblNewTitle.AutoSize = true;
        lblNewTitle.Location = new Point(23, 40);
        lblNewTitle.Name = "lblNewTitle";
        lblNewTitle.Size = new Size(79, 20);
        lblNewTitle.TabIndex = 8;
        lblNewTitle.Text = "Book Title:";
        // 
        // txtNewBookTitle
        // 
        txtNewBookTitle.Location = new Point(23, 67);
        txtNewBookTitle.Margin = new Padding(3, 4, 3, 4);
        txtNewBookTitle.Name = "txtNewBookTitle";
        txtNewBookTitle.Size = new Size(325, 27);
        txtNewBookTitle.TabIndex = 4;
        // 
        // lblCoverPreview
        // 
        lblCoverPreview.AutoSize = true;
        lblCoverPreview.Location = new Point(23, 113);
        lblCoverPreview.Name = "lblCoverPreview";
        lblCoverPreview.Size = new Size(105, 20);
        lblCoverPreview.TabIndex = 9;
        lblCoverPreview.Text = "Cover Preview:";
        // 
        // pbCoverPreview
        // 
        pbCoverPreview.BorderStyle = BorderStyle.FixedSingle;
        pbCoverPreview.Location = new Point(23, 140);
        pbCoverPreview.Margin = new Padding(3, 4, 3, 4);
        pbCoverPreview.Name = "pbCoverPreview";
        pbCoverPreview.Size = new Size(325, 193);
        pbCoverPreview.SizeMode = PictureBoxSizeMode.Zoom;
        pbCoverPreview.TabIndex = 6;
        pbCoverPreview.TabStop = false;
        // 
        // btnSelectCover
        // 
        btnSelectCover.Location = new Point(23, 347);
        btnSelectCover.Margin = new Padding(3, 4, 3, 4);
        btnSelectCover.Name = "btnSelectCover";
        btnSelectCover.Size = new Size(326, 40);
        btnSelectCover.TabIndex = 5;
        btnSelectCover.Text = "Select Cover Image ...";
        btnSelectCover.UseVisualStyleBackColor = true;
        // 
        // btnAddBook
        // 
        btnAddBook.Location = new Point(23, 400);
        btnAddBook.Margin = new Padding(3, 4, 3, 4);
        btnAddBook.Name = "btnAddBook";
        btnAddBook.Size = new Size(326, 47);
        btnAddBook.TabIndex = 7;
        btnAddBook.Text = "Add Book";
        btnAddBook.UseVisualStyleBackColor = true;
        // 
        // grpRentals
        // 
        grpRentals.Controls.Add(btnViewStats);
        grpRentals.Controls.Add(lblCustomerName);
        grpRentals.Controls.Add(txtCustomerName);
        grpRentals.Controls.Add(lblRentDays);
        grpRentals.Controls.Add(nudRentDays);
        grpRentals.Controls.Add(btnRent);
        grpRentals.Controls.Add(dgvRentals);
        grpRentals.Controls.Add(btnReturn);
        grpRentals.Location = new Point(14, 531);
        grpRentals.Margin = new Padding(3, 4, 3, 4);
        grpRentals.Name = "grpRentals";
        grpRentals.Padding = new Padding(3, 4, 3, 4);
        grpRentals.Size = new Size(981, 367);
        grpRentals.TabIndex = 2;
        grpRentals.TabStop = false;
        grpRentals.Text = "2. Rental Desk (Select from Inventory to Rent, or from below to Return)";
        // 
        // btnViewStats
        // 
        btnViewStats.Location = new Point(823, 168);
        btnViewStats.Margin = new Padding(3, 4, 3, 4);
        btnViewStats.Name = "btnViewStats";
        btnViewStats.Size = new Size(135, 72);
        btnViewStats.TabIndex = 7;
        btnViewStats.Text = "View Store Statistics";
        btnViewStats.UseVisualStyleBackColor = true;
        btnViewStats.Click += BtnViewStats_Click;
        // 
        // lblCustomerName
        // 
        lblCustomerName.AutoSize = true;
        lblCustomerName.Location = new Point(17, 47);
        lblCustomerName.Name = "lblCustomerName";
        lblCustomerName.Size = new Size(119, 20);
        lblCustomerName.TabIndex = 0;
        lblCustomerName.Text = "Customer Name:";
        // 
        // txtCustomerName
        // 
        txtCustomerName.Location = new Point(142, 44);
        txtCustomerName.Margin = new Padding(3, 4, 3, 4);
        txtCustomerName.Name = "txtCustomerName";
        txtCustomerName.Size = new Size(171, 27);
        txtCustomerName.TabIndex = 1;
        // 
        // lblRentDays
        // 
        lblRentDays.AutoSize = true;
        lblRentDays.Location = new Point(326, 47);
        lblRentDays.Name = "lblRentDays";
        lblRentDays.Size = new Size(98, 20);
        lblRentDays.TabIndex = 2;
        lblRentDays.Text = "Days To Rent:";
        // 
        // nudRentDays
        // 
        nudRentDays.Location = new Point(430, 44);
        nudRentDays.Margin = new Padding(3, 4, 3, 4);
        nudRentDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudRentDays.Name = "nudRentDays";
        nudRentDays.Size = new Size(69, 27);
        nudRentDays.TabIndex = 3;
        nudRentDays.Value = new decimal(new int[] { 7, 0, 0, 0 });
        // 
        // btnRent
        // 
        btnRent.Location = new Point(525, 44);
        btnRent.Margin = new Padding(3, 4, 3, 4);
        btnRent.Name = "btnRent";
        btnRent.Size = new Size(137, 27);
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
        dgvRentals.Location = new Point(17, 100);
        dgvRentals.Margin = new Padding(3, 4, 3, 4);
        dgvRentals.Name = "dgvRentals";
        dgvRentals.ReadOnly = true;
        dgvRentals.RowHeadersWidth = 51;
        dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRentals.Size = new Size(789, 247);
        dgvRentals.TabIndex = 5;
        // 
        // btnReturn
        // 
        btnReturn.Location = new Point(823, 100);
        btnReturn.Margin = new Padding(3, 4, 3, 4);
        btnReturn.Name = "btnReturn";
        btnReturn.Size = new Size(137, 60);
        btnReturn.TabIndex = 6;
        btnReturn.Text = "Return Selected";
        btnReturn.UseVisualStyleBackColor = true;
        // 
        // chkDarkMode
        // 
        chkDarkMode.AutoSize = true;
        chkDarkMode.Location = new Point(14, 16);
        chkDarkMode.Margin = new Padding(3, 4, 3, 4);
        chkDarkMode.Name = "chkDarkMode";
        chkDarkMode.Size = new Size(105, 24);
        chkDarkMode.TabIndex = 3;
        chkDarkMode.Text = "Dark Mode";
        chkDarkMode.UseVisualStyleBackColor = true;
        chkDarkMode.CheckedChanged += ChkDarkMode_CheckedChanged;
        // 
        // ChkSimulateTime
        // 
        ChkSimulateTime.Location = new Point(102, 12);
        ChkSimulateTime.Name = "ChkSimulateTime";
        ChkSimulateTime.Size = new Size(114, 23);
        ChkSimulateTime.TabIndex = 6;
        ChkSimulateTime.Text = "Simulate Time";
        ChkSimulateTime.CheckedChanged += ChkSimulateTime_CheckedChanged;
        // 
        // DtpSimulateTime
        // 
        DtpSimulateTime.Enabled = false;
        DtpSimulateTime.Format = DateTimePickerFormat.Short;
        DtpSimulateTime.Location = new Point(233, 12);
        DtpSimulateTime.Name = "DtpSimulateTime";
        DtpSimulateTime.Size = new Size(99, 23);
        DtpSimulateTime.TabIndex = 5;
        DtpSimulateTime.ValueChanged += DtpSimulateTime_ValueChanged;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 693);
        Controls.Add(DtpSimulateTime);
        Controls.Add(ChkSimulateTime);
        Controls.Add(chkDarkMode);
        Controls.Add(grpRentals);
        Controls.Add(grpAddBook);
        Controls.Add(grpInventory);
        Margin = new Padding(3, 4, 3, 4);
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
        PerformLayout();
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
    private Button btnViewStats;
    private CheckBox chkDarkMode;
    private CheckBox ChkSimulateTime;
    private DateTimePicker DtpSimulateTime;
}