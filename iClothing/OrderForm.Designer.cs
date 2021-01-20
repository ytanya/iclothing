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
            this.quanLyNhapXuat1 = new iClothing.QuanLyNhapXuat();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chiTietNhapXuat1 = new iClothing.ChiTietNhapXuat();
            this.tbManageInOutOrder.SuspendLayout();
            this.tabInputNhap.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbManageInOutOrder
            // 
            this.tbManageInOutOrder.Controls.Add(this.tabInputNhap);
            this.tbManageInOutOrder.Controls.Add(this.tabPage2);
            this.tbManageInOutOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbManageInOutOrder.Location = new System.Drawing.Point(0, 0);
            this.tbManageInOutOrder.Name = "tbManageInOutOrder";
            this.tbManageInOutOrder.SelectedIndex = 0;
            this.tbManageInOutOrder.Size = new System.Drawing.Size(1054, 817);
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
            this.tabInputNhap.Size = new System.Drawing.Size(998, 786);
            this.tabInputNhap.TabIndex = 0;
            this.tabInputNhap.Text = "Quản Lý Nhập Xuất";
            // 
            // quanLyNhapXuat1
            // 
            this.quanLyNhapXuat1.BackColor = System.Drawing.Color.White;
            this.quanLyNhapXuat1.Location = new System.Drawing.Point(0, 0);
            this.quanLyNhapXuat1.Margin = new System.Windows.Forms.Padding(4);
            this.quanLyNhapXuat1.Name = "quanLyNhapXuat1";
            this.quanLyNhapXuat1.Size = new System.Drawing.Size(1003, 791);
            this.quanLyNhapXuat1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chiTietNhapXuat1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1046, 786);
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
            this.chiTietNhapXuat1.Size = new System.Drawing.Size(1025, 779);
            this.chiTietNhapXuat1.TabIndex = 34;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1066, 811);
            this.Controls.Add(this.tbManageInOutOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.tbManageInOutOrder.ResumeLayout(false);
            this.tabInputNhap.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tbManageInOutOrder;
        private System.Windows.Forms.TabPage tabInputNhap;
        private QuanLyNhapXuat quanLyNhapXuat1;
        private System.Windows.Forms.TabPage tabPage2;
        private ChiTietNhapXuat chiTietNhapXuat1;
    }
}