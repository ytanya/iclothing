﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;

namespace iClothing
{
    public partial class ArtManagement : UserControl
    {
        private System.Data.DataTable dt = new System.Data.DataTable();
        private System.Data.DataTable dtnew = new System.Data.DataTable();
        private System.Data.DataTable OrignalADGVdt = null;
        private int currentPageNumber = 1;
        private int pageSize = 1;
        private int rowPerPage = 10;
        private string currentOrderByItem = "ARTID";
        public ArtManagement()
        {
            InitializeComponent();
        }

        private void ArtManagement_Load(object sender, EventArgs e)
        {
            if (DBAccess.IsServerConnected())
            {
                PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            txtArtID.Enabled = false;
            txtTen.Enabled = false;
            txtMieuta.Enabled = false;
            btnSave.Enabled = false;

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            IExcelDataReader reader;
                            if (ofd.FilterIndex == 2)
                            {
                                reader = ExcelReaderFactory.CreateBinaryReader(stream);
                            }
                            else
                            {
                                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            }

                            DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            foreach (System.Data.DataTable dt in ds.Tables)
                            {
                                if (Convert.ToString(dt.Columns[0]).ToLower() != "ART")
                                {
                                    MessageBox.Show("File bị lỗi!");
                                    btnSave.Enabled = false;
                                    return;
                                }
                                else
                                {
                                    string id, name, desc, createDate, modifyDate;
                                    string InsertItemQry = "";
                                    int count = 0;
                                    var csv = new StringBuilder();
                                    //foreach (DataRow dr in dtItem.Rows)
                                    //{
                                    id = txtArtID.Text;
                                    name = txtTen.Text;
                                    desc = txtMieuta.Text;
                                    createDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                                    modifyDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                                    if (id != "")
                                    {
                                        InsertItemQry += "INSERT INTO [ART] (ARTID,Ten,Mota,Anh, Ngaytao,Ngaysua)VALUES('" + id + "','" + name + "','" + desc + "','" + null + "','" + createDate + "','" + modifyDate + "');";
                                        //var newLine = $"{id},{name},{desc},{createDate},{modifyDate}";
                                        //csv.AppendLine(newLine);
                                        //count++;
                                    }
                                    //
                                    if (DBAccess.IsServerConnected())
                                    {
                                        if (InsertItemQry.Length > 5)
                                        {
                                            bool isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                                            if (isSuccess)
                                            {
                                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            reader.Close();

                        }
                    }

                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.ShowDialog();
                    int ImportedRecord = 0, inValidItem = 0;
                    string SourceURl = "";

                    if (dialog.FileName != "")
                    {
                        if (dialog.FileName.EndsWith(".xlsx"))
                        {

                            //dtNew = CSVHelper.GetDataTabletFromCSVFile(dialog.FileName, "");
                            //if (Convert.ToString(dtNew.Columns[0]).ToLower() != "ART")
                            //{
                            //    MessageBox.Show("File bị lỗi!");
                            //    btnSave.Enabled = false;
                            //    return;
                            //}
                            //txtFile.Text = dialog.SafeFileName;
                            //SourceURl = dialog.FileName;
                            //if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                            //{
                            //    dvgArt.DataSource = dtNew;
                            //}
                            foreach (DataGridViewRow row in dvgArt.Rows)
                            {
                                if (Convert.ToString(row.Cells["ART"].Value) == "")
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red;
                                    inValidItem += 1;
                                }
                                else
                                {
                                    ImportedRecord += 1;
                                }
                            }
                            if (dvgArt.Rows.Count == 0)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgArt.DataSource != null)
                {
                    //DataTable dtItem = (DataTable)(dvgArt.DataSource);
                    string id, name, desc, createDate, modifyDate;
                    string InsertItemQry = "";
                    int count = 0;
                    var csv = new StringBuilder();
                    //foreach (DataRow dr in dtItem.Rows)
                    //{
                    id = txtArtID.Text;
                    name = txtTen.Text;
                    desc = txtMieuta.Text;
                    createDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    modifyDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    if (id != "")
                    {
                        InsertItemQry += "INSERT INTO [ART] (ARTID,Ten,Mota,Anh, Ngaytao,Ngaysua)VALUES('" + id + "','" + name + "','" + desc + "','"+ null +"','" + createDate + "','" + modifyDate + "');";
                        //var newLine = $"{id},{name},{desc},{createDate},{modifyDate}";
                        //csv.AppendLine(newLine);
                        //count++;
                    }
                    //
                    if (DBAccess.IsServerConnected())
                    {
                        if (InsertItemQry.Length > 5)
                        {
                            bool isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                            if (isSuccess)
                            {
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
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
            string id = txtArtID.Text;
            if (!string.IsNullOrEmpty(id))
            {
                string query = "DELETE FROM Art WHERE ARTID ='" + id + "';";
                if (DBAccess.IsServerConnected())
                {
                    if (query.Length > 5)
                    {
                        bool isSuccess = DBAccess.ExecuteQuery(query);
                        if (isSuccess)
                        {
                            MessageBox.Show("Số sản phẩm đã nhập Thành công: ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // Update datalist
                        PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
                    }
                }

            }
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

        

        private void PopulateData(int currentPageNumber, int rowPerPage, string orderbyItem)
        {
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = currentPageNumber * rowPerPage;
            string query = "SELECT ARTID, Ten, Mota, Anh, Ngaytao, Ngaysua FROM Art Order by " + orderbyItem + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            //dt = new DataTable();
            //dtnew = new DataTable();
            dtnew = DBAccess.FillDataTable(query, dt);

            dvgArt.AutoGenerateColumns = false;
            dvgArt.DataSource = dtnew;
            int rowCount = dtnew.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Total rows:" + dtnew.Rows.Count.ToString();
            DisablePagingButton(currentPageNumber, pageSize);
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

        private void dvgArt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dvgArt.Rows[e.RowIndex];
                txtArtID.Text = dgvRow.Cells[0].Value.ToString();
                txtArtID.Enabled = false;
                txtTen.Text = dgvRow.Cells[1].Value.ToString();
                txtMieuta.Text = dgvRow.Cells[2].Value.ToString();
                btnSave.Enabled = false;
            }
        }

        private void dvgArt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string ARTID = Convert.ToString(dvgArt.Rows[e.RowIndex].Cells["ARTID"].Value);
                string Ten = Convert.ToString(dvgArt.Rows[e.RowIndex].Cells["Ten"].Value);
                string Mieuta = Convert.ToString(dvgArt.Rows[e.RowIndex].Cells["Mota"].Value);
                string now = System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                if (!string.IsNullOrEmpty(ARTID))
                {
                    string query = "UPDATE ART SET Ten = '" + Ten + "',Mota = '" + Mieuta + "',Ngaytao = '" + now + "',Ngaysua = '" + now + "' WHERE SonID= " + ARTID;
                    bool isSuccess = DBAccess.ExecuteQuery(query);
                    if (isSuccess)
                    {
                        PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
                        lblMess.Text = " Ban da sua thanh cong ARTID: " + ARTID;
                    }
                }

            }
            if (e.ColumnIndex == 6)
            {
                string ARTID = Convert.ToString(dvgArt.Rows[e.RowIndex].Cells["ARTID"].Value);
                if (!string.IsNullOrEmpty(ARTID))
                {
                    string query = "DELETE FROM ART WHERE ARTID= " + ARTID;
                    bool isSuccess = DBAccess.ExecuteQuery(query);
                    if (isSuccess)
                    {
                        PopulateData(currentPageNumber, pageSize, currentOrderByItem);
                        lblMess.Text = " Ban da xoa thanh cong ARTID: " + ARTID;
                    }
                }
            }
        }
    }
}
