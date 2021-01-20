namespace iClothing
{
    partial class CustomerForm
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
            this.customerManagement11 = new iClothing.CustomerManagement1();
            this.SuspendLayout();
            // 
            // customerManagement11
            // 
            this.customerManagement11.BackColor = System.Drawing.Color.White;
            this.customerManagement11.Location = new System.Drawing.Point(-3, -2);
            this.customerManagement11.Name = "customerManagement11";
            this.customerManagement11.Size = new System.Drawing.Size(870, 750);
            this.customerManagement11.TabIndex = 0;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 750);
            this.Controls.Add(this.customerManagement11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomerManagement1 customerManagement11;
    }
}