namespace iClothing
{
    partial class QuanLyNhapXuat
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
            this.rbXuat = new System.Windows.Forms.RadioButton();
            this.rbNhap = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.quanLyNhap1 = new iClothing.QuanLyNhap();
            this.quanLyXuat1 = new iClothing.QuanLyXuat();
            this.SuspendLayout();
            // 
            // rbXuat
            // 
            this.rbXuat.AutoSize = true;
            this.rbXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXuat.ForeColor = System.Drawing.Color.Orange;
            this.rbXuat.Location = new System.Drawing.Point(289, 20);
            this.rbXuat.Name = "rbXuat";
            this.rbXuat.Size = new System.Drawing.Size(60, 22);
            this.rbXuat.TabIndex = 56;
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
            this.rbNhap.Location = new System.Drawing.Point(64, 20);
            this.rbNhap.Name = "rbNhap";
            this.rbNhap.Size = new System.Drawing.Size(65, 22);
            this.rbNhap.TabIndex = 55;
            this.rbNhap.TabStop = true;
            this.rbNhap.Text = "Nhập";
            this.rbNhap.UseVisualStyleBackColor = true;
            this.rbNhap.CheckedChanged += new System.EventHandler(this.rbNhap_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(5, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(680, 3);
            this.label1.TabIndex = 57;
            // 
            // quanLyNhap1
            // 
            this.quanLyNhap1.AutoScroll = true;
            this.quanLyNhap1.Location = new System.Drawing.Point(0, 52);
            this.quanLyNhap1.Name = "quanLyNhap1";
            this.quanLyNhap1.Size = new System.Drawing.Size(927, 645);
            this.quanLyNhap1.TabIndex = 58;
            // 
            // quanLyXuat1
            // 
            this.quanLyXuat1.Location = new System.Drawing.Point(0, 52);
            this.quanLyXuat1.Name = "quanLyXuat1";
            this.quanLyXuat1.Size = new System.Drawing.Size(879, 520);
            this.quanLyXuat1.TabIndex = 59;
            // 
            // QuanLyNhapXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.quanLyNhap1);
            this.Controls.Add(this.rbXuat);
            this.Controls.Add(this.rbNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quanLyXuat1);
            this.Name = "QuanLyNhapXuat";
            this.Size = new System.Drawing.Size(927, 700);
            this.Load += new System.EventHandler(this.QuanLyNhapXuat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbXuat;
        private System.Windows.Forms.RadioButton rbNhap;
        private System.Windows.Forms.Label label1;
        private QuanLyNhap quanLyNhap1;
        private QuanLyXuat quanLyXuat1;
    }
}
