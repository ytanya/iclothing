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
using ExcelDataReader;
using System.Data.SqlServerCe;

namespace iClothing
{
    public partial class ArtManagement1 : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        public ArtManagement1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            txtARTID.Enabled = false;
            txtMaArt.Enabled = false;
            txtMota.Enabled = false;
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
                                    id = txtARTID.Text;
                                    name = txtMaArt.Text;
                                    desc = txtMota.Text;
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
                            foreach (DataGridViewRow row in dgvArt.Rows)
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
                            if (dgvArt.Rows.Count == 0)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                bool isSuccess = false;
                string ngayxong = string.Empty;
                string ARTID, MaART, Mota;
                ARTID = MaART = Mota = string.Empty;


                if (string.IsNullOrEmpty(txtARTID.Text))
                {
                    // ARTID
                    ARTID = CommonHelper.RandomString(8);
                    // MaART
                    MaART = txtMaArt.Text;
                    // Mota
                    Mota = txtMota.Text;

                    // Created Date
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    query = "INSERT INTO [ART] ([ARTID],[Ten],[Mota],[Ngaytao],[Ngaysua])VALUES('" + ARTID + "','" + MaART + "','" + Mota + "','" + createDate + "','" + createDate + "')";
                }
                else
                {
                    ARTID = txtARTID.Text;
                    string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                    // MaART
                    MaART = txtMaArt.Text;
                    // Mota
                    Mota = txtMota.Text;

                    query = "UPDATE [ART] SET[Ten] ='" + MaART + "',[Mota]= '" + Mota + "',[Ngaysua]= '" + modifyDate + "' WHERE ARTID ='" + ARTID + "';";

                }

                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);

                    if (isSuccess)
                    {
                        if (string.IsNullOrEmpty(txtARTID.Text))
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
                if (dgvArt.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvArt.SelectedRows)
                    {

                        string artID = row.Cells[0].Value.ToString();
                        string query = "DELETE FROM[ART] WHERE ARTID = '" + artID + "'";
                        isSuccess = DBAccess.ExecuteQuery(query);
                        if (!isSuccess) return;
                        dgvArt.Rows.Remove(row);

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

        private void ClearText()
        {
            txtARTID.Text = string.Empty;
            txtMaArt.Text = string.Empty;
            txtMota.Text = string.Empty;
            
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

        private void ArtManagement1_Load(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllData(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
        }

        private void dgvArt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvArt.Rows[e.RowIndex];
                txtARTID.Text = dgvRow.Cells[0].Value.ToString();                
                txtMaArt.Text = dgvRow.Cells[1].Value.ToString();
                txtMota.Text = dgvRow.Cells[2].Value.ToString();

            }
        }

        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [ART]";
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

            string query = "Select ARTID, Ten [Tên], Mota [Mô Tả] from ART order by Ngaysua DESC" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dgvArt.DataSource = dtMain;
                    dgvArt.Columns[0].Visible = false;

                }
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

    }
}
