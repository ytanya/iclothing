namespace iClothing
{
    partial class CustomerOrder
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
            this.managerOrder1 = new iClothing.ManagerOrder();
            this.SuspendLayout();
            // 
            // managerOrder1
            // 
            this.managerOrder1.BackColor = System.Drawing.Color.White;
            this.managerOrder1.Location = new System.Drawing.Point(-2, -3);
            this.managerOrder1.Name = "managerOrder1";
            this.managerOrder1.Size = new System.Drawing.Size(881, 730);
            this.managerOrder1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 730);
            this.Controls.Add(this.managerOrder1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private ManagerOrder managerOrder1;
    }
}