
namespace iClothing
{
    partial class Form3
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
            this.rbXuat = new System.Windows.Forms.RadioButton();
            this.rbNhap = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.tbManageInOutOrder.Size = new System.Drawing.Size(826, 720);
            this.tbManageInOutOrder.TabIndex = 66;
            // 
            // tabInputNhap
            // 
            this.tabInputNhap.BackColor = System.Drawing.Color.White;
            this.tabInputNhap.Controls.Add(this.rbXuat);
            this.tabInputNhap.Controls.Add(this.rbNhap);
            this.tabInputNhap.Controls.Add(this.label1);
            this.tabInputNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInputNhap.ForeColor = System.Drawing.Color.Black;
            this.tabInputNhap.Location = new System.Drawing.Point(4, 27);
            this.tabInputNhap.Name = "tabInputNhap";
            this.tabInputNhap.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputNhap.Size = new System.Drawing.Size(818, 689);
            this.tabInputNhap.TabIndex = 0;
            this.tabInputNhap.Text = "Quản Lý Nhập Xuất";
            // 
            // rbXuat
            // 
            this.rbXuat.AutoSize = true;
            this.rbXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXuat.ForeColor = System.Drawing.Color.Orange;
            this.rbXuat.Location = new System.Drawing.Point(290, 10);
            this.rbXuat.Name = "rbXuat";
            this.rbXuat.Size = new System.Drawing.Size(60, 22);
            this.rbXuat.TabIndex = 51;
            this.rbXuat.Text = "Xuất";
            this.rbXuat.UseVisualStyleBackColor = true;
            // 
            // rbNhap
            // 
            this.rbNhap.AutoSize = true;
            this.rbNhap.Checked = true;
            this.rbNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNhap.ForeColor = System.Drawing.Color.Orange;
            this.rbNhap.Location = new System.Drawing.Point(65, 10);
            this.rbNhap.Name = "rbNhap";
            this.rbNhap.Size = new System.Drawing.Size(65, 22);
            this.rbNhap.TabIndex = 50;
            this.rbNhap.TabStop = true;
            this.rbNhap.Text = "Nhập";
            this.rbNhap.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(826, 3);
            this.label1.TabIndex = 54;
            // 
            // btnExport
            // 
            this.btnExport.AutoSize = true;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(628, 585);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(124, 30);
            this.btnExport.TabIndex = 143;
            this.btnExport.Text = "Truy Xuất File";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(818, 689);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chi Tiết Nhập Xuất";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(826, 720);
            this.Controls.Add(this.tbManageInOutOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.Text = "Form3";
            this.tbManageInOutOrder.ResumeLayout(false);
            this.tabInputNhap.ResumeLayout(false);
            this.tabInputNhap.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbManageInOutOrder;
        private System.Windows.Forms.TabPage tabInputNhap;
        private System.Windows.Forms.RadioButton rbXuat;
        private System.Windows.Forms.RadioButton rbNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExport;
    }
}