namespace iClothing
{
    partial class ArtManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtManagement));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtMieuta = new System.Windows.Forms.TextBox();
            this.lblMieuta = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtArtID = new System.Windows.Forms.TextBox();
            this.lblSon = new System.Windows.Forms.Label();
            this.lblARTId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.dvgArt = new ADGV.AdvancedDataGridView();
            this.ARTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mieuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaytao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMess = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbAnh = new System.Windows.Forms.PictureBox();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(236, 707);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 49;
            this.textBox2.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(353, 47);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(129, 32);
            this.btnImport.TabIndex = 45;
            this.btnImport.Text = "Tải lên";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(35, 48);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(308, 26);
            this.txtFile.TabIndex = 44;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(642, 249);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 32);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtMieuta
            // 
            this.txtMieuta.BackColor = System.Drawing.Color.White;
            this.txtMieuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMieuta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMieuta.Location = new System.Drawing.Point(159, 167);
            this.txtMieuta.Multiline = true;
            this.txtMieuta.Name = "txtMieuta";
            this.txtMieuta.Size = new System.Drawing.Size(609, 76);
            this.txtMieuta.TabIndex = 42;
            // 
            // lblMieuta
            // 
            this.lblMieuta.AutoSize = true;
            this.lblMieuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMieuta.ForeColor = System.Drawing.Color.Orange;
            this.lblMieuta.Location = new System.Drawing.Point(30, 167);
            this.lblMieuta.Name = "lblMieuta";
            this.lblMieuta.Size = new System.Drawing.Size(64, 16);
            this.lblMieuta.TabIndex = 41;
            this.lblMieuta.Text = "Miêu Tả";
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(159, 126);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(323, 26);
            this.txtTen.TabIndex = 40;
            // 
            // txtArtID
            // 
            this.txtArtID.BackColor = System.Drawing.Color.White;
            this.txtArtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArtID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtID.Location = new System.Drawing.Point(159, 86);
            this.txtArtID.Name = "txtArtID";
            this.txtArtID.Size = new System.Drawing.Size(323, 26);
            this.txtArtID.TabIndex = 39;
            // 
            // lblSon
            // 
            this.lblSon.AutoSize = true;
            this.lblSon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSon.ForeColor = System.Drawing.Color.Orange;
            this.lblSon.Location = new System.Drawing.Point(30, 126);
            this.lblSon.Name = "lblSon";
            this.lblSon.Size = new System.Drawing.Size(35, 16);
            this.lblSon.TabIndex = 38;
            this.lblSon.Text = "Tên";
            // 
            // lblARTId
            // 
            this.lblARTId.AutoSize = true;
            this.lblARTId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblARTId.ForeColor = System.Drawing.Color.Orange;
            this.lblARTId.Location = new System.Drawing.Point(30, 86);
            this.lblARTId.Name = "lblARTId";
            this.lblARTId.Size = new System.Drawing.Size(64, 16);
            this.lblARTId.TabIndex = 37;
            this.lblARTId.Text = "Mã ART";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(29, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(826, 2);
            this.label2.TabIndex = 36;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(631, 678);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(81, 13);
            this.lblTotalPage.TabIndex = 33;
            this.lblTotalPage.Text = "Total rows: 0";
            // 
            // dvgArt
            // 
            this.dvgArt.AllowUserToAddRows = false;
            this.dvgArt.AutoGenerateContextFilters = true;
            this.dvgArt.BackgroundColor = System.Drawing.Color.White;
            this.dvgArt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgArt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgArt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dvgArt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgArt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ARTID,
            this.Ten,
            this.Mieuta,
            this.Ngaytao,
            this.Ngaysua});
            this.dvgArt.DateWithTime = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgArt.DefaultCellStyle = dataGridViewCellStyle7;
            this.dvgArt.EnableHeadersVisualStyles = false;
            this.dvgArt.GridColor = System.Drawing.Color.White;
            this.dvgArt.Location = new System.Drawing.Point(29, 355);
            this.dvgArt.Name = "dvgArt";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgArt.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dvgArt.Size = new System.Drawing.Size(813, 294);
            this.dvgArt.TabIndex = 32;
            this.dvgArt.TimeFilter = false;
            this.dvgArt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgArt_CellClick);
            this.dvgArt.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgArt_CellContentClick);
            // 
            // ARTID
            // 
            this.ARTID.DataPropertyName = "ARTID";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ARTID.DefaultCellStyle = dataGridViewCellStyle6;
            this.ARTID.HeaderText = "Ma ART";
            this.ARTID.MinimumWidth = 22;
            this.ARTID.Name = "ARTID";
            this.ARTID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ten
            // 
            this.Ten.DataPropertyName = "Ten";
            this.Ten.HeaderText = "Ten";
            this.Ten.MinimumWidth = 22;
            this.Ten.Name = "Ten";
            this.Ten.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Mieuta
            // 
            this.Mieuta.DataPropertyName = "Mieuta";
            this.Mieuta.HeaderText = "Mieu Ta";
            this.Mieuta.MinimumWidth = 22;
            this.Mieuta.Name = "Mieuta";
            this.Mieuta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.lblMess.Location = new System.Drawing.Point(71, 50);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(0, 13);
            this.lblMess.TabIndex = 31;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(493, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 32);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbAnh
            // 
            this.pbAnh.Location = new System.Drawing.Point(566, 12);
            this.pbAnh.Name = "pbAnh";
            this.pbAnh.Size = new System.Drawing.Size(202, 140);
            this.pbAnh.TabIndex = 52;
            this.pbAnh.TabStop = false;
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(353, 678);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(38, 21);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 80;
            this.pbLast.TabStop = false;
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(284, 678);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 79;
            this.pbNext.TabStop = false;
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(200, 678);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 21);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 78;
            this.pbPrev.TabStop = false;
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(118, 678);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 77;
            this.pbFirst.TabStop = false;
            // 
            // ArtManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.pbAnh);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtMieuta);
            this.Controls.Add(this.lblMieuta);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtArtID);
            this.Controls.Add(this.lblSon);
            this.Controls.Add(this.lblARTId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.dvgArt);
            this.Controls.Add(this.lblMess);
            this.Controls.Add(this.btnSave);
            this.Name = "ArtManagement";
            this.Size = new System.Drawing.Size(870, 750);
            this.Load += new System.EventHandler(this.ArtManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtMieuta;
        private System.Windows.Forms.Label lblMieuta;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtArtID;
        private System.Windows.Forms.Label lblSon;
        private System.Windows.Forms.Label lblARTId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPage;
        private ADGV.AdvancedDataGridView dvgArt;
        private System.Windows.Forms.Label lblMess;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mieuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaytao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysua;
        private System.Windows.Forms.PictureBox pbAnh;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.PictureBox pbFirst;
    }
}
