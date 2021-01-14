namespace iClothing
{
    partial class ProductManagement1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagement1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            this.cbArt = new System.Windows.Forms.ComboBox();
            this.txtRong = new System.Windows.Forms.TextBox();
            this.lblRong = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.lblARTID = new System.Windows.Forms.Label();
            this.lblMess = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.txtMieuta = new System.Windows.Forms.TextBox();
            this.lblMieuta = new System.Windows.Forms.Label();
            this.txtPaging = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDai = new System.Windows.Forms.TextBox();
            this.lblDai = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblKihieu = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.dvgProduct = new ADGV.AdvancedDataGridView();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cbPageSize = new System.Windows.Forms.ComboBox();
            this.cbSon = new System.Windows.Forms.ComboBox();
            this.lblSon = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(396, 686);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(38, 21);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 128;
            this.pbLast.TabStop = false;
            this.pbLast.Click += new System.EventHandler(this.pbLast_Click);
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(327, 686);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 127;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(79, 686);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 125;
            this.pbFirst.TabStop = false;
            this.pbFirst.Click += new System.EventHandler(this.pbFirst_Click);
            // 
            // cbArt
            // 
            this.cbArt.FormattingEnabled = true;
            this.cbArt.Location = new System.Drawing.Point(131, 230);
            this.cbArt.Name = "cbArt";
            this.cbArt.Size = new System.Drawing.Size(121, 21);
            this.cbArt.TabIndex = 122;
            // 
            // txtRong
            // 
            this.txtRong.BackColor = System.Drawing.Color.White;
            this.txtRong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRong.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRong.Location = new System.Drawing.Point(300, 186);
            this.txtRong.Name = "txtRong";
            this.txtRong.Size = new System.Drawing.Size(66, 26);
            this.txtRong.TabIndex = 121;
            this.txtRong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRong_KeyPress);
            // 
            // lblRong
            // 
            this.lblRong.AutoSize = true;
            this.lblRong.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRong.ForeColor = System.Drawing.Color.Orange;
            this.lblRong.Location = new System.Drawing.Point(232, 194);
            this.lblRong.Name = "lblRong";
            this.lblRong.Size = new System.Drawing.Size(44, 16);
            this.lblRong.TabIndex = 120;
            this.lblRong.Text = "Rộng";
            // 
            // txtDVT
            // 
            this.txtDVT.BackColor = System.Drawing.Color.White;
            this.txtDVT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDVT.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Location = new System.Drawing.Point(544, 190);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(251, 26);
            this.txtDVT.TabIndex = 119;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVT.ForeColor = System.Drawing.Color.Orange;
            this.lblDVT.Location = new System.Drawing.Point(415, 190);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(38, 16);
            this.lblDVT.TabIndex = 118;
            this.lblDVT.Text = "ĐVT";
            // 
            // lblARTID
            // 
            this.lblARTID.AutoSize = true;
            this.lblARTID.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblARTID.ForeColor = System.Drawing.Color.Orange;
            this.lblARTID.Location = new System.Drawing.Point(6, 230);
            this.lblARTID.Name = "lblARTID";
            this.lblARTID.Size = new System.Drawing.Size(69, 16);
            this.lblARTID.TabIndex = 116;
            this.lblARTID.Text = "Hoạ Tiết";
            // 
            // lblMess
            // 
            this.lblMess.AutoSize = true;
            this.lblMess.Location = new System.Drawing.Point(45, 42);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(0, 13);
            this.lblMess.TabIndex = 99;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(606, 266);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 32);
            this.btnAdd.TabIndex = 98;
            this.btnAdd.Text = "Lưu";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(161, 686);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 21);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 126;
            this.pbPrev.TabStop = false;
            this.pbPrev.Click += new System.EventHandler(this.pbPrev_Click);
            // 
            // txtMieuta
            // 
            this.txtMieuta.BackColor = System.Drawing.Color.White;
            this.txtMieuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMieuta.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMieuta.Location = new System.Drawing.Point(543, 110);
            this.txtMieuta.Multiline = true;
            this.txtMieuta.Name = "txtMieuta";
            this.txtMieuta.Size = new System.Drawing.Size(251, 65);
            this.txtMieuta.TabIndex = 115;
            // 
            // lblMieuta
            // 
            this.lblMieuta.AutoSize = true;
            this.lblMieuta.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMieuta.ForeColor = System.Drawing.Color.Orange;
            this.lblMieuta.Location = new System.Drawing.Point(414, 110);
            this.lblMieuta.Name = "lblMieuta";
            this.lblMieuta.Size = new System.Drawing.Size(64, 16);
            this.lblMieuta.TabIndex = 113;
            this.lblMieuta.Text = "Miêu Tả";
            // 
            // txtPaging
            // 
            this.txtPaging.Location = new System.Drawing.Point(221, 687);
            this.txtPaging.Name = "txtPaging";
            this.txtPaging.Size = new System.Drawing.Size(93, 20);
            this.txtPaging.TabIndex = 112;
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(327, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(129, 32);
            this.btnImport.TabIndex = 111;
            this.btnImport.Text = "Tải lên";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(9, 18);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(308, 26);
            this.txtFile.TabIndex = 110;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(705, 266);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 32);
            this.btnDelete.TabIndex = 109;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDai
            // 
            this.txtDai.BackColor = System.Drawing.Color.White;
            this.txtDai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDai.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDai.Location = new System.Drawing.Point(130, 190);
            this.txtDai.Name = "txtDai";
            this.txtDai.Size = new System.Drawing.Size(66, 26);
            this.txtDai.TabIndex = 108;
            this.txtDai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDai_KeyPress);
            // 
            // lblDai
            // 
            this.lblDai.AutoSize = true;
            this.lblDai.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDai.ForeColor = System.Drawing.Color.Orange;
            this.lblDai.Location = new System.Drawing.Point(6, 194);
            this.lblDai.Name = "lblDai";
            this.lblDai.Size = new System.Drawing.Size(32, 16);
            this.lblDai.TabIndex = 107;
            this.lblDai.Text = "Dài";
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(130, 110);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(236, 26);
            this.txtTen.TabIndex = 106;
            // 
            // lblKihieu
            // 
            this.lblKihieu.AutoSize = true;
            this.lblKihieu.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKihieu.ForeColor = System.Drawing.Color.Orange;
            this.lblKihieu.Location = new System.Drawing.Point(6, 110);
            this.lblKihieu.Name = "lblKihieu";
            this.lblKihieu.Size = new System.Drawing.Size(62, 16);
            this.lblKihieu.TabIndex = 104;
            this.lblKihieu.Text = "Kí Hiệu";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.Orange;
            this.lblBarcode.Location = new System.Drawing.Point(6, 70);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(63, 16);
            this.lblBarcode.TabIndex = 103;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(730, 685);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(65, 14);
            this.lblTotalPage.TabIndex = 101;
            this.lblTotalPage.Text = "Tổng số: 0";
            // 
            // dvgProduct
            // 
            this.dvgProduct.AllowUserToAddRows = false;
            this.dvgProduct.AutoGenerateContextFilters = true;
            this.dvgProduct.BackgroundColor = System.Drawing.Color.White;
            this.dvgProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProduct.DateWithTime = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgProduct.EnableHeadersVisualStyles = false;
            this.dvgProduct.GridColor = System.Drawing.Color.White;
            this.dvgProduct.Location = new System.Drawing.Point(3, 317);
            this.dvgProduct.Name = "dvgProduct";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgProduct.Size = new System.Drawing.Size(826, 347);
            this.dvgProduct.TabIndex = 100;
            this.dvgProduct.TimeFilter = false;
            this.dvgProduct.SortStringChanged += new System.EventHandler(this.dvgProduct_SortStringChanged);
            this.dvgProduct.FilterStringChanged += new System.EventHandler(this.dvgProduct_FilterStringChanged);
            this.dvgProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgProduct_CellClick);
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(130, 70);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(236, 26);
            this.txtBarcode.TabIndex = 105;
            // 
            // cbPageSize
            // 
            this.cbPageSize.ForeColor = System.Drawing.Color.Orange;
            this.cbPageSize.FormattingEnabled = true;
            this.cbPageSize.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100",
            "200"});
            this.cbPageSize.Location = new System.Drawing.Point(533, 682);
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.Size = new System.Drawing.Size(45, 21);
            this.cbPageSize.TabIndex = 129;
            this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
            // 
            // cbSon
            // 
            this.cbSon.FormattingEnabled = true;
            this.cbSon.Location = new System.Drawing.Point(544, 70);
            this.cbSon.Name = "cbSon";
            this.cbSon.Size = new System.Drawing.Size(121, 21);
            this.cbSon.TabIndex = 131;
            // 
            // lblSon
            // 
            this.lblSon.AutoSize = true;
            this.lblSon.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSon.ForeColor = System.Drawing.Color.Orange;
            this.lblSon.Location = new System.Drawing.Point(415, 70);
            this.lblSon.Name = "lblSon";
            this.lblSon.Size = new System.Drawing.Size(35, 16);
            this.lblSon.TabIndex = 130;
            this.lblSon.Text = "Sơn";
            // 
            // txtMaSP
            // 
            this.txtMaSP.BackColor = System.Drawing.Color.White;
            this.txtMaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaSP.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(130, 150);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(236, 26);
            this.txtMaSP.TabIndex = 133;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSP.ForeColor = System.Drawing.Color.Orange;
            this.lblMaSP.Location = new System.Drawing.Point(6, 150);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(68, 16);
            this.lblMaSP.TabIndex = 132;
            this.lblMaSP.Text = "Mã Hàng";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(606, 266);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 32);
            this.btnUpdate.TabIndex = 134;
            this.btnUpdate.Text = "Lưu";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ProductManagement1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lblMaSP);
            this.Controls.Add(this.cbSon);
            this.Controls.Add(this.lblSon);
            this.Controls.Add(this.cbPageSize);
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.cbArt);
            this.Controls.Add(this.txtRong);
            this.Controls.Add(this.lblRong);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.lblDVT);
            this.Controls.Add(this.lblARTID);
            this.Controls.Add(this.lblMess);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.txtMieuta);
            this.Controls.Add(this.lblMieuta);
            this.Controls.Add(this.txtPaging);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtDai);
            this.Controls.Add(this.lblDai);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblKihieu);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.dvgProduct);
            this.Controls.Add(this.txtBarcode);
            this.Name = "ProductManagement1";
            this.Size = new System.Drawing.Size(870, 750);
            this.Load += new System.EventHandler(this.ProductManagement1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbFirst;
        private System.Windows.Forms.ComboBox cbArt;
        private System.Windows.Forms.TextBox txtRong;
        private System.Windows.Forms.Label lblRong;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.Label lblARTID;
        private System.Windows.Forms.Label lblMess;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.TextBox txtMieuta;
        private System.Windows.Forms.Label lblMieuta;
        private System.Windows.Forms.TextBox txtPaging;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDai;
        private System.Windows.Forms.Label lblDai;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblKihieu;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblTotalPage;
        private ADGV.AdvancedDataGridView dvgProduct;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cbPageSize;
        private System.Windows.Forms.ComboBox cbSon;
        private System.Windows.Forms.Label lblSon;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Button btnUpdate;
    }
}
