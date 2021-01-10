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
        public static string ConnectionString = "Data Source=" + ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
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
                string SonId = Convert.ToString(dvgColor.Rows[e.RowIndex].Cells["SonID"].Value);
                string Ten = Convert.ToString(dvgColor.Rows[e.RowIndex].Cells["Ten"].Value);
                string Mieuta = Convert.ToString(dvgColor.Rows[e.RowIndex].Cells["Mieuta"].Value);
                string now = System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
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
                string SonId = Convert.ToString(dvgColor.Rows[e.RowIndex].Cells["SonID"].Value);
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

            dvgColor.AutoGenerateColumns = false;
            dvgColor.DataSource = dtnew;
            int rowCount = dtnew.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Total rows:" + dtnew.Rows.Count.ToString();
            DisablePagingButton(currentPageNumber, pageSize);
        }

        private void dvgColor_SortStringChanged(object sender, EventArgs e)
        {
            ADGV.AdvancedDataGridView fdgv = dvgColor;
            if (fdgv.SortString.Length == 0)
            {
                return;
            }
            string[] strtok = fdgv.SortString.Split(',');            
            currentOrderByItem = String.Join(",", strtok);
            foreach (string str in strtok)
            {
                string[] columnorder = str.Split(']');
                ListSortDirection lds = ListSortDirection.Ascending;
                if (columnorder[1].Trim().Equals("DESC"))
                {
                    lds = ListSortDirection.Descending;
                }
                dvgColor.Sort(dvgColor.Columns[columnorder[0].Replace('[', ' ').Trim()], lds);
            }

        }

        private void dvgColor_FilterStringChanged(object sender, EventArgs e)
        {
            ADGV.AdvancedDataGridView fdgv = dvgColor;
            DataTable dt = null;
            if (OrignalADGVdt == null)
            {
                OrignalADGVdt = (DataTable)fdgv.DataSource;
            }
            else
            {
                int row = OrignalADGVdt.Rows.Count;
                fdgv.DataSource = OrignalADGVdt;
            }
            if (fdgv.FilterString.Length > 0)
            {
                dt = (DataTable)fdgv.DataSource;
            }
            else//Clear Filter
            {
                dt = OrignalADGVdt;
            }

            fdgv.DataSource = dt.Select(fdgv.FilterString).CopyToDataTable();
            //BindingSource filter = (BindingSource)this.dvgColor.DataSource;
            //filter.Filter = this.dvgColor.FilterString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgColor.DataSource != null)
                {
                    DataTable dtItem = (DataTable)(dvgColor.DataSource);
                    string id, name, desc, createDate, modifyDate;
                    string InsertItemQry = "";
                    int count = 0;
                    var csv = new StringBuilder();
                    //foreach (DataRow dr in dtItem.Rows)
                    //{
                    id = txtSonID.Text;
                    name = txtTen.Text;
                    desc = txtMieuta.Text;
                    createDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    modifyDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
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
                DataGridViewRow dgvRow = dvgColor.Rows[e.RowIndex];
                txtSonID.Text = dgvRow.Cells[0].Value.ToString();
                txtSonID.Enabled = false;
                txtTen.Text = dgvRow.Cells[1].Value.ToString();
                txtMieuta.Text = dgvRow.Cells[2].Value.ToString();
                btnSave.Enabled = false;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            txtSonID.Enabled = false;
            txtTen.Enabled = false;
            txtMieuta.Enabled = false;
            btnSave.Enabled = false;

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";

                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".xlsx"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = CSVHelper.GetDataTabletFromCSVFile(dialog.FileName, "");
                        if (Convert.ToString(dtNew.Columns[0]).ToLower() != "MaSon")
                        {
                            MessageBox.Show("File bị lỗi!");
                            btnSave.Enabled = false;
                            return;
                        }
                        txtFile.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dvgColor.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dvgColor.Rows)
                        {
                            if (Convert.ToString(row.Cells["MaSon"].Value) == "" || row.Cells["Ten"].Value == null)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dvgColor.Rows.Count == 0)
                        {
                            btnSave.Enabled = false;
                            MessageBox.Show("Không đọc được dữ liệu trong file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn file excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
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
    }
}
