namespace QuanLyThuVienSachCaNhan
{
    partial class frmBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBook));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbThemSach = new System.Windows.Forms.ToolStripDropDownButton();
            this.thêmThủCôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmTừFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSuaTT = new System.Windows.Forms.ToolStripButton();
            this.tsbXoaSach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMuonSach = new System.Windows.Forms.ToolStripButton();
            this.tsbTraSach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLamMoi = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrowing = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Borrower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbbTimKiem = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiemNangCao = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlTTSach = new System.Windows.Forms.Panel();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlTTSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbThemSach,
            this.tsbSuaTT,
            this.tsbXoaSach,
            this.toolStripSeparator3,
            this.tsbMuonSach,
            this.tsbTraSach,
            this.toolStripSeparator1,
            this.tsbLamMoi});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1262, 90);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbThemSach
            // 
            this.tsbThemSach.AutoSize = false;
            this.tsbThemSach.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmThủCôngToolStripMenuItem,
            this.thêmTừFileToolStripMenuItem});
            this.tsbThemSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbThemSach.Image = ((System.Drawing.Image)(resources.GetObject("tsbThemSach.Image")));
            this.tsbThemSach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbThemSach.Name = "tsbThemSach";
            this.tsbThemSach.Size = new System.Drawing.Size(120, 70);
            this.tsbThemSach.Text = "Thêm sách";
            this.tsbThemSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbThemSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // thêmThủCôngToolStripMenuItem
            // 
            this.thêmThủCôngToolStripMenuItem.Name = "thêmThủCôngToolStripMenuItem";
            this.thêmThủCôngToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.thêmThủCôngToolStripMenuItem.Text = "Thêm thông tin sách";
            // 
            // thêmTừFileToolStripMenuItem
            // 
            this.thêmTừFileToolStripMenuItem.Name = "thêmTừFileToolStripMenuItem";
            this.thêmTừFileToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.thêmTừFileToolStripMenuItem.Text = "Thêm từ File";
            // 
            // tsbSuaTT
            // 
            this.tsbSuaTT.AutoSize = false;
            this.tsbSuaTT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbSuaTT.Image = ((System.Drawing.Image)(resources.GetObject("tsbSuaTT.Image")));
            this.tsbSuaTT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSuaTT.Name = "tsbSuaTT";
            this.tsbSuaTT.Size = new System.Drawing.Size(130, 70);
            this.tsbSuaTT.Text = "Sửa thông tin";
            this.tsbSuaTT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSuaTT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbXoaSach
            // 
            this.tsbXoaSach.AutoSize = false;
            this.tsbXoaSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbXoaSach.Image = ((System.Drawing.Image)(resources.GetObject("tsbXoaSach.Image")));
            this.tsbXoaSach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbXoaSach.Name = "tsbXoaSach";
            this.tsbXoaSach.Size = new System.Drawing.Size(115, 70);
            this.tsbXoaSach.Text = "Xóa sách";
            this.tsbXoaSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbXoaSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 90);
            // 
            // tsbMuonSach
            // 
            this.tsbMuonSach.AutoSize = false;
            this.tsbMuonSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbMuonSach.Image = ((System.Drawing.Image)(resources.GetObject("tsbMuonSach.Image")));
            this.tsbMuonSach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMuonSach.Name = "tsbMuonSach";
            this.tsbMuonSach.Size = new System.Drawing.Size(115, 70);
            this.tsbMuonSach.Text = "Mượn sách";
            this.tsbMuonSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbMuonSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbTraSach
            // 
            this.tsbTraSach.AutoSize = false;
            this.tsbTraSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbTraSach.Image = ((System.Drawing.Image)(resources.GetObject("tsbTraSach.Image")));
            this.tsbTraSach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTraSach.Name = "tsbTraSach";
            this.tsbTraSach.Size = new System.Drawing.Size(115, 70);
            this.tsbTraSach.Text = "Trả sách";
            this.tsbTraSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbTraSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 90);
            // 
            // tsbLamMoi
            // 
            this.tsbLamMoi.AutoSize = false;
            this.tsbLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("tsbLamMoi.Image")));
            this.tsbLamMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLamMoi.Name = "tsbLamMoi";
            this.tsbLamMoi.Size = new System.Drawing.Size(115, 70);
            this.tsbLamMoi.Text = "Làm mới";
            this.tsbLamMoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1262, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSach.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.Author,
            this.Topic,
            this.Publisher,
            this.PublishDate,
            this.DateAdded,
            this.FileSize,
            this.Borrowing,
            this.Borrower,
            this.LoanDate,
            this.DueDate});
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(0, 0);
            this.dgvSach.MultiSelect = false;
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersVisible = false;
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(980, 490);
            this.dgvSach.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 70;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Tiêu đề";
            this.Title.MinimumWidth = 200;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.HeaderText = "Tác giả";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            this.Author.Width = 155;
            // 
            // Topic
            // 
            this.Topic.HeaderText = "Chủ đề";
            this.Topic.MinimumWidth = 6;
            this.Topic.Name = "Topic";
            this.Topic.ReadOnly = true;
            this.Topic.Width = 155;
            // 
            // Publisher
            // 
            this.Publisher.HeaderText = "Nhà xuất bản";
            this.Publisher.MinimumWidth = 6;
            this.Publisher.Name = "Publisher";
            this.Publisher.ReadOnly = true;
            this.Publisher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Publisher.Width = 155;
            // 
            // PublishDate
            // 
            dataGridViewCellStyle32.Format = "dd/MM/yyyy";
            this.PublishDate.DefaultCellStyle = dataGridViewCellStyle32;
            this.PublishDate.HeaderText = "Ngày xuất bản";
            this.PublishDate.MinimumWidth = 6;
            this.PublishDate.Name = "PublishDate";
            this.PublishDate.ReadOnly = true;
            this.PublishDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PublishDate.Width = 155;
            // 
            // DateAdded
            // 
            dataGridViewCellStyle33.Format = "dd/MM/yyyy";
            this.DateAdded.DefaultCellStyle = dataGridViewCellStyle33;
            this.DateAdded.HeaderText = "Ngày nhập";
            this.DateAdded.MinimumWidth = 6;
            this.DateAdded.Name = "DateAdded";
            this.DateAdded.ReadOnly = true;
            this.DateAdded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DateAdded.Width = 155;
            // 
            // FileSize
            // 
            dataGridViewCellStyle34.Format = "N2";
            this.FileSize.DefaultCellStyle = dataGridViewCellStyle34;
            this.FileSize.HeaderText = "Dung lượng (MB)";
            this.FileSize.MinimumWidth = 6;
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            this.FileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FileSize.Width = 155;
            // 
            // Borrowing
            // 
            this.Borrowing.HeaderText = "Trạng thái mượn";
            this.Borrowing.MinimumWidth = 6;
            this.Borrowing.Name = "Borrowing";
            this.Borrowing.ReadOnly = true;
            this.Borrowing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Borrowing.Width = 155;
            // 
            // Borrower
            // 
            this.Borrower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Borrower.HeaderText = "Người mượn";
            this.Borrower.MinimumWidth = 200;
            this.Borrower.Name = "Borrower";
            this.Borrower.ReadOnly = true;
            this.Borrower.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoanDate
            // 
            dataGridViewCellStyle35.Format = "dd/MM/yyyy";
            this.LoanDate.DefaultCellStyle = dataGridViewCellStyle35;
            this.LoanDate.HeaderText = "Ngày mượn";
            this.LoanDate.MinimumWidth = 6;
            this.LoanDate.Name = "LoanDate";
            this.LoanDate.ReadOnly = true;
            this.LoanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoanDate.Width = 155;
            // 
            // DueDate
            // 
            dataGridViewCellStyle36.Format = "dd/MM/yyyy";
            this.DueDate.DefaultCellStyle = dataGridViewCellStyle36;
            this.DueDate.HeaderText = "Hạn trả";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DueDate.Width = 155;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.cbbTimKiem);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(92, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1125, 41);
            this.panel5.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyThuVienSachCaNhan.Properties.Resources.loupe;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(948, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 41);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // cbbTimKiem
            // 
            this.cbbTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTimKiem.FormattingEnabled = true;
            this.cbbTimKiem.Location = new System.Drawing.Point(0, 4);
            this.cbbTimKiem.Name = "cbbTimKiem";
            this.cbbTimKiem.Size = new System.Drawing.Size(920, 33);
            this.cbbTimKiem.TabIndex = 5;
            this.cbbTimKiem.SelectedIndexChanged += new System.EventHandler(this.cbbTimKiem_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Controls.Add(this.splitter1);
            this.panel7.Controls.Add(this.btnTimKiem);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(989, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(136, 41);
            this.panel7.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 41);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(10, 0);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(126, 41);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTimKiemNangCao);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 71);
            this.panel1.TabIndex = 2;
            // 
            // btnTimKiemNangCao
            // 
            this.btnTimKiemNangCao.BackColor = System.Drawing.SystemColors.Control;
            this.btnTimKiemNangCao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimKiemNangCao.BackgroundImage")));
            this.btnTimKiemNangCao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTimKiemNangCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemNangCao.FlatAppearance.BorderSize = 0;
            this.btnTimKiemNangCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemNangCao.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemNangCao.Location = new System.Drawing.Point(29, 12);
            this.btnTimKiemNangCao.Name = "btnTimKiemNangCao";
            this.btnTimKiemNangCao.Size = new System.Drawing.Size(41, 41);
            this.btnTimKiemNangCao.TabIndex = 4;
            this.btnTimKiemNangCao.UseVisualStyleBackColor = false;
            this.btnTimKiemNangCao.Click += new System.EventHandler(this.btnTimKiemNangCao_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 161);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlTTSach);
            this.splitContainer1.Panel1.Controls.Add(this.pnlBoLoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSach);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 490);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // pnlTTSach
            // 
            this.pnlTTSach.Controls.Add(this.tableLayoutPanel1);
            this.pnlTTSach.Controls.Add(this.pictureBox2);
            this.pnlTTSach.Location = new System.Drawing.Point(12, 179);
            this.pnlTTSach.Name = "pnlTTSach";
            this.pnlTTSach.Size = new System.Drawing.Size(240, 281);
            this.pnlTTSach.TabIndex = 1;
            // 
            // pnlBoLoc
            // 
            this.pnlBoLoc.Location = new System.Drawing.Point(12, 22);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(240, 129);
            this.pnlBoLoc.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 156);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 156);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 125);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // frmBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "frmBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý thư viện sách cá nhân";
            this.Load += new System.EventHandler(this.frmBook_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlTTSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton tsbSuaTT;
        private System.Windows.Forms.ToolStripButton tsbXoaSach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbMuonSach;
        private System.Windows.Forms.ToolStripButton tsbTraSach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLamMoi;
        private System.Windows.Forms.ToolStripDropDownButton tsbThemSach;
        private System.Windows.Forms.ToolStripMenuItem thêmThủCôngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmTừFileToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbbTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTimKiemNangCao;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Topic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Publisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAdded;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Borrowing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Borrower;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.Panel pnlTTSach;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

