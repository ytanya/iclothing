using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlServerCe;

namespace iClothing
{
    public partial class QuanLyXuat : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        private int currentPageNumberFilter, rowPerPageFilter, pageSizeFilter, rowCountFilter;
        private string IsCompleted = "false";
        private bool ngayXuatFilterChanged = false, ngayXongFilterChanged = false;
        string strSearch = string.Empty;
        public QuanLyXuat()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrder.Text))
            {
                if (MessageBox.Show("Bạn có muốn tạo mới không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CreateNew();
                }
                else
                {
                    txtOrder.Text = string.Empty;
                    cbCustomer.SelectedIndex = 0;
                    cbKyHieu.SelectedIndex = 0;
                    txtBTPChuaIn.Text = "0";
                    txtBTPDaIn.Text = "0";
                    txtTP.Text = "0";
                    txtSPLoi.Text = "0";
                    dtpNgayXuat.Enabled = true;
                    dtpNgayXuat.Value = DateTime.Today;
                    IsCompleted = "false";
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
            string ngayxong = string.Empty;
            bool isSuccess = false;
            string isNhap = "false";
            IsCompleted = "false";
            string Ngay, DonhangID, barcode, KHID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL;
            Ngay = DonhangID = barcode = KHID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = string.Empty;
            // Set value for number field
            if (string.IsNullOrEmpty(txtBTPChuaIn.Text)) txtBTPChuaIn.Text = "0";
            if (string.IsNullOrEmpty(txtBTPDaIn.Text)) txtBTPDaIn.Text = "0";
            if (string.IsNullOrEmpty(txtTP.Text)) txtTP.Text = "0";
            if (string.IsNullOrEmpty(txtSPLoi.Text)) txtSPLoi.Text = "0";

                // DonhangID
                DonhangID = CommonHelper.RandomString(8);
                // Customer
                KHID = cbCustomer.SelectedValue.ToString();
                // Ngay nhap
                Ngay = dtpNgayXuat.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                // Barcode
                barcode = cbKyHieu.SelectedValue.ToString();
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

                ItemQryList = AddNewOrder(Ngay, DonhangID, KHID, barcode, IsCompleted, createDate, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);
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
                        SaveOrderToTransactionDB(barcode, BTPChuaInID, "", BTPChuaInSL, isNhap, IsCompleted);
                        SaveOrderToTransactionDB(barcode, BTPDaInID, "", BTPDaInSL, isNhap, IsCompleted);
                        SaveOrderToTransactionDB(barcode, TPID, "", TPSL, isNhap, IsCompleted);
                        SaveOrderToTransactionDB(barcode, SPLoiID, "", SPLoiSL, isNhap, IsCompleted);

                            cbCustomer.SelectedIndex = 0;
                            currentPageNumber = 1;
                            ClearText();
                            // Update datalist
                            GetTotalRow();
                            GetAllDataOrder(currentPageNumber, rowPerPage);
                      
                        MessageBox.Show("Đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
            private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ItemQryList = new List<string>();
                string ngayxong = string.Empty;
                bool isSuccess = false;
                string isNhap = "false";

                string Ngay, DonhangID, barcode, KHID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL;
                Ngay = DonhangID = barcode = KHID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = string.Empty;
                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaIn.Text)) txtBTPChuaIn.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaIn.Text)) txtBTPDaIn.Text = "0";
                if (string.IsNullOrEmpty(txtTP.Text)) txtTP.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi.Text)) txtSPLoi.Text = "0";

                    DonhangID = txtOrder.Text;
                    string ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    // NhaccID
                    KHID = cbCustomer.SelectedValue.ToString();
                    // Ngay nhap
                    ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    // Ngay xong
                    if (!DBHelper.isXong(DonhangID) && bool.Parse(IsCompleted))
                    {
                        ngayxong = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    // Barcode
                    barcode = cbKyHieu.SelectedValue.ToString();
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

                    ItemQryList = UpdateOrder(DonhangID, barcode, KHID, ngayxong, ngaysua, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, IsCompleted);


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
                        SaveOrderToTransactionDB(barcode, BTPChuaInID, "", BTPChuaInSL, isNhap, IsCompleted);
                        SaveOrderToTransactionDB(barcode, BTPDaInID, "", BTPDaInSL, isNhap, IsCompleted);
                        SaveOrderToTransactionDB(barcode, TPID, "", TPSL, isNhap, IsCompleted);
                        SaveOrderToTransactionDB(barcode, SPLoiID, "", SPLoiSL, isNhap, IsCompleted);
                        if (IsCompleted.ToLower() == "true")
                        {
                            AddIntoStock(barcode, ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, "-" + BTPChuaInSL, "-" + BTPDaInSL, "-" + TPSL, "-" + SPLoiSL);
                        }

                            cbCustomer.SelectedIndex = 0;
                            currentPageNumber = 1;
                            ClearText();
                            // Update datalist
                            GetAllDataOrder(currentPageNumber, rowPerPage);
                        MessageBox.Show("Đã cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private List<string> AddNewOrder(string Ngaynhap, string DonhangID, string KHID, string barcode, string IsCompleted, string createDate,
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

        private List<string> UpdateOrder(string DonhangID, string barcode, string KHID, string ngayxong, string ngaysua, string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
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

            //if (DBAccess.IsServerConnected())
            //{

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
            // }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (dgvOrder.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOrder.SelectedRows)
                {

                    if (Convert.ToBoolean(row.Cells[2].Value.ToString()) == false)
                    {
                        string orderID = row.Cells[0].Value.ToString();
                        string query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        if (!isSuccess) return;
                        query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        
                        if (!isSuccess) return;
                        dgvOrder.Rows.Remove(row);
                        
                    }
                }
                GetTotalRow();
                GetAllDataOrder(1, 10);
                ClearText();
            }
            else
            {
                MessageBox.Show("Mời chọn lại đơn hàng muốn xóa!");
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
                InsertItemQry = "INSERT INTO [Transaction]([TransID],[Barcode],[LoaiID],[Mota],[Soluong],[Nhap],[Xong],[Ngaytao],[Ngaysua])VALUES('" + TransID + "','" + barcode + "','" + LoaiID + "','" + Mota + "','" + soluong + "','" + Nhap + "','" + Xong + "','" + createDate + "','" + modifyDate + "')";
                //if (DBAccess.IsServerConnected())
                //{

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
                // }

            }
        }
        private void ClearText()
        {
            txtOrder.Text = string.Empty;
            cbCustomer.Enabled = true;
            cbCustomer.SelectedIndex = 0;
            cbKyHieu.SelectedIndex = 0;
            txtBTPChuaIn.Text = string.Empty;
            txtBTPDaIn.Text = string.Empty;
            txtTP.Text = string.Empty;
            txtSPLoi.Text = string.Empty;
            dtpNgayXuat.Enabled = true;
            IsCompleted = "false";
        }
        private void dtpNgayXuatFilter_ValueChanged(object sender, EventArgs e)
        {
            ngayXuatFilterChanged = true;
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
            cbKyHieuFilter.SelectedIndex = -1;
            dtpNgayXuatFilter.Value = DateTime.Today;
            dtpNgayXongFilter.Value = DateTime.Today;
            ngayXongFilterChanged = false;
            txtBTPChuaInFilter.Text = string.Empty;
            txtDaInFilter.Text = string.Empty;
            txtTPFilter.Text = string.Empty;
            txtSPLoiFilter.Text = string.Empty;
            cbChuaInSign.SelectedIndex = -1;
            cbSignDaInFilter.SelectedIndex = -1;
            cbSignTP.SelectedIndex = -1;
            cbSignSPLoi.SelectedIndex = -1;
            ngayXuatFilterChanged = false;
            strSearch = string.Empty;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
    
            string ngayXuat = ngayXuatFilterChanged ? string.Format("total.[Xuất Phiếu] > '{0}' AND total.[Xuất Phiếu] < '{1}'", dtpNgayXuatFilter.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpNgayXuatFilter.Value.AddDays(1).ToString("yyyy-MM-dd")) : string.Empty;
            strSearch = ngayXuat;
            string ngayXong = ngayXongFilterChanged ? string.Format("total.[Ngày Xuất Kho] >= '{0}' AND total.[Ngày Xuất Kho] < '{1}'", dtpNgayXongFilter.Value.AddDays(-1).ToString("yyyy-MM-dd"), dtpNgayXongFilter.Value.AddDays(1).ToString("yyyy-MM-dd")) : string.Empty;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(ngayXong) ? "" : ngayXong) : (string.IsNullOrEmpty(ngayXong) ? strSearch : strSearch + " AND " + ngayXong);
            //string nhaccValue = DBHelper.Lookup("Supplier", "Ten", "NhaccID", cbNhaccFilter.SelectedValue.ToString());
            //string nhacc = string.IsNullOrEmpty(nhaccValue) ? string.Empty : " [Nhà Cung Cấp] like '% " + nhaccValue + "%'";
            //strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(nhacc) ? "" : nhacc) : (string.IsNullOrEmpty(nhacc) ? strSearch : strSearch + " AND " + nhacc);

            string kihieuValue = cbKyHieuFilter.SelectedIndex == -1 ? string.Empty : DBHelper.Lookup("Product", "Kyhieu", "Barcode", cbKyHieuFilter.SelectedValue.ToString());
            string kyhieu = string.IsNullOrEmpty(kihieuValue) ? string.Empty : " total.[Ký Hiệu] like '" + kihieuValue + "'";
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(kyhieu) ? "" : kyhieu) : (string.IsNullOrEmpty(kyhieu) ? strSearch : strSearch + " AND " + kyhieu);

            string btpchuainFilter, btpdainFilter, tpFilter, sploiFilter;
            btpchuainFilter = string.IsNullOrEmpty(txtBTPChuaInFilter.Text) ? string.Empty : " total.[BTP Chưa In] " + cbChuaInSign.Text + " " + txtBTPChuaInFilter.Text;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(btpchuainFilter) ? "" : btpchuainFilter) : (string.IsNullOrEmpty(btpchuainFilter) ? strSearch : strSearch + " AND " + btpchuainFilter);

            btpdainFilter = string.IsNullOrEmpty(txtDaInFilter.Text) ? string.Empty : " total.[BTP Đã In] " + cbSignDaInFilter.Text + " " + txtDaInFilter.Text;
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

        private void GetTotalRowFilter(string query)
        {
            string queryAll = "Select Count (*) AS Total FROM (Select New.DonhangID [Mã Đơn Hàng], Customer.HoTen [Tên Khách Hàng],[Order].Xong [Xuất Kho],[Order].Ngaynhap [Xuất Phiếu], [Order].Ngayxong [Ngày Xuất Kho], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi]  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Customer on[Order].KHID = Customer.KHID) total " + query;
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
                    txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
                    lblTotalPageFilter.Text = "Tổng số:" + rowCountFilter.ToString();
                }
            }
        }
        private void GetAllDataOrderFilter(int currentPageNumber, int rowPerPage, string strSearch)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "select * from(Select New.DonhangID [Mã Đơn Hàng], Customer.HoTen [Tên Khách Hàng],[Order].Xong [Xuất Kho],[Order].Ngaynhap [Xuất Phiếu], [Order].Ngayxong [Ngày Xuất Kho], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi]  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Customer on[Order].KHID = Customer.KHID ) total " + strSearch + " order by total.[Xuất Phiếu] DESC OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY;";
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
                    dgvOrderFilter.Columns[3].Width = 130;
                    dgvOrderFilter.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvOrderFilter.Columns[4].Width = 130;
                    dgvOrderFilter.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvOrderFilter.Columns[2].Width = 150;
                    dgvOrderFilter.Columns["Ký Hiệu"].Width = 60;
                    dgvOrderFilter.Columns["BTP Chưa in"].Width = 120;
                    this.dgvOrderFilter.Columns["BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.Columns["BTP Đã in"].Width = 100;
                    this.dgvOrderFilter.Columns["BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.Columns["Thành Phẩm"].Width = 120;
                    this.dgvOrderFilter.Columns["Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.Columns["Sản phẩm lỗi"].Width = 110;
                    this.dgvOrderFilter.Columns["Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrderFilter.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

        }
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == false)
            {
                DataGridViewRow dgvRow = dgvOrder.Rows[e.RowIndex];
                txtOrder.Text = dgvRow.Cells[0].Value.ToString();
                cbCustomer.SelectedValue = DBHelper.Lookup("Customer", "KHID", "HoTen", dgvRow.Cells[1].Value.ToString());
                cbCustomer.Text = dgvRow.Cells[1].Value.ToString();
                if (Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true)
                {
                    IsCompleted = "true";

                }
                dtpNgayXuat.Value = DateTime.Parse(dgvRow.Cells[3].Value.ToString());
                cbKyHieu.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[5].Value.ToString());
                cbKyHieu.Text = dgvRow.Cells[5].Value.ToString();
                txtBTPChuaIn.Text = dgvRow.Cells[6].Value.ToString();
                txtBTPDaIn.Text = dgvRow.Cells[7].Value.ToString();
                txtTP.Text = dgvRow.Cells[8].Value.ToString();
                txtSPLoi.Text = dgvRow.Cells[9].Value.ToString();

                dtpNgayXuat.Enabled = false;

            }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!bool.Parse(IsCompleted))
            {
                if (e.ColumnIndex == dgvOrder.Columns[2].Index)
                    if (Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true) IsCompleted = "true"; else IsCompleted = "false";
            }
        }

        private void dgvOrder_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells[2].EditedFormattedValue))
            {
                e.Cancel = true;
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
            if (currentPageNumber < pageSize)
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

        private void cbPagingSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPagingSize.SelectedItem.ToString());
            currentPageNumber = 1;
            GetAllDataOrder(currentPageNumber, rowPerPage);
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            if (pageSize >0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
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

        private void txtBTPChuaInFilter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtpNgayXongFilter_ValueChanged(object sender, EventArgs e)
        {
            ngayXongFilterChanged = true;
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
            txtPageSizeFilter.Text = currentPageNumberFilter.ToString() + " /" + pageSizeFilter.ToString();
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

        private void tbXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbXuat.SelectedIndex)
            {
                case 0:
                    {
                        ClearText();
                        currentPageNumber = 1;
                        rowPerPage = 10;
                        GetTotalRow();
                        GetAllDataOrder(currentPageNumber, rowPerPage);
                        cbPagingSize.SelectedIndex = 0;
                    }
                    break;
                case 1:
                    {
                        InitSearch();
                    }
                    break;
            }
        }

        private void QuanLyXuat_Load(object sender, EventArgs e)
        {
            GetAllInitData();
        }

        private void GetAllInitData()
        {
            dtpNgayXuat.Format = DateTimePickerFormat.Custom;
            dtpNgayXuat.CustomFormat = "dd/MM/yyyy";
            dtpNgayXuatFilter.Format = DateTimePickerFormat.Custom;
            dtpNgayXuatFilter.CustomFormat = "dd/MM/yyyy";
            dtpNgayXongFilter.Format = DateTimePickerFormat.Custom;
            dtpNgayXongFilter.CustomFormat = "dd/MM/yyyy";

            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllDataOrder(currentPageNumber, rowPerPage);
            cbPagingSize.SelectedIndex = 0;
            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                cbKyHieu.DataSource = dtProduct;
                cbKyHieu.ValueMember = "Barcode";
                cbKyHieu.DisplayMember = "Kyhieu";
                cbKyHieu.SelectedIndex = 0;
                cbKyHieuFilter.DataSource = dtProduct;
                cbKyHieuFilter.ValueMember = "Barcode";
                cbKyHieuFilter.DisplayMember = "Kyhieu";
                cbKyHieuFilter.SelectedIndex = -1;
            }

            // Init Supplier combobox
            DataTable dtCustomer = DBHelper.GetAllCustomer();
            if (dtCustomer.Rows.Count > 0)
            {
                cbCustomer.DataSource = dtCustomer;
                cbCustomer.ValueMember = "KHID";
                cbCustomer.DisplayMember = "HoTen";
                cbCustomer.SelectedIndex = 0;
            }
        }

        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Order] where KHID is not null";
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
                    if(pageSize>0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPage.Text = "Tổng số:" + rowCount.ToString();
                }
            }
        }

        private void GetAllDataOrder(int currentPageNumber, int rowPerPage)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "Select New.DonhangID [Mã Đơn Hàng], Customer.HoTen [Tên Khách Hàng],[Order].Xong [Xuất Kho],[Order].Ngaynhap [Xuất Phiếu], [Order].Ngayxong [Ngày Xuất Kho], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi]  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Customer on[Order].KHID = Customer.KHID order by [Order].Ngaynhap DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvOrder.DataSource = dtMain;
                    if (dtMain.Rows.Count > 0)
                    {
                        dgvOrder.Columns[0].Visible = false;
                        dgvOrder.Columns[1].Visible = false;
                        dgvOrder.Columns[3].Width = 130;
                        dgvOrder.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        dgvOrder.Columns[4].Width = 130;
                        dgvOrder.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        dgvOrder.Columns[2].Width = 150;
                        dgvOrder.Columns["Ký Hiệu"].Width = 60;
                        dgvOrder.Columns["BTP Chưa in"].Width = 120;
                        this.dgvOrder.Columns["BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrder.Columns["BTP Đã in"].Width = 100;
                        this.dgvOrder.Columns["BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrder.Columns["Thành Phẩm"].Width = 120;
                        this.dgvOrder.Columns["Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrder.Columns["Sản phẩm lỗi"].Width = 110;
                        this.dgvOrder.Columns["Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                }
            }

        }
    }
}
