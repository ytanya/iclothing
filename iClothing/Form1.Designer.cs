﻿namespace iClothing
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSignout = new System.Windows.Forms.Button();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.pnStuff = new System.Windows.Forms.Panel();
            this.btnStuff = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.pnSystem = new System.Windows.Forms.Panel();
            this.btnSystem = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btnPaint = new System.Windows.Forms.Button();
            this.btnArt = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SidePanelLeft = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnRight = new System.Windows.Forms.Panel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btnMini = new System.Windows.Forms.Button();
            this.pnMenu.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.pnStuff.SuspendLayout();
            this.pnSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSignout
            // 
            this.btnSignout.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSignout, "btnSignout");
            this.btnSignout.ForeColor = System.Drawing.Color.White;
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.UseVisualStyleBackColor = true;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnMenu.Controls.Add(this.lblCurrentUser);
            this.pnMenu.Controls.Add(this.btnClose);
            this.pnMenu.Controls.Add(this.btnSignout);
            resources.ApplyResources(this.pnMenu, "pnMenu");
            this.pnMenu.Name = "pnMenu";
            // 
            // lblCurrentUser
            // 
            resources.ApplyResources(this.lblCurrentUser, "lblCurrentUser");
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Name = "lblCurrentUser";
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnLeft.Controls.Add(this.btnMini);
            this.pnLeft.Controls.Add(this.pnStuff);
            this.pnLeft.Controls.Add(this.pnSystem);
            this.pnLeft.Controls.Add(this.lblVersion);
            this.pnLeft.Controls.Add(this.SidePanelLeft);
            resources.ApplyResources(this.pnLeft, "pnLeft");
            this.pnLeft.Name = "pnLeft";
            // 
            // pnStuff
            // 
            this.pnStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnStuff.Controls.Add(this.btnStuff);
            this.pnStuff.Controls.Add(this.btnOrder);
            this.pnStuff.Controls.Add(this.btnStock);
            resources.ApplyResources(this.pnStuff, "pnStuff");
            this.pnStuff.Name = "pnStuff";
            // 
            // btnStuff
            // 
            this.btnStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.btnStuff.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnStuff, "btnStuff");
            this.btnStuff.ForeColor = System.Drawing.Color.White;
            this.btnStuff.Name = "btnStuff";
            this.btnStuff.UseVisualStyleBackColor = false;
            this.btnStuff.Click += new System.EventHandler(this.btnStuff_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnOrder.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnOrder, "btnOrder");
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnStock.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnStock, "btnStock");
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Name = "btnStock";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // pnSystem
            // 
            this.pnSystem.Controls.Add(this.btnSystem);
            this.pnSystem.Controls.Add(this.btnCustomer);
            this.pnSystem.Controls.Add(this.btnProduct);
            this.pnSystem.Controls.Add(this.btnStaff);
            this.pnSystem.Controls.Add(this.btnTransaction);
            this.pnSystem.Controls.Add(this.btnSupplier);
            this.pnSystem.Controls.Add(this.btnType);
            this.pnSystem.Controls.Add(this.btnPaint);
            this.pnSystem.Controls.Add(this.btnArt);
            resources.ApplyResources(this.pnSystem, "pnSystem");
            this.pnSystem.Name = "pnSystem";
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.btnSystem.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSystem, "btnSystem");
            this.btnSystem.ForeColor = System.Drawing.Color.White;
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnProduct.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnProduct, "btnProduct");
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnStaff.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnStaff, "btnStaff");
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTransaction, "btnTransaction");
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSupplier, "btnSupplier");
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnType
            // 
            this.btnType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnType.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnType, "btnType");
            this.btnType.ForeColor = System.Drawing.Color.White;
            this.btnType.Name = "btnType";
            this.btnType.UseVisualStyleBackColor = false;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnPaint
            // 
            this.btnPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnPaint.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnPaint, "btnPaint");
            this.btnPaint.ForeColor = System.Drawing.Color.White;
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.UseVisualStyleBackColor = false;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnArt
            // 
            this.btnArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnArt.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnArt, "btnArt");
            this.btnArt.ForeColor = System.Drawing.Color.White;
            this.btnArt.Name = "btnArt";
            this.btnArt.UseVisualStyleBackColor = false;
            this.btnArt.Click += new System.EventHandler(this.btnArt_Click);
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Name = "lblVersion";
            // 
            // SidePanelLeft
            // 
            this.SidePanelLeft.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.SidePanelLeft, "SidePanelLeft");
            this.SidePanelLeft.Name = "SidePanelLeft";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pnRight
            // 
            resources.ApplyResources(this.pnRight, "pnRight");
            this.pnRight.Name = "pnRight";
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.btnMini.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnMini, "btnMini");
            this.btnMini.ForeColor = System.Drawing.Color.White;
            this.btnMini.Name = "btnMini";
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnRight);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.pnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.pnStuff.ResumeLayout(false);
            this.pnSystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel pnStuff;
        private System.Windows.Forms.Button btnStuff;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Panel pnSystem;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.Button btnArt;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel SidePanelLeft;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.Timer timer3;
    }
}