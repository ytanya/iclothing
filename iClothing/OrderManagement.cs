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
        private bool ngayXuatFilterChanged = false;
        private bool ngayXongXuatFilterChanged = false;
        private bool ngayNhapXuatFilterChanged = false;
        System.Windows.Forms.CheckBox headerCheckBox = new System.Windows.Forms.CheckBox();

        private DataTable dtTemp = new DataTable();
        private DataTable dtManageOrderNew = new DataTable();
        private int currentPageNumber = 1;
        private int pageSize = 0;
        private int rowPerPage = 10;
        //private string currentOrderByItem = "Ngaytao";
        private Bitmap bmp;
        public static string currentpath = System.IO.Directory.GetCurrentDirectory();
        public static string conn = "Data Source=" + currentpath + ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
        public OrderManagement()
        {
            InitializeComponent();
            rbNhap.Checked = true;
            //pnXuat.Visible = false;
            //txtBTPChuaIn1.Enabled = false;
            //txtOrderID1.Enabled = false;
            //dtTemp.Columns.Add("Donhang", typeof(string));
            //dtTemp.Columns.Add("Xong", typeof(int));
            dtpNgaynhap.Format = DateTimePickerFormat.Custom;
            dtpNgaynhap.CustomFormat = "dd/MM/yyyy";
            //btnNewNhap.Enabled = false;
            //btnSaveNhap.Visible = true;
            pnNhap.Visible = true;
            pnXuat.Visible = false;
        }
        /******************************** Start Common******************************************/
        private void rbNhap_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    IsCompleted = "false";
                    pnNhap.Visible = true;
                    pnXuat.Visible = false;
                    //dgvOrderXuat.Visible = false;
                    dgvOrderNhap.Visible = true;
                    currentPageNumber = 1;
                    rowPerPage = 10;
                    GetAllDataOrderNhap();
                    dtCurrent = dtTab1Nhap;
                    PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                    cbPageSizeNhap.SelectedIndex = 0;
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
                    IsCompleted = "false";
                    pnXuat.Visible = true;
                    pnNhap.Visible = false;
                    currentPageNumber = 1;
                    rowPerPage = 10;

                    GetAllDataOrderXuat();
                    dtCurrent = dtTab1Xuat;
                    PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                    cbPagingSizeXuat.SelectedIndex = 0;
                }
            }
        }

        private void OrderManagement_Load(object sender, EventArgs e)
        {
            GetAllDataTab1();

        }
        private void GetAllDataTab1()
        {
            dtpNgayXuat.Format = DateTimePickerFormat.Custom;
            dtpNgayXuat.CustomFormat = "dd/MM/yyyy";
            rbNhap.Checked = true;
            GetAllDataOrderNhap();
            dtCurrent = dtTab1Nhap;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            cbPageSizeNhap.SelectedIndex = 0;
            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                cbKyHieuXuat.DataSource = dtProduct;
                cbKyHieuXuat.ValueMember = "Barcode";
                cbKyHieuXuat.DisplayMember = "Kyhieu";
                cbKyHieuXuat.SelectedIndex = 0;
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

            DataTable dtCustomer = DBHelper.GetAllCustomer();
            if (dtCustomer.Rows.Count > 0)
            {
                cbCustomer.DataSource = dtCustomer;
                cbCustomer.ValueMember = "KHID";
                cbCustomer.DisplayMember = "HoTen";
                cbCustomer.SelectedIndex = 0;
            }

        }
        private void PopulateDataOrder(int currentPageNumber, int rowPerPage, DataTable dt)
        {
            int skipRecord = (currentPageNumber - 1) * rowPerPage;

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

                    //dgvOrderNhap.Columns["Xong"].ReadOnly = true;
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
                    dgvOrderNhap.ClearSelection();
                    if (dgvOrderNhap.CurrentRow != null)
                        dgvOrderNhap.CurrentRow.Selected = true;

                    countPageSizeNhap(dt);

                }
                else
                {
                    currentPageNumber = 0;
                    //pbFirstNhap.Visible = false;
                    //pbPrevNhap.Visible = false;
                    //pbNextNhap.Visible = false;
                    //pbLastNhap.Visible = false;
                    //txtPagingNhap.Visible = false;
                    //cbPageSizeNhap.Visible = false;
                }
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    
                    dgvOrderXuat.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
                    dgvOrderXuat.Columns[0].Visible = false;
                    dgvOrderXuat.Columns[1].Visible = false;
                    //dgvOrderNhap.Columns[3].Width = 130;
                    //dgvOrderNhap.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    //dgvOrderNhap.Columns[4].Width = 130;
                    //dgvOrderNhap.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvOrderXuat.Columns["Xong"].Width = 50;
                    dgvOrderXuat.Columns["Tên Khách Hàng"].Width = 120;
                    dgvOrderXuat.Columns["Ký Hiệu"].Width = 60;
                    dgvOrderXuat.Columns["BTP Chưa in"].Width = 120;
                    this.dgvOrderXuat.Columns["BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderXuat.Columns["BTP Đã in"].Width = 120;
                    this.dgvOrderXuat.Columns["BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderXuat.Columns["Thành Phẩm"].Width = 120;
                    this.dgvOrderXuat.Columns["Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderXuat.Columns["Sản phẩm lỗi"].Width = 110;
                    this.dgvOrderXuat.Columns["Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderXuat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvOrderXuat.Sort(dgvOrderXuat.Columns["Ngày Xuất"], ListSortDirection.Descending);
                    dgvOrderXuat.ClearSelection();
                    if (dgvOrderXuat.CurrentRow != null)
                        dgvOrderXuat.CurrentRow.Selected = true;

                    countPageSizeXuat(dt);
                }
                else
                {
                    currentPageNumber = 0;
                    //pbFirstXuat.Visible = false;
                    //pbPrevXuat.Visible = false;
                    //pbNextXuat.Visible = false;
                    //pbLastXuat.Visible = false;
                    //txtPagingXuat.Visible = false;
                    //cbPagingSizeXuat.Visible = false;
                }
            }
        }
        //else
        //{
        //    dvgManageInOut.DataSource = dtManageOrderNew.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();


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
                InsertItemQry = "INSERT INTO [Transaction]([TransID],[Barcode],[LoaiID],[Mota],[Soluong],[Nhap],[Xong],[Ngaytao],[Ngaysua])VALUES('" + TransID + "','" + barcode + "','" + LoaiID + "','" + Mota + "','" + soluong + "','" + Nhap + "','" + Xong + "','" + createDate + "','" + modifyDate + "')";
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

        /******************************** Start Common******************************************/
        /******************************** Start Panel Nhap******************************************/
        private void txtChuaInFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDaInFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTPFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSPLoiFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbNhap.SelectedIndex == 1)
            {
                dtpFilterNgayNhap.Format = DateTimePickerFormat.Custom;
                dtpFilterNgayNhap.CustomFormat = "dd/MM/yyyy";
                dtpFilterNgayXong.Format = DateTimePickerFormat.Custom;
                dtpFilterNgayXong.CustomFormat = "dd/MM/yyyy";

                // Init Ki hieu combobox
                DataTable dtProduct = DBHelper.GetAllProduct();
                // generate the data you want to insert
                DataRow toInsert = dtProduct.NewRow();
                toInsert[0] = "";
                toInsert[1] = "";
                // insert in the desired place
                dtProduct.Rows.InsertAt(toInsert, 0);
                if (dtProduct.Rows.Count > 0)
                {
                    cbKyhieuFilter.DataSource = dtProduct;
                    cbKyhieuFilter.ValueMember = "Barcode";
                    cbKyhieuFilter.DisplayMember = "Kyhieu";
                    cbKyhieuFilter.SelectedIndex = 0;
                    
                }

                // Init Supplier combobox
                //DataTable dtSupplier = DBHelper.GetAllSupplier();
                //if (dtSupplier.Rows.Count > 0)
                //{
                //    cbNhaccFilter.DataSource = dtSupplier;
                //    cbNhaccFilter.ValueMember = "NhaccID";
                //    cbNhaccFilter.DisplayMember = "Ten";
                //    cbNhaccFilter.SelectedIndex = 0;
                //}
            }
        }
        private void GetAllDataOrderNhap()
        {
            string query = "Select New.DonhangID [Mã Đơn Hàng],Supplier.Ten [Nhà Cung Cấp],[Order].Xong,[Order].Ngaynhap [Ngày Nhập], [Order].Ngayxong [Ngày Xong], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi]  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID order by [Order].Ngaynhap";
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
            
        }

        private void btnNewNhap_Click(object sender, EventArgs e)
        {
            cbNhacc.SelectedIndex = 0;
            cbKihieuNhap.SelectedIndex = 0;
            txtBTPChuaInNhap.Text = "0";
            txtBTPDaInNhap.Text = "0";
            txtTPNhap.Text = "0";
            txtSPLoiNhap.Text = "0";
            dtpNgaynhap.Enabled = true;
            dtpNgaynhap.Value = DateTime.Today;
            IsCompleted = "false";
        }

        private void btnSaveNhap_Click(object sender, EventArgs e)
        {
            try
            {                
                List<string> ItemQryList = new List<string>();

                bool isSuccess = false;
                string isNhap = "true";
                DataRow rd = dtTab1Nhap.NewRow();
                string ngayxong = string.Empty;
                string Ngay, DonhangID, barcode, NhaccID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL;
                Ngay = DonhangID = barcode = NhaccID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = string.Empty;
                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaInNhap.Text)) txtBTPChuaInNhap.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaInNhap.Text)) txtBTPDaInNhap.Text = "0";
                if (string.IsNullOrEmpty(txtTPNhap.Text)) txtTPNhap.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoiNhap.Text)) txtSPLoiNhap.Text = "0";


                if (string.IsNullOrEmpty(txtOrderIDNhap.Text))
                {
                    // DonhangID
                    DonhangID = CommonHelper.RandomString(8);
                    rd[0] = DonhangID;
                    // NhaccID
                    NhaccID = cbNhacc.SelectedValue.ToString();
                    rd[1] = DBHelper.Lookup("Supplier", "Ten", "NhaccID", NhaccID);
                    // Xong
                    rd[2] = "false";
                    // Ngay nhap
                    Ngay = dtpNgaynhap.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                    rd[3] = Ngay;
                    // Barcode
                    barcode = cbKihieuNhap.SelectedValue.ToString();
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
                    
                    ItemQryList = AddNewOrderNhap(Ngay, DonhangID, NhaccID, barcode, IsCompleted, createDate, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL,TPSL, SPLoiSL);
                }
                else
                {
                    DonhangID = txtOrderIDNhap.Text;
                    DataRow row = dtTab1Nhap.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();

                    
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
                    barcode = cbKihieuNhap.SelectedValue.ToString();
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
                            SaveOrderToTransactionDB(barcode, BTPChuaInID, "", BTPChuaInSL, isNhap, IsCompleted);
                            SaveOrderToTransactionDB(barcode, BTPDaInID, "", BTPDaInSL, isNhap, IsCompleted);
                            SaveOrderToTransactionDB(barcode, TPID, "", TPSL, isNhap, IsCompleted);
                            SaveOrderToTransactionDB(barcode, SPLoiID, "", SPLoiSL, isNhap, IsCompleted);
                            
                            if (IsCompleted.ToLower() == "true")
                            {
                                AddIntoStock(barcode, ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);
                            }
                            if (string.IsNullOrEmpty(txtOrderIDNhap.Text))
                            {
                                dtTab1Nhap.Rows.InsertAt(rd, 0);
                                cbNhacc.SelectedIndex = 0;
                                currentPageNumber = 1;
                                countPageSizeNhap(dtTab1Nhap);
                                ClearTextNhap();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Nhap);
                            }
                            else
                            {
                                cbNhacc.SelectedIndex = 0;
                                currentPageNumber = 1;
                                //countPageSizeNhap(dtTab1Nhap);
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

        private void AddIntoStock(string barcode, string createDate, string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
            string TPSL, string SPLoiSL)
        {
            List<string> InsertItemQryList = new List<string>();
            string InsertItemQry = "";
            bool isSuccess = false;
            string TonkhoID1 = CommonHelper.RandomString(7) + 1;
            string TonkhoID2 = CommonHelper.RandomString(7) + 2;
            string TonkhoID3 = CommonHelper.RandomString(7) + 3;
            string TonkhoID4 = CommonHelper.RandomString(7) + 4;

            InsertItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID1 + "','" + barcode + "','" + BTPChuaInID + "','" + BTPChuaInSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID2 + "','" + barcode + "','" + BTPDaInID + "','" + BTPDaInSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID3 + "','" + barcode + "','" + TPID + "','" + TPSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID4 + "','" + barcode + "','" + SPLoiID + "','" + SPLoiSL + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);

            if (DBAccess.IsServerConnected())
            {

                if (InsertItemQry.Length > 5)
                {
                    bool isExisted = DBHelper.CheckItemExist("[Product]", "Barcode", barcode);

                    if (isExisted)
                    {
                        foreach (var item in InsertItemQryList)
                        {
                            isSuccess = DBAccess.ExecuteQuery(item);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Barcode chưa tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private List<string> AddNewOrderNhap(string Ngaynhap, string DonhangID, string NhaccID, string barcode, string IsCompleted, string createDate,
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
            InsertItemQry = "INSERT INTO [Order] ([DonhangID],[NhaccID],[Xong],[Ngaytao],[Ngaysua],[Ngaynhap])VALUES('" + DonhangID + "','" + NhaccID + "','" + IsCompleted + "','" + createDate + "','" + createDate + "','" + Ngaynhap + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID1 + "','" + DonhangID + "','" + barcode + "','" + BTPChuaInID + "','" + BTPChuaInSL + "','" + createDate + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID2 + "','" + DonhangID + "','" + barcode + "','" + BTPDaInID + "','" + BTPDaInSL + "','" + createDate + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID3 + "','" + DonhangID + "','" + barcode + "','" + TPID + "','" + TPSL + "','" + createDate + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID4 + "','" + DonhangID + "','" + barcode + "','" + SPLoiID + "','" + SPLoiSL + "','" + createDate + "','" + createDate + "')";
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

        private void countPageSizeNhap(DataTable dt)
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
            txtOrderIDNhap.Text = string.Empty;
            cbNhacc.Enabled = true;
            cbNhacc.SelectedIndex = 0;
            cbKihieuNhap.SelectedIndex = 0;
            txtBTPChuaInNhap.Text = string.Empty;
            txtBTPDaInNhap.Text = string.Empty;
            txtTPNhap.Text = string.Empty;
            txtSPLoiNhap.Text = string.Empty;
            dtpNgaynhap.Enabled = true;
            IsCompleted = "false";
        }
        private void btnDeleteNhap_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrderNhap.SelectedRows)
            {               
                if (Convert.ToBoolean(row.Cells[2].Value.ToString()) == false)
                {
                    string orderID = row.Cells[0].Value.ToString();
                    string query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                    bool isSuccess = DBAccess.ExecuteQuery(query);
                    if (!isSuccess) return;
                    query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                    isSuccess = DBAccess.ExecuteQuery(query);
                    if (!isSuccess) return;
                    dgvOrderNhap.Rows.Remove(row);
                    int rowCount = dgvOrderNhap.Rows.Count;
                    pageSize = rowCount / rowPerPage;
                    // if any row left after calculated pages, add one more page 
                    if (rowCount % rowPerPage > 0)
                        pageSize += 1;
                    txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPageNhap.Text = "Tổng số:" + dgvOrderNhap.Rows.Count.ToString();
                }
            }
        }

        private void dgvOrderNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && Convert.ToBoolean(dgvOrderNhap.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == false)
            {
                DataGridViewRow dgvRow = dgvOrderNhap.Rows[e.RowIndex];
                txtOrderIDNhap.Text = dgvRow.Cells[0].Value.ToString();
                cbNhacc.SelectedValue = DBHelper.Lookup("Supplier", "NhaccID", "Ten", dgvRow.Cells[1].Value.ToString());
                cbNhacc.Text = dgvRow.Cells[1].Value.ToString();
                if (Convert.ToBoolean(dgvOrderNhap.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true)
                {
                    IsCompleted = "true";
                    
                }
                else IsCompleted = "false";
                dtpNgaynhap.Value = DateTime.Parse(dgvRow.Cells[3].Value.ToString());
                cbKihieuNhap.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[5].Value.ToString());
                cbKihieuNhap.Text = dgvRow.Cells[5].Value.ToString();
                txtBTPChuaInNhap.Text = dgvRow.Cells[6].Value.ToString();
                txtBTPDaInNhap.Text = dgvRow.Cells[7].Value.ToString();
                txtTPNhap.Text = dgvRow.Cells[8].Value.ToString();
                txtSPLoiNhap.Text = dgvRow.Cells[9].Value.ToString();
                dtpNgaynhap.Enabled = false;
                
            }
        }

        private void dgvOrderNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!bool.Parse(IsCompleted))
            {
                if (e.ColumnIndex == dgvOrderNhap.Columns["Xong"].Index)
                    if (Convert.ToBoolean(dgvOrderNhap.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true) IsCompleted = "true"; else IsCompleted = "false";
            }
            
        }

        private void dgvOrderNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (Convert.ToBoolean(dgvOrderNhap.Rows[e.RowIndex].Cells[2].EditedFormattedValue))
            {
                e.Cancel = true;
            }
        }
        private void dtpFilterNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            ngayNhapFilterChanged = true;
        }

        private void pbFirstNhap_Click(object sender, EventArgs e)
        {           
            if (currentPageNumber > 1)
            {
                currentPageNumber = 1;
                dtCurrent = dtTab1Nhap;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                //txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbPrevNhap_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Nhap;
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            }
            //txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNextNhap_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Nhap;
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                //txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLastNhap_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Nhap;
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                //txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void cbPageSizeNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rowPerPage != Convert.ToInt32(cbPageSizeNhap.SelectedItem))
            {
                rowPerPage = Convert.ToInt32(cbPageSizeNhap.SelectedItem);
                currentPageNumber = 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                //txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
            
        }

        private void dtpFilterNgayXong_ValueChanged(object sender, EventArgs e)
        {
            ngayXongFilterChanged = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch = string.Empty;
            string ngayNhap = ngayNhapFilterChanged ? string.Format("[Ngày Nhập] > '{0}' AND [Ngày Nhập] < '{1}'", dtpFilterNgayNhap.Value.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss"), dtpFilterNgayNhap.Value.AddDays(1).ToString("dd/MM/yyyy HH:mm:ss")) : string.Empty;
            strSearch = ngayNhap;
            string ngayXong = ngayXongFilterChanged ? string.Format("[Ngày Xong] >= '{0}' AND [Ngày Xong] < '{1}'", dtpFilterNgayXong.Value.AddDays(-1), dtpFilterNgayXong.Value.AddDays(1)) : string.Empty;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(ngayXong) ?"" : ngayXong): (string.IsNullOrEmpty(ngayXong) ? strSearch : strSearch + " AND " + ngayXong);
            
            //string nhaccValue = DBHelper.Lookup("Supplier", "Ten", "NhaccID", cbNhaccFilter.SelectedValue.ToString());
            //string nhacc = string.IsNullOrEmpty(nhaccValue) ? string.Empty : " [Nhà Cung Cấp] like '% " + nhaccValue + "%'";
            //strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(nhacc) ? "" : nhacc) : (string.IsNullOrEmpty(nhacc) ? strSearch : strSearch + " AND " + nhacc);
            
            string kihieuValue= DBHelper.Lookup("Product", "Kyhieu", "Barcode", cbKyhieuFilter.SelectedValue.ToString());
            string kyhieu = string.IsNullOrEmpty(kihieuValue) ? string.Empty : " [Ký Hiệu] like '" + kihieuValue + "'";
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(kyhieu) ? "" : kyhieu) : (string.IsNullOrEmpty(kyhieu) ? strSearch : strSearch + " AND " + kyhieu);

            string btpchuainFilter, btpdainFilter, tpFilter, sploiFilter;
            btpchuainFilter = string.IsNullOrEmpty(txtChuaInFilter.Text) ? string.Empty : " [BTP Chưa In] " + cbSignChuaIn.Text + " " + txtChuaInFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(btpchuainFilter) ? "" : btpchuainFilter) : (string.IsNullOrEmpty(btpchuainFilter) ? strSearch : strSearch + " AND " + btpchuainFilter);

            btpdainFilter = string.IsNullOrEmpty(txtDaInFilter.Text) ? string.Empty : " [BTP Đã In] " + cbSignDaIn.Text + " " + txtDaInFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(btpdainFilter) ? "" : btpdainFilter) : (string.IsNullOrEmpty(btpdainFilter) ? strSearch : strSearch + " AND " + btpdainFilter);

            tpFilter = string.IsNullOrEmpty(txtTPFilter.Text) ? string.Empty : " [Thành Phẩm] " + cbSignTP.Text + " " + txtTPFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(tpFilter) ? "" : tpFilter) : (string.IsNullOrEmpty(tpFilter) ? strSearch : strSearch + " AND " + tpFilter);

            sploiFilter = string.IsNullOrEmpty(txtSPLoiFilter.Text) ? string.Empty : " [Sản Phẩm Lỗi] " + cbSignSPLoi.Text + " " + txtSPLoiFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(sploiFilter) ? "" : sploiFilter) : (string.IsNullOrEmpty(sploiFilter) ? strSearch : strSearch + " AND " + sploiFilter);
            //string filterQuery = string.Format("[Ngày Nhập] like '%{0}%' AND [Ngày Xong] like '%{1}%' {2} {3} {4} {5} {6} {7}", "", "", nhacc, kyhieu, btpchuainFilter, btpdainFilter, tpFilter, sploiFilter);

            (dgvOrderNhap.DataSource as DataTable).DefaultView.RowFilter = strSearch;

        }
        private void txtBTPChuaInNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBTPDaInNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTPNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSPLoiNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnResetNhap_Click(object sender, EventArgs e)
        {
            dtpFilterNgayNhap.Value = DateTime.Today;
            ngayNhapFilterChanged = false;
            dtpFilterNgayXong.Value = DateTime.Today;
            ngayXongFilterChanged = false;
            cbKyhieuFilter.SelectedIndex = 0;
            txtChuaInFilter.Text = string.Empty;
            txtDaInFilter.Text = string.Empty;
            txtTPFilter.Text = string.Empty;
            txtSPLoiFilter.Text = string.Empty;
            cbSignChuaIn.SelectedIndex = -1;
            cbSignDaIn.SelectedIndex = -1;
            cbSignTP.SelectedIndex = -1;
            cbSignSPLoi.SelectedIndex = -1;
            if (dgvOrderNhap.DataSource != null)
            {
                (dgvOrderNhap.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }
        /******************************** End Panel Nhap******************************************/
        /******************************** Start Panel Xuat******************************************/
        private void btnResetXuat_Click(object sender, EventArgs e)
        {
            dtpNgayXuatFilter.Value = DateTime.Today;
            dtpNgayXongFilterXuat.Value = DateTime.Today;
            cbKyHieuFilterXuat.SelectedIndex = 0;
            txtBTPChuaInFilterXuat.Text = string.Empty;
            txtDaInXuatFilter.Text = string.Empty;
            txtTPFilterXuat.Text = string.Empty;
            txtSPLoiFilterXuat.Text = string.Empty;
            cbChuaInSignXuat.SelectedIndex = -1;
            cbSignDaInFilterXuat.SelectedIndex = -1;
            cbSignTPXuat.SelectedIndex = -1;
            cbSignSPLoiXuat.SelectedIndex = -1;
            if (dgvOrderXuat.DataSource != null)
            {
                (dgvOrderXuat.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }

        }
        private List<string> AddNewOrderXuat(string Ngaynhap, string DonhangID, string KHID, string barcode, string IsCompleted, string createDate,
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
            InsertItemQry = "INSERT INTO [Order] ([DonhangID],[KHID],[Xong],[Ngaytao],[Ngaysua],[Ngaynhap])VALUES('" + DonhangID + "','" + KHID + "','" + IsCompleted + "','" + createDate + "','" + createDate + "','" + Ngaynhap + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID1 + "','" + DonhangID + "','" + barcode + "','" + BTPChuaInID + "','" + BTPChuaInSL + "','" + createDate + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID2 + "','" + DonhangID + "','" + barcode + "','" + BTPDaInID + "','" + BTPDaInSL + "','" + createDate + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID3 + "','" + DonhangID + "','" + barcode + "','" + TPID + "','" + TPSL + "','" + createDate + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaytao],[Ngaysua])VALUES('" + orderDetailID4 + "','" + DonhangID + "','" + barcode + "','" + SPLoiID + "','" + SPLoiSL + "','" + createDate + "','" + createDate + "')";
            InsertItemQryList.Add(InsertItemQry);
            return InsertItemQryList;
        }

        private List<string> UpdateOrderXuat(string DonhangID, string barcode, string KHID, string ngayxong, string ngaysua, string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
            string TPSL, string SPLoiSL, string xong)
        {
            List<string> UpdateItemQryList = new List<string>();
            string UpdateItemQry = "";

            if (!string.IsNullOrEmpty(ngayxong))
            {
                ngayxong = "',[Ngayxong]= '" + ngayxong;
            }
            // query update
            UpdateItemQry = "UPDATE [Order] SET[KHID] ='" + KHID + ngayxong + "',[Ngaysua]= '" + ngaysua + "',[Xong]= '" + xong + "' WHERE DonhangID ='" + DonhangID + "';";
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
        private void ClearTextXuat()
        {
            txtOrderXuat.Text = string.Empty;
            cbCustomer.Enabled = true;
            cbCustomer.SelectedIndex = 0;
            cbKyHieuXuat.SelectedIndex = 0;
            txtBTPChuaInXuat.Text = string.Empty;
            txtBTPDaInXuat.Text = string.Empty;
            txtTPXuat.Text = string.Empty;
            txtSPLoiXuat.Text = string.Empty;
            dtpNgayXuat.Enabled = true;
            IsCompleted = "false";
        }
        private void countPageSizeXuat(DataTable dt)
        {
            int rowCount = dt.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPagingXuat.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            lblTotalPageXuat.Text = "Tổng số:" + dt.Rows.Count.ToString();
        }
        private void GetAllDataOrderXuat()
        {
            string query = "Select New.DonhangID [Mã Đơn Hàng], Customer.HoTen [Tên Khách Hàng],[Order].Xong,[Order].Ngaynhap [Ngày Xuất], [Order].Ngayxong [Ngày Xong], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi]  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Customer on[Order].KHID = Customer.KHID order by [Order].Ngaynhap";
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
        }

        private void btnSearchXuat_Click(object sender, EventArgs e)
        {
            string strSearch = string.Empty;
            string ngayXuat = ngayXuatFilterChanged ? string.Format("[Ngày Xuất] > '{0}' AND [Ngày Xuất] < '{1}'", dtpNgayXuatFilter.Value.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss"), dtpNgayXuatFilter.Value.AddDays(1).ToString("dd/MM/yyyy HH:mm:ss")) : string.Empty;
            strSearch = ngayXuat;
            string ngayXong = ngayXongXuatFilterChanged ? string.Format("[Ngày Xong] >= '{0}' AND [Ngày Xong] < '{1}'", dtpNgayXongFilterXuat.Value.AddDays(-1), dtpNgayXongFilterXuat.Value.AddDays(1)) : string.Empty;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(ngayXong) ? "" : ngayXong) : (string.IsNullOrEmpty(ngayXong) ? strSearch : strSearch + " AND " + ngayXong);

            //string nhaccValue = DBHelper.Lookup("Supplier", "Ten", "NhaccID", cbNhaccFilter.SelectedValue.ToString());
            //string nhacc = string.IsNullOrEmpty(nhaccValue) ? string.Empty : " [Nhà Cung Cấp] like '% " + nhaccValue + "%'";
            //strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(nhacc) ? "" : nhacc) : (string.IsNullOrEmpty(nhacc) ? strSearch : strSearch + " AND " + nhacc);

            string kihieuValue = DBHelper.Lookup("Product", "Kyhieu", "Barcode", cbKyHieuFilterXuat.SelectedValue.ToString());
            string kyhieu = string.IsNullOrEmpty(kihieuValue) ? string.Empty : " [Ký Hiệu] like '" + kihieuValue + "'";
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(kyhieu) ? "" : kyhieu) : (string.IsNullOrEmpty(kyhieu) ? strSearch : strSearch + " AND " + kyhieu);

            string btpchuainFilter, btpdainFilter, tpFilter, sploiFilter;
            btpchuainFilter = string.IsNullOrEmpty(txtBTPChuaInFilterXuat.Text) ? string.Empty : " [BTP Chưa In] " + cbChuaInSignXuat.Text + " " + txtBTPChuaInFilterXuat.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(btpchuainFilter) ? "" : btpchuainFilter) : (string.IsNullOrEmpty(btpchuainFilter) ? strSearch : strSearch + " AND " + btpchuainFilter);

            btpdainFilter = string.IsNullOrEmpty(txtDaInXuatFilter.Text) ? string.Empty : " [BTP Đã In] " + cbSignDaInFilterXuat.Text + " " + txtDaInXuatFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(btpdainFilter) ? "" : btpdainFilter) : (string.IsNullOrEmpty(btpdainFilter) ? strSearch : strSearch + " AND " + btpdainFilter);

            tpFilter = string.IsNullOrEmpty(txtTPFilterXuat.Text) ? string.Empty : " [Thành Phẩm] " + cbSignTPXuat.Text + " " + txtTPFilterXuat.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(tpFilter) ? "" : tpFilter) : (string.IsNullOrEmpty(tpFilter) ? strSearch : strSearch + " AND " + tpFilter);

            sploiFilter = string.IsNullOrEmpty(txtSPLoiXuat.Text) ? string.Empty : " [Sản Phẩm Lỗi] " + cbSignSPLoiXuat.Text + " " + txtSPLoiXuat.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(sploiFilter) ? "" : sploiFilter) : (string.IsNullOrEmpty(sploiFilter) ? strSearch : strSearch + " AND " + sploiFilter);
            //string filterQuery = string.Format("[Ngày Nhập] like '%{0}%' AND [Ngày Xong] like '%{1}%' {2} {3} {4} {5} {6} {7}", "", "", nhacc, kyhieu, btpchuainFilter, btpdainFilter, tpFilter, sploiFilter);

            (dgvOrderXuat.DataSource as DataTable).DefaultView.RowFilter = strSearch;
        }

        private void btnNewXuat_Click(object sender, EventArgs e)
        {
            cbCustomer.SelectedIndex = 0;
            cbKyHieuXuat.SelectedIndex = 0;
            txtBTPChuaInXuat.Text = "0";
            txtBTPDaInXuat.Text = "0";
            txtTPXuat.Text = "0";
            txtSPLoiXuat.Text = "0";
            dtpNgayXuat.Enabled = true;
            dtpNgayXuat.Value = DateTime.Today;
            IsCompleted = "false";
        }

        private void btnSaveXuat_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ItemQryList = new List<string>();
                string ngayxong = string.Empty;
                bool isSuccess = false;
                string isNhap = "false";
                DataRow rd = dtTab1Xuat.NewRow();

                string Ngay, DonhangID, barcode, KHID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL;
                Ngay = DonhangID = barcode = KHID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = string.Empty;
                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaInXuat.Text)) txtBTPChuaInXuat.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaInXuat.Text)) txtBTPDaInXuat.Text = "0";
                if (string.IsNullOrEmpty(txtTPXuat.Text)) txtTPXuat.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoiXuat.Text)) txtSPLoiXuat.Text = "0";


                if (string.IsNullOrEmpty(txtOrderXuat.Text))
                {
                    // DonhangID
                    DonhangID = CommonHelper.RandomString(8);
                    rd[0] = DonhangID;
                    // Customer
                    KHID = cbCustomer.SelectedValue.ToString();
                    rd[1] = DBHelper.Lookup("Customer", "HoTen", "KHID", KHID);
                    // Xong
                    rd[2] = IsCompleted;
                    // Ngay nhap
                    Ngay = dtpNgaynhap.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                    rd[3] = Ngay;
                    // Barcode
                    barcode = cbKyHieuXuat.SelectedValue.ToString();
                    rd[5] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                    // BTPChuaIn
                    BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                    BTPChuaInSL = txtBTPChuaInXuat.Text;
                    rd[6] = BTPChuaInSL;
                    // BTPDaIn
                    BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                    BTPDaInSL = txtBTPDaInXuat.Text;
                    rd[7] = BTPDaInSL;
                    // TP
                    TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                    TPSL = txtTPXuat.Text;
                    rd[8] = TPSL;
                    // SPLoi
                    SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                    SPLoiSL = txtSPLoiXuat.Text;
                    rd[9] = SPLoiSL;

                    // Created Date
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    ItemQryList = AddNewOrderXuat(Ngay, DonhangID, KHID, barcode, IsCompleted, createDate, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);
                }
                else
                {
                    DonhangID = txtOrderXuat.Text;
                    DataRow row = dtTab1Xuat.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();

                    
                    string ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    // NhaccID
                    KHID = cbCustomer.SelectedValue.ToString();
                    row[1] = DBHelper.Lookup("Customer", "HoTen", "KHID", KHID);
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
                    barcode = cbKyHieuXuat.SelectedValue.ToString();
                    row[5] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                    // BTPChuaIn
                    BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                    BTPChuaInSL = txtBTPChuaInXuat.Text;
                    row[6] = BTPChuaInSL;
                    // BTPDaIn
                    BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                    BTPDaInSL = txtBTPDaInXuat.Text;
                    row[7] = BTPDaInSL;
                    // TP
                    TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                    TPSL = txtTPXuat.Text;
                    row[8] = TPSL;
                    // SPLoi
                    SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                    SPLoiSL = txtSPLoiXuat.Text;
                    row[9] = SPLoiSL;

                    ItemQryList = UpdateOrderXuat(DonhangID, barcode, KHID, ngayxong, ngaysua, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, IsCompleted);

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
                            SaveOrderToTransactionDB(barcode, BTPChuaInID, "", BTPChuaInSL, isNhap, IsCompleted);
                            SaveOrderToTransactionDB(barcode, BTPDaInID, "", BTPDaInSL, isNhap, IsCompleted);
                            SaveOrderToTransactionDB(barcode, TPID, "", TPSL, isNhap, IsCompleted);
                            SaveOrderToTransactionDB(barcode, SPLoiID, "", SPLoiSL, isNhap, IsCompleted);
                            if (IsCompleted.ToLower() == "true")
                            {
                                AddIntoStock(barcode, ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, "-" + BTPChuaInSL, "-" +BTPDaInSL, "-" + TPSL, "-" + SPLoiSL);
                            }
                            if (string.IsNullOrEmpty(txtOrderXuat.Text))
                            {
                                dtTab1Xuat.Rows.InsertAt(rd, 0);
                                cbCustomer.SelectedIndex = 0;
                                currentPageNumber = 1;
                                countPageSizeXuat(dtTab1Xuat);
                                ClearTextXuat();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Xuat);
                            }
                            else
                            {
                                cbCustomer.SelectedIndex = 0;
                                currentPageNumber = 1;
                                //countPageSizeNhap(dtTab1Nhap);
                                ClearTextXuat();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Xuat);
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

        private void btnXoaXuat_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrderXuat.SelectedRows)
            {
                string orderID = row.Cells[0].Value.ToString();
                string query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                bool isSuccess = DBAccess.ExecuteQuery(query);
                if (!isSuccess) return;
                query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                isSuccess = DBAccess.ExecuteQuery(query);
                if (!isSuccess) return;
                dgvOrderXuat.Rows.Remove(row);
                int rowCount = dgvOrderXuat.Rows.Count;
                pageSize = rowCount / rowPerPage;
                // if any row left after calculated pages, add one more page 
                if (rowCount % rowPerPage > 0)
                    pageSize += 1;
                txtPagingXuat.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                lblTotalPageXuat.Text = "Tổng số:" + dgvOrderXuat.Rows.Count.ToString();
            }
        }

        private void pbFirstXuat_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab1Xuat);
            txtPagingXuat.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrevXuat_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber -= 1;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab1Xuat);
            }
            txtPagingXuat.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNextXuat_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab1Xuat);
                txtPagingXuat.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLastXuat_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab1Xuat);
                txtPagingXuat.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void cbPagingSizeXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rowPerPage != Convert.ToInt32(cbPagingSizeXuat.SelectedItem))
            {
                rowPerPage = Convert.ToInt32(cbPagingSizeXuat.SelectedItem);
                currentPageNumber = 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                //txtPagingNhap.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void txtBTPChuaInXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBTPDaInXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTPXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSPLoiXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dgvOrderXuat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (Convert.ToBoolean(dgvOrderXuat.Rows[e.RowIndex].Cells[2].EditedFormattedValue))
            {
                e.Cancel = true;
            }
        }

        private void dgvOrderXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!bool.Parse(IsCompleted))
            {
                if (e.ColumnIndex == dgvOrderXuat.Columns["Xong"].Index)
                    if (Convert.ToBoolean(dgvOrderXuat.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true) IsCompleted = "true"; else IsCompleted = "false";
            }
        }

        private void dgvOrderXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && Convert.ToBoolean(dgvOrderXuat.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == false)
            {
                DataGridViewRow dgvRow = dgvOrderXuat.Rows[e.RowIndex];
                txtOrderXuat.Text = dgvRow.Cells[0].Value.ToString();
                cbCustomer.SelectedValue = DBHelper.Lookup("Customer", "KHID", "HoTen", dgvRow.Cells[1].Value.ToString());
                cbCustomer.Text = dgvRow.Cells[1].Value.ToString();
                if (Convert.ToBoolean(dgvOrderXuat.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true)
                {
                    IsCompleted = "true";

                }
                dtpNgayXuat.Value = DateTime.Parse(dgvRow.Cells[3].Value.ToString());
                cbKyHieuXuat.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[5].Value.ToString());
                cbKyHieuXuat.Text = dgvRow.Cells[5].Value.ToString();
                txtBTPChuaInXuat.Text = dgvRow.Cells[6].Value.ToString();
                txtBTPDaInXuat.Text = dgvRow.Cells[7].Value.ToString();
                txtTPXuat.Text = dgvRow.Cells[8].Value.ToString();
                txtSPLoiXuat.Text = dgvRow.Cells[9].Value.ToString();

                dtpNgayXuat.Enabled = false;

            }
        }
        private void tbXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbXuat.SelectedIndex == 1)
            {
                dtpNgayXuatFilter.Format = DateTimePickerFormat.Custom;
                dtpNgayXuatFilter.CustomFormat = "dd/MM/yyyy";
                dtpNgayXongFilterXuat.Format = DateTimePickerFormat.Custom;
                dtpNgayXongFilterXuat.CustomFormat = "dd/MM/yyyy";

                // Init Ki hieu combobox
                DataTable dtProduct = DBHelper.GetAllProduct();
                // generate the data you want to insert
                DataRow toInsert = dtProduct.NewRow();
                toInsert[0] = "";
                toInsert[1] = "";
                // insert in the desired place
                dtProduct.Rows.InsertAt(toInsert, 0);
                if (dtProduct.Rows.Count > 0)
                {
                    cbKyHieuFilterXuat.DataSource = dtProduct;
                    cbKyHieuFilterXuat.ValueMember = "Barcode";
                    cbKyHieuFilterXuat.DisplayMember = "Kyhieu";
                    cbKyHieuFilterXuat.SelectedIndex = 0;

                }

                // Init Supplier combobox
                //DataTable dtSupplier = DBHelper.GetAllSupplier();
                //if (dtSupplier.Rows.Count > 0)
                //{
                //    cbNhaccFilter.DataSource = dtSupplier;
                //    cbNhaccFilter.ValueMember = "NhaccID";
                //    cbNhaccFilter.DisplayMember = "Ten";
                //    cbNhaccFilter.SelectedIndex = 0;
                //}
            }
        }

        private void dtpNgayXuatFilter_ValueChanged(object sender, EventArgs e)
        {
            ngayXuatFilterChanged = true;
        }

        private void dtpNgayXongFilterXuat_ValueChanged(object sender, EventArgs e)
        {
            ngayXongXuatFilterChanged = true;
        }
        private void txtBTPChuaInFilterXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDaInXuatFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTPFilterXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSPLoiFilterXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /********************************End Panel 2******************************************/

        private void GetAllOrder()
        {
            string query = "select * from (select [order].ngayxong [Ngày Nhập/ Xuất], product.kyhieu [Ký Hiệu], product.masp [Mã Sản Phẩm],"
+ "SUM(CASE WHEN LoaiID = 0000001 AND[order].NhacciD is not null Then Soluong else 0 end)[Nhập BTP Chưa in], "
+ "SUM(CASE WHEN LoaiID = 0000002 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập BTP Đã in], "
+ "SUM(CASE WHEN LoaiID = 0000003 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Thành Phẩm],"
+ "SUM(CASE WHEN LoaiID = 000004 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Sản phẩm lỗi],"
+ "SUM(CASE WHEN LoaiID = 0000001 AND[order].KHID is not null Then Soluong else 0 end)[Xuất BTP Chưa in],"
+ "SUM(CASE WHEN LoaiID = 0000002 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất BTP Đã in], "
+ "SUM(CASE WHEN LoaiID = 0000003 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Thành Phẩm], "
+ "SUM(CASE WHEN LoaiID = 000004 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Sản phẩm lỗi] "
+ "from orderdetail "
+ "join [order] on orderdetail.donhangid = [order].donhangid "
+ "join product on orderdetail.barcode = product.barcode "
+ "where [order].xong = 1 "
+ "GROUP BY[order].donhangid, product.kyhieu,product.masp, [order].ngayxong) New order by New.[Ngày Nhập/ Xuất]; "; 
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
                dvgManageInOut.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dvgManageInOut.Columns[1].Width = 130;
                //dgvOrderNhap.Columns["Xong"].ReadOnly = true;
                dvgManageInOut.Columns["Ký Hiệu"].Width = 60;
                dvgManageInOut.Columns["Nhập BTP Chưa in"].Width = 120;
                this.dvgManageInOut.Columns["Nhập BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.Columns["Nhập BTP Đã in"].Width = 100;
                this.dvgManageInOut.Columns["Nhập BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.Columns["Nhập Thành Phẩm"].Width = 120;
                this.dvgManageInOut.Columns["Nhập Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.Columns["Nhập Sản phẩm lỗi"].Width = 110;
                this.dvgManageInOut.Columns["Nhập Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.Columns["Xuất BTP Chưa in"].Width = 120;
                this.dvgManageInOut.Columns["Xuất BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.Columns["Xuất BTP Đã in"].Width = 100;
                this.dvgManageInOut.Columns["Xuất BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.Columns["Xuất Thành Phẩm"].Width = 120;
                this.dvgManageInOut.Columns["Xuất Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.Columns["Xuất Sản phẩm lỗi"].Width = 110;
                this.dvgManageInOut.Columns["Xuất Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dvgManageInOut.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dvgManageInOut.Sort(dvgManageInOut.Columns["Ngày Nhập/ Xuất"], ListSortDirection.Descending);
            }
            else
            {
                dvgManageInOut.DataSource = dt;
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
                        dtpNhapXuatFilter.Format = DateTimePickerFormat.Custom;
                        dtpNhapXuatFilter.CustomFormat = "dd/MM/yyyy";

                        DataTable dtProduct = DBHelper.GetAllProduct();
                        if (dtProduct.Rows.Count > 0)
                        {
                            cbKyHieuNhapXuatFilter.DataSource = dtProduct;
                            cbKyHieuNhapXuatFilter.ValueMember = "Barcode";
                            cbKyHieuNhapXuatFilter.DisplayMember = "Kyhieu";
                            cbKyHieuNhapXuatFilter.SelectedIndex = 0;

                        }
                        currentPageNumber = 1;
                        rowPerPage = 10;
                        GetAllOrder();
                        PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
                        cbPageSize1.SelectedIndex = 0;


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

                MessageBox.Show("Microsoft Office Excel bị lỗi!");
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
            string ngay, kyhieu, masp, nhapbtpchuain, nhapbtpdain, nhaptp, nhapsploi, xuatbtpchuain, xuatbtpdain, xuattp, xuatsploi, ghichu;
            for (int i = 0; i < dtTab2NhapXuat.Rows.Count; i++)
            {
                ngay = DateTime.Parse(dtTab2NhapXuat.Rows[i][0].ToString()).ToString("dd/MM/yyy");
                kyhieu = dtTab2NhapXuat.Rows[i][1].ToString();
                masp = dtTab2NhapXuat.Rows[i][2].ToString();
                nhapbtpchuain = dtTab2NhapXuat.Rows[i][3].ToString();
                nhapbtpdain = dtTab2NhapXuat.Rows[i][4].ToString();
                nhaptp = dtTab2NhapXuat.Rows[i][5].ToString();
                nhapsploi = dtTab2NhapXuat.Rows[i][6].ToString();
                xuatbtpchuain = dtTab2NhapXuat.Rows[i][7].ToString();
                xuatbtpdain = dtTab2NhapXuat.Rows[i][8].ToString();
                xuattp = dtTab2NhapXuat.Rows[i][9].ToString();
                xuatsploi = dtTab2NhapXuat.Rows[i][10].ToString();
                ghichu = "";
                dtManageOrderNew.Rows.Add(i + 1, ngay, kyhieu, masp, nhapbtpchuain, nhapbtpdain, nhaptp, nhapsploi, xuatbtpchuain, xuatbtpdain, xuattp, xuatsploi, ghichu);
            }
            return dtManageOrderNew;
        }
        

        private void cbPageSize1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize1.SelectedItem);
            currentPageNumber = 1;
            PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtTab2NhapXuat);
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void btnNhapXuatReset_Click(object sender, EventArgs e)
        {
            dtpNhapXuatFilter.Value = DateTime.Today;

            cbKyHieuNhapXuatFilter.SelectedIndex = 0;
            if (dvgManageInOut.DataSource != null)
            {
                (dvgManageInOut.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void btnNhapXuatSearch_Click(object sender, EventArgs e)
        {
            string strSearch = string.Empty;
            string ngayNhapXuat = ngayNhapXuatFilterChanged ? string.Format("[Ngày Nhập] > '{0}' AND [Ngày Nhập] < '{1}'", dtpNhapXuatFilter.Value.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss"), dtpNhapXuatFilter.Value.AddDays(1).ToString("dd/MM/yyyy HH:mm:ss")) : string.Empty;
            strSearch = ngayNhapXuat;
            
            string kihieuValue = DBHelper.Lookup("Product", "Kyhieu", "Barcode", cbKyHieuNhapXuatFilter.SelectedValue.ToString());
            string kyhieu = string.IsNullOrEmpty(kihieuValue) ? string.Empty : " [Ký Hiệu] like '" + kihieuValue + "'";
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(kyhieu) ? "" : kyhieu) : (string.IsNullOrEmpty(kyhieu) ? strSearch : strSearch + " AND " + kyhieu);            

            (dvgManageInOut.DataSource as DataTable).DefaultView.RowFilter = strSearch;
        }

        private void dtpNhapXuatFilter_ValueChanged(object sender, EventArgs e)
        {
            ngayNhapXuatFilterChanged = true;
        }

        
    }
}
