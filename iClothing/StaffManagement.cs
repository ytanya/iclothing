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
    public partial class StaffManagement : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        public StaffManagement()
        {
            InitializeComponent();
        }

        private void StaffManagement_Load(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllData(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
            // Init Role combobox
            DataTable dtRole = DBHelper.GetAllRole();
            if (dtRole.Rows.Count > 0)
            {
                cbRole.DataSource = dtRole;
                cbRole.ValueMember = "RoleID";
                cbRole.DisplayMember = "Ten";
                cbRole.SelectedIndex = 0;
            }
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                bool isSuccess = false;
                string NhanvienID, Ho, Ten, Address, Sodt, Email, Username, Password, Role;
                NhanvienID = Ho = Ten = Address = Sodt = Email = Username = Password = Role = string.Empty;


                if (string.IsNullOrEmpty(txtNhanvienID.Text))
                {
                    // NhanvienID
                    NhanvienID = CommonHelper.RandomString(8);
                    // Ho
                    Ho = txtHo.Text;
                    // Ten
                    Ten = txtTen.Text;
                    // Address
                    Address = txtAddress.Text;
                    // Sodt
                    Sodt = txtSodt.Text;
                    // Email
                    Email = txtEmail.Text;
                    // Username
                    Username = txtUsername.Text;
                    // Password
                    Password = txtPassword.Text;
                    // Role
                    Role = cbRole.SelectedValue.ToString();
                    // Created Date
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    query = "INSERT INTO [Staff] ([NhanvienID],[Ho],[Ten],[Diachi],[Sodt],[Email],[Tendangnhap],[Matkhau],[RoleID],[Ngaytao],[Ngaysua])VALUES('" + NhanvienID + "','" + Ho + "','" + Ten + "','" + Address + "','" + Sodt + "','" + Email + "','" +Username + "','" +Password + "','" +Role + "','" + createDate + "','" + createDate + "')";
                }
                else
                {
                    NhanvienID = txtNhanvienID.Text;
                    string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                    // Ho
                    Ho = txtHo.Text;
                    // Ten
                    Ten = txtTen.Text;
                    // Address
                    Address = txtAddress.Text;
                    // Sodt
                    Sodt = txtSodt.Text;
                    // Email
                    Email = txtEmail.Text;
                    // Username
                    Username = txtUsername.Text;
                    // Password
                    Password = txtPassword.Text;
                    // Role
                    Role = cbRole.SelectedValue.ToString();

                    query = "UPDATE [Staff] SET[Ho] ='" + Ho + "',[Ten]= '" + Ten + "',[Diachi]= '" + Address + "',[Sodt]= '" + Sodt + "',[Email]= '" + Email + "',[Tendangnhap]= '" + Username + "',[Matkhau]= '" + Password + "',[RoleID]= '" + Role + "',[Ngaysua]= '" + modifyDate + "' WHERE NhanvienID ='" + NhanvienID + "';";

                }

                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);

                    if (isSuccess)
                    {
                        if (string.IsNullOrEmpty(txtNhanvienID.Text))
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
                if (dgvStaff.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvStaff.SelectedRows)
                    {
                        Form1 form1 = new Form1();
                        bool isExisted = DBHelper.CheckItemExist("[Staff]", "Tendangnhap", form1.lblCurrentUser.Text);
                        bool isAmdin = DBHelper.CheckItemExist("[Staff]", "RoleID", "0000001");
                        if (!isAmdin)
                        {
                            if (!isExisted)
                            {
                                string NhanvienID = row.Cells[0].Value.ToString();
                                string query = "DELETE FROM[Staff] WHERE NhanvienID = '" + NhanvienID + "'";
                                isSuccess = DBAccess.ExecuteQuery(query);
                                if (!isSuccess) return;
                                dgvStaff.Rows.Remove(row);
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa, tên truy cập đang sử dụng!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa admin!");
                        }
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



        

        private void dvgStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvStaff.Rows[e.RowIndex];
                txtNhanvienID.Text = dgvRow.Cells[0].Value.ToString();
                txtHo.Text = dgvRow.Cells[1].Value.ToString();
                txtTen.Text = dgvRow.Cells[2].Value.ToString();
                txtAddress.Text = dgvRow.Cells[3].Value.ToString();
                txtSodt.Text = dgvRow.Cells[4].Value.ToString();
                txtEmail.Text = dgvRow.Cells[5].Value.ToString();
                txtUsername.Text = dgvRow.Cells[6].Value.ToString();
                txtPassword.Text = dgvRow.Cells[7].Value.ToString();
                cbRole.SelectedValue = DBHelper.Lookup("Roles", "RoleID", "Ten", dgvRow.Cells[8].Value.ToString());
                cbRole.Text = dgvRow.Cells[8].Value.ToString();
            }
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            txtNhanvienID.Text = string.Empty;
            txtHo.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSodt.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbRole.SelectedIndex = 0;
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

        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Staff]";
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

            string query = "Select NhanvienID, Ho [Họ], Staff.Ten [Tên], Diachi [Địa Chỉ], Sodt [Số ĐT], Email, Tendangnhap [Tên Truy Cập], Matkhau [Mật Khẩu], Roles.Ten [Quyền Truy Cập] from Staff join Roles on Staff.RoleID = Roles.RoleID order by Ngaysua DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvStaff.DataSource = dtMain;
                    dgvStaff.Columns[0].Visible = false;

                }
            }

        }
    }
}
