namespace iClothing
{
    partial class ArtManagement1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtManagement1));
            this.txtMota = new System.Windows.Forms.TextBox();
            this.lblMota = new System.Windows.Forms.Label();
            this.dgvArt = new System.Windows.Forms.DataGridView();
            this.txtMaArt = new System.Windows.Forms.TextBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.cbPageSize = new System.Windows.Forms.ComboBox();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.txtARTID = new System.Windows.Forms.TextBox();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.lblMaArt = new System.Windows.Forms.Label();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.txtPaging = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMota
            // 
            this.txtMota.BackColor = System.Drawing.Color.White;
            this.txtMota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(582, 62);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(207, 65);
            this.txtMota.TabIndex = 193;
            // 
            // lblMota
            // 
            this.lblMota.AutoSize = true;
            this.lblMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMota.ForeColor = System.Drawing.Color.Orange;
            this.lblMota.Location = new System.Drawing.Point(444, 66);
            this.lblMota.Name = "lblMota";
            this.lblMota.Size = new System.Drawing.Size(46, 16);
            this.lblMota.TabIndex = 192;
            this.lblMota.Text = "Mô tả";
            // 
            // dgvArt
            // 
            this.dgvArt.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orange;
            this.dgvArt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArt.BackgroundColor = System.Drawing.Color.White;
            this.dgvArt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArt.EnableHeadersVisualStyles = false;
            this.dgvArt.GridColor = System.Drawing.Color.White;
            this.dgvArt.Location = new System.Drawing.Point(16, 226);
            this.dgvArt.Name = "dgvArt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArt.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvArt.RowTemplate.Height = 35;
            this.dgvArt.Size = new System.Drawing.Size(842, 244);
            this.dgvArt.TabIndex = 191;
            this.dgvArt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArt_CellClick);
            // 
            // txtMaArt
            // 
            this.txtMaArt.BackColor = System.Drawing.Color.White;
            this.txtMaArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaArt.Location = new System.Drawing.Point(161, 62);
            this.txtMaArt.Name = "txtMaArt";
            this.txtMaArt.Size = new System.Drawing.Size(207, 24);
            this.txtMaArt.TabIndex = 190;
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(375, 492);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 184;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
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
            this.cbPageSize.Location = new System.Drawing.Point(557, 488);
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.Size = new System.Drawing.Size(45, 21);
            this.cbPageSize.TabIndex = 186;
            this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(647, 495);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(68, 13);
            this.lblTotalPage.TabIndex = 180;
            this.lblTotalPage.Text = "Tổng số: 0";
            // 
            // txtARTID
            // 
            this.txtARTID.BackColor = System.Drawing.Color.White;
            this.txtARTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtARTID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtARTID.Location = new System.Drawing.Point(848, 21);
            this.txtARTID.Name = "txtARTID";
            this.txtARTID.Size = new System.Drawing.Size(10, 24);
            this.txtARTID.TabIndex = 188;
            this.txtARTID.Visible = false;
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(436, 491);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(66, 20);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 185;
            this.pbLast.TabStop = false;
            this.pbLast.Click += new System.EventHandler(this.pbLast_Click);
            // 
            // lblMaArt
            // 
            this.lblMaArt.AutoSize = true;
            this.lblMaArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaArt.ForeColor = System.Drawing.Color.Orange;
            this.lblMaArt.Location = new System.Drawing.Point(23, 66);
            this.lblMaArt.Name = "lblMaArt";
            this.lblMaArt.Size = new System.Drawing.Size(64, 16);
            this.lblMaArt.TabIndex = 189;
            this.lblMaArt.Text = "Mã ART";
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(116, 492);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 182;
            this.pbFirst.TabStop = false;
            this.pbFirst.Click += new System.EventHandler(this.pbFirst_Click);
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(189, 492);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 20);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 183;
            this.pbPrev.TabStop = false;
            this.pbPrev.Click += new System.EventHandler(this.pbPrev_Click);
            // 
            // txtPaging
            // 
            this.txtPaging.Location = new System.Drawing.Point(257, 492);
            this.txtPaging.Name = "txtPaging";
            this.txtPaging.Size = new System.Drawing.Size(93, 20);
            this.txtPaging.TabIndex = 181;
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(557, 150);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 30);
            this.btnNew.TabIndex = 178;
            this.btnNew.Text = "Tạo Mới";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Orange;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(21, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(770, 3);
            this.label6.TabIndex = 177;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(749, 150);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 30);
            this.btnDelete.TabIndex = 179;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(659, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 30);
            this.btnSave.TabIndex = 187;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(288, 21);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(80, 32);
            this.btnImport.TabIndex = 195;
            this.btnImport.Text = "Tải lên";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(16, 25);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(266, 26);
            this.txtFile.TabIndex = 194;
            // 
            // ArtManagement1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.txtMota);
            this.Controls.Add(this.lblMota);
            this.Controls.Add(this.dgvArt);
            this.Controls.Add(this.txtMaArt);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.cbPageSize);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.txtARTID);
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.lblMaArt);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.txtPaging);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Name = "ArtManagement1";
            this.Size = new System.Drawing.Size(870, 750);
            this.Load += new System.EventHandler(this.ArtManagement1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.Label lblMota;
        public System.Windows.Forms.DataGridView dgvArt;
        private System.Windows.Forms.TextBox txtMaArt;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.ComboBox cbPageSize;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.TextBox txtARTID;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.Label lblMaArt;
        private System.Windows.Forms.PictureBox pbFirst;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.TextBox txtPaging;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtFile;
    }
}
