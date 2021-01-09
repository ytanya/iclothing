namespace iClothing
{
    partial class TransactionManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionManagement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.dvgTransaction = new ADGV.AdvancedDataGridView();
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(200, 600);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 83;
            this.textBox2.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(758, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 24);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSearch.TabIndex = 80;
            this.btnSearch.TabStop = false;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(755, 566);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(81, 13);
            this.lblTotalPage.TabIndex = 78;
            this.lblTotalPage.Text = "Total rows: 0";
            // 
            // dvgTransaction
            // 
            this.dvgTransaction.AllowUserToAddRows = false;
            this.dvgTransaction.AutoGenerateContextFilters = true;
            this.dvgTransaction.BackgroundColor = System.Drawing.Color.White;
            this.dvgTransaction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgTransaction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dvgTransaction.DateWithTime = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgTransaction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgTransaction.EnableHeadersVisualStyles = false;
            this.dvgTransaction.GridColor = System.Drawing.Color.White;
            this.dvgTransaction.Location = new System.Drawing.Point(28, 75);
            this.dvgTransaction.Name = "dvgTransaction";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgTransaction.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgTransaction.Size = new System.Drawing.Size(866, 485);
            this.dvgTransaction.TabIndex = 77;
            this.dvgTransaction.TimeFilter = false;
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(98, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker1.TabIndex = 86;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(377, 25);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker2.TabIndex = 88;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.Orange;
            this.lblFrom.Location = new System.Drawing.Point(25, 25);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(26, 16);
            this.lblFrom.TabIndex = 89;
            this.lblFrom.Text = "Từ";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.Orange;
            this.lblTo.Location = new System.Drawing.Point(284, 29);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(39, 16);
            this.lblTo.TabIndex = 90;
            this.lblTo.Text = " Đến";
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(353, 566);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(38, 21);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 94;
            this.pbLast.TabStop = false;
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(284, 566);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 93;
            this.pbNext.TabStop = false;
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(200, 566);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 21);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 92;
            this.pbPrev.TabStop = false;
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(118, 566);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 91;
            this.pbFirst.TabStop = false;
            // 
            // TransactionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.dvgTransaction);
            this.Name = "TransactionManagement";
            this.Size = new System.Drawing.Size(953, 623);
            this.Load += new System.EventHandler(this.TransactionManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.Label lblTotalPage;
        private ADGV.AdvancedDataGridView dvgTransaction;
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.PictureBox pbFirst;
    }
}
