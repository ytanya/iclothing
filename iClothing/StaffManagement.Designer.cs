namespace iClothing
{
    partial class StaffManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffManagement));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNhanVienID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.dvgStaff = new System.Windows.Forms.DataGridView();
            this.NhanvienID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTruyCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matkhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sodt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaytao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMess = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblNhanVienID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblHo = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrev = new System.Windows.Forms.PictureBox();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(220, 727);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 68;
            this.textBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(28, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(821, 2);
            this.label3.TabIndex = 65;
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(346, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(129, 32);
            this.btnImport.TabIndex = 64;
            this.btnImport.Text = "Tải lên";
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(28, 11);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(308, 26);
            this.txtFile.TabIndex = 63;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(635, 269);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 32);
            this.btnDelete.TabIndex = 62;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(152, 132);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(184, 26);
            this.txtUsername.TabIndex = 61;
            // 
            // txtNhanVienID
            // 
            this.txtNhanVienID.BackColor = System.Drawing.Color.White;
            this.txtNhanVienID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNhanVienID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVienID.Location = new System.Drawing.Point(152, 51);
            this.txtNhanVienID.Name = "txtNhanVienID";
            this.txtNhanVienID.Size = new System.Drawing.Size(184, 26);
            this.txtNhanVienID.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(22, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(826, 2);
            this.label2.TabIndex = 58;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalPage.Location = new System.Drawing.Point(624, 698);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(81, 13);
            this.lblTotalPage.TabIndex = 55;
            this.lblTotalPage.Text = "Tổng số: 0";
            // 
            // dvgStaff
            // 
            this.dvgStaff.AllowUserToAddRows = false;
            this.dvgStaff.BackgroundColor = System.Drawing.Color.White;
            this.dvgStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgStaff.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NhanvienID,
            this.Role,
            this.TenTruyCap,
            this.Matkhau,
            this.Ho,
            this.Ten,
            this.Diachi,
            this.Sodt,
            this.Ngaytao,
            this.Ngaysua});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgStaff.DefaultCellStyle = dataGridViewCellStyle3;
            this.dvgStaff.EnableHeadersVisualStyles = false;
            this.dvgStaff.GridColor = System.Drawing.Color.White;
            this.dvgStaff.Location = new System.Drawing.Point(22, 375);
            this.dvgStaff.Name = "dvgStaff";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgStaff.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgStaff.Size = new System.Drawing.Size(813, 294);
            this.dvgStaff.TabIndex = 54;
            // 
            // NhanvienID
            // 
            this.NhanvienID.DataPropertyName = "NhanvienID";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.NhanvienID.DefaultCellStyle = dataGridViewCellStyle2;
            this.NhanvienID.HeaderText = "Ma Nhan Vien";
            this.NhanvienID.MinimumWidth = 22;
            this.NhanvienID.Name = "NhanvienID";
            this.NhanvienID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Role
            // 
            this.Role.DataPropertyName = "Role";
            this.Role.HeaderText = "Role";
            this.Role.MinimumWidth = 22;
            this.Role.Name = "Role";
            this.Role.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TenTruyCap
            // 
            this.TenTruyCap.DataPropertyName = "TenTruyCap";
            this.TenTruyCap.HeaderText = "Ten Truy Cap";
            this.TenTruyCap.MinimumWidth = 22;
            this.TenTruyCap.Name = "TenTruyCap";
            this.TenTruyCap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Matkhau
            // 
            this.Matkhau.HeaderText = "Mat Khau";
            this.Matkhau.MinimumWidth = 22;
            this.Matkhau.Name = "Matkhau";
            this.Matkhau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ho
            // 
            this.Ho.HeaderText = "Ho";
            this.Ho.MinimumWidth = 22;
            this.Ho.Name = "Ho";
            this.Ho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ten
            // 
            this.Ten.HeaderText = "Ten";
            this.Ten.MinimumWidth = 22;
            this.Ten.Name = "Ten";
            this.Ten.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Diachi
            // 
            this.Diachi.HeaderText = "Dia Chi";
            this.Diachi.MinimumWidth = 22;
            this.Diachi.Name = "Diachi";
            this.Diachi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Sodt
            // 
            this.Sodt.HeaderText = "So dt";
            this.Sodt.MinimumWidth = 22;
            this.Sodt.Name = "Sodt";
            this.Sodt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ngaytao
            // 
            this.Ngaytao.DataPropertyName = "Ngaytao";
            this.Ngaytao.HeaderText = "Ngay Tao";
            this.Ngaytao.MinimumWidth = 22;
            this.Ngaytao.Name = "Ngaytao";
            this.Ngaytao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ngaysua
            // 
            this.Ngaysua.DataPropertyName = "Ngaysua";
            this.Ngaysua.HeaderText = "Ngay Sua";
            this.Ngaysua.MinimumWidth = 22;
            this.Ngaysua.Name = "Ngaysua";
            this.Ngaysua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lblMess
            // 
            this.lblMess.AutoSize = true;
            this.lblMess.Location = new System.Drawing.Point(44, 45);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(0, 13);
            this.lblMess.TabIndex = 30;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(486, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 32);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Orange;
            this.lblUsername.Location = new System.Drawing.Point(25, 142);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(106, 16);
            this.lblUsername.TabIndex = 74;
            this.lblUsername.Text = " Tên Truy Cập";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.Orange;
            this.lblRole.Location = new System.Drawing.Point(25, 101);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(41, 16);
            this.lblRole.TabIndex = 73;
            this.lblRole.Text = "Role";
            // 
            // lblNhanVienID
            // 
            this.lblNhanVienID.AutoSize = true;
            this.lblNhanVienID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVienID.ForeColor = System.Drawing.Color.Orange;
            this.lblNhanVienID.Location = new System.Drawing.Point(25, 61);
            this.lblNhanVienID.Name = "lblNhanVienID";
            this.lblNhanVienID.Size = new System.Drawing.Size(104, 16);
            this.lblNhanVienID.TabIndex = 72;
            this.lblNhanVienID.Text = "Mã Nhân Viên";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Orange;
            this.lblPassword.Location = new System.Drawing.Point(25, 189);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 16);
            this.lblPassword.TabIndex = 76;
            this.lblPassword.Text = "Mật Khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(152, 179);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(184, 26);
            this.txtPassword.TabIndex = 75;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.Orange;
            this.lblPhone.Location = new System.Drawing.Point(450, 189);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(48, 16);
            this.lblPhone.TabIndex = 83;
            this.lblPhone.Text = " Số đt";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(577, 179);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(184, 26);
            this.txtPhone.TabIndex = 82;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Orange;
            this.lblAddress.Location = new System.Drawing.Point(450, 142);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(57, 16);
            this.lblAddress.TabIndex = 81;
            this.lblAddress.Text = "Địa Chỉ";
            // 
            // lblHo
            // 
            this.lblHo.AutoSize = true;
            this.lblHo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo.ForeColor = System.Drawing.Color.Orange;
            this.lblHo.Location = new System.Drawing.Point(450, 61);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(28, 16);
            this.lblHo.TabIndex = 80;
            this.lblHo.Text = "Họ";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(577, 132);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(184, 26);
            this.txtAddress.TabIndex = 79;
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(577, 91);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(184, 26);
            this.txtTen.TabIndex = 78;

            // 
            // txtHo
            // 
            this.txtHo.BackColor = System.Drawing.Color.White;
            this.txtHo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHo.Location = new System.Drawing.Point(577, 51);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(184, 26);
            this.txtHo.TabIndex = 77;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.ForeColor = System.Drawing.Color.Orange;
            this.lblTen.Location = new System.Drawing.Point(450, 101);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(35, 16);
            this.lblTen.TabIndex = 84;
            this.lblTen.Text = "Tên";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(152, 91);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(121, 21);
            this.cbRole.TabIndex = 85;
            // 
            // pbLast
            // 
            this.pbLast.Image = ((System.Drawing.Image)(resources.GetObject("pbLast.Image")));
            this.pbLast.Location = new System.Drawing.Point(345, 698);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(38, 21);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLast.TabIndex = 89;
            this.pbLast.TabStop = false;
            // 
            // pbNext
            // 
            this.pbNext.Image = ((System.Drawing.Image)(resources.GetObject("pbNext.Image")));
            this.pbNext.Location = new System.Drawing.Point(276, 698);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(39, 20);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 88;
            this.pbNext.TabStop = false;
            // 
            // pbPrev
            // 
            this.pbPrev.Image = ((System.Drawing.Image)(resources.GetObject("pbPrev.Image")));
            this.pbPrev.Location = new System.Drawing.Point(192, 698);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(47, 21);
            this.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrev.TabIndex = 87;
            this.pbPrev.TabStop = false;
            // 
            // pbFirst
            // 
            this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
            this.pbFirst.Location = new System.Drawing.Point(110, 698);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(48, 20);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFirst.TabIndex = 86;
            this.pbFirst.TabStop = false;
            // 
            // StaffManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblMess);
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrev);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblHo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblNhanVienID);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtNhanVienID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.dvgStaff);
            this.Controls.Add(this.btnSave);
            this.Name = "StaffManagement";
            this.Size = new System.Drawing.Size(870, 750);
            this.Load += new System.EventHandler(this.StaffManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMess;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtNhanVienID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.DataGridView dvgStaff;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblNhanVienID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblHo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanvienID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTruyCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matkhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sodt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaytao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysua;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrev;
        private System.Windows.Forms.PictureBox pbFirst;
    }
}
