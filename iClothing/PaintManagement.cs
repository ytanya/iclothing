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
    public partial class PaintManagement : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        public PaintManagement()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            txtSonID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMota.Text = string.Empty;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                bool isSuccess = false;
                string ngayxong = string.Empty;
                string SonID, Ten, Mota;
                SonID = Ten = Mota = string.Empty;


                if (string.IsNullOrEmpty(txtSonID.Text))
                {
                    // SonID
                    SonID = CommonHelper.RandomString(8);
                    // Ten
                    Ten = txtName.Text;
                    // Mota
                    Mota = txtMota.Text;

                    // Created Date
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    query = "INSERT INTO [Color] ([SonID],[Ten],[Mieuta],[Ngaytao],[Ngaysua])VALUES('" + SonID + "','" + Ten + "','" + Mota + "','" + createDate + "','" + createDate + "')";
                }
                else
                {
                    SonID = txtSonID.Text;
                    string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    // Ten
                    Ten = txtName.Text;
                    // Mota
                    Mota = txtMota.Text;

                    query = "UPDATE [Color] SET[Ten] ='" + Ten + "',[Mieuta]= '" + Mota + "',[Ngaysua]= '" + modifyDate + "' WHERE SonID ='" + SonID + "';";

                }

                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);

                    if (isSuccess)
                    {
                        if (string.IsNullOrEmpty(txtSonID.Text))
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
                if (dgvColor.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvColor.SelectedRows)
                    {

                        string sonID = row.Cells[0].Value.ToString();
                        string query = "DELETE FROM[Color] WHERE SonID = '" + sonID + "'";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        if (!isSuccess) return;
                        dgvColor.Rows.Remove(row);

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

        private void PaintManagement_Load(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllData(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
        }

        private void dgvColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvColor.Rows[e.RowIndex];
                txtSonID.Text = dgvRow.Cells[0].Value.ToString();
                txtName.Text = dgvRow.Cells[1].Value.ToString();
                txtMota.Text = dgvRow.Cells[2].Value.ToString();
            }
        }

        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Color]";
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

            string query = "Select SonID, Ten [Tên], Mieuta [Mô Tả] from Color order by Ngaysua DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvColor.DataSource = dtMain;
                    dgvColor.Columns[0].Visible = false;

                }
            }

        }
    }
}
