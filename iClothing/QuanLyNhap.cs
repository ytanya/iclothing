﻿using System;
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

namespace iClothing
{
    public partial class QuanLyNhap : UserControl
    {
        //public static string currentpath = ConfigurationManager.AppSettings["datapath"];
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        private int currentPageNumberFilter, rowPerPageFilter, pageSizeFilter, rowCountFilter;
        private bool ngayNhapFilterChanged = false, ngayXongFilterChanged = false;
        string strSearch = string.Empty;
        private bool isEdit = true;
        public QuanLyNhap()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderIDNhap.Text))
            {
                if (MessageBox.Show("Bạn có muốn tạo mới không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CreateNew();
                }
                else
                {
                    txtOrderIDNhap.Text = string.Empty;
                    cbNhacc.SelectedIndex = 0;
                    cbKihieu.SelectedIndex = 0;
                    txtBTPChuaIn.Text = "0";
                    txtBTPDaIn.Text = "0";
                    txtTP.Text = "0";
                    txtSPLoi.Text = "0";
                }
            }
            else
            {
                CreateNew();
            }
        }

        private void CreateNew()
        {
            List<string> ItemQryList = new List<string>();
            string isNhap = "true";
            bool isSuccess = false;
            string Ngay, Ngayxong, DonhangID, barcode, NhaccID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, GhiChu;
            Ngay = Ngayxong = DonhangID = barcode = NhaccID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = GhiChu = string.Empty;
            //IsCompleted = "false";
            // Set value for number field
            if (string.IsNullOrEmpty(txtBTPChuaIn.Text)) txtBTPChuaIn.Text = "0";
            if (string.IsNullOrEmpty(txtBTPDaIn.Text)) txtBTPDaIn.Text = "0";
            if (string.IsNullOrEmpty(txtTP.Text)) txtTP.Text = "0";
            if (string.IsNullOrEmpty(txtSPLoi.Text)) txtSPLoi.Text = "0";

            if (DBHelper.checkValidField(txtBTPChuaIn.Text) && DBHelper.checkValidField(txtBTPDaIn.Text) && DBHelper.checkValidField(txtTP.Text) && DBHelper.checkValidField(txtSPLoi.Text))
                 CommonHelper.showDialog("Mời nhập số lượng sản phẩm!", Color.FromArgb(255,187,51));
            else
            {
                // DonhangID
                DonhangID = CommonHelper.RandomString(8);
                // NhaccID
                NhaccID = cbNhacc.SelectedValue.ToString();
                // Ngay tao phieu
                Ngay = dtpNgayNhapKho.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                // Ngay nhap kho
                Ngayxong = dtpNgayNhapKho.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                // Barcode
                barcode = cbKihieu.SelectedValue.ToString();
                GhiChu = txtghichu.Text;
                // BTPChuaIn
                BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                BTPChuaInSL = txtBTPChuaIn.Text;
                // BTPDaIn
                BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                BTPDaInSL = txtBTPDaIn.Text;
                // TP
                TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                TPSL = txtTP.Text;
                // SPLoi
                SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                SPLoiSL = txtSPLoi.Text;

                // Created Date
                string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                ItemQryList = AddNewOrder(Ngay, Ngayxong, DonhangID, NhaccID, barcode, "true", createDate, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, GhiChu);
                if (DBAccess.IsServerConnected())
                {

                    if (ItemQryList.Count > 0)
                    {

                        foreach (var item in ItemQryList)
                        {
                            isSuccess = DBAccess.ExecuteQuery(item);
                        }
                        if (isSuccess)
                        {
                            SaveOrderToTransactionDB(barcode, BTPChuaInID, "", BTPChuaInSL, isNhap, "true");
                            SaveOrderToTransactionDB(barcode, BTPDaInID, "", BTPDaInSL, isNhap, "true");
                            SaveOrderToTransactionDB(barcode, TPID, "", TPSL, isNhap, "true");
                            SaveOrderToTransactionDB(barcode, SPLoiID, "", SPLoiSL, isNhap, "true");

                            bool isAddedStock =  DBHelper.AddIntoStock(barcode, DonhangID, Ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);

                            if (isAddedStock)
                            {
                                cbNhacc.SelectedIndex = 0;
                                currentPageNumber = 1;
                                ClearText();
                                // Update datalist
                                GetTotalRow();
                                GetAllDataOrder(currentPageNumber, rowPerPage);

                                CommonHelper.showDialog("Đã thêm thành công!", Color.FromArgb(0, 200, 81));
                            }
                        }
                    }
                }
            }
            

        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ItemQryList = new List<string>();

                bool isSuccess = false;
                string isNhap = "true";
                string ngayxong = string.Empty;
                string Ngay, DonhangID, barcode, NhaccID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, GhiChu;
                Ngay = DonhangID = barcode = NhaccID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = GhiChu = string.Empty;
                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaIn.Text)) txtBTPChuaIn.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaIn.Text)) txtBTPDaIn.Text = "0";
                if (string.IsNullOrEmpty(txtTP.Text)) txtTP.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi.Text)) txtSPLoi.Text = "0";

                if (!string.IsNullOrEmpty(txtOrderIDNhap.Text))
                {
                    if (DBHelper.checkValidField(txtBTPChuaIn.Text) && DBHelper.checkValidField(txtBTPDaIn.Text) && DBHelper.checkValidField(txtTP.Text) && DBHelper.checkValidField(txtSPLoi.Text))
                        CommonHelper.showDialog("Mời nhập số lượng sản phẩm!", Color.FromArgb(255, 187, 51));
                    else
                    {
                        DonhangID = txtOrderIDNhap.Text;
                        string ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                        // NhaccID
                        NhaccID = cbNhacc.SelectedValue.ToString();

                        // Ngay nhap
                        ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

                            ngayxong = dtpNgayNhapKho.Value.ToString("MM/dd/yyyy hh:mm:ss tt");

                        // Barcode
                        barcode = cbKihieu.SelectedValue.ToString();
                        GhiChu = txtghichu.Text;
                        // BTPChuaIn
                        BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                        BTPChuaInSL = txtBTPChuaIn.Text;
                        // BTPDaIn
                        BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                        BTPDaInSL = txtBTPDaIn.Text;
                        // TP
                        TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                        TPSL = txtTP.Text;
                        // SPLoi
                        SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                        SPLoiSL = txtSPLoi.Text;

                        ItemQryList = UpdateOrder(DonhangID, barcode, NhaccID, ngayxong, ngaysua, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, "true", GhiChu);


                        if (DBAccess.IsServerConnected())
                        {

                            if (ItemQryList.Count > 0)
                            {

                                foreach (var item in ItemQryList)
                                {
                                    isSuccess = DBAccess.ExecuteQuery(item);
                                }


                                if (isSuccess)
                                {
                                    SaveOrderToTransactionDB(barcode, BTPChuaInID, "", BTPChuaInSL, isNhap, "true");
                                    SaveOrderToTransactionDB(barcode, BTPDaInID, "", BTPDaInSL, isNhap, "true");
                                    SaveOrderToTransactionDB(barcode, TPID, "", TPSL, isNhap, "true");
                                    SaveOrderToTransactionDB(barcode, SPLoiID, "", SPLoiSL, isNhap, "true");


                                    bool isUpdatededStock = DBHelper.UpdateStock(barcode, DonhangID, ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);

                                    if (isUpdatededStock)
                                    {
                                        cbNhacc.SelectedIndex = 0;
                                        currentPageNumber = 1;
                                        ClearText();
                                        // Update datalist
                                        GetAllDataOrder(currentPageNumber, rowPerPage);
                                        CommonHelper.showDialog("Đã cập nhật thành công!", Color.FromArgb(4, 132, 75));
                                    }
                                    
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.showDialog("Đang Hoàn Thiện Hệ Thống!", Color.FromArgb(255,53,71));
            }
        }

        private void ClearText()
        {
            //dtpNgayTaoPhieu.Value = DateTime.Today;
            //dtpNgayNhapKho.Value = DateTime.Today;
            txtOrderIDNhap.Text = string.Empty;
            cbNhacc.Enabled = true;
            cbNhacc.SelectedIndex = 0;
            cbKihieu.SelectedIndex = 0;
            txtBTPChuaIn.Text = string.Empty;
            txtBTPDaIn.Text = string.Empty;
            txtTP.Text = string.Empty;
            txtSPLoi.Text = string.Empty;
            txtghichu.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            int count = 0;
            if (dgvOrder.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOrder.SelectedRows)
                {

                    if(isEdit)
                    {
                        string orderID = row.Cells[0].Value.ToString();
                        string query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        if (!isSuccess) return;
                        query = "DELETE FROM[Stock] WHERE DonhangID = '" + orderID + "'";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        if (!isSuccess) return;
                        query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        if (!isSuccess) return;
                        dgvOrder.Rows.Remove(row);
                        count++;

                    }
                }
                GetTotalRow();
                GetAllDataOrder(1, 10);
                ClearText();
                CommonHelper.showDialog("Đã xoá thành công " + count + " dòng!", Color.FromArgb(4, 132, 75));
            }
            else
            {
                CommonHelper.showDialog("Mời chọn đơn hàng muốn xóa!", Color.FromArgb(255, 187, 51));

            }
        }

        private void txtBTPChuaIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBTPDaIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSPLoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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
        private void pbFirst_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber = 1;
                GetAllDataOrder(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                GetAllDataOrder(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSizeFilter)
            {
                currentPageNumber += 1;
                GetAllDataOrder(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }


        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                GetAllDataOrder(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void QuanLyNhap_Load(object sender, EventArgs e)
        {
            GetAllInitData();
        }

        private void GetAllInitData()
        {
            dtpNgayNhapKho.Format = DateTimePickerFormat.Custom;
            dtpNgayNhapKho.CustomFormat = "dd/MM/yyyy";
            dtpFilterNgayXong.Format = DateTimePickerFormat.Custom;
            dtpFilterNgayXong.CustomFormat = "dd/MM/yyyy";

            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllDataOrder(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                cbKihieu.DataSource = dtProduct;
                cbKihieu.ValueMember = "Barcode";
                cbKihieu.DisplayMember = "Kyhieu";
                cbKihieu.SelectedIndex = 0;
                cbKyhieuFilter.DataSource = dtProduct;
                cbKyhieuFilter.ValueMember = "Barcode";
                cbKyhieuFilter.DisplayMember = "Kyhieu";
                cbKyhieuFilter.SelectedIndex = -1;
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
        }

        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Order] where NhaccID is not null";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(queryAll, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    rowCount = Convert.ToInt32(dt.Rows[0][0].ToString());
                    pageSize = rowCount / rowPerPage;
                    // if any row left after calculated pages, add one more page 
                    if (rowCount % rowPerPage > 0)
                        pageSize += 1;
                    if (pageSize > 0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPage.Text = "Tổng số:" + rowCount.ToString();
                }
            }
        }
        private void GetAllDataOrder(int currentPageNumber, int rowPerPage)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "Select New.DonhangID [Mã Đơn Hàng],Supplier.Ten [Nhà Cung Cấp],[Order].Ngayxong [Ngày Nhập Kho], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], [Order].Ghichu   from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID order by [Order].Ngaynhap DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvOrder.DataSource = dtMain;
                    dgvOrder.Columns[0].Visible = false;
                    dgvOrder.Columns[1].Visible = false;
                    dgvOrder.Columns[8].Visible = false;
                    dgvOrder.Columns[2].Width = 150;
                    dgvOrder.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvOrder.Columns[2].ReadOnly = true;
                    dgvOrder.Columns["Ký Hiệu"].Width = 80;
                    dgvOrder.Columns["Ký Hiệu"].ReadOnly = true;
                    dgvOrder.Columns["BTP Chưa in"].Width = 120;
                    this.dgvOrder.Columns["BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrder.Columns["BTP Chưa in"].ReadOnly = true;
                    dgvOrder.Columns["BTP Đã in"].Width = 120;
                    this.dgvOrder.Columns["BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrder.Columns["BTP Đã in"].ReadOnly = true;
                    dgvOrder.Columns["Thành Phẩm"].Width = 120;
                    this.dgvOrder.Columns["Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrder.Columns["Thành Phẩm"].ReadOnly = true;
                    dgvOrder.Columns["Sản phẩm lỗi"].Width = 120;
                    this.dgvOrder.Columns["Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrder.Columns["Sản phẩm lỗi"].ReadOnly = true;
                    dgvOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem.ToString());
            currentPageNumber = 1;
            GetAllDataOrder(currentPageNumber, rowPerPage);
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            if (pageSize > 0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
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
                            CommonHelper.showDialog("Barcode chưa tồn tại!", Color.FromArgb(255, 53, 71));
                        }
                    }
                }

            }
        }

        private List<string> AddNewOrder(string Ngaynhap, string Ngayxong, string DonhangID, string NhaccID, string barcode, string IsCompleted, string createDate,
            string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
            string TPSL, string SPLoiSL, string GhiChu)
        {
            List<string> InsertItemQryList = new List<string>();
            string InsertItemQry = "";
            string orderDetailID1 = CommonHelper.RandomString(7) + 1;
            string orderDetailID2 = CommonHelper.RandomString(7) + 2;
            string orderDetailID3 = CommonHelper.RandomString(7) + 3;
            string orderDetailID4 = CommonHelper.RandomString(7) + 4;
            // query insert
            if (string.IsNullOrEmpty(Ngayxong))
            {
                InsertItemQry = "INSERT INTO [Order] ([DonhangID],[NhaccID],[Xong],[Ngaytao],[Ngaysua],[Ngaynhap], [Ghichu])VALUES('" + DonhangID + "','" + NhaccID + "','" + IsCompleted + "','" + createDate + "','" + createDate + "','" + Ngaynhap + "','" + GhiChu +  "')";
            }
            else
            InsertItemQry = "INSERT INTO [Order] ([DonhangID],[NhaccID],[Xong],[Ngaytao],[Ngaysua],[Ngaynhap],[Ngayxong])VALUES('" + DonhangID + "','" + NhaccID + "','" + IsCompleted + "','" + createDate + "','" + createDate + "','" + Ngaynhap + "','" + Ngayxong + "')";
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

        private List<string> UpdateOrder(string DonhangID, string barcode, string NhaccID, string ngayxong, string ngaysua, string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
            string TPSL, string SPLoiSL, string xong, string GhiChu)
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
            UpdateItemQry = "UPDATE [Order] SET[NhaccID] ='" + NhaccID + ngayxong + "',[Ngaysua]= '" + ngaysua + "',[Ghichu]= '" + GhiChu + "',[Xong]= '" + xong + "' WHERE DonhangID ='" + DonhangID + "';";
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

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)               
            {
                //if (Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == false)
                //{
                
                    DataGridViewRow dgvRow = dgvOrder.Rows[e.RowIndex];
                txtOrderIDNhap.Text = dgvRow.Cells[0].Value.ToString();
                cbNhacc.SelectedValue = DBHelper.Lookup("Supplier", "NhaccID", "Ten", dgvRow.Cells[1].Value.ToString());
                cbNhacc.Text = dgvRow.Cells[1].Value.ToString();
                dtpFilterNgayXong.Value = DateTime.Parse(dgvRow.Cells[2].Value.ToString());
                cbKihieu.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[3].Value.ToString());
                cbKihieu.Text = dgvRow.Cells[3].Value.ToString();
                
                txtBTPChuaIn.Text = dgvRow.Cells[4].Value.ToString();
                txtBTPDaIn.Text = dgvRow.Cells[5].Value.ToString();
                txtTP.Text = dgvRow.Cells[6].Value.ToString();
                txtSPLoi.Text = dgvRow.Cells[7].Value.ToString();
                txtghichu.Text = dgvRow.Cells[8].Value.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Không thể cập nhật đơn hàng hoàn thành!");
            //}
        }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (!bool.Parse(IsCompleted))
            //{
            //    if (e.ColumnIndex == dgvOrder.Columns[2].Index)
            //        if (Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true) IsCompleted = "true"; else IsCompleted = "false";
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ngayXong = string.Format("total.[Ngày Nhập Kho] > '{0}' AND total.[Ngày Nhập Kho] < '{1}'", dtpFilterNgayXong.Value.ToString("yyyy-MM-dd"), dtpFilterNgayXongTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            strSearch = ngayXong;

            //string nhaccValue = DBHelper.Lookup("Supplier", "Ten", "NhaccID", cbNhaccFilter.SelectedValue.ToString());
            //string nhacc = string.IsNullOrEmpty(nhaccValue) ? string.Empty : " [Nhà Cung Cấp] like '% " + nhaccValue + "%'";
            //strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(nhacc) ? "" : nhacc) : (string.IsNullOrEmpty(nhacc) ? strSearch : strSearch + " AND " + nhacc);

            string kihieuValue = cbKyhieuFilter.SelectedIndex == -1 ? string.Empty : DBHelper.Lookup("Product", "Kyhieu", "Barcode", cbKyhieuFilter.SelectedValue.ToString());
            string kyhieu = string.IsNullOrEmpty(kihieuValue) ? string.Empty : " total.[Ký Hiệu] like '" + kihieuValue + "'";
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(kyhieu) ? "" : kyhieu) : (string.IsNullOrEmpty(kyhieu) ? strSearch : strSearch + " AND " + kyhieu);

            string btpchuainFilter, btpdainFilter, tpFilter, sploiFilter;
            btpchuainFilter = string.IsNullOrEmpty(txtChuaInFilter.Text) ? string.Empty : " total.[BTP Chưa In] " + cbSignChuaIn.Text + " " + txtChuaInFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(btpchuainFilter) ? "" : btpchuainFilter) : (string.IsNullOrEmpty(btpchuainFilter) ? strSearch : strSearch + " AND " + btpchuainFilter);

            btpdainFilter = string.IsNullOrEmpty(txtDaInFilter.Text) ? string.Empty : " total.[BTP Đã In] " + cbSignDaIn.Text + " " + txtDaInFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(btpdainFilter) ? "" : btpdainFilter) : (string.IsNullOrEmpty(btpdainFilter) ? strSearch : strSearch + " AND " + btpdainFilter);

            tpFilter = string.IsNullOrEmpty(txtTPFilter.Text) ? string.Empty : " total.[Thành Phẩm] " + cbSignTP.Text + " " + txtTPFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(tpFilter) ? "" : tpFilter) : (string.IsNullOrEmpty(tpFilter) ? strSearch : strSearch + " AND " + tpFilter);

            sploiFilter = string.IsNullOrEmpty(txtSPLoiFilter.Text) ? string.Empty : " total.[Sản Phẩm Lỗi] " + cbSignSPLoi.Text + " " + txtSPLoiFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(sploiFilter) ? "" : sploiFilter) : (string.IsNullOrEmpty(sploiFilter) ? strSearch : strSearch + " AND " + sploiFilter);
            //string filterQuery = string.Format("[Ngày Nhập] like '%{0}%' AND [Ngày Xong] like '%{1}%' {2} {3} {4} {5} {6} {7}", "", "", nhacc, kyhieu, btpchuainFilter, btpdainFilter, tpFilter, sploiFilter);

            if (!string.IsNullOrEmpty(strSearch)) strSearch = " WHERE " + strSearch;
            GetTotalRowFilter(strSearch);
            GetAllDataOrderFilter(currentPageNumberFilter, rowPerPageFilter, strSearch);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitSearch();
            GetTotalRowFilter(strSearch);
            GetAllDataOrderFilter(currentPageNumberFilter, rowPerPageFilter, strSearch);
        }

        private void InitSearch()
        {
            currentPageNumberFilter = 1;
            rowPerPageFilter = 10;
            cbKyhieuFilter.SelectedIndex = -1;
            dtpFilterNgayXong.Value = DateTime.Today;
            txtChuaInFilter.Text = string.Empty;
            txtDaInFilter.Text = string.Empty;
            txtTPFilter.Text = string.Empty;
            txtSPLoiFilter.Text = string.Empty;
            cbSignChuaIn.SelectedIndex = -1;
            cbSignDaIn.SelectedIndex = -1;
            cbSignTP.SelectedIndex = -1;
            cbSignSPLoi.SelectedIndex = -1;
            strSearch = string.Empty;
        }
        private void dtpFilterNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            ngayNhapFilterChanged = true;
        }

        private void pbFirstFilter_Click(object sender, EventArgs e)
        {
            if (currentPageNumberFilter > 1)
            {
                currentPageNumberFilter = 1;
                GetAllDataOrderFilter(currentPageNumberFilter, rowPerPageFilter, strSearch);
                txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
            }
        }

        private void pbPrevFilter_Click(object sender, EventArgs e)
        {
            if (currentPageNumberFilter > 1)
            {
                currentPageNumberFilter -= 1;
                GetAllDataOrderFilter(currentPageNumberFilter, rowPerPageFilter, strSearch);
                txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
            }
        }

        private void pbNextFilter_Click(object sender, EventArgs e)
        {
            if (currentPageNumberFilter < pageSizeFilter)
            {
                currentPageNumberFilter += 1;
                GetAllDataOrderFilter(currentPageNumberFilter, rowPerPageFilter, strSearch);
                txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
            }
        }

        private void pbLastFilter_Click(object sender, EventArgs e)
        {
            if (currentPageNumberFilter < pageSizeFilter)
            {
                currentPageNumberFilter = pageSizeFilter;
                GetAllDataOrderFilter(currentPageNumberFilter, rowPerPageFilter, strSearch);
                txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
            }
        }


        private void cbPageSizeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPageFilter = Convert.ToInt32(cbPageSizeFilter.SelectedItem.ToString());
            currentPageNumberFilter = 1;
            GetAllDataOrder(currentPageNumberFilter, rowPerPageFilter);
            pageSizeFilter = rowCountFilter / rowPerPageFilter;
            // if any row left after calculated pages, add one more page 
            if (rowCountFilter % rowPerPageFilter > 0)
                pageSizeFilter += 1;
            if (pageSizeFilter > 0) txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
        }

        private void tbNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbNhap.SelectedIndex)
            {
                case 0:
                    {
                        ClearText();
                        currentPageNumber = 1;
                        rowPerPage = 10;
                        GetTotalRow();
                        GetAllDataOrder(currentPageNumber, rowPerPage);
                        cbPageSize.SelectedIndex = 0;
                        //dtpNgayTaoPhieu.Value = DateTime.Today;
                        //dtpNgayNhapKho.Value = DateTime.Today;
                    }
                    break;
                case 1:
                    {
                        InitSearch();
                    }
                    break;
            }
        }

        private void dtpFilterNgayXong_ValueChanged(object sender, EventArgs e)
        {
            ngayXongFilterChanged = true;
        }

        private void dgvOrder_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells[2].EditedFormattedValue))
            {
                e.Cancel = true;
            }
        }

        

        private void GetTotalRowFilter(string query)
        {
            string queryAll = "Select Count (*) AS Total FROM (Select New.DonhangID[Mã Đơn Hàng], Supplier.Ten[Nhà Cung Cấp],[Order].Xong[Nhập Kho],[Order].Ngaynhap[Ngày Tạo Phiếu], [Order].Ngayxong[Ngày Nhập Kho], Product.Kyhieu[Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], [Order].GhiChu  from(SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID) total " + query;
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(queryAll, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    rowCountFilter = Convert.ToInt32(dt.Rows[0][0].ToString());
                    pageSizeFilter = rowCountFilter / rowPerPageFilter;
                    // if any row left after calculated pages, add one more page 
                    if (rowCountFilter % rowPerPageFilter > 0)
                        pageSizeFilter += 1;
                    if (pageSizeFilter > 0) txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
                    lblTotalPageFilter.Text = "Tổng số:" + rowCountFilter.ToString();
                }
            }
        }
        private void GetAllDataOrderFilter(int currentPageNumber, int rowPerPage, string strSearch)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "select * from(Select New.DonhangID [Mã Đơn Hàng],Supplier.Ten [Nhà Cung Cấp],[Order].Ngayxong [Ngày Nhập Kho], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], [Order].GhiChu  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID ) total " + strSearch + " order by total.[Ngày Nhập Kho] DESC OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvOrderFilter.DataSource = dtMain;
                    dgvOrderFilter.Columns[0].Visible = false;
                    dgvOrderFilter.Columns[1].Visible = false;
                    dgvOrderFilter.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvOrderFilter.Columns[2].Width = 150;

                    dgvOrderFilter.Columns["Ký Hiệu"].Width = 80;
                    dgvOrderFilter.Columns["BTP Chưa in"].Width = 100;
                    this.dgvOrderFilter.Columns["BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.Columns["BTP Đã in"].Width = 100;
                    this.dgvOrderFilter.Columns["BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.Columns["Thành Phẩm"].Width = 100;
                    this.dgvOrderFilter.Columns["Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.Columns["Sản phẩm lỗi"].Width = 100;
                    this.dgvOrderFilter.Columns["Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

        }
    }
}
