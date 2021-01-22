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
using System.Configuration;

namespace iClothing
{
    public partial class ProductManagement1 : UserControl
    {
        private DataTable dtMain = new DataTable();
        private DataTable dtCurrent = new DataTable();
        bool isSuccess = true;
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        public ProductManagement1()
        {
            InitializeComponent();
            cbPageSize.SelectedText = "10";
            txtBarcode.Enabled = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
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
                                string Barcode, Kyhieu, MaSP, Dai, Rong, ARTID, SonID, DVT, Mieuta, ngaytao, ngaysua;
                                string InsertItemQry = "";
                                int count = 0;
                                string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

                                for (int i = 7; i < dt.Rows.Count; i++)
                                {

                                    Barcode = CommonHelper.RandomString(14);
                                    Kyhieu = Convert.ToString(dt.Rows[i][1]);
                                    MaSP = Convert.ToString(dt.Rows[i][2]);
                                    Dai = Convert.ToString(dt.Rows[i][3]);
                                    Rong = Convert.ToString(dt.Rows[i][4]);
                                    ARTID = DBHelper.Lookup("ART", "ARTID", "Ten", Convert.ToString(dt.Rows[i][5]).Trim('\''));
                                    SonID = DBHelper.Lookup("Color", "SonID", "Ten", Convert.ToString(dt.Rows[i][6]).Trim('\''));
                                    DVT = Convert.ToString(dt.Rows[i][8]);
                                    Mieuta = string.Empty;
                                    ngaytao = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                                    ngaysua = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                                    if (Kyhieu != "")
                                    {
                                        InsertItemQry = "Insert into Product([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) Values ('" + Barcode + "','" + Kyhieu + "','" + Dai + "','" + Rong + "','" + ARTID + "','" + SonID + "','" + DVT + "','" + "" + "','" + ngaysua + "','" + ngaytao + "','" + MaSP + "')";
                                        if (DBAccess.IsServerConnected())
                                        {
                                            if (InsertItemQry.Length > 5)
                                            {
                                                isSuccess = DBAccess.ExecuteQuery(InsertItemQry);

                                            }
                                        }
                                    }
                                }

                            }
                            if (isSuccess)
                            {

                                MessageBox.Show("Import file thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Import file không thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("File không đúng format! Format Đúng: Dữ liệu bắt đầu từ dòng 7, cột 1: Ký Hiệu, cột 2: Mã SP, cột 3: Dài, cột 4: Rộng, cột 5: ART, cột 6: SON, cột 8:DVT ");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                bool isSuccess = false;
                string Barcode, Kyhieu, Dai, Rong, ARTID, SonID, DVT, MaSP, Mieuta;
                Barcode = Kyhieu = Dai = Rong = ARTID = SonID = DVT = MaSP = Mieuta = string.Empty;

                // Set value for number field
                if (string.IsNullOrEmpty(txtDai.Text)) txtDai.Text = "0";
                if (string.IsNullOrEmpty(txtRong.Text)) txtRong.Text = "0";


                // Barcode
                Barcode = txtBarcode.Text;
                //Kyhieu
                Kyhieu = txtKyhieu.Text;
                Dai = txtDai.Text;
                Rong = txtRong.Text;
                ARTID = cbArt.SelectedValue.ToString();
                SonID = cbSon.SelectedValue.ToString();
                DVT = txtDVT.Text;
                MaSP = txtMaSP.Text;
                Mieuta = txtMieuta.Text;

                string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                query = "UPDATE [Product] SET[Kyhieu] ='" + Kyhieu + "',[Dai]= '" + Dai + "',[Rong]= '" + Rong + "',[ARTID]= '" + ARTID + "',[SonID]= '" + SonID + "',[DVT]= '" + DVT + "',[Mieuta]= '" + Mieuta + "',[Ngaysua]= '" + modifyDate + "' WHERE Barcode ='" + Barcode + "';";


                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);
                }


