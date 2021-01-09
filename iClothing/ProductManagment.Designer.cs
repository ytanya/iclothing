namespace iClothing
{
    partial class ProductManagment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagment));
            this.txtMieuta = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblMieuta = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDai = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtKHID = new System.Windows.Forms.TextBox();
            this.lblKihieu = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.dvgColor = new ADGV.AdvancedDataGridView();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kihieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoatiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Son = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mieuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaytao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMess = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSon = new System.Windows.Forms.Label();
            this.lblARTID = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtRong = new System.Windows.Forms.TextBox();
            this.lblRong = new System.Windows.Forms.Label();
            this.cbArt = new System.Windows.Forms.ComboBox();
            this.cbSon = new System.Windows.Forms.ComboBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMieuta
            // 
            this.txtMieuta.BackColor = System.Drawing.Color.White;
            this.txtMieuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMieuta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMieuta.Location = new System.Drawing.Point(542, 92);
            this.txtMieuta.Multiline = true;
            this.txtMieuta.Name = "txtMieuta";
            this.txtMieuta.Size = new System.Drawing.Size(251, 80);
            this.txtMieuta.TabIndex = 79;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.ForeColor = System.Drawing.Color.Orange;
            this.lblLoai.Location = new System.Drawing.Point(413, 178);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(38, 16);
            this.lblLoai.TabIndex = 78;
            this.lblLoai.Text = "Loại";
            // 
            // lblMieuta
            // 
            this.lblMieuta.AutoSize = true;
            this.lblMieuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMieuta.ForeColor = System.Drawing.Color.Orange;
            this.lblMieuta.Location = new System.Drawing.Point(413, 92);
            this.lblMieuta.Name = "lblMieuta";
            this.lblMieuta.Size = new System.Drawing.Size(64, 16);
            this.lblMieuta.TabIndex = 77;
            this.lblMieuta.Text = "Miêu Tả";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(174, 727);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 74;
            this.textBox2.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(326, 31);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(129, 32);
            this.btnImport.TabIndex = 70;
            this.btnImport.Text = "Tải lên";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(8, 32);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(308, 26);
            this.txtFile.TabIndex = 69;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(667, 267);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 32);
            this.btnDelete.TabIndex = 68;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.Color.White;
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(132, 173);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(66, 26);
            this.txtDiaChi.TabIndex = 67;
            // 
            // lblDai
            // 
            this.lblDai.AutoSize = true;
            this.lblDai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDai.ForeColor = System.Drawing.Color.Orange;
            this.lblDai.Location = new System.Drawing.Point(3, 173);
            this.lblDai.Name = "lblDai";
            this.lblDai.Size = new System.Drawing.Size(32, 16);
            this.lblDai.TabIndex = 66;
            this.lblDai.Text = "Dài";
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(132, 132);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(251, 26);
            this.txtTen.TabIndex = 65;
            // 
            // txtKHID
            // 
            this.txtKHID.BackColor = System.Drawing.Color.White;
            this.txtKHID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKHID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKHID.Location = new System.Drawing.Point(132, 92);
            this.txtKHID.Name = "txtKHID";
            this.txtKHID.Size = new System.Drawing.Size(251, 26);
            this.txtKHID.TabIndex = 64;
            // 
            // lblKihieu
            // 
            this.lblKihieu.AutoSize = true;
            this.lblKihieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKihieu.ForeColor = System.Drawing.Color.Orange;
            this.lblKihieu.Location = new System.Drawing.Point(3, 132);
            this.lblKihieu.Name = "lblKihieu";
            this.lblKihieu.Size = new System.Drawing.Size(57, 16);
            this.lblKihieu.TabIndex = 63;
            this.lblKihieu.Text = "Kí Hiệu";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.Orange;
            this.lblBarcode.Location = new System.Drawing.Point(3, 92);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(67, 16);
            this.lblBarcode.TabIndex = 62;
            this.lblBarcode.Text = "Barcode";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(2, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(826, 2);
            this.label2.TabIndex = 61;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(729, 699);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(81, 13);
            this.lblTotalPage.TabIndex = 58;
            this.lblTotalPage.Text = "Total rows: 0";
            // 
            // dvgColor
            // 
            this.dvgColor.AllowUserToAddRows = false;
            this.dvgColor.AutoGenerateContextFilters = true;
            this.dvgColor.BackgroundColor = System.Drawing.Color.White;
            this.dvgColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgColor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgColor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.Kihieu,
            this.Dai,
            this.Rong,
            this.Hoatiet,
            this.Son,
            this.Mieuta,
            this.Loai,
            this.DVT,
            this.Ngaytao,
            this.Ngaysua});
            this.dvgColor.DateWithTime = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgColor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgColor.EnableHeadersVisualStyles = false;
            this.dvgColor.GridColor = System.Drawing.Color.White;
            this.dvgColor.Location = new System.Drawing.Point(2, 418);
            this.dvgColor.Name = "dvgColor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgColor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgColor.Size = new System.Drawing.Size(866, 260);
            this.dvgColor.TabIndex = 57;
            this.dvgColor.TimeFilter = false;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "KHID";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.MinimumWidth = 22;
            this.Barcode.Name = "Barcode";
            this.Barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Kihieu
            // 
            this.Kihieu.DataPropertyName = "Hihieu";
            this.Kihieu.HeaderText = "Ki Hiieu";
            this.Kihieu.MinimumWidth = 22;
            this.Kihieu.Name = "Kihieu";
            this.Kihieu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Dai
            // 
            this.Dai.DataPropertyName = "Dai";
            this.Dai.HeaderText = "Dai";
            this.Dai.MinimumWidth = 22;
            this.Dai.Name = "Dai";
            this.Dai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Rong
            // 
            this.Rong.DataPropertyName = "Rong";
            this.Rong.HeaderText = "Rong";
            this.Rong.MinimumWidth = 22;
            this.Rong.Name = "Rong";
            this.Rong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Hoatiet
            // 
            this.Hoatiet.DataPropertyName = "Hoa Tiet";
            this.Hoatiet.HeaderText = "Hoa Tiet";
            this.Hoatiet.MinimumWidth = 22;
            this.Hoatiet.Name = "Hoatiet";
            this.Hoatiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Son
            // 
            this.Son.HeaderText = "Son";
            this.Son.MinimumWidth = 22;
            this.Son.Name = "Son";
            this.Son.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Mieuta
            // 
            this.Mieuta.HeaderText = "Mieu Ta";
            this.Mieuta.MinimumWidth = 22;
            this.Mieuta.Name = "Mieuta";
            this.Mieuta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Loai
            // 
            this.Loai.HeaderText = "Loai";
            this.Loai.MinimumWidth = 22;
            this.Loai.Name = "Loai";
            this.Loai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DVT
            // 
            this.DVT.HeaderText = "DVT";
            this.DVT.MinimumWidth = 22;
            this.DVT.Name = "DVT";
            this.DVT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ngaytao
            // 
            this.Ngaytao.DataPropertyName = "Ngaytao";
            this.Ngaytao.HeaderText = "Ngay Tao";
            this.Ngaytao.MinimumWidth = 22;
            this.Ngaytao.Name = "Ngaytao";
            this.Ngaytao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ngaysua
            // 
            this.Ngaysua.DataPropertyName = "Ngaysua";
            this.Ngaysua.HeaderText = "Ngay Sua";
            this.Ngaysua.MinimumWidth = 22;
            this.Ngaysua.Name = "Ngaysua";
            this.Ngaysua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lblMess
            // 
            this.lblMess.AutoSize = true;
            this.lblMess.Location = new System.Drawing.Point(44, 56);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(0, 13);
            this.lblMess.TabIndex = 56;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(532, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 32);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSon
            // 
            this.lblSon.AutoSize = true;
            this.lblSon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSon.ForeColor = System.Drawing.Color.Orange;
            this.lblSon.Location = new System.Drawing.Point(1, 259);
            this.lblSon.Name = "lblSon";
            this.lblSon.Size = new System.Drawing.Size(35, 16);
            this.lblSon.TabIndex = 83;
            this.lblSon.Text = "Sơn";
            // 
            // lblARTID
            // 
            this.lblARTID.AutoSize = true;
            this.lblARTID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblARTID.ForeColor = System.Drawing.Color.Orange;
            this.lblARTID.Location = new System.Drawing.Point(1, 218);
            this.lblARTID.Name = "lblARTID";
            this.lblARTID.Size = new System.Drawing.Size(68, 16);
            this.lblARTID.TabIndex = 81;
            this.lblARTID.Text = "Hoạ Tiết";
            // 
            // txtDVT
            // 
            this.txtDVT.BackColor = System.Drawing.Color.White;
            this.txtDVT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDVT.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Location = new System.Drawing.Point(543, 214);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(251, 26);
            this.txtDVT.TabIndex = 86;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVT.ForeColor = System.Drawing.Color.Orange;
            this.lblDVT.Location = new System.Drawing.Point(414, 214);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(38, 16);
            this.lblDVT.TabIndex = 85;
            this.lblDVT.Text = "ĐVT";
            // 
            // txtRong
            // 
            this.txtRong.BackColor = System.Drawing.Color.White;
            this.txtRong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRong.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRong.Location = new System.Drawing.Point(317, 178);
            this.txtRong.Name = "txtRong";
            this.txtRong.Size = new System.Drawing.Size(66, 26);
            this.txtRong.TabIndex = 90;
            // 
            // lblRong
            // 
            this.lblRong.AutoSize = true;
            this.lblRong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRong.ForeColor = System.Drawing.Color.Orange;
            this.lblRong.Location = new System.Drawing.Point(222, 178);
            this.lblRong.Name = "lblRong";
            this.lblRong.Size = new System.Drawing.Size(45, 16);
            this.lblRong.TabIndex = 89;
            this.lblRong.Text = "Rộng";
            // 
            // cbArt
            // 
            this.cbArt.FormattingEnabled = true;
            this.cbArt.Location = new System.Drawing.Point(130, 208);
            this.cbArt.Name = "cbArt";
            this.cbArt.Size = new System.Drawing.Size(121, 21);
            this.cbArt.TabIndex = 91;
            // 
            // cbSon
            // 
            this.cbSon.FormattingEnabled = true;
            this.cbSon.Location = new System.Drawing.Point(132, 254);
            this.cbSon.Name = "cbSon";
            this.cbSon.Size = new System.Drawing.Size(121, 21);
            this.cbSon.TabIndex = 92;
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(543, 183);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(121, 21);
            this.cbLoai.TabIndex = 93;
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(313, 700);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(38, 21);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 97;
            this.pbLast.TabStop = false;
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(244, 700);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 96;
            this.pbNext.TabStop = false;
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(160, 700);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 21);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 95;
            this.pbPrev.TabStop = false;
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(78, 700);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 94;
            this.pbFirst.TabStop = false;
            // 
            // ProductManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.cbLoai);
            this.Controls.Add(this.cbSon);
            this.Controls.Add(this.cbArt);
            this.Controls.Add(this.txtRong);
            this.Controls.Add(this.lblRong);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.lblDVT);
            this.Controls.Add(this.lblSon);
            this.Controls.Add(this.lblARTID);
            this.Controls.Add(this.txtMieuta);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.lblMieuta);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDai);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtKHID);
            this.Controls.Add(this.lblKihieu);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.dvgColor);
            this.Controls.Add(this.lblMess);
            this.Controls.Add(this.btnSave);
            this.Name = "ProductManagment";
            this.Size = new System.Drawing.Size(870, 750);
            this.Load += new System.EventHandler(this.ProductManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMieuta;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Label lblMieuta;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDai;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtKHID;
        private System.Windows.Forms.Label lblKihieu;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPage;
        private ADGV.AdvancedDataGridView dvgColor;
        private System.Windows.Forms.Label lblMess;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSon;
        private System.Windows.Forms.Label lblARTID;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtRong;
        private System.Windows.Forms.Label lblRong;
        private System.Windows.Forms.ComboBox cbArt;
        private System.Windows.Forms.ComboBox cbSon;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kihieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoatiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Son;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mieuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaytao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysua;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.PictureBox pbFirst;
    }
}
