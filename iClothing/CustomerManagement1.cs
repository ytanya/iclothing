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
    public partial class CustomerManagement1 : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        public CustomerManagement1()
        {
            InitializeComponent();
        }

        private void txtSodt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            txtKHID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSodt.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                bool isSuccess = false;
                string ngayxong = string.Empty;
                string KHID, Name, Address, Sodt, Email;
                KHID = Name = Address = Sodt = Email = string.Empty;


                if (string.IsNullOrEmpty(txtKHID.Text))
                {
                    // KHID
                    KHID = CommonHelper.RandomString(8);
                    // Ten khach hang
                    Name = txtName.Text;
                    // Address
                    Address = txtAddress.Text;
                    // Sodt
                    Sodt = txtSodt.Text;
                    // Email
                    Email = txtEmail.Text;

                    // Created Date
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    query = "INSERT INTO [Customer] ([KHID],[HoTen],[Diachi],[Sodt],[Email],[Ngaytao],[Ngaysua])VALUES('" + KHID + "','" + Name + "','" + Address + "','" +Sodt + "','" +Email + "','" + createDate + "','" + createDate + "')";
                }
                else
                {
                    KHID = txtKHID.Text;
                    string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                    // Ten khach hang
                    Name = txtName.Text;
                    // Address
                    Address = txtAddress.Text;
                    // Sodt
                    Sodt = txtSodt.Text;
                    // Email
                    Email = txtEmail.Text;

                    query = "UPDATE [Customer] SET[HoTen] ='" + Name + "',[Diachi]= '" + Address + "',[Sodt]= '" + Sodt + "',[Email]= '" + Email + "',[Ngaysua]= '" + modifyDate + "' WHERE KHID ='" + KHID + "';";

                }

                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);

                    if (isSuccess)
                    {
                        if (string.IsNullOrEmpty(txtKHID.Text))
                        {
                            currentPageNumber = 1;
                            ClearText();
                            // Update datalist
                            GetTotalRow();
                            GetAllData(currentPageNumber, rowPerPage);
                        }
                        else
                        {
                            currentPageNumber = 1;
                            ClearText();
                            // Update datalist
                            GetAllData(currentPageNumber, rowPerPage);
                        }
                        CommonHelper.showDialog("Đã cập nhật thành công!", Color.FromArgb(4, 132, 75));
                    }

                }
            }
            catch (Exception ex)
            {
                CommonHelper.showDialog("Đang Hoàn Thiện Hệ Thống!", Color.FromArgb(255, 53, 71));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvCustomer.SelectedRows)
                    {

                        string KHID = row.Cells[0].Value.ToString();
                        bool isExisted = DBHelper.CheckItemExist("[Order]", "KHID", KHID);
                        if (!isExisted)
                        {
                            string query = "DELETE FROM[Customer] WHERE KHID = '" + KHID + "'";
                            isSuccess = DBAccess.ExecuteQuery(query);
                            if (!isSuccess) return;
                            dgvCustomer.Rows.Remove(row);
                        }
                        else
                        {
                            CommonHelper.showDialog("Khách hàng đang giao dịch!", Color.FromArgb(255, 53, 71));
                        }
                    }
                    GetTotalRow();
                    GetAllData(1, rowPerPage);
                    ClearText();
                }
                else
                {
                    CommonHelper.showDialog("Mời chọn dòng muốn xóa!", Color.FromArgb(255, 187, 51));
                }
                if (isSuccess)
                {
                    CommonHelper.showDialog("Đã xóa thành công!", Color.FromArgb(4, 132, 75));
                }
            }
            catch (Exception ex)
            {

                CommonHelper.showDialog("Mời chọn dòng muốn xóa!", Color.FromArgb(255, 187, 51));
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvCustomer.Rows[e.RowIndex];
                txtKHID.Text = dgvRow.Cells[0].Value.ToString();
                txtName.Text = dgvRow.Cells[1].Value.ToString();
                txtAddress.Text = dgvRow.Cells[2].Value.ToString();
                txtSodt.Text = dgvRow.Cells[3].Value.ToString();
                txtEmail.Text = dgvRow.Cells[4].Value.ToString();
            }
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber = 1;
                GetAllData(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                GetAllData(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                GetAllData(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                GetAllData(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem.ToString());
            currentPageNumber = 1;
            GetAllData(currentPageNumber, rowPerPage);
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSodtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        }

        private void CustomerManagement1_Load(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllData(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
        }

        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Customer]";
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
        private void GetAllData(int currentPageNumber, int rowPerPage)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "Select KHID, HoTen [Tên Khách Hàng], Diachi [Địa Chỉ], Sodt [Số ĐT], Email from Customer order by Ngaysua DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvCustomer.DataSource = dtMain;
                    dgvCustomer.Columns[0].Visible = false;

                }
            }

        }
    }
}