                if (isSuccess)
                {
                    cbSon.SelectedIndex = 0;
                    cbArt.SelectedIndex = 0;
                    currentPageNumber = 1;
                    ClearText();
                    // Update datalist
                    GetAllDataOrder(currentPageNumber, rowPerPage);
                    MessageBox.Show("Đã cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void ClearText()
        {
            txtBarcode.Text = string.Empty;
            txtKyhieu.Text = string.Empty;
            txtMaSP.Text = string.Empty;
            txtDai.Text = string.Empty;
            txtRong.Text = string.Empty;
            cbArt.SelectedIndex = 0;
            cbSon.SelectedIndex = 0;
            txtMieuta.Text = string.Empty;
            txtDVT.Text = string.Empty;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (dvgProduct.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dvgProduct.SelectedRows)
                {
                    string barcode = row.Cells[0].Value.ToString();

                    string orderID = row.Cells[0].Value.ToString();
                    string query = "DELETE FROM Product WHERE Barcode ='" + barcode + "';";
                    isSuccess = DBAccess.ExecuteQuery(query);
                    if (!isSuccess) return;
                    dvgProduct.Rows.Remove(row);
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

        private void ClearTextBox()
        {
            txtBarcode.Text = string.Empty;
            txtBarcode.Enabled = true;
            txtDai.Text = string.Empty;
            txtRong.Text = string.Empty;
            txtDVT.Text = string.Empty;
            txtMaSP.Text = string.Empty;
            txtMieuta.Text = string.Empty;
            txtKyhieu.Text = string.Empty;
        }

        private void ProductManagement1_Load(object sender, EventArgs e)
        {
            GetAllInitData();
        }

        private void GetAllInitData()
        {
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllDataOrder(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
            // Init Color combobox
            DataTable dtColor = DBHelper.GetAllColor();
            if (dtColor.Rows.Count > 0)
            {
                cbSon.DataSource = dtColor;
                cbSon.ValueMember = "SonID";
                cbSon.DisplayMember = "Ten";
                cbSon.SelectedIndex = 0;
            }

            // Init Art combobox
            DataTable dtArt = DBHelper.GetAllArt();
            if (dtArt.Rows.Count > 0)
            {
                cbArt.DataSource = dtArt;
                cbArt.ValueMember = "ARTID";
                cbArt.DisplayMember = "Ten";
                cbArt.SelectedIndex = 0;
            }
        }
        private void GetTotalRow()
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Product]";
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
                    if (pageSize >0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPage.Text = "Tổng số:" + rowCount.ToString();
                }
            }
        }
        private void GetAllDataOrder(int currentPageNumber, int rowPerPage)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "SELECT Barcode, Kyhieu [Ký Hiệu], MASP [Mã Sản Phẩm], Dai [Dài], Rong [Rộng], ART.Ten [ART], Color.Ten [Sơn], DVT, Product.Mieuta [Miêu tả] FROM [Product] Join ART on ART.ArtID = Product.ArtID join Color on Color.SonID = Product.SonID Order by Product.Ngaysua " + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dvgProduct.DataSource = dtMain;
                    dvgProduct.Columns["Dài"].Width = 60;
                    this.dvgProduct.Columns["Dài"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgProduct.Columns["Rộng"].Width = 60;
                    this.dvgProduct.Columns["Rộng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
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

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                GetAllDataOrder(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                GetAllDataOrder(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void dvgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dvgProduct.Rows[e.RowIndex];
                txtBarcode.Text = dgvRow.Cells[0].Value.ToString();
                txtKyhieu.Text = dgvRow.Cells[1].Value.ToString();
                txtMaSP.Text = dgvRow.Cells[2].Value.ToString();
                txtDai.Text = dgvRow.Cells[3].Value.ToString();
                txtRong.Text = dgvRow.Cells[4].Value.ToString();
                cbArt.Text = dgvRow.Cells[5].Value.ToString();
                cbArt.SelectedValue = DBHelper.Lookup("Art", "ArtID", "Ten", dgvRow.Cells[5].Value.ToString());
                cbSon.Text = dgvRow.Cells[6].Value.ToString();
                cbSon.SelectedValue = DBHelper.Lookup("Color", "SonID", "Ten", dgvRow.Cells[6].Value.ToString());
                txtDVT.Text = dgvRow.Cells[7].Value.ToString();
                txtMieuta.Text = dgvRow.Cells[8].Value.ToString();

                txtBarcode.Enabled = false;

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
            if (pageSize > 0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }




        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!txtBarcode.Enabled)
            {
                if (MessageBox.Show("Bạn có muốn tạo mới không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    txtBarcode.Text = CommonHelper.RandomString(14);
                    CreateNew();
                }
                else
                {
                    ClearText();
                }
            }
            else
            {
                CreateNew();
            }
        }

        private void CreateNew()
        {
            string query = "";
            bool isSuccess = false;
            string Barcode, Kyhieu, Dai, Rong, ARTID, SonID, DVT, MaSP, Mieuta;
            Barcode = Kyhieu = Dai = Rong = ARTID = SonID = DVT = MaSP = Mieuta = string.Empty;

            // Set value for number field
            if (string.IsNullOrEmpty(txtDai.Text)) txtDai.Text = "0";
            if (string.IsNullOrEmpty(txtRong.Text)) txtRong.Text = "0";


            // Barcode
            if (string.IsNullOrEmpty(txtBarcode.Text)) Barcode = CommonHelper.RandomString(14);
            else Barcode = txtBarcode.Text;
            //Kyhieu
            Kyhieu = txtKyhieu.Text;
            Dai = txtDai.Text;
            Rong = txtRong.Text;
            ARTID = cbArt.SelectedValue.ToString();
            SonID = cbSon.SelectedValue.ToString();
            DVT = txtDVT.Text;
            MaSP = txtMaSP.Text;
            Mieuta = txtMieuta.Text;
            // Created Date
            string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

            query = "Insert into Product([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) Values ('" + Barcode + "','" + Kyhieu + "','" + Dai + "','" + Rong + "','" + ARTID + "','" + SonID + "','" + DVT + "','" + Mieuta + "','" + createDate + "','" + createDate + "','" + MaSP + "')";
            if (DBAccess.IsServerConnected())
            {

                isSuccess = DBAccess.ExecuteQuery(query);

                if (isSuccess)
                {
                    cbSon.SelectedIndex = 0;
                    cbArt.SelectedIndex = 0;
                    currentPageNumber = 1;
                    ClearText();
                    // Update datalist
                    GetTotalRow();
                    GetAllDataOrder(currentPageNumber, rowPerPage);

                    MessageBox.Show("Đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void txtDai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
