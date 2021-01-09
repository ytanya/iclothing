namespace iClothing
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.pnMenu = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnArt = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnPaint = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.pnStuff = new System.Windows.Forms.Panel();
            this.btnStuff = new System.Windows.Forms.Button();
            this.pnSystem = new System.Windows.Forms.Panel();
            this.btnSystem = new System.Windows.Forms.Button();
            this.SidePanelLeft = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.login2 = new iClothing.Login();
            this.colorManagement1 = new iClothing.ColorManagement();
            this.customerManagement1 = new iClothing.CustomerManagement();
            this.artManagement1 = new iClothing.ArtManagement();
            this.orderManagement1 = new iClothing.OrderManagement();
            this.productManagment1 = new iClothing.ProductManagment();
            this.staffManagement1 = new iClothing.StaffManagement();
            this.stockManagement1 = new iClothing.StockManagement();
            this.supplierManagement1 = new iClothing.SupplierManagement();
            this.typeManagement1 = new iClothing.TypeManagement();
            this.transactionManagement1 = new iClothing.TransactionManagement();
            this.pnLeft.SuspendLayout();
            this.pnStuff.SuspendLayout();
            this.pnSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(1106, 45);
            this.pnMenu.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(12, 749);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 18);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "v1.0.0";
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("btnStaff.Image")));
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(0, 435);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(223, 54);
            this.btnStaff.TabIndex = 7;
            this.btnStaff.Text = "       Nhân viên";
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnTransaction.Image")));
            this.btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.Location = new System.Drawing.Point(3, 165);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(223, 54);
            this.btnTransaction.TabIndex = 6;
            this.btnTransaction.Text = "       Giao Dịch";
            this.btnTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStock.Image")));
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(3, 111);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(223, 54);
            this.btnStock.TabIndex = 5;
            this.btnStock.Text = "       Tồn Kho";
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(3, 57);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(223, 54);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "       Khách Hàng";
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnArt
            // 
            this.btnArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnArt.FlatAppearance.BorderSize = 0;
            this.btnArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArt.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArt.ForeColor = System.Drawing.Color.White;
            this.btnArt.Image = ((System.Drawing.Image)(resources.GetObject("btnArt.Image")));
            this.btnArt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArt.Location = new System.Drawing.Point(3, 327);
            this.btnArt.Name = "btnArt";
            this.btnArt.Size = new System.Drawing.Size(223, 54);
            this.btnArt.TabIndex = 4;
            this.btnArt.Text = "       Họa Tiết";
            this.btnArt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArt.UseVisualStyleBackColor = false;
            this.btnArt.Click += new System.EventHandler(this.btnArt_Click);
            // 
            // btnType
            // 
            this.btnType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnType.FlatAppearance.BorderSize = 0;
            this.btnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnType.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnType.ForeColor = System.Drawing.Color.White;
            this.btnType.Image = ((System.Drawing.Image)(resources.GetObject("btnType.Image")));
            this.btnType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnType.Location = new System.Drawing.Point(3, 273);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(223, 54);
            this.btnType.TabIndex = 4;
            this.btnType.Text = "       Loại Sản Phẩm";
            this.btnType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnType.UseVisualStyleBackColor = false;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(0, 219);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(223, 54);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Text = "       Nhà Cung Ứng";
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(3, 111);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(223, 54);
            this.btnProduct.TabIndex = 4;
            this.btnProduct.Text = "       Sản Phẩm";
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnPaint
            // 
            this.btnPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnPaint.FlatAppearance.BorderSize = 0;
            this.btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaint.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaint.ForeColor = System.Drawing.Color.White;
            this.btnPaint.Image = ((System.Drawing.Image)(resources.GetObject("btnPaint.Image")));
            this.btnPaint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaint.Location = new System.Drawing.Point(0, 381);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(223, 54);
            this.btnPaint.TabIndex = 4;
            this.btnPaint.Text = "       Màu Sơn";
            this.btnPaint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaint.UseVisualStyleBackColor = false;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(3, 57);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(223, 54);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "       Đơn Hàng";
            this.btnOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnLeft.Controls.Add(this.pnStuff);
            this.pnLeft.Controls.Add(this.pnSystem);
            this.pnLeft.Controls.Add(this.lblVersion);
            this.pnLeft.Controls.Add(this.SidePanelLeft);
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(238, 788);
            this.pnLeft.TabIndex = 2;
            // 
            // pnStuff
            // 
            this.pnStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnStuff.Controls.Add(this.btnStuff);
            this.pnStuff.Controls.Add(this.btnOrder);
            this.pnStuff.Controls.Add(this.btnStock);
            this.pnStuff.Location = new System.Drawing.Point(6, 556);
            this.pnStuff.Name = "pnStuff";
            this.pnStuff.Size = new System.Drawing.Size(225, 165);
            this.pnStuff.TabIndex = 3;
            // 
            // btnStuff
            // 
            this.btnStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.btnStuff.FlatAppearance.BorderSize = 0;
            this.btnStuff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStuff.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStuff.ForeColor = System.Drawing.Color.White;
            this.btnStuff.Image = ((System.Drawing.Image)(resources.GetObject("btnStuff.Image")));
            this.btnStuff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStuff.Location = new System.Drawing.Point(0, 3);
            this.btnStuff.Name = "btnStuff";
            this.btnStuff.Size = new System.Drawing.Size(232, 54);
            this.btnStuff.TabIndex = 9;
            this.btnStuff.Text = "Quản Lý Nghiệp Vụ";
            this.btnStuff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStuff.UseVisualStyleBackColor = false;
            this.btnStuff.Click += new System.EventHandler(this.btnStuff_Click);
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
            this.pnSystem.Location = new System.Drawing.Point(11, 61);
            this.pnSystem.Name = "pnSystem";
            this.pnSystem.Size = new System.Drawing.Size(225, 494);
            this.pnSystem.TabIndex = 10;
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.btnSystem.FlatAppearance.BorderSize = 0;
            this.btnSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystem.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystem.ForeColor = System.Drawing.Color.White;
            this.btnSystem.Image = ((System.Drawing.Image)(resources.GetObject("btnSystem.Image")));
            this.btnSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystem.Location = new System.Drawing.Point(3, 3);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(223, 54);
            this.btnSystem.TabIndex = 8;
            this.btnSystem.Text = "Quản Lý Hệ Thống";
            this.btnSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // SidePanelLeft
            // 
            this.SidePanelLeft.BackColor = System.Drawing.Color.White;
            this.SidePanelLeft.Location = new System.Drawing.Point(1, 64);
            this.SidePanelLeft.Name = "SidePanelLeft";
            this.SidePanelLeft.Size = new System.Drawing.Size(10, 54);
            this.SidePanelLeft.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // login2
            // 
            this.login2.BackColor = System.Drawing.Color.White;
            this.login2.Location = new System.Drawing.Point(6, 0);
            this.login2.Margin = new System.Windows.Forms.Padding(4);
            this.login2.Name = "login2";
            this.login2.Size = new System.Drawing.Size(1123, 767);
            this.login2.TabIndex = 0;
            // 
            // colorManagement1
            // 
            this.colorManagement1.BackColor = System.Drawing.Color.White;
            this.colorManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorManagement1.ForeColor = System.Drawing.Color.Orange;
            this.colorManagement1.Location = new System.Drawing.Point(237, 38);
            this.colorManagement1.Name = "colorManagement1";
            this.colorManagement1.Size = new System.Drawing.Size(870, 750);
            this.colorManagement1.TabIndex = 3;
            // 
            // customerManagement1
            // 
            this.customerManagement1.BackColor = System.Drawing.Color.White;
            this.customerManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerManagement1.ForeColor = System.Drawing.Color.Orange;
            this.customerManagement1.Location = new System.Drawing.Point(237, 38);
            this.customerManagement1.Name = "colorManagement1";
            this.customerManagement1.Size = new System.Drawing.Size(870, 750);
            this.customerManagement1.TabIndex = 3;
            // 
            // artManagement1
            // 
            this.artManagement1.BackColor = System.Drawing.Color.White;
            this.artManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artManagement1.ForeColor = System.Drawing.Color.Orange;
            this.artManagement1.Location = new System.Drawing.Point(237, 38);
            this.artManagement1.Name = "colorManagement1";
            this.artManagement1.Size = new System.Drawing.Size(870, 750);
            this.artManagement1.TabIndex = 3;
            // 
            // orderManagement1
            // 
            this.orderManagement1.BackColor = System.Drawing.Color.White;
            this.orderManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderManagement1.ForeColor = System.Drawing.Color.Orange;
            this.orderManagement1.Location = new System.Drawing.Point(237, 38);
            this.orderManagement1.Name = "colorManagement1";
            this.orderManagement1.Size = new System.Drawing.Size(870, 750);
            this.orderManagement1.TabIndex = 3;
            // 
            // productManagment1
            // 
            this.productManagment1.BackColor = System.Drawing.Color.White;
            this.productManagment1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productManagment1.ForeColor = System.Drawing.Color.Orange;
            this.productManagment1.Location = new System.Drawing.Point(237, 38);
            this.productManagment1.Name = "colorManagement1";
            this.productManagment1.Size = new System.Drawing.Size(870, 750);
            this.productManagment1.TabIndex = 3;
            // 
            // staffManagement1
            // 
            this.staffManagement1.BackColor = System.Drawing.Color.White;
            this.staffManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffManagement1.ForeColor = System.Drawing.Color.Orange;
            this.staffManagement1.Location = new System.Drawing.Point(237, 38);
            this.staffManagement1.Name = "colorManagement1";
            this.staffManagement1.Size = new System.Drawing.Size(870, 750);
            this.staffManagement1.TabIndex = 3;
            // 
            // stockManagement1
            // 
            this.stockManagement1.BackColor = System.Drawing.Color.White;
            this.stockManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockManagement1.ForeColor = System.Drawing.Color.Orange;
            this.stockManagement1.Location = new System.Drawing.Point(237, 38);
            this.stockManagement1.Name = "colorManagement1";
            this.stockManagement1.Size = new System.Drawing.Size(870, 750);
            this.stockManagement1.TabIndex = 3;
            // 
            // supplierManagement1
            // 
            this.supplierManagement1.BackColor = System.Drawing.Color.White;
            this.supplierManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierManagement1.ForeColor = System.Drawing.Color.Orange;
            this.supplierManagement1.Location = new System.Drawing.Point(237, 38);
            this.supplierManagement1.Name = "colorManagement1";
            this.supplierManagement1.Size = new System.Drawing.Size(870, 750);
            this.supplierManagement1.TabIndex = 3;
            // 
            // typeManagement1
            // 
            this.typeManagement1.BackColor = System.Drawing.Color.White;
            this.typeManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeManagement1.ForeColor = System.Drawing.Color.Orange;
            this.typeManagement1.Location = new System.Drawing.Point(237, 38);
            this.typeManagement1.Name = "colorManagement1";
            this.typeManagement1.Size = new System.Drawing.Size(870, 750);
            this.typeManagement1.TabIndex = 3;
            // 
            // transactionManagement1
            // 
            this.transactionManagement1.BackColor = System.Drawing.Color.White;
            this.transactionManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionManagement1.ForeColor = System.Drawing.Color.Orange;
            this.transactionManagement1.Location = new System.Drawing.Point(237, 38);
            this.transactionManagement1.Name = "colorManagement1";
            this.transactionManagement1.Size = new System.Drawing.Size(870, 750);
            this.transactionManagement1.TabIndex = 3;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 801);
            this.Controls.Add(this.colorManagement1);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.login2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.pnStuff.ResumeLayout(false);
            this.pnSystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnArt;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel SidePanelLeft;
        private System.Windows.Forms.Timer timer1;
        private Login login2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pnSystem;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Panel pnStuff;
        private System.Windows.Forms.Button btnStuff;
        private ColorManagement colorManagement1;
        private CustomerManagement customerManagement1;
        private ArtManagement artManagement1;
        private OrderManagement orderManagement1;
        private ProductManagment productManagment1;
        private StaffManagement staffManagement1;
        private StockManagement stockManagement1;
        private SupplierManagement supplierManagement1;
        private TypeManagement typeManagement1;
        private TransactionManagement transactionManagement1;
    }
}