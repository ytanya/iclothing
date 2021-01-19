namespace iClothing
{
    partial class TransactionManagement1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionManagement1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            this.txtPaging = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.dvgTransaction = new System.Windows.Forms.DataGridView();
            this.cbPageSize = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTransaction)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(13, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(826, 3);
            this.label1.TabIndex = 108;
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(424, 621);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(38, 21);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 107;
            this.pbLast.TabStop = false;
            this.pbLast.Click += new System.EventHandler(this.pbLast_Click);
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(355, 621);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 106;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(176, 621);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 21);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 105;
            this.pbPrev.TabStop = false;
            this.pbPrev.Click += new System.EventHandler(this.pbPrev_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.Orange;
            this.lblTo.Location = new System.Drawing.Point(260, 84);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 16);
            this.lblTo.TabIndex = 103;
            this.lblTo.Text = " Đến";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.Orange;
            this.lblFrom.Location = new System.Drawing.Point(1, 80);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(25, 16);
            this.lblFrom.TabIndex = 102;
            this.lblFrom.Text = "Từ";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(353, 80);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(134, 20);
            this.dtpTo.TabIndex = 101;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(74, 80);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(107, 20);
            this.dtpFrom.TabIndex = 100;
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(94, 621);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 104;
            this.pbFirst.TabStop = false;
            this.pbFirst.Click += new System.EventHandler(this.pbFirst_Click);
            // 
            // txtPaging
            // 
            this.txtPaging.Location = new System.Drawing.Point(244, 622);
            this.txtPaging.Name = "txtPaging";
            this.txtPaging.Size = new System.Drawing.Size(93, 20);
            this.txtPaging.TabIndex = 99;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(580, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 24);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSearch.TabIndex = 98;
            this.btnSearch.TabStop = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(722, 628);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(68, 14);
            this.lblTotalPage.TabIndex = 97;
            this.lblTotalPage.Text = "Tổng số:: 0";
            // 
            // dvgTransaction
            // 
            this.dvgTransaction.AllowUserToAddRows = false;
            this.dvgTransaction.BackgroundColor = System.Drawing.Color.White;
            this.dvgTransaction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgTransaction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dvgTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgTransaction.DefaultCellStyle = dataGridViewCellStyle8;
            this.dvgTransaction.EnableHeadersVisualStyles = false;
            this.dvgTransaction.GridColor = System.Drawing.Color.White;
            this.dvgTransaction.Location = new System.Drawing.Point(4, 130);
            this.dvgTransaction.Name = "dvgTransaction";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgTransaction.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dvgTransaction.Size = new System.Drawing.Size(866, 485);
            this.dvgTransaction.TabIndex = 96;
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
            this.cbPageSize.Location = new System.Drawing.Point(547, 620);
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.Size = new System.Drawing.Size(45, 21);
            this.cbPageSize.TabIndex = 136;
            this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
            // 
            // TransactionManagement1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbPageSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.txtPaging);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.dvgTransaction);
            this.Name = "TransactionManagement1";
            this.Size = new System.Drawing.Size(870, 750);
            this.Load += new System.EventHandler(this.TransactionManagement1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTransaction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.PictureBox pbFirst;
        private System.Windows.Forms.TextBox txtPaging;
        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.DataGridView dvgTransaction;
        private System.Windows.Forms.ComboBox cbPageSize;
    }
}
