namespace iClothing
{
    partial class OrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chiTietNhapXuat1 = new iClothing.ChiTietNhapXuat();
            this.dvgManageInOut = new System.Windows.Forms.DataGridView();
            this.tbManageInOutOrder = new System.Windows.Forms.TabControl();
            this.tabInputNhap = new System.Windows.Forms.TabPage();
            this.quanLyNhapXuat1 = new iClothing.QuanLyNhapXuat();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgManageInOut)).BeginInit();
            this.tbManageInOutOrder.SuspendLayout();
            this.tabInputNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chiTietNhapXuat1);
            this.tabPage2.Controls.Add(this.dvgManageInOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1096, 725);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chi Tiết Nhập Xuất";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chiTietNhapXuat1
            // 
            this.chiTietNhapXuat1.BackColor = System.Drawing.Color.White;
            this.chiTietNhapXuat1.Location = new System.Drawing.Point(7, 7);
            this.chiTietNhapXuat1.Margin = new System.Windows.Forms.Padding(4);
            this.chiTietNhapXuat1.Name = "chiTietNhapXuat1";
            this.chiTietNhapXuat1.Size = new System.Drawing.Size(1089, 718);
            this.chiTietNhapXuat1.TabIndex = 34;
            // 
            // dvgManageInOut
            // 
            this.dvgManageInOut.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Orange;
            this.dvgManageInOut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dvgManageInOut.BackgroundColor = System.Drawing.Color.White;
            this.dvgManageInOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgManageInOut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgManageInOut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dvgManageInOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgManageInOut.DefaultCellStyle = dataGridViewCellStyle7;
            this.dvgManageInOut.EnableHeadersVisualStyles = false;
            this.dvgManageInOut.GridColor = System.Drawing.Color.White;
            this.dvgManageInOut.Location = new System.Drawing.Point(19, 164);
            this.dvgManageInOut.Name = "dvgManageInOut";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgManageInOut.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dvgManageInOut.RowTemplate.Height = 35;
            this.dvgManageInOut.Size = new System.Drawing.Size(771, 350);
            this.dvgManageInOut.TabIndex = 33;
            // 
            // tbManageInOutOrder
            // 
            this.tbManageInOutOrder.Controls.Add(this.tabInputNhap);
            this.tbManageInOutOrder.Controls.Add(this.tabPage2);
            this.tbManageInOutOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbManageInOutOrder.Location = new System.Drawing.Point(0, 0);
            this.tbManageInOutOrder.Name = "tbManageInOutOrder";
            this.tbManageInOutOrder.SelectedIndex = 0;
            this.tbManageInOutOrder.Size = new System.Drawing.Size(1104, 756);
            this.tbManageInOutOrder.TabIndex = 66;
            // 
            // tabInputNhap
            // 
            this.tabInputNhap.BackColor = System.Drawing.Color.White;
            this.tabInputNhap.Controls.Add(this.quanLyNhapXuat1);
            this.tabInputNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInputNhap.ForeColor = System.Drawing.Color.Black;
            this.tabInputNhap.Location = new System.Drawing.Point(4, 27);
            this.tabInputNhap.Name = "tabInputNhap";
            this.tabInputNhap.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputNhap.Size = new System.Drawing.Size(1096, 725);
            this.tabInputNhap.TabIndex = 0;
            this.tabInputNhap.Text = "Quản Lý Nhập Xuất";
            // 
            // quanLyNhapXuat1
            // 
            this.quanLyNhapXuat1.BackColor = System.Drawing.Color.White;
            this.quanLyNhapXuat1.Location = new System.Drawing.Point(-4, 0);
            this.quanLyNhapXuat1.Margin = new System.Windows.Forms.Padding(4);
            this.quanLyNhapXuat1.Name = "quanLyNhapXuat1";
            this.quanLyNhapXuat1.Size = new System.Drawing.Size(1091, 725);
            this.quanLyNhapXuat1.TabIndex = 0;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1126, 705);
            this.Controls.Add(this.tbManageInOutOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgManageInOut)).EndInit();
            this.tbManageInOutOrder.ResumeLayout(false);
            this.tabInputNhap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dvgManageInOut;
        private System.Windows.Forms.TabControl tbManageInOutOrder;
        private System.Windows.Forms.TabPage tabInputNhap;
        private QuanLyNhapXuat quanLyNhapXuat1;
        private ChiTietNhapXuat chiTietNhapXuat1;
    }
}