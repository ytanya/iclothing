using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace iClothing
{
    public partial class ColorManagement : UserControl
    {
        private DataTable dt = new DataTable();
        private DataTable dtnew = new DataTable();
        private DataTable OrignalADGVdt = null;
        private int currentPageNumber = 1;
        private int pageSize = 1;
        private int rowPerPage=10;
        private string currentOrderByItem = "SonID";
        public string ConnectionString = DBAccess.ConnectionString;
        public ColorManagement()
        {
            InitializeComponent();
        }

        public void ColorManagement_Load(object sender, EventArgs e)
        {
            //if (DBAccess.IsServerConnected())
            //{
            //    PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
            //}
            //else
            //{
            //    //string query = "Select `SonID,`Ten`.`MieuTa`,`NgayTao`,`NgaySua` from `Color`";
            //}
        }

        private void dvgColor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string SonId = Convert.ToString(dgvColor.Rows[e.RowIndex].Cells["SonID"].Value);
                string Ten = Convert.ToString(dgvColor.Rows[e.RowIndex].Cells["Ten"].Value);
                string Mieuta = Convert.ToString(dgvColor.Rows[e.RowIndex].Cells["Mieuta"].Value);
                string now = System.DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                if (!string.IsNullOrEmpty(SonId))
                {
                    string query = "UPDATE Color SET Ten = '" + Ten + "',Mieuta = '" + Mieuta + "',Ngaytao = '" + now + "',Ngaysua = '" + now + "' WHERE SonID= " + SonId;
                    //bool isSuccess = DBAccess.ExecuteQuery(query);
                    //if (isSuccess)
                    //{
                    //    PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
                    //    lblMess.Text = " Ban da sua thanh cong SonID: " + SonId;
                    //}
                }

            }
            if (e.ColumnIndex == 6)
            {
                string SonId = Convert.ToString(dgvColor.Rows[e.RowIndex].Cells["SonID"].Value);
                if (!string.IsNullOrEmpty(SonId))
                {
                    string query = "DELETE FROM Color WHERE SonID= " + SonId;
                    //bool isSuccess = DBAccess.ExecuteQuery(query);
                    //if (isSuccess)
                    //{
                    //    PopulateData(currentPageNumber, pageSize, currentOrderByItem);
                    //    lblMess.Text = " Ban da xoa thanh cong SonID: " + SonId;
                    //}
                }
            }
        }

        private void PopulateData(int currentPageNumber, int rowPerPage, string orderbyItem)
        {
            int skipRecord = currentPageNumber-1;
            if (skipRecord != 0) skipRecord= currentPageNumber* rowPerPage;
            string query = "SELECT SonID, Ten, Mieuta, Ngaytao, Ngaysua FROM Color Order by " + orderbyItem + " OFFSET " + skipRecord.ToString() +" ROWS FETCH NEXT " + rowPerPage.ToString() +" ROWS ONLY; ";
            dt = new DataTable();
            dtnew = new DataTable();
            //dtnew = DBAccess.FillDataTable(query, dt);

            dgvColor.AutoGenerateColumns = false;
            dgvColor.DataSource = dtnew;
            int rowCount = dtnew.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Tổng số:" + dtnew.Rows.Count.ToString();
            DisablePagingButton(currentPageNumber, pageSize);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvColor.DataSource != null)
                {
                    DataTable dtItem = (DataTable)(dgvColor.DataSource);
                    string id, name, desc, createDate, modifyDate;
                    string InsertItemQry = "";
                    int count = 0;
                    var csv = new StringBuilder();
                    //foreach (DataRow dr in dtItem.Rows)
                    //{
                    id = txtSonID.Text;
                    name = txtName.Text;
                    desc = txtMota.Text;
                    createDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                    modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                    if (id != "")
                    {
                        InsertItemQry += "INSERT INTO [Color] (SonID,Ten,Mieuta,Ngaytao,Ngaysua)VALUES('" + id + "','" + name + "','" + desc + "','" + createDate + "','" + modifyDate + "');";
                        //var newLine = $"{id},{name},{desc},{createDate},{modifyDate}";
                        //csv.AppendLine(newLine);
                        //count++;
                    }
                    //
                    //if (DBAccess.IsServerConnected())
                    //{
                    //    if (InsertItemQry.Length > 5)
                    //    {
                    //        bool isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                    //        if (isSuccess)
                    //        {
                    //            MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    File.AppendAllText(pathCSV, csv.ToString());
                    //    MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    // Update datalist
                    PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtSonID.Text;
            if (!string.IsNullOrEmpty(id))
            {
                string query = "DELETE FROM Color WHERE SonID ='" + id + "';";
                //if (DBAccess.IsServerConnected())
                //{
                //    if (query.Length > 5)
                //    {
                //        bool isSuccess = DBAccess.ExecuteQuery(query);
                //        if (isSuccess)
                //        {
                //            MessageBox.Show("Số sản phẩm đã nhập Thành công: ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //        // Update datalist
                //        PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
                //    }
                //}

            }
        }

        private void dvgColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvColor.Rows[e.RowIndex];
                txtSonID.Text = dgvRow.Cells[0].Value.ToString();
                txtSonID.Enabled = false;
                txtName.Text = dgvRow.Cells[1].Value.ToString();
                txtMota.Text = dgvRow.Cells[2].Value.ToString();
                btnSave.Enabled = false;
            }
        }

        

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedpageSize = (string)comboBox.SelectedItem;
            //PopulatePager(selectedpageSize, pageNumber);
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            currentPageNumber -= 1;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            currentPageNumber += 1;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            currentPageNumber = pageSize;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        void DisablePagingButton(int currentPageNumber, int pageSize)
        {
            // Show all paging button
            ShowAllPagingButton();

            // Disable First and Previous button if it's the first page
            if (currentPageNumber == 1)
            {
                pbFirst.Enabled = false;
                pbPrev.Enabled = false;
            }
            // Disable Last and Next button if it's the last page
            if (currentPageNumber == pageSize)
            {
                pbLast.Enabled = false;
                pbNext.Enabled = false;
            }
                
        }

        void ShowAllPagingButton()
        {
            pbFirst.Enabled = true;
            pbPrev.Enabled = true;
            pbLast.Enabled = true;
            pbNext.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }
    }
}
