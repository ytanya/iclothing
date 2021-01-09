namespace iClothing
{
    partial class StockManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockManagement));
            this.lblSoluong = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgColor = new ADGV.AdvancedDataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mieuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaytao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblTotalPage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSoluong
            // 
            this.lblSoluong.AutoSize = true;
            this.lblSoluong.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoluong.ForeColor = System.Drawing.Color.Orange;
            this.lblSoluong.Location = new System.Drawing.Point(52, 55);
            this.lblSoluong.Name = "lblSoluong";
            this.lblSoluong.Size = new System.Drawing.Size(60, 16);
            this.lblSoluong.TabIndex = 44;
            this.lblSoluong.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(196, 51);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(200, 24);
            this.txtBarcode.TabIndex = 43;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(27, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(826, 3);
            this.label1.TabIndex = 55;
            // 
            // dvgColor
            // 
            this.dvgColor.AllowUserToAddRows = false;
            this.dvgColor.AutoGenerateContextFilters = true;
            this.dvgColor.BackgroundColor = System.Drawing.Color.White;
            this.dvgColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgColor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgColor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.SonID,
            this.Ten,
            this.Mieuta,
            this.Ngaytao,
            this.Ngaysua});
            this.dvgColor.DateWithTime = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgColor.DefaultCellStyle = dataGridViewCellStyle5;
            this.dvgColor.EnableHeadersVisualStyles = false;
            this.dvgColor.GridColor = System.Drawing.Color.White;
            this.dvgColor.Location = new System.Drawing.Point(55, 124);
            this.dvgColor.Name = "dvgColor";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgColor.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dvgColor.Size = new System.Drawing.Size(771, 361);
            this.dvgColor.TabIndex = 56;
            this.dvgColor.TimeFilter = false;
            // 
            // checkbox
            // 
            this.checkbox.HeaderText = "";
            this.checkbox.MinimumWidth = 22;
            this.checkbox.Name = "checkbox";
            this.checkbox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SonID
            // 
            this.SonID.DataPropertyName = "SonID";
            this.SonID.HeaderText = "Ma Son";
            this.SonID.MinimumWidth = 22;
            this.SonID.Name = "SonID";
            this.SonID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // btnExport
            // 
            this.btnExport.AutoSize = true;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(711, 539);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 30);
            this.btnExport.TabIndex = 57;
            this.btnExport.Text = "Truy Xuất File";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(456, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 24);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSearch.TabIndex = 81;
            this.btnSearch.TabStop = false;
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(309, 509);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(38, 21);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 100;
            this.pbLast.TabStop = false;
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(240, 509);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 99;
            this.pbNext.TabStop = false;
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(156, 509);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 21);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 98;
            this.pbPrev.TabStop = false;
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(74, 509);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 97;
            this.pbFirst.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(156, 543);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 96;
            this.textBox2.Visible = false;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(711, 509);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(81, 13);
            this.lblTotalPage.TabIndex = 95;
            this.lblTotalPage.Text = "Total rows: 0";
            // 
            // StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dvgColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSoluong);
            this.Controls.Add(this.txtBarcode);
            this.Name = "StockManagement";
            this.Size = new System.Drawing.Size(870, 750);
            ((System.ComponentModel.ISupportInitialize)(this.dvgColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoluong;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private ADGV.AdvancedDataGridView dvgColor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mieuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaytao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysua;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.PictureBox pbFirst;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblTotalPage;
    }
}
