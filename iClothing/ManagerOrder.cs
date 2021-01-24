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

namespace iClothing
{
    public partial class ManagerOrder : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        private string KHID;
        public ManagerOrder()
        {
            InitializeComponent();
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber = 1;
                GetAllData(currentPageNumber, rowPerPage,KHID);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                GetAllData(currentPageNumber, rowPerPage, KHID);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbNextNhap_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                GetAllData(currentPageNumber, rowPerPage, KHID);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLastNhap_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                GetAllData(currentPageNumber, rowPerPage, KHID);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                bool isSuccess = false;
                
                string Ngay, DonhangID, Barcode, Soluong, Ghichu;
                DonhangID = Barcode = Soluong = Ghichu = string.Empty;
                DonhangID = CommonHelper.RandomString(8);
                KHID = cbCustomer.SelectedValue.ToString();
                    Barcode = cbKyHieu.SelectedValue.ToString();
                    Soluong = txtSoluong.Text;
                    Ghichu = txtghichu.Text;
                Ngay = dtpNgay.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                // Created Date
                string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    query = "INSERT INTO [CustomerOrder] ([DonhangID],[KHID],[Barcode],[Soluong],[Ghichu],[NgayGD], [Ngaytao],[Ngaysua])VALUES('" + DonhangID + "','" + KHID + "','" + Barcode + "','" + Soluong + "','" + Ghichu + "','" +Ngay +  "','" + createDate + "','" + createDate + "')";
               

                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);

                    if (isSuccess)
                    {
                            currentPageNumber = 1;
                            ClearText();
                            // Update datalist
                            GetTotalRow(KHID);
                            GetAllData(currentPageNumber, rowPerPage, KHID);

                        MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void GetTotalRow(string KHID)
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [CustomerOrder] where KHID ='"+ KHID +"'";
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
        private void GetAllData(int currentPageNumber, int rowPerPage, string KHID)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;
             if (dgvOrder.Rows.Count>0) dgvOrder.DataSource = null;
            string query = "Select DonhangID [Mã Đơn Hàng], NgayGD [Ngày], Customer.HoTen [Tên Khách Hàng], Product.Kyhieu [Ký Hiệu],Soluong [Số Lượng], Ghichu [Ghi Chú] from CustomerOrder join Product on CustomerOrder.Barcode = Product.Barcode join Customer on CustomerOrder.KHID=Customer.KHID where CustomerOrder.KHID = '" + KHID + "' order by CustomerOrder.Ngaysua DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvOrder.DataSource = dtMain;
                    dgvOrder.Columns[1].Visible = false;                   
                    dgvOrder.Columns[2].Width = 130;
                    dgvOrder.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvOrder.Columns[3].ReadOnly = true;
                    dgvOrder.Columns["Ký Hiệu"].Width = 60;
                    dgvOrder.Columns["Ký Hiệu"].ReadOnly = true;                    
                    dgvOrder.Columns["Số Lượng"].Width = 80;
                    this.dgvOrder.Columns["Số Lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvOrder.Columns["Số Lượng"].ReadOnly = true;
                    dgvOrder.Columns[5].ReadOnly = true;
                    dgvOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            if (rowCount>0)
            {
                
            }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string DonhangID;
            SqlCeConnection conn = new SqlCeConnection(ConnectionString);
            conn.Open();
            //edit column 
            //if (e.ColumnIndex == 5)
            //{
            //    DonhangID = Convert.ToString(dgvOrder.Rows[e.RowIndex].Cells[0].Value);
            //    dgvOrder.Rows[e.RowIndex].Cells[1].ReadOnly = true;
            //    dgvOrder.Rows[e.RowIndex].Cells[2].ReadOnly = true;

            //    //Form2 frm2 = new Form3(this);
            //    //fm2.a = id;
            //    //fm2.Show();
            //    dgvOrder.Refresh();
            //}
                //delete column
                if (e.ColumnIndex == 0)
                {
                DonhangID = Convert.ToString(dgvOrder.Rows[e.RowIndex].Cells[1].Value);
                    SqlCeDataAdapter da = new SqlCeDataAdapter("Delete from CustomerOrder where DonhangID = '" + DonhangID + "'", ConnectionString);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                KHID = cbCustomer.SelectedValue.ToString();
                GetTotalRow(KHID);
                GetAllData(1, 10, KHID);

                }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string KHID = cbCustomer.SelectedValue.ToString();
            GetTotalRow(KHID);
            GetAllData(currentPageNumber, rowPerPage, KHID);
        }

        private void ClearText()
        {
            dtpNgay.Value = DateTime.Today;
            dtpNgay.Value = DateTime.Today;
            cbCustomer.SelectedIndex = 0;
            cbKyHieu.SelectedIndex = 0;
            txtSoluong.Text = string.Empty;
            txtghichu.Text = string.Empty;
        }
        private void InitData()
        {
            
            currentPageNumber = 1;
            rowPerPage = 10;
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            
            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                cbKyHieu.DataSource = dtProduct;
                cbKyHieu.ValueMember = "Barcode";
                cbKyHieu.DisplayMember = "Kyhieu";
                cbKyHieu.SelectedIndex = 0;
            }

            DataTable dtCustomer = DBHelper.GetAllCustomer();
            if (dtCustomer.Rows.Count > 0)
            {
                cbCustomer.DataSource = dtCustomer;
                cbCustomer.ValueMember = "KHID";
                cbCustomer.DisplayMember = "HoTen";
                cbCustomer.SelectedIndex = 0;
            }
            string KHID = cbCustomer.SelectedValue.ToString();
            GetTotalRow(KHID);
            GetAllData(currentPageNumber, rowPerPage, KHID);
            //Edit link

            //DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            //Editlink.UseColumnTextForLinkValue = true;
            //Editlink.HeaderText = "Cập Nhật";
            //Editlink.DataPropertyName = "lnkColumn";
            //Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            //Editlink.Text = "Cập Nhật";
            //Editlink.LinkColor = Color.FromArgb(255, 128, 0);
            //dgvOrder.Columns.Add(Editlink);

            //Delete link

            //DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            //Deletelink.UseColumnTextForLinkValue = true;
            //Deletelink.HeaderText = "Xóa";
            //Deletelink.DataPropertyName = "lnkColumn";
            //Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            //Deletelink.Text = "Xóa";
            //Deletelink.LinkColor = Color.FromArgb(255, 128, 0);
            //dgvOrder.Columns.Add(Deletelink);
        }

        private void ManagerOrder_Load(object sender, EventArgs e)
        {
            InitData();
            
        }
    }
}
