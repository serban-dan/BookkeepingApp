namespace BookkeepingApp;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
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

        grpInventory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
        grpAddBook.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbCoverPreview).BeginInit();
        SuspendLayout();

        // 
        // grpInventory
        // 
        grpInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grpInventory.Controls.Add(lblSearch);
        grpInventory.Controls.Add(txtSearch);
        grpInventory.Controls.Add(btnSearch);
        grpInventory.Controls.Add(dgvBooks);
        grpInventory.Controls.Add(btnOrderMissing);
        grpInventory.Location = new Point(12, 12);
        grpInventory.Name = "grpInventory";
        grpInventory.Size = new Size(520, 480);
        grpInventory.TabIndex = 0;
        grpInventory.TabStop = false;
        grpInventory.Text = "Inventory Management";
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
        txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.Location = new Point(15, 50);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(395, 23);
        txtSearch.TabIndex = 0;
        // 
        // btnSearch
        // 
        btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
        dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBooks.Location = new Point(15, 85);
        dgvBooks.Name = "dgvBooks";
        dgvBooks.ReadOnly = true;
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.Size = new Size(490, 335);
        dgvBooks.TabIndex = 3;
        // 
        // btnOrderMissing
        // 
        btnOrderMissing.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnOrderMissing.Enabled = false;
        btnOrderMissing.Location = new Point(15, 430);
        btnOrderMissing.Name = "btnOrderMissing";
        btnOrderMissing.Size = new Size(160, 35);
        btnOrderMissing.TabIndex = 2;
        btnOrderMissing.Text = "Order Missing Book";
        btnOrderMissing.UseVisualStyleBackColor = true;
        // 
        // grpAddBook
        // 
        grpAddBook.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        grpAddBook.Controls.Add(lblNewTitle);
        grpAddBook.Controls.Add(txtNewBookTitle);
        grpAddBook.Controls.Add(lblCoverPreview);
        grpAddBook.Controls.Add(pbCoverPreview);
        grpAddBook.Controls.Add(btnSelectCover);
        grpAddBook.Controls.Add(btnAddBook);
        grpAddBook.Location = new Point(545, 12);
        grpAddBook.Name = "grpAddBook";
        grpAddBook.Size = new Size(325, 480);
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
        pbCoverPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pbCoverPreview.BorderStyle = BorderStyle.FixedSingle;
        pbCoverPreview.Location = new Point(20, 105);
        pbCoverPreview.Name = "pbCoverPreview";
        pbCoverPreview.Size = new Size(285, 275);
        pbCoverPreview.SizeMode = PictureBoxSizeMode.Zoom;
        pbCoverPreview.TabIndex = 6;
        pbCoverPreview.TabStop = false;
        // 
        // btnSelectCover
        // 
        btnSelectCover.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btnSelectCover.Location = new Point(20, 390);
        btnSelectCover.Name = "btnSelectCover";
        btnSelectCover.Size = new Size(285, 30);
        btnSelectCover.TabIndex = 5;
        btnSelectCover.Text = "Select Cover Image ...";
        btnSelectCover.UseVisualStyleBackColor = true;
        // 
        // btnAddBook
        // 
        btnAddBook.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btnAddBook.Location = new Point(20, 430);
        btnAddBook.Name = "btnAddBook";
        btnAddBook.Size = new Size(285, 35);
        btnAddBook.TabIndex = 7;
        btnAddBook.Text = "Add Book";
        btnAddBook.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 511);
        Controls.Add(grpAddBook);
        Controls.Add(grpInventory);
        MinimumSize = new Size(750, 450);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Admin Panel - Bookkeeping";

        grpInventory.ResumeLayout(false);
        grpInventory.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
        grpAddBook.ResumeLayout(false);
        grpAddBook.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pbCoverPreview).EndInit();
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
}