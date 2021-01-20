namespace iClothing
{
    partial class StaffForm
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
            this.staffManagement1 = new iClothing.StaffManagement();
            this.SuspendLayout();
            // 
            // staffManagement1
            // 
            this.staffManagement1.BackColor = System.Drawing.Color.White;
            this.staffManagement1.Location = new System.Drawing.Point(-3, -1);
            this.staffManagement1.Name = "staffManagement1";
            this.staffManagement1.Size = new System.Drawing.Size(870, 750);
            this.staffManagement1.TabIndex = 0;
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 750);
            this.Controls.Add(this.staffManagement1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffForm";
            this.Text = "StaffForm";
            this.ResumeLayout(false);

        }

        #endregion

        private StaffManagement staffManagement1;
    }
}