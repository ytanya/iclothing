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
            this.tbManageInOutOrder = new System.Windows.Forms.TabControl();
            this.tabInputNhap = new System.Windows.Forms.TabPage();
            this.quanLyXuat1 = new iClothing.QuanLyXuat();
            this.quanLyNhap1 = new iClothing.QuanLyNhap();
            this.rbXuat = new System.Windows.Forms.RadioButton();
            this.rbNhap = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tpFilter = new System.Windows.Forms.TabPage();
            this.chiTietNhapXuat1 = new iClothing.ChiTietNhapXuat();
            this.tbManageInOutOrder.SuspendLayout();
            this.tabInputNhap.SuspendLayout();
            this.tpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbManageInOutOrder
            // 
            this.tbManageInOutOrder.Controls.Add(this.tabInputNhap);
            this.tbManageInOutOrder.Controls.Add(this.tpFilter);
            this.tbManageInOutOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbManageInOutOrder.Location = new System.Drawing.Point(0, 0);
            this.tbManageInOutOrder.Name = "tbManageInOutOrder";
            this.tbManageInOutOrder.SelectedIndex = 0;
            this.tbManageInOutOrder.Size = new System.Drawing.Size(1236, 728);
            this.tbManageInOutOrder.TabIndex = 66;
            // 
            // tabInputNhap
            // 
            this.tabInputNhap.BackColor = System.Drawing.Color.White;
            this.tabInputNhap.Controls.Add(this.quanLyXuat1);
            this.tabInputNhap.Controls.Add(this.quanLyNhap1);
            this.tabInputNhap.Controls.Add(this.rbXuat);
            this.tabInputNhap.Controls.Add(this.rbNhap);
            this.tabInputNhap.Controls.Add(this.label1);
            this.tabInputNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInputNhap.ForeColor = System.Drawing.Color.Black;
            this.tabInputNhap.Location = new System.Drawing.Point(4, 27);
            this.tabInputNhap.Name = "tabInputNhap";
            this.tabInputNhap.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputNhap.Size = new System.Drawing.Size(1194, 697);
            this.tabInputNhap.TabIndex = 0;
            this.tabInputNhap.Text = "Quản Lý Nhập Xuất";
            // 
            // quanLyXuat1
            // 
            this.quanLyXuat1.Location = new System.Drawing.Point(0, 39);
            this.quanLyXuat1.Margin = new System.Windows.Forms.Padding(4);
            this.quanLyXuat1.Name = "quanLyXuat1";
            this.quanLyXuat1.Size = new System.Drawing.Size(1200, 654);
            this.quanLyXuat1.TabIndex = 62;
            // 
            // quanLyNhap1
            // 
            this.quanLyNhap1.AutoScroll = true;
            this.quanLyNhap1.BackColor = System.Drawing.Color.White;
            this.quanLyNhap1.Location = new System.Drawing.Point(0, 39);
            this.quanLyNhap1.Margin = new System.Windows.Forms.Padding(4);
            this.quanLyNhap1.Name = "quanLyNhap1";
            this.quanLyNhap1.Size = new System.Drawing.Size(1200, 654);
            this.quanLyNhap1.TabIndex = 61;
            // 
            // rbXuat
            // 
            this.rbXuat.AutoSize = true;
            this.rbXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXuat.ForeColor = System.Drawing.Color.Orange;
            this.rbXuat.Location = new System.Drawing.Point(300, 6);
            this.rbXuat.Name = "rbXuat";
            this.rbXuat.Size = new System.Drawing.Size(60, 22);
            this.rbXuat.TabIndex = 59;
            this.rbXuat.Text = "Xuất";
            this.rbXuat.UseVisualStyleBackColor = true;
            this.rbXuat.CheckedChanged += new System.EventHandler(this.rbXuat_CheckedChanged);
            // 
            // rbNhap
            // 
            this.rbNhap.AutoSize = true;
            this.rbNhap.Checked = true;
            this.rbNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNhap.ForeColor = System.Drawing.Color.Orange;
            this.rbNhap.Location = new System.Drawing.Point(75, 6);
            this.rbNhap.Name = "rbNhap";
            this.rbNhap.Size = new System.Drawing.Size(65, 22);
            this.rbNhap.TabIndex = 58;
            this.rbNhap.TabStop = true;
            this.rbNhap.Text = "Nhập";
            this.rbNhap.UseVisualStyleBackColor = true;
            this.rbNhap.CheckedChanged += new System.EventHandler(this.rbNhap_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1190, 3);
            this.label1.TabIndex = 60;
            // 
            // tpFilter
            // 
            this.tpFilter.Controls.Add(this.chiTietNhapXuat1);
            this.tpFilter.Location = new System.Drawing.Point(4, 27);
            this.tpFilter.Name = "tpFilter";
            this.tpFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tpFilter.Size = new System.Drawing.Size(1228, 697);
            this.tpFilter.TabIndex = 1;
            this.tpFilter.Text = "Chi Tiết Nhập Xuất";
            this.tpFilter.UseVisualStyleBackColor = true;
            // 
            // chiTietNhapXuat1
            // 
            this.chiTietNhapXuat1.BackColor = System.Drawing.Color.White;
            this.chiTietNhapXuat1.Location = new System.Drawing.Point(0, 0);
            this.chiTietNhapXuat1.Margin = new System.Windows.Forms.Padding(4);
            this.chiTietNhapXuat1.Name = "chiTietNhapXuat1";
            this.chiTietNhapXuat1.Size = new System.Drawing.Size(1190, 700);
            this.chiTietNhapXuat1.TabIndex = 34;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 730);
            this.Controls.Add(this.tbManageInOutOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.tbManageInOutOrder.ResumeLayout(false);
            this.tabInputNhap.ResumeLayout(false);
            this.tabInputNhap.PerformLayout();
            this.tpFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tbManageInOutOrder;
        private System.Windows.Forms.TabPage tabInputNhap;
        private System.Windows.Forms.TabPage tpFilter;
        private ChiTietNhapXuat chiTietNhapXuat1;
        private System.Windows.Forms.RadioButton rbXuat;
        private System.Windows.Forms.RadioButton rbNhap;
        private System.Windows.Forms.Label label1;
        private QuanLyNhap quanLyNhap1;
        private QuanLyXuat quanLyXuat1;
    }
}