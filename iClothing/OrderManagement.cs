using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using System.IO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace iClothing
{
    public partial class OrderManagement : UserControl
    {
        private DataTable dtTab1Nhap = new DataTable();
        private DataTable dtTab1Xuat = new DataTable();
        
        private DataTable dtTab2NhapXuat = new DataTable();
        private DataTable dtCurrent = new DataTable();
        //private DataTable OrignalADGVdt = null;
        private string IsCompleted = "false";
        private bool ngayNhapFilterChanged = false;
        private bool ngayXongFilterChanged = false;
        System.Windows.Forms.CheckBox headerCheckBox = new System.Windows.Forms.CheckBox();

        private DataTable dtTemp = new DataTable();
        private DataTable dtManageOrderNew = new DataTable();
        private int currentPageNumber = 1;
        private int pageSize = 0;
        private int rowPerPage = 10;
        private string currentOrderByItem = "Ngaytao";
        private Bitmap bmp;
        public static string conn = "Data Source=" + ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
        public OrderManagement()
        {
            InitializeComponent();
            rbNhap.Checked = true;
            pnXuat.Visible = false;
            //txtBTPChuaIn1.Enabled = false;
            //txtOrderID1.Enabled = false;
            dtTemp.Columns.Add("Donhang", typeof(string));
            dtTemp.Columns.Add("Xong", typeof(int));
            dtpNgaynhap.Format = DateTimePickerFormat.Custom;
            dtpNgaynhap.CustomFormat = "dd/MM/yyyy";
            //btnNewNhap.Enabled = false;
            //btnSaveNhap.Visible = true;
            
        }
        /******************************** Start Common******************************************/
        private void rbNhap_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    pnNhap.Visible = true;
                    pnXuat.Visible = false;
                    dgvOrderXuat.Visible = false;
                    dgvOrderNhap.Visible = true;
                    currentPageNumber = 1;
                    rowPerPage = 10;
                    GetAllDataOrderNhap();
                    dtCurrent = dtTab1Nhap;
                    PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                    //cbPageSizeNhap.SelectedIndex = 0;
                }
            }
        }

        private void rbXuat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    pnXuat.Visible = true;
                    pnNhap.Visible = false;
                    dgvOrderXuat.Visible = true;
                    dgvOrderNhap.Visible = false;
                    currentPageNumber = 1;
                    rowPerPage = 10;

                    GetAllDataOrderInput();
                    dtCurrent = dtTab1Xuat;
                    PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                    //cbPageSizeNhap.SelectedIndex = 0;
                }
            }
        }

        private void OrderManagement_Load(object sender, EventArgs e)
        {
            GetAllDataTab1();
            
        }
        private void GetAllDataTab1()
        {
            btnUpdate.Visible = false;

            dgvOrderXuat.Visible = false;
            // Input
            GetAllDataOrderInput();
            // Output
            GetAllDataOrderNhap();

            dtCurrent = dtTab1Nhap;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);


            // Init Customer combobox
            DataTable dtCustomer = DBHelper.GetAllCustomer();
            if (dtCustomer.Rows.Count > 0)
            {
                cbCustomer.DataSource = dtCustomer;
                cbCustomer.ValueMember = "KHID";
                cbCustomer.DisplayMember = "HoTen";
                cbCustomer.SelectedIndex = 0;
            }

            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                cbKihieu2.DataSource = dtProduct;
                cbKihieu2.ValueMember = "Barcode";
                cbKihieu2.DisplayMember = "Kyhieu";
                cbKihieu2.SelectedIndex = 0;
                cbKihieuNhap.DataSource = dtProduct;
                cbKihieuNhap.ValueMember = "Barcode";
                cbKihieuNhap.DisplayMember = "Kyhieu";
                cbKihieuNhap.SelectedIndex = 0;
            }

            // Init Supplier combobox
            DataTable dtSupplier = DBHelper.GetAllSupplier();
            if (dtSupplier.Rows.Count > 0)
            {
                cbNhacc.DataSource = dtSupplier;
                cbNhacc.ValueMember = "NhaccID";
                cbNhacc.DisplayMember = "Ten";
                cbNhacc.SelectedIndex = 0;
            }
            //cbPageSizeNhap.SelectedIndex = 0;
        }
        private void PopulateDataOrder(int currentPageNumber, int rowPerPage, DataTable dt)
        {
            int skipRecord = (currentPageNumber - 1) * rowPerPage;
            if (tbManageInOutOrder.SelectedIndex == 0)
            {
                if (rbNhap.Checked)
                {
                    if (dt.Rows.Count > 0)
                    {
                        //if(dgvOrderNhap!=null) dgvOrderNhap.Columns["Xong"].Frozen = false;
                        dgvOrderNhap.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();                        
                        dgvOrderNhap.Columns[0].Visible = false;
                        dgvOrderNhap.Columns[1].Visible = false;
                        dgvOrderNhap.Columns[3].Width = 130;
                        dgvOrderNhap.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        dgvOrderNhap.Columns[4].Width = 130;
                        dgvOrderNhap.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        dgvOrderNhap.Columns["Xong"].Width = 50;
                        //dgvOrderNhap.Columns["Xong"].Frozen = true;
                        dgvOrderNhap.Columns["Ký Hiệu"].Width = 60;
                        dgvOrderNhap.Columns["BTP Chưa in"].Width = 120;
                        this.dgvOrderNhap.Columns["BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrderNhap.Columns["BTP Đã in"].Width = 100;
                        this.dgvOrderNhap.Columns["BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrderNhap.Columns["Thành Phẩm"].Width = 120;
                        this.dgvOrderNhap.Columns["Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrderNhap.Columns["Sản phẩm lỗi"].Width = 110;
                        this.dgvOrderNhap.Columns["Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrderNhap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvOrderNhap.Sort(dgvOrderNhap.Columns["Ngày Nhập"], ListSortDirection.Descending);
                        AddCheckBoxHeader(2);

                    }
                    else
                    {
                        dgvOrderNhap.DataSource = dt;
                        dgvOrderNhap.Columns[0].Visible = false;
                        dgvOrderNhap.Columns[1].Visible = false;
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        dgvOrderXuat.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
                        dgvOrderXuat.Columns["Tên Khách Hàng"].Width = 120;
                        dgvOrderXuat.Columns["Ký Hiệu"].Width = 60;
                        dgvOrderXuat.Columns["BTP Chưa in"].Width = 60;
                        dgvOrderXuat.Columns["BTP Đã in"].Width = 60;
                        dgvOrderXuat.Columns["Thành Phẩm"].Width = 60;
                        dgvOrderXuat.Columns["Sản phẩm lỗi"].Width = 60;
                        dgvOrderXuat.Columns["Xong"].Width = 50;
                    }
                }
            }
            else
            {
                dvgManageInOut.DataSource = dtManageOrderNew.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();

            }

        }
        /******************************** Start Common******************************************/
        /******************************** Start Panel Nhap******************************************/
        private void HeaderCBNhap_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dgvOrderNhap.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dgvOrderNhap.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["cbSelectNhap"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void AddCheckBoxHeader(int columnIndex)
        {
            //Add a CheckBox Column to the DataGridView Header Cell.

            //Find the Location of Header Cell.
            System.Drawing.Point headerCellLocation = this.dgvOrderNhap.GetCellDisplayRectangle(columnIndex, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new System.Drawing.Point(headerCellLocation.X + 8, headerCellLocation.Y + 8);
            headerCheckBox.BackColor = Color.Orange;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCBNhap_Clicked);
            dgvOrderNhap.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "cbSelectNhap";
            dgvOrderNhap.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            dgvOrderNhap.CellContentClick += new DataGridViewCellEventHandler(dgvOrderNhap_CellClick);
        }

        private void GetAllDataOrderNhap()
        {
            string query = "Select New.DonhangID [Mã Đơn Hàng],Supplier.Ten [Nhà Cung Cấp],[Order].Xong,[Order].Ngaynhap [Ngày nhập], [Order].Ngayxong [Ngày Xong], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi]  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID order by [Order].Ngaynhap";
            dtTab1Nhap = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtTab1Nhap.Merge(dt);
                }
            }
            int rowCount = dtTab1Nhap.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPageNhap.Text = "Tổng số:" + dtTab1Nhap.Rows.Count.ToString();
            txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void btnNewNhap_Click(object sender, EventArgs e)
        {
            cbNhacc.SelectedIndex = 1;
            cbKihieuNhap.SelectedIndex = 1;
            txtBTPChuaInNhap.Text = "0";
            txtBTPDaInNhap.Text = "0";
            txtTPNhap.Text = "0";
            txtSPLoiNhap.Text = "0";
        }

        private void btnSaveNhap_Click(object sender, EventArgs e)
        {
            try
            {
                List<DBModel> dbModels = new List<DBModel>();
                //DataTable dtItem = (DataTable)(dgvOrderNhap.DataSource);
                
                List<string> ItemQryList = new List<string>();

                bool isSuccess = false;
                string isNhap = "true";
                DataRow rd = dtTab1Nhap.NewRow();

                string Ngay, DonhangID, barcode, NhaccID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL;
                Ngay = DonhangID = barcode = NhaccID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = string.Empty;
                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaInNhap.Text)) txtBTPChuaInNhap.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaInNhap.Text)) txtBTPDaInNhap.Text = "0";
                if (string.IsNullOrEmpty(txtTPNhap.Text)) txtTPNhap.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoiNhap.Text)) txtSPLoiNhap.Text = "0";


                if (string.IsNullOrEmpty(txtOrderIDNhap.Text))
                {
                    isNhap = "true";
                    // DonhangID
                    DonhangID = CommonHelper.RandomString(8);
                    rd[0] = DonhangID;
                    // NhaccID
                    NhaccID = cbNhacc.SelectedValue.ToString();
                    rd[1] = DBHelper.Lookup("Supplier", "Ten", "NhaccID", NhaccID);
                    // Xong
                    rd[2] = IsCompleted;
                    // Ngay nhap
                    Ngay = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    rd[3] = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    // Barcode
                    barcode = cbKihieu2.SelectedValue.ToString();
                    rd[5] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                    
                   
                    // BTPChuaIn
                    BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                    BTPChuaInSL = txtBTPChuaInNhap.Text;
                    rd[6] = BTPChuaInSL;
                    // BTPDaIn
                    BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                    BTPDaInSL = txtBTPDaInNhap.Text;
                    rd[7] = BTPDaInSL;
                    // TP
                    TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                    TPSL = txtTPNhap.Text;
                    rd[8] = TPSL;
                    // SPLoi
                    SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                    SPLoiSL = txtSPLoiNhap.Text;
                    rd[9] = SPLoiSL;

                    // Created Date
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                    
                    ItemQryList = AddNewOrderNhap(Ngay, DonhangID, NhaccID, barcode, IsCompleted, createDate, createDate, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL,TPSL, SPLoiSL);
                }
                else
                {
                    isNhap = "false";
                    DonhangID = txtOrderIDNhap.Text;
                    DataRow row = dtTab1Nhap.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();

                    string ngayxong = string.Empty;
                    string ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    // NhaccID
                    NhaccID = cbNhacc.SelectedValue.ToString();
                    row[1] = DBHelper.Lookup("Supplier", "Ten", "NhaccID", NhaccID);
                    // Xong                   
                    row[2] = IsCompleted;

                    // Ngay nhap
                    ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    //rd[3] = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    // Ngay xong
                    if (!DBHelper.isXong(DonhangID) && bool.Parse(IsCompleted))
                    {
                        ngayxong = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                        row[4] = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    // Barcode
                    barcode = cbKihieu2.SelectedValue.ToString();
                    row[5] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                    // BTPChuaIn
                    BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                    BTPChuaInSL = txtBTPChuaInNhap.Text;
                    row[6] = BTPChuaInSL;
                    // BTPDaIn
                    BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                    BTPDaInSL = txtBTPDaInNhap.Text;
                    row[7] = BTPDaInSL;
                    // TP
                    TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                    TPSL = txtTPNhap.Text;
                    row[8] = TPSL;
                    // SPLoi
                    SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                    SPLoiSL = txtSPLoiNhap.Text;
                    row[9] = SPLoiSL;

                    ItemQryList = UpdateOrderNhap(DonhangID, barcode, NhaccID, ngayxong, ngaysua, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL,BTPDaInSL,TPSL, SPLoiSL, IsCompleted);

                }

                if (DBAccess.IsServerConnected())
                {
                    //bool isExisted = DBHelper.CheckItemExist("Order", "DonhangID", DonhangID);

                    //if (!isExisted)
                    //{
                    if (ItemQryList.Count > 0)
                    {
                        foreach (var item in ItemQryList)
                        {
                            isSuccess = DBAccess.ExecuteQuery(item);
                        }

                        if (isSuccess)
                        {
                            SaveOrderToTransactionDB(barcode, BTPChuaInID, "", BTPChuaInSL, isNhap, "false");
                            SaveOrderToTransactionDB(barcode, BTPDaInID, "", BTPDaInSL, isNhap, "false");
                            SaveOrderToTransactionDB(barcode, TPID, "", TPSL, isNhap, "false");
                            SaveOrderToTransactionDB(barcode, SPLoiID, "", SPLoiSL, isNhap, "false");
                            if (isNhap == "true")
                            {
                                dtTab1Nhap.Rows.InsertAt(rd, 0);
                                cbNhacc.SelectedIndex = 0;
                                currentPageNumber = 1;
                                countPageSize(dtTab1Nhap);
                                ClearTextNhap();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Nhap);
                            }
                            else
                            {
                                cbNhacc.SelectedIndex = 0;
                                currentPageNumber = 1;
                                countPageSize(dtTab1Nhap);
                                ClearTextNhap();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Nhap);
                            }  
                            

                            
                            MessageBox.Show("Đơn hàng này đã cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Barcode da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private List<string> AddNewOrderNhap(string Ngaynhap, string DonhangID, string NhaccID, string barcode, string IsCompleted, string createDate, string ngaynhap,
            string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
            string TPSL, string SPLoiSL)
        {
            List<string> InsertItemQryList = new List<string>();
            string InsertItemQry = "";
            string orderDetailID1 = CommonHelper.RandomString(7) + 1;
            string orderDetailID2 = CommonHelper.RandomString(7) + 2;
            string orderDetailID3 = CommonHelper.RandomString(7) + 3;
            string orderDetailID4 = CommonHelper.RandomString(7) + 4;

            // query insert
            InsertItemQry = "INSERT INTO [Order] ([DonhangID],[NhaccID],[Xong],[Ngaytao],[Ngaysua],[Ngaynhap])VALUES('" + DonhangID + "','" + NhaccID + "','" + IsCompleted + "','" + createDate + "','" + createDate + "','" + ngaynhap + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID1 + "','" + DonhangID + "','" + barcode + "','" + BTPChuaInID + "','" + BTPChuaInSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID2 + "','" + DonhangID + "','" + barcode + "','" + BTPDaInID + "','" + BTPDaInSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID3 + "','" + DonhangID + "','" + barcode + "','" + TPID + "','" + TPSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID4 + "','" + DonhangID + "','" + barcode + "','" + SPLoiID + "','" + SPLoiSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            return InsertItemQryList;
        }

        private List<string> UpdateOrderNhap(string DonhangID, string barcode, string NhaccID, string ngayxong, string ngaysua, string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
            string TPSL, string SPLoiSL, string xong)
        {
            List<string> UpdateItemQryList = new List<string>();
            string UpdateItemQry = "";
            string orderDetailID1 = CommonHelper.RandomString(7) + 1;
            string orderDetailID2 = CommonHelper.RandomString(7) + 2;
            string orderDetailID3 = CommonHelper.RandomString(7) + 3;
            string orderDetailID4 = CommonHelper.RandomString(7) + 4;

            if (!string.IsNullOrEmpty(ngayxong))
            {
                ngayxong = "',[Ngayxong]= '" + ngayxong;
            }
            // query update
            UpdateItemQry = "UPDATE [Order] SET[NhaccID] ='" + NhaccID  + ngayxong + "',[Ngaysua]= '" + ngaysua + "',[Xong]= '" + xong + "' WHERE DonhangID ='" + DonhangID  + "';";
            UpdateItemQryList.Add(UpdateItemQry);
            UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + BTPChuaInSL + "',[Ngaysua]= '" + ngaysua + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPChuaInID + "';";
            UpdateItemQryList.Add(UpdateItemQry);
            UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + BTPDaInSL + "',[Ngaysua]= '" + ngaysua + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPDaInID + "';";
            UpdateItemQryList.Add(UpdateItemQry);
            UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + TPSL + "',[Ngaysua]= '" + ngaysua + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + TPID + "';";
            UpdateItemQryList.Add(UpdateItemQry);
            UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + SPLoiSL + "',[Ngaysua]= '" + ngaysua + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + SPLoiID + "';";
            UpdateItemQryList.Add(UpdateItemQry);
            return UpdateItemQryList;
        }



        /******************************** End Panel Nhap******************************************/
        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            try
            {
                //List<DBModel> dbModelsUpdate = new List<DBModel>();
                //DBModel itemModelUpdate = new DBModel();
                //List<DBModel> dbModelsLookupList = new List<DBModel>();
                //DBModel itemModelLookup = new DBModel();
                //DBModel modelWhere = new DBModel();
                List<string> UpdateItemQryList = new List<string>();
                DataTable dtItem = (DataTable)(dgvOrderNhap.DataSource);
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, createDate, modifyDate;
                string UpdateItemQry = "";
                bool isSuccess = false;
                int count = 0;

                // DonhangID
                DonhangID = txtOrderIDNhap.Text;
                DataRow row = dtTab1Nhap.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();

                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaInNhap.Text)) txtBTPChuaInNhap.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaInNhap.Text)) txtBTPDaInNhap.Text = "0";
                if (string.IsNullOrEmpty(txtTPNhap.Text)) txtTPNhap.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoiNhap.Text)) txtSPLoiNhap.Text = "0";


                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                row[2] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                // BTPChuaIn
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                row[3] = txtBTPChuaInNhap.Text;
                // BTPDaIn
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                row[4] = txtBTPDaInNhap.Text;
                // TP
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                row[5] = txtTPNhap.Text;
                // SPLoi
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                row[6] = txtSPLoiNhap.Text;
                // Modify Date
                modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                row[7] = modifyDate;


                if (barcode != "")
                {
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtBTPChuaInNhap.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPChuaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtBTPDaInNhap.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPDaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtTPNhap.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + TP + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtSPLoiNhap.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + SPLoi + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                }

                if (DBAccess.IsServerConnected())
                {
                    bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", DonhangID);

                    if (isExisted)
                    {
                        if (UpdateItemQry.Length > 5)
                        {
                            foreach (var item in UpdateItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }

                            if (isSuccess)
                            {
                                //dtTab1Output.Rows.InsertAt(row, 0);
                                SaveOrderToTransactionDB(barcode, BTPChuaIn, "", txtBTPChuaInNhap.Text, "true", "false");
                                SaveOrderToTransactionDB(barcode, BTPDaIn, "", txtBTPDaInNhap.Text, "true", "false");
                                SaveOrderToTransactionDB(barcode, TP, "", txtTPNhap.Text, "true", "false");
                                SaveOrderToTransactionDB(barcode, SPLoi, "", txtSPLoiNhap.Text, "true", "false");
                                //dtTab1Output = DBHelper.UpdateDatatable(dtTab1Output, modelWhere, dbModelsUpdate);
                                currentPageNumber = 1;
                                countPageSize(dtTab1Nhap);
                                ClearTextNhap();

                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Nhap);

                                MessageBox.Show("Sửa đơn hàng này thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn hàng này chưa tồn tại!" + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }
        /******************************** Start Panel 1******************************************/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtItem = (DataTable)(dgvOrderNhap.DataSource);
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, KHID, modifyDate;
                List<string> InsertItemQryList = new List<string>();
                string InsertItemQry = "";
                bool isSuccess = false;
                int count = 0;
                DataRow rd = dtTab1Xuat.NewRow();

                // Set value for number field
                if (string.IsNullOrEmpty(txtChuaIn2.Text)) txtChuaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtDaIn2.Text)) txtDaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtTP2.Text)) txtTP2.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi2.Text)) txtSPLoi2.Text = "0";

                // DonhangID
                DonhangID = CommonHelper.RandomString(8);
                rd[0] = DonhangID;
                // KHID
                KHID = cbCustomer.SelectedValue.ToString();
                rd[1] = DBHelper.Lookup("Customer", "HoTen", "KHID", KHID);
                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                rd[2] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                // BTPChuaIn
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                rd[3] = txtChuaIn2.Text;
                // BTPDaIn
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                rd[4] = txtDaIn2.Text;
                // TP
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                rd[5] = txtTP2.Text;
                // SPLoi
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                rd[6] = txtSPLoi2.Text;
                // Modify Date
                modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                rd[7] = modifyDate;
                // Xong
                rd[8] = IsCompleted;

                string orderDetailID1 = CommonHelper.RandomString(7) + 1;
                string orderDetailID2 = CommonHelper.RandomString(7) + 2;
                string orderDetailID3 = CommonHelper.RandomString(7) + 3;
                string orderDetailID4 = CommonHelper.RandomString(7) + 4;
                if (barcode != "")
                {
                    InsertItemQry = "INSERT INTO [Order] ([DonhangID],[KHID],[Xong],[Ngaytao],[Ngaysua])VALUES('" + DonhangID + "','" + KHID + "','" + IsCompleted + "','" + modifyDate + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID1 + "','" + DonhangID + "','" + barcode + "','" + BTPChuaIn + "','" + txtChuaIn2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID2 + "','" + DonhangID + "','" + barcode + "','" + BTPDaIn + "','" + txtDaIn2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID3 + "','" + DonhangID + "','" + barcode + "','" + TP + "','" + txtTP2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID4 + "','" + DonhangID + "','" + barcode + "','" + SPLoi + "','" + txtSPLoi2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                }

                if (DBAccess.IsServerConnected())
                {
                    //bool isExisted = DBHelper.CheckItemExist("Order", "DonhangID", DonhangID);

                    //if (!isExisted)
                    //{
                    if (InsertItemQryList.Count > 0)
                    {
                        foreach (var item in InsertItemQryList)
                        {
                            isSuccess = DBAccess.ExecuteQuery(item);
                        }

                        if (isSuccess)
                        {
                            SaveOrderToTransactionDB(barcode, BTPChuaIn, "", txtChuaIn2.Text, "false", "false");
                            SaveOrderToTransactionDB(barcode, BTPDaIn, "", txtDaIn2.Text, "false", "false");
                            SaveOrderToTransactionDB(barcode, TP, "", txtTP2.Text, "false", "false");
                            SaveOrderToTransactionDB(barcode, SPLoi, "", txtSPLoi2.Text, "false", "false");

                            dtTab1Xuat.Rows.InsertAt(rd, 0);
                            cbCustomer.SelectedIndex = 0;
                            currentPageNumber = 1;
                            countPageSize(dtTab1Xuat);
                            ClearTextNhap();
                            // Update datalist
                            PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Xuat);
                            MessageBox.Show("Thêm Mới Thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Barcode da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string orderID = txtOrder2.Text;
            string query;
            bool isSuccess = false;
            List<string> DeleteItemQryList = new List<string>();
            if (!string.IsNullOrEmpty(orderID))
            {
                query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                DeleteItemQryList.Add(query);
                query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                DeleteItemQryList.Add(query);
                if (DBAccess.IsServerConnected())
                {
                    DataRow row = dtTab1Xuat.Select("[Mã Đơn Hàng]=" + orderID, "[Mã Đơn Hàng]").FirstOrDefault();

                    if (query.Length > 5)
                    {
                        bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", orderID);

                        if (isExisted)
                        {
                            foreach (var item in DeleteItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }
                            if (isSuccess)
                            {
                               
                                currentPageNumber = 1;
                                dtTab1Xuat.Rows.Remove(row);
                                countPageSize(dtTab1Xuat);
                                ClearTextNhap();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Xuat);
                                MessageBox.Show("Xóa Đơn Hàng Thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                            
                        }
                        else
                        {
                            MessageBox.Show("Mã đơn hàng này không tồn tại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void GetAllDataOrderInput()
        {
            string query = "Select New.DonhangID [Mã Đơn Hàng], Customer.HoTen [Tên Khách Hàng], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], [New].Ngaysua [Ngày], [Order].Xong  from (SELECT DonhangID, Barcode, Ngaysua, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Customer on[Order].KHID = Customer.KHID where [Order].Xong = 0 order by New.Ngaysua;";
            dtTab1Xuat = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtTab1Xuat.Merge(dt);
                }
            }
            int rowCount = dtTab1Xuat.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPageNhap.Text = "Tổng số:" + dtTab1Xuat.Rows.Count.ToString();
            txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }
        

        
        private void dgvOrderXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvOrderXuat.Rows[e.RowIndex];
                txtOrder2.Text = dgvRow.Cells[0].Value.ToString();
                txtChuaIn2.Text = dgvRow.Cells[3].Value.ToString();
                txtDaIn2.Text = dgvRow.Cells[4].Value.ToString();
                txtTP2.Text = dgvRow.Cells[5].Value.ToString();
                txtSPLoi2.Text = dgvRow.Cells[6].Value.ToString();
                cbCustomer.SelectedValue = DBHelper.Lookup("Customer", "KHID", "HoTen", dgvRow.Cells[1].Value.ToString());
                cbCustomer.Text = dgvRow.Cells[1].Value.ToString();
                cbCustomer.Enabled = false;

                cbKihieuNhap.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[2].Value.ToString());
                cbKihieuNhap.Text = dgvRow.Cells[2].Value.ToString();


                btnAdd1.Visible = false;
                btnUpdate.Visible = true;
                if(e.ColumnIndex != -1)
                {
                    if (dgvOrderXuat.Columns[e.ColumnIndex].Name == "Xong")
                    {
                        //btnXong.Enabled = true;
                    }
                }
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> UpdateItemQryList = new List<string>();
                DataTable dtItem = (DataTable)(dgvOrderNhap.DataSource);
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, createDate, modifyDate;
                string UpdateItemQry = "";
                bool isSuccess = false;
                int count = 0;
                var csv = new StringBuilder();
                // DonhangID
                DonhangID = txtOrder2.Text;
                DataRow row = dtTab1Xuat.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();

                // Set value for number field
                if (string.IsNullOrEmpty(txtChuaIn2.Text)) txtChuaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtDaIn2.Text)) txtDaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtTP2.Text)) txtTP2.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi2.Text)) txtSPLoi2.Text = "0";
                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                row[2] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                // BTPChuaIn
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                row[3] = txtChuaIn2.Text;
                // BTPDaIn
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                row[4] = txtDaIn2.Text;
                // TP
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                row[5] = txtTP2.Text;
                // SPLoi
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                row[6] = txtSPLoi2.Text;
                // Modify Date
                modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                row[7] = modifyDate;

                if (barcode != "")
                {
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtChuaIn2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPChuaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtDaIn2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPDaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtTP2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + TP + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtSPLoi2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + SPLoi + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                }

                if (DBAccess.IsServerConnected())
                {
                    bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", DonhangID);

                    if (isExisted)
                    {
                        if (UpdateItemQry.Length > 5)
                        {
                            foreach (var item in UpdateItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }

                            if (isSuccess)
                            {
                                SaveOrderToTransactionDB(barcode, BTPChuaIn, "", txtChuaIn2.Text, "false", "false");
                                SaveOrderToTransactionDB(barcode, BTPDaIn, "", txtDaIn2.Text, "false", "false");
                                SaveOrderToTransactionDB(barcode, TP, "", txtTP2.Text, "false", "false");
                                SaveOrderToTransactionDB(barcode, SPLoi, "", txtSPLoi2.Text, "false", "false");
                                
                                currentPageNumber = 1;
                                countPageSize(dtTab1Xuat);
                                ClearTextNhap();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Xuat);
                                MessageBox.Show("Nhập Đơn Hàng Thành công!" + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn Hàng Này Chưa Tồn Tại!" + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            dtCurrent = dtTab1Nhap;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Nhap;
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            }
            txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Nhap;
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Xuat;
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }
        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSizeNhap.SelectedItem);
            currentPageNumber = 1;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void countPageSize(DataTable dt)
        {
            int rowCount = dt.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            lblTotalPageNhap.Text = "Tổng số:" + dt.Rows.Count.ToString();
        }

        private void ClearTextNhap()
        {
            //btnAdd1.Visible = true;
            //btnNewNhap.Visible = true;
            //btnUpdate.Visible = false;
            //btnSaveNhap.Visible = false;
            txtOrderIDNhap.Text = string.Empty;
            //cbCustomer.SelectedIndex = 0;
            //cbKihieu2.SelectedIndex = 0;
            cbNhacc.Enabled = true;
            cbNhacc.SelectedIndex = 1;
            //cbKihieu2.SelectedIndex = 1;
            txtBTPChuaInNhap.Text = string.Empty;
            txtBTPDaInNhap.Text = string.Empty;
            txtTPNhap.Text = string.Empty;
            txtSPLoiNhap.Text = string.Empty;
            //txtChuaIn2.Text = string.Empty;
            //txtDaIn2.Text = string.Empty;
            //txtTP2.Text = string.Empty;
            //txtSPLoi2.Text = string.Empty;
            //txtQuantity.Text = string.Empty;
        }
        /******************************** End Panel 1 ******************************************/



        /******************************** Start Panel 2******************************************/
        private void btnXong_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> UpdateItemQryList = new List<string>();
                string UpdateItemQry = string.Empty;
                bool isSuccess = false;
                string DonhangID, Barcode, BTPChuaInID, BTPDaInID, TPID, SPLoiID,BTPChuaIn, BTPDaIn, TP, SPLoi;
                DonhangID = Barcode = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaIn = BTPDaIn = TP = SPLoi = string.Empty;
                DataRow row;
                int count = 0;
                var csv = new StringBuilder();

                // BTPChuaIn
                BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                // BTPDaIn
                BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                // TP
                TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                // SPLoi
                SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");

                if (rbXuat.Checked)
                {
                    DonhangID = txtOrder2.Text;
                    row = dtTab1Xuat.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();
                    Barcode = cbKihieu2.SelectedValue.ToString();
                    // Convert soluong to negative
                    BTPChuaIn = "-" + txtChuaIn2.Text;
                    BTPDaIn = "-" + txtDaIn2.Text;
                    TP = "-" + txtTP2.Text;
                    SPLoi = "-" + txtSPLoi2.Text;
                    SaveOrderToTransactionDB(Barcode, BTPChuaInID, "", txtChuaIn2.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, BTPDaIn, "", txtDaIn2.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, TPID, "", txtTP2.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, SPLoiID, "", txtSPLoi2.Text, "true", "false");
                }
                else
                {
                    DonhangID = txtOrderIDNhap.Text;
                    row = dtTab1Nhap.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();
                    Barcode = cbKihieuNhap.SelectedValue.ToString();
                    BTPChuaIn = txtBTPChuaInNhap.Text;
                    BTPDaIn = txtBTPDaInNhap.Text;
                    TP = txtTPNhap.Text;
                    SPLoi = txtSPLoiNhap.Text;
                    SaveOrderToTransactionDB(Barcode, BTPChuaInID, "", txtBTPChuaInNhap.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, BTPDaIn, "", txtBTPDaInNhap.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, TPID, "", txtTPNhap.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, SPLoiID, "", txtSPLoiNhap.Text, "true", "false");
                }
                

                string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                string TonkhoID1 = CommonHelper.RandomString(7) + 1;
                string TonkhoID2 = CommonHelper.RandomString(7) + 2;
                string TonkhoID3 = CommonHelper.RandomString(7) + 3;
                string TonkhoID4 = CommonHelper.RandomString(7) + 4;

                UpdateItemQry = "UPDATE[Order] SET [Xong] = 1";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID1 + "','" + Barcode + "','" + BTPChuaInID + "','" + BTPChuaIn + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID2 + "','" + Barcode + "','" + BTPDaInID + "','" + BTPDaIn + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID3 + "','" + Barcode + "','" + TPID + "','" + TP + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID4 + "','" + Barcode + "','" + SPLoiID + "','" + SPLoi + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);

                
                if (DBAccess.IsServerConnected())
                {
                    bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", DonhangID);

                    if (isExisted)
                    {
                        if (UpdateItemQry.Length > 5)
                        {
                            foreach (var item in UpdateItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }
                            


                            if (isSuccess)
                            {
                                if (rbXuat.Checked)
                                {
                                    currentPageNumber = 1;
                                    dtTab1Xuat.Rows.Remove(row);
                                    countPageSize(dtTab1Xuat);
                                    PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Xuat);
                                   
                                }
                                else
                                {
                                    currentPageNumber = 1;
                                    dtTab1Nhap.Rows.Remove(row);
                                    countPageSize(dtTab1Nhap);
                                    PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Nhap);
                                    
                                }
                                ClearTextNhap();
                                // Update datalist
                                
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn hàng này chưa tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }


        }
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrderNhap.SelectedRows)
            {
                string orderID = row.Cells[1].Value.ToString();
                string query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                bool isSuccess = DBAccess.ExecuteQuery(query);
                if (!isSuccess) return;
                query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                isSuccess = DBAccess.ExecuteQuery(query);
                if (!isSuccess) return;
                dgvOrderNhap.Rows.Remove(row);
            }
            //DBModel modelWhere = new DBModel();
            //string orderID = txtOrderIDNhap.Text;
            //string query;
            //bool isSuccess = false;
            //List<string> DeleteItemQryList = new List<string>();
            //if (!string.IsNullOrEmpty(orderID))
            //{
            //    query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
            //    DeleteItemQryList.Add(query);
            //    query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
            //    DeleteItemQryList.Add(query);
            //    if (DBAccess.IsServerConnected())
            //    {
            //        // Barcode
            //        // modelWhere.text = "DonhangID";
            //        //modelWhere.value = orderID;
            //        //modelWhere.type = "string";
            //        DataRow row = dtTab1Nhap.Select("[Mã Đơn Hàng]=" + orderID, "[Mã Đơn Hàng]").FirstOrDefault();

            //        if (query.Length > 5)
            //        {
            //            bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", orderID);

            //            if (isExisted)
            //            {
            //                foreach (var item in DeleteItemQryList)
            //                {
            //                    isSuccess = DBAccess.ExecuteQuery(item);
            //                }
            //                if (isSuccess)
            //                {
            //                    //dtTab1Output = DBHelper.DeleteDatatable(dtTab1Output, modelWhere);
            //                    currentPageNumber = 1;
            //                    dtTab1Nhap.Rows.Remove(row);
            //                    countPageSize(dtTab1Nhap);

            //                    ClearTextNhap();
            //                    // Update datalist
            //                    PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Nhap);
            //                    MessageBox.Show("Số sản phẩm đã nhập Thành công: ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }


            //            }
            //            else
            //            {
            //                MessageBox.Show("Đơn hàng này chưa tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //    }

            //}
        }


        

        

        
 
        private void dgvOrderNhap_FilterStringChanged(object sender, EventArgs e)
        {
            //ADGV.AdvancedDataGridView fdgv = dgvOrderNhap;
            //DataTable dt = null;
            //if (OrignalADGVdt == null)
            //{
            //    OrignalADGVdt = (DataTable)fdgv.DataSource;
            //}
            //else
            //{
            //    int row = OrignalADGVdt.Rows.Count;
            //    fdgv.DataSource = OrignalADGVdt;
            //}
            //if (fdgv.FilterString.Length > 0)
            //{
            //    dt = (DataTable)fdgv.DataSource;
            //}
            //else//Clear Filter
            //{
            //    dt = OrignalADGVdt;
            //}

            //fdgv.DataSource = dt.Select(fdgv.FilterString).CopyToDataTable();
        }

        private void dgvOrderNhap_SortStringChanged(object sender, EventArgs e)
        {
            //ADGV.AdvancedDataGridView fdgv = dgvOrderNhap;
            //if (fdgv.SortString.Length == 0)
            //{
            //    return;
            //}
            //string[] strtok = fdgv.SortString.Split(',');
            //currentOrderByItem = String.Join(",", strtok);
            //foreach (string str in strtok)
            //{
            //    string[] columnorder = str.Split(']');
            //    ListSortDirection lds = ListSortDirection.Ascending;
            //    if (columnorder[1].Trim().Equals("DESC"))
            //    {
            //        lds = ListSortDirection.Descending;
            //    }
            //    dgvOrderNhap.Sort(dgvOrderNhap.Columns[columnorder[0].Replace('[', ' ').Trim()], lds);
            //}
        }

        private void dgvOrderNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvOrderNhap.Rows[e.RowIndex];
                txtOrderIDNhap.Text= dgvRow.Cells[1].Value.ToString();
                cbNhacc.SelectedValue = DBHelper.Lookup("Supplier", "NhaccID", "Ten", dgvRow.Cells[2].Value.ToString());
                cbNhacc.Text = dgvRow.Cells[2].Value.ToString();
                if (Convert.ToBoolean(dgvRow.Cells["Xong"].EditedFormattedValue) == true) IsCompleted = "true"; else IsCompleted = "false";
                dtpNgaynhap.Value = DateTime.Parse(dgvRow.Cells[4].Value.ToString());
                cbKihieuNhap.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[6].Value.ToString());
                cbKihieuNhap.Text = dgvRow.Cells[6].Value.ToString();
                txtBTPChuaInNhap.Text = dgvRow.Cells[7].Value.ToString();
                txtBTPDaInNhap.Text = dgvRow.Cells[8].Value.ToString();
                txtTPNhap.Text = dgvRow.Cells[9].Value.ToString();
                txtSPLoiNhap.Text = dgvRow.Cells[10].Value.ToString();
                

                


                //btnNewNhap.Visible = false;
                //btnSaveNhap.Visible = true;
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row in dgvOrderNhap.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["cbSelectNhap"].EditedFormattedValue) == false)
                        {
                            isChecked = false;
                            break;
                        }
                    }
                    headerCheckBox.Checked = isChecked;
                }
                    if (e.ColumnIndex != -1)
                {
                    if (dgvOrderNhap.Columns[e.ColumnIndex].Name == "Xong")
                    {
                        
                    }
                }
                
            }
            
        }

        /********************************End Panel 2******************************************/

        private void GetAllOrder()
        {
            string query = "select * from (select[order].donhangid [Mã Đơn Hàng], barcode [Barcode], SUM(CASE WHEN LoaiID = 0000001 AND[order].NhacciD is not null Then Soluong else 0 end)[Nhập BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Thành Phẩm],SUM(CASE WHEN LoaiID = 000004 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Sản phẩm lỗi],SUM(CASE WHEN LoaiID = 0000001 AND[order].KHID is not null Then Soluong else 0 end)[Xuất BTP Chưa in],SUM(CASE WHEN LoaiID = 0000002 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Sản phẩm lỗi], [order].ngaysua from orderdetail join [order] on orderdetail.donhangid = [order].donhangid GROUP BY[order].donhangid, Barcode,[order].ngaysua) New order by New.ngaysua;";
            dtTab2NhapXuat = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtTab2NhapXuat.Merge(dt);
                }
            }
            int rowCount = dtTab2NhapXuat.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage1.Text = "Tổng số:" + dtTab2NhapXuat.Rows.Count.ToString();
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void PopulateDataOrderInOut(int currentPageNumber, int rowPerPage, DataTable dt)
        {
            int skipRecord = (currentPageNumber - 1) * rowPerPage;

            if (dt.Rows.Count > 0)
            {
                dvgManageInOut.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
            }
            else
            {
                dvgManageInOut.DataSource = dt;
            }


        }
        private void pbFirst1_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev1_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber -= 1;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
            }
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext1_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
                txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast1_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
                txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void tbNewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbManageInOutOrder.SelectedIndex)
            {
                case 0:
                    { GetAllDataTab1(); }
                    break;
                case 1:
                    {
                        currentPageNumber = 1;
                        rowPerPage = 10;
                        GetAllOrder();
                        PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
                        cbPageSize1.SelectedItem = "10";
                    }
                    break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Creating Save File Dialog
            SaveFileDialog save = new SaveFileDialog();
            //Showing the dialog
            save.ShowDialog();
            //Setting default directory
            save.InitialDirectory = @"C:\";
            save.RestoreDirectory = true;
            string fileName = save.FileName;
            save.AddExtension = true;
            save.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            //Setting title
            save.Title = "Select save location and input file name";
            //filtering to only show .xlsx files in the directory
            save.DefaultExt = "xlsx";
            // Write Data to DataTable
            ExportToExcel();
            //Write Data To Excel
            ToExcel(fileName);
        }
        private void ToExcel(string fileName)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName + DateTime.Now.ToString("M-dd-yyyy-HH.mm.ss") + ".xlsx");
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "CHI TIẾT XUẤT NHẬP";
                // storing header part in Excel  
                var columnHeadingsRangeIn = worksheet.Range[worksheet.Cells[1, 5], worksheet.Cells[1, 8]];
                columnHeadingsRangeIn.Interior.Color = XlRgbColor.rgbPaleVioletRed;
                var columnHeadingsRangeOut = worksheet.Range[worksheet.Cells[1, 9], worksheet.Cells[1, 12]];
                columnHeadingsRangeOut.Interior.Color = XlRgbColor.rgbBlueViolet;
                for (int i = 0; i < dtManageOrderNew.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dtManageOrderNew.Columns[i].ToString();
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dtManageOrderNew.Rows.Count; i++)
                {
                    for (int j = 0; j < dtManageOrderNew.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dtManageOrderNew.Rows[i][j].ToString();
                    }
                }
                // save the application  
                workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public System.Data.DataTable ExportToExcel()
        {
            dtManageOrderNew = new DataTable();
            dtManageOrderNew.Columns.Add("STT", typeof(int));
            dtManageOrderNew.Columns.Add("NGÀY", typeof(string));
            dtManageOrderNew.Columns.Add("KÝ HIỆU", typeof(string));
            dtManageOrderNew.Columns.Add("MÃ HÀNG", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP BTP Chưa in ", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP BTP Đã in ", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP Thành Phẩm ", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP SP Lỗi ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT BTP Chưa in ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT BTP Đã in ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT Thành Phẩm ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT SP Lỗi ", typeof(string));
            dtManageOrderNew.Columns.Add("GHI CHÚ", typeof(string));

            DataRow row;
            string ngay, kyhieu, masp, nhapbtpchuain, nhapbtpdain, nhaptp, nhapsploi, xuatbtpchuain, xuatbtpdain, xuattp, xuatsploi,ghichu;
            for (int i = 0; i < dtTab2NhapXuat.Rows.Count; i++)
            {
                ngay = DateTime.Parse(dtTab2NhapXuat.Rows[i][10].ToString()).ToString("dd/MM/yyy");
                kyhieu = DBHelper.Lookup("Product","Kyhieu","Barcode",dtTab2NhapXuat.Rows[i][1].ToString());
                masp = DBHelper.Lookup("Product", "MaSP", "Barcode", dtTab2NhapXuat.Rows[i][1].ToString());
                nhapbtpchuain = dtTab2NhapXuat.Rows[i][2].ToString();
                nhapbtpdain = dtTab2NhapXuat.Rows[i][3].ToString();
                nhaptp = dtTab2NhapXuat.Rows[i][4].ToString();
                nhapsploi = dtTab2NhapXuat.Rows[i][5].ToString();
                xuatbtpchuain = dtTab2NhapXuat.Rows[i][6].ToString();
                xuatbtpdain = dtTab2NhapXuat.Rows[i][7].ToString();
                xuattp = dtTab2NhapXuat.Rows[i][8].ToString();
                xuatsploi = dtTab2NhapXuat.Rows[i][9].ToString();
                ghichu = "";
                dtManageOrderNew.Rows.Add(i + 1, ngay, kyhieu, masp, nhapbtpchuain, nhapbtpdain, nhaptp, nhapsploi, xuatbtpchuain, xuatbtpdain, xuattp, xuatsploi, ghichu);
            }
            return dtManageOrderNew;
        }

        private void txtBTPChuaIn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDaIn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSPLoi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBTPDaIn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChuaIn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SaveOrderToTransactionDB(string barcode, string LoaiID, string Mota, string soluong, string Nhap, string Xong)
        {
            DBModel modelWhere = new DBModel();
            bool isSuccess = false;
            string InsertItemQry;
            string TransID = CommonHelper.RandomString(8);
            string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            if (!string.IsNullOrEmpty(barcode))
            {
                InsertItemQry = "INSERT INTO [Transaction]([TransID],[Barcode],[LoaiID],[Mota],[Soluong],[Nhap],[Xong],[Ngaytao],[Ngaysua])VALUES('"+ TransID + "','" + barcode + "','"+LoaiID+"','"+Mota +"','" + soluong + "','" + Nhap + "','"+Xong+ "','" + createDate + "','" + modifyDate + "')";
                if (DBAccess.IsServerConnected())
                {

                    if (InsertItemQry.Length > 5)
                    {
                        bool isExisted = DBHelper.CheckItemExist("[Product]", "Barcode", barcode);

                        if (isExisted)
                        {
                                isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                        }
                        else
                        {
                            MessageBox.Show("Barcode chưa tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //(dgvOrderNhap.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Ký Hiệu] like '{0}%' OR [Nhà Cung Cấp] like '{0}%'", txtSearch.Text);
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            (dgvOrderXuat.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Ký Hiệu] like '{0}%' OR [Tên Khách Hàng] like '{0}%'", txtSearch2.Text);
        }

        private void cbPageSize1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize1.SelectedItem);
            currentPageNumber = 1;
            PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void dtpFilterNgayXong_ValueChanged(object sender, EventArgs e)
        {
            ngayXongFilterChanged = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string ngayNhap = ngayNhapFilterChanged ? string.Format("Data > '{0}' AND Data < '{1}'", dtpFilterNgayNhap.Value.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss"), dtpFilterNgayNhap.Value.AddDays(1).ToString("dd/MM/yyyy HH:mm:ss")):string.Empty;            
            //string ngayXong = ngayXongFilterChanged ? string.Format("Data > '{0}' AND Data < '{1}'", dtpFilterNgayXong.Value.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss"), dtpFilterNgayXong.Value.AddDays(1).ToString("dd/MM/yyyy HH:mm:ss")) : string.Empty;
            //ngayXong = string.IsNullOrEmpty(ngayNhap) ? (string.IsNullOrEmpty(ngayXong)? : " AND " + ngayXong;
            //string nhacc = string.IsNullOrEmpty(cbNhaccFilter.SelectedText) ? string.Empty : " AND [Nhà Cung Cấp] like '% " + cbNhaccFilter.SelectedText + "%'"; 
            //nhacc 
            //string kyhieu = string.IsNullOrEmpty(cbKyhieuFilter.SelectedText) ? string.Empty : " AND [Ký Hiệu] like '%" + cbSignChuaIn.Text + "%'";
            //string btpchuainFilter, btpdainFilter, tpFilter, sploiFilter;
            //btpchuainFilter = string.IsNullOrEmpty(txtChuaInFilter.Text) ? string.Empty : " AND [BTP Chưa In] " + cbSignChuaIn.Text + " " + txtChuaInFilter.Text;
            //btpdainFilter = string.IsNullOrEmpty(txtDaInFilter.Text) ? string.Empty : " AND [BTP Đã In] " + cbSignDaIn.Text + " " + txtDaInFilter.Text;
            //tpFilter = string.IsNullOrEmpty(txtTPFilter.Text) ? string.Empty : " AND [Thành Phẩm] " + cbSignTP.Text + " " + txtTPFilter.Text;
            //sploiFilter = string.IsNullOrEmpty(txtSPLoiFilter.Text) ? string.Empty : " AND[Sản Phẩm Lỗi] " + cbSignSPLoi.Text + " " + txtSPLoiFilter.Text;
            //string filterQuery = string.Format("[Ngày Nhập] like '%{0}%' AND [Ngày Xong] like '%{1}%' {2} {3} {4} {5} {6} {7}", "", "", nhacc, kyhieu, btpchuainFilter, btpdainFilter, tpFilter, sploiFilter);

            //(dgvOrderNhap.DataSource as DataTable).DefaultView.RowFilter = filterQuery;
        }

        private void dtpFilterNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            ngayNhapFilterChanged = true;
        }
    }
}
