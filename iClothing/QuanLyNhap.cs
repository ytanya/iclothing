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

namespace iClothing
{
    public partial class QuanLyNhap : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        private string IsCompleted = "false";
        private bool ngayNhapFilterChanged = false, ngayXongFilterChanged = false;
        public QuanLyNhap()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtOrderIDNhap.Text = string.Empty;
            cbNhacc.SelectedIndex = 0;
            cbKihieu.SelectedIndex = 0;
            txtBTPChuaIn.Text = "0";
            txtBTPDaIn.Text = "0";
            txtTP.Text = "0";
            txtSPLoi.Text = "0";
            dtpNgayNhap.Enabled = true;
            dtpNgayNhap.Value = DateTime.Today;
            IsCompleted = "false";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ItemQryList = new List<string>();

                bool isSuccess = false;
                string isNhap = "true";
                string ngayxong = string.Empty;
                string Ngay, DonhangID, barcode, NhaccID, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL;
                Ngay = DonhangID = barcode = NhaccID = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaInSL = BTPDaInSL = TPSL = SPLoiSL = string.Empty;
                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaIn.Text)) txtBTPChuaIn.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaIn.Text)) txtBTPDaIn.Text = "0";
                if (string.IsNullOrEmpty(txtTP.Text)) txtTP.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi.Text)) txtSPLoi.Text = "0";


                if (string.IsNullOrEmpty(txtOrderIDNhap.Text))
                {
                    // DonhangID
                    DonhangID = CommonHelper.RandomString(8);
                    // NhaccID
                    NhaccID = cbNhacc.SelectedValue.ToString();
                    // Ngay nhap
                    Ngay = dtpNgayNhap.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                    // Barcode
                    barcode = cbKihieu.SelectedValue.ToString();
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

                    ItemQryList = AddNewOrder(Ngay, DonhangID, NhaccID, barcode, IsCompleted, createDate, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);
                }
                else
                {
                    DonhangID = txtOrderIDNhap.Text;
                    string ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    // NhaccID
                    NhaccID = cbNhacc.SelectedValue.ToString();

                    // Ngay nhap
                    ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    // Ngay xong
                    if (!DBHelper.isXong(DonhangID) && bool.Parse(IsCompleted))
                    {
                        ngayxong = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    // Barcode
                    barcode = cbKihieu.SelectedValue.ToString();
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

                    ItemQryList = UpdateOrder(DonhangID, barcode, NhaccID, ngayxong, ngaysua, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, IsCompleted);

                }

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
                                AddIntoStock(barcode, ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);
                            }
                            if (string.IsNullOrEmpty(txtOrderIDNhap.Text))
                            {
                                cbNhacc.SelectedIndex = 0;
                                currentPageNumber = 1;
                                ClearText();
                                // Update datalist
                                GetTotalRow();
                                GetAllDataOrder(currentPageNumber, rowPerPage);
                            }
                            else
                            {
                                cbNhacc.SelectedIndex = 0;
                                currentPageNumber = 1;
                                ClearText();
                                // Update datalist
                                GetAllDataOrder(currentPageNumber, rowPerPage);
                            }
                            MessageBox.Show("Đơn hàng này đã cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void ClearText()
        {
            txtOrderIDNhap.Text = string.Empty;
            cbNhacc.Enabled = true;
            cbNhacc.SelectedIndex = 0;
            cbKihieu.SelectedIndex = 0;
            txtBTPChuaIn.Text = string.Empty;
            txtBTPDaIn.Text = string.Empty;
            txtTP.Text = string.Empty;
            txtSPLoi.Text = string.Empty;
            dtpNgayNhap.Enabled = true;
            IsCompleted = "false";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (dgvOrderFilter.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOrderFilter.SelectedRows)
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
                        dgvOrderFilter.Rows.Remove(row);
                        
                    }
                }
                GetTotalRow();
                GetAllDataOrder(1, 10);
                ClearText();
            }
            else
            {
                MessageBox.Show("Mời chọn đơn hàng muốn xóa!");
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

        private void pbNextNhap_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                GetAllDataOrder(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLastNhap_Click(object sender, EventArgs e)
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
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpFilterNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpFilterNgayNhap.CustomFormat = "dd/MM/yyyy";
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
                    txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPage.Text = "Tổng số:" + rowCount.ToString();
                }
            }
        }
        private void GetAllDataOrder(int currentPageNumber, int rowPerPage)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "Select New.DonhangID [Mã Đơn Hàng],Supplier.Ten [Nhà Cung Cấp],[Order].Xong,[Order].Ngaynhap [Ngày Nhập], [Order].Ngayxong [Ngày Xong], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi]  from (SELECT DonhangID, Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID order by [Order].Ngaynhap DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
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
                    dgvOrderFilter.Columns["Xong"].Width = 50;
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

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem.ToString());
            currentPageNumber = 1;
            GetAllDataOrder(currentPageNumber, rowPerPage);
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
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
                            MessageBox.Show("Barcode chưa tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private List<string> AddNewOrder(string Ngaynhap, string DonhangID, string NhaccID, string barcode, string IsCompleted, string createDate,
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

        private List<string> UpdateOrder(string DonhangID, string barcode, string NhaccID, string ngayxong, string ngaysua, string BTPChuaInID, string BTPDaInID, string TPID, string SPLoiID, string BTPChuaInSL, string BTPDaInSL,
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
            UpdateItemQry = "UPDATE [Order] SET[NhaccID] ='" + NhaccID + "',[Ngayxong]= '" + ngayxong + "',[Ngaysua]= '" + ngaysua + "',[Xong]= '" + xong + "' WHERE DonhangID ='" + DonhangID + "';";
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
            if (e.RowIndex != -1 && Convert.ToBoolean(dgvOrderFilter.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == false)
            {
                DataGridViewRow dgvRow = dgvOrderFilter.Rows[e.RowIndex];
                txtOrderIDNhap.Text = dgvRow.Cells[0].Value.ToString();
                cbNhacc.SelectedValue = DBHelper.Lookup("Supplier", "NhaccID", "Ten", dgvRow.Cells[1].Value.ToString());
                cbNhacc.Text = dgvRow.Cells[1].Value.ToString();
                if (Convert.ToBoolean(dgvOrderFilter.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true)
                {
                    IsCompleted = "true";

                }
                else IsCompleted = "false";
                dtpNgayNhap.Value = DateTime.Parse(dgvRow.Cells[3].Value.ToString());
                cbKihieu.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[5].Value.ToString());
                cbKihieu.Text = dgvRow.Cells[5].Value.ToString();
                txtBTPChuaIn.Text = dgvRow.Cells[6].Value.ToString();
                txtBTPDaIn.Text = dgvRow.Cells[7].Value.ToString();
                txtTP.Text = dgvRow.Cells[8].Value.ToString();
                txtSPLoi.Text = dgvRow.Cells[9].Value.ToString();
                dtpNgayNhap.Enabled = false;

            }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!bool.Parse(IsCompleted))
            {
                if (e.ColumnIndex == dgvOrderFilter.Columns["Xong"].Index)
                    if (Convert.ToBoolean(dgvOrderFilter.Rows[e.RowIndex].Cells[2].EditedFormattedValue) == true) IsCompleted = "true"; else IsCompleted = "false";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch = string.Empty;
            string ngayNhap = ngayNhapFilterChanged ? string.Format("[Ngày Nhập] > '{0}' AND [Ngày Nhập] < '{1}'", dtpFilterNgayNhap.Value.AddDays(-1), dtpFilterNgayNhap.Value.AddDays(1)) : string.Empty;
            strSearch = ngayNhap;
            string ngayXong = ngayXongFilterChanged ? string.Format("[Ngày Xong] >= '{0}' AND [Ngày Xong] < '{1}'", dtpFilterNgayXong.Value.AddDays(-1), dtpFilterNgayXong.Value.AddDays(1)) : string.Empty;
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(ngayXong) ? "" : ngayXong) : (string.IsNullOrEmpty(ngayXong) ? strSearch : strSearch + " AND " + ngayXong);

            //string nhaccValue = DBHelper.Lookup("Supplier", "Ten", "NhaccID", cbNhaccFilter.SelectedValue.ToString());
            //string nhacc = string.IsNullOrEmpty(nhaccValue) ? string.Empty : " [Nhà Cung Cấp] like '% " + nhaccValue + "%'";
            //strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(nhacc) ? "" : nhacc) : (string.IsNullOrEmpty(nhacc) ? strSearch : strSearch + " AND " + nhacc);

            string kihieuValue = cbKyhieuFilter.SelectedIndex == -1 ? string.Empty : DBHelper.Lookup("Product", "Kyhieu", "Barcode", cbKyhieuFilter.SelectedValue.ToString());
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

            (dgvOrderFilter.DataSource as DataTable).DefaultView.RowFilter = strSearch;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitSearch();
        }

        private void InitSearch()
        {
            dtpFilterNgayNhap.Value = DateTime.Today;
            ngayNhapFilterChanged = false;
            dtpFilterNgayXong.Value = DateTime.Today;
            ngayXongFilterChanged = false;
            cbKyhieuFilter.SelectedIndex = -1;
            txtChuaInFilter.Text = string.Empty;
            txtDaInFilter.Text = string.Empty;
            txtTPFilter.Text = string.Empty;
            txtSPLoiFilter.Text = string.Empty;
            cbSignChuaIn.SelectedIndex = -1;
            cbSignDaIn.SelectedIndex = -1;
            cbSignTP.SelectedIndex = -1;
            cbSignSPLoi.SelectedIndex = -1;
            if (dgvOrderFilter.DataSource != null)
            {
                (dgvOrderFilter.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }
        private void dtpFilterNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            ngayNhapFilterChanged = true;
        }

        private void pbFirstFilter_Click(object sender, EventArgs e)
        {

        }

        private void pbPrevFilter_Click(object sender, EventArgs e)
        {

        }

        private void pbNextFilter_Click(object sender, EventArgs e)
        {

        }

        private void pbLastFilter_Click(object sender, EventArgs e)
        {

        }

        private void cbPageSizeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSizeFilter.SelectedItem.ToString());
            currentPageNumber = 1;
            GetAllDataOrder(currentPageNumber, rowPerPage);
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
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
            if (Convert.ToBoolean(dgvOrderFilter.Rows[e.RowIndex].Cells[2].EditedFormattedValue))
            {
                e.Cancel = true;
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
                //  }
            }
        }
    }
}
