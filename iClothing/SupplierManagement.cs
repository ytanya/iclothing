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
    public partial class SupplierManagement : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                bool isSuccess = false;
                string NhaccID, Name, Mota, Address, Sodt, Email;
                NhaccID = Name = Mota= Address = Sodt = Email = string.Empty;


                if (string.IsNullOrEmpty(txtNhaccID.Text))
                {
                    // NhaccID
                    NhaccID = CommonHelper.RandomString(8);
                    // Nha cung ung
                    Name = txtName.Text;
                    // Mota
                    Mota = txtMota.Text;
                    // Address
                    Address = txtAddress.Text;
                    // Sodt
                    Sodt = txtSodt.Text;
                    // Email
                    Email = txtEmail.Text;

                    // Created Date
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    query = "INSERT INTO [Supplier] ([NhaccID],[Ten],[Mota],[Diachi],[Sodt],[Email],[Ngaytao],[Ngaysua])VALUES('" + NhaccID + "','" + Name + "','" +Mota + "','" + Address + "','" + Sodt + "','" + Email + "','" + createDate + "','" + createDate + "')";
                }
                else
                {
                    NhaccID = txtNhaccID.Text;
                    string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                    // Ten khach hang
                    Name = txtName.Text;
                    // Mota
                    Mota = txtMota.Text;
                    // Address
                    Address = txtAddress.Text;
                    // Sodt
                    Sodt = txtSodt.Text;
                    // Email
                    Email = txtEmail.Text;

                    query = "UPDATE [Supplier] SET[Ten] ='" + Name + "',[Mota]= '" + Mota + "',[Diachi]= '" + Address + "',[Sodt]= '" + Sodt + "',[Email]= '" + Email + "',[Ngaysua]= '" + modifyDate + "' WHERE NhaccID ='" + NhaccID + "';";

                }

                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);

                    if (isSuccess)
                    {
                        if (string.IsNullOrEmpty(txtNhaccID.Text))
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
                        MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            try
            {
                if (dgvSupplier.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvSupplier.SelectedRows)
                    {

                        string NhaccID = row.Cells[0].Value.ToString();
                        string query = "DELETE FROM[Supplier] WHERE NhaccID = '" + NhaccID + "'";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        if (!isSuccess) return;
                        dgvSupplier.Rows.Remove(row);

                    }
                    GetTotalRow();
                    GetAllData(1, rowPerPage);
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Mời chọn dòng muốn xóa!");
                }
                if (isSuccess)
                {
                    MessageBox.Show("Đã xóa thành công!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Mời chọn dòng muốn xóa!");
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

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvSupplier.Rows[e.RowIndex];
                txtNhaccID.Text = dgvRow.Cells[0].Value.ToString();
                txtName.Text = dgvRow.Cells[1].Value.ToString();
                txtAddress.Text = dgvRow.Cells[2].Value.ToString();
                txtSodt.Text = dgvRow.Cells[3].Value.ToString();
                txtEmail.Text = dgvRow.Cells[4].Value.ToString();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            txtNhaccID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSodt.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }
        public SupplierManagement()
        {
            InitializeComponent();
        }

        private void SupplierManagement_Load(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllData(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
        }

        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Supplier]";
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

            string query = "Select NhaccID, Ten [Nhà Cung Ứng], Diachi [Địa Chỉ], Sodt [Số ĐT], Email from Supplier order by Ngaysua DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvSupplier.DataSource = dtMain;
                    dgvSupplier.Columns[0].Visible = false;

                }
            }

        }
    }
        

        
    }

