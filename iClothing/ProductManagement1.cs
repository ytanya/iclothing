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
        private DataTable OrignalADGVdt = null;
        private int currentPageNumber = 1;
        private int pageSize = 1;
        private int rowPerPage = 10;
        private string currentOrderByItem = "Kyhieu";
        bool isSuccess = true;
        public string ConnectionString = DBAccess.ConnectionString;
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
                                string Barcode, Kyhieu, MaSP, Dai, Rong,ARTID,SonID,DVT, Mieuta, ngaytao, ngaysua;
                                string InsertItemQry = "";
                                int count = 0;
                                string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

                                for (int i = 7; i < dt.Rows.Count; i++)
                                {

                                    Barcode = CommonHelper.RandomString(14);
                                    Kyhieu= Convert.ToString(dt.Rows[i][1]);
                                    MaSP = Convert.ToString(dt.Rows[i][2]);
                                    Dai = Convert.ToString(dt.Rows[i][3]);
                                    Rong = Convert.ToString(dt.Rows[i][4]);
                                    ARTID = DBHelper.Lookup("ART","ARTID", "Ten",Convert.ToString(dt.Rows[i][5]));
                                    SonID = DBHelper.Lookup("Color", "SonID", "Ten", Convert.ToString(dt.Rows[i][6]));
                                    DVT = Convert.ToString(dt.Rows[i][8]);
                                    Mieuta = string.Empty;
                                    ngaytao = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                                    ngaysua = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                                    if (Kyhieu != "")
                                    {
                                        InsertItemQry = "Insert into Product([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) Values ('" + Barcode + "','" + Kyhieu + "','" + Dai + "','" + Rong +"','" + ARTID + "','" + SonID + "','" +DVT + "','" +"" + "','" + ngaysua + "','"+ ngaytao + "','" + MaSP + "')";
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
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgProduct.DataSource != null)
                {
                    int dai, rong;
                    string barcode, ten, ARTID, SonID, DVT, Mieuta, MaSP, createDate, modifyDate;
                    string InsertItemQry = "";

                    DataRow rd = dtMain.NewRow();

                    // Set value for number field
                    if (string.IsNullOrEmpty(txtDai.Text)) txtDai.Text = "0";
                    if (string.IsNullOrEmpty(txtRong.Text)) txtRong.Text = "0";

                    // Barcode
                    barcode = txtBarcode.Text;
                    rd[0] = barcode;
                    // Ten
                    ten = txtTen.Text;
                    rd[1] = ten;
                    // MaSP
                    MaSP = txtMaSP.Text;
                    rd[2] = MaSP;
                    // Dai
                    dai = Convert.ToInt32(txtDai.Text);
                    rd[3] = dai.ToString();
                    // Rong
                    rong = Convert.ToInt32(txtRong.Text);
                    rd[4] = rong.ToString();
                    // ARTID
                    ARTID = cbArt.SelectedValue.ToString();
                    rd[5] = DBHelper.Lookup("ART", "Ten", "ArtID", ARTID); 
                    // SonID
                    SonID = cbSon.SelectedValue.ToString();
                    rd[6] = DBHelper.Lookup("Color", "Ten", "SonID", SonID);
                    // DVT
                    DVT = txtDVT.Text;
                    rd[7] = DVT;
                    // Mieu ta
                    Mieuta = txtMieuta.Text;
                    rd[8] = Mieuta;
                    
                    // Created Date
                    createDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                    rd[9] = createDate;
                    // Modify Date
                    modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                    //rd[10] = modifyDate;

                    if (barcode != "")
                    {
                        InsertItemQry += "INSERT INTO [Product] ([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[MaSP],[Ngaytao],[Ngaysua])VALUES('" + barcode + "','" + ten + "','" + dai+ "','" +rong + "','" +ARTID+ "','" +SonID+ "','" +DVT+ "','" +Mieuta+ "','" +MaSP+ "','" + createDate + "','" + modifyDate + "');";                     
                    }

                    if (DBAccess.IsServerConnected())
                    {
                        bool isExisted = DBHelper.CheckItemExist("Product", "Barcode", barcode);

                        if (!isExisted)
                        {
                            if (InsertItemQry.Length > 5)
                            {
                                bool isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                                if (isSuccess)
                                {
                                    dtMain.Rows.InsertAt(rd, 0);
                                    currentPageNumber = 1;
                                    countPageSize();
                                    ClearTextBox();
                                    // Update datalist
                                    PopulateData(currentPageNumber, rowPerPage);
                                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Barcode đã tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    
                }

                //Update
                if (dvgProduct.DataSource != null)
                {
                    DataTable dtItem = (DataTable)(dvgProduct.DataSource);
                    int dai, rong;
                    string barcode, ten, ARTID, SonID, DVT, Mieuta, MaSP, createDate, modifyDate;
                    string InsertItemQry = "";
                    int count = 0;
                    var csv = new StringBuilder();
                    // Barcode
                    barcode = txtBarcode.Text;
                    DataRow row = dtMain.Select("[Barcode]=" + barcode, "[Barcode]").FirstOrDefault();

                    // Set value for number field
                    if (string.IsNullOrEmpty(txtDai.Text)) txtDai.Text = "0";
                    if (string.IsNullOrEmpty(txtRong.Text)) txtRong.Text = "0";

                    // Ten
                    ten = txtTen.Text;
                    row[1] = ten;
                    // MaSP
                    MaSP = txtMaSP.Text;
                    row[2] = MaSP;
                    // Dai
                    dai = Convert.ToInt32(txtDai.Text);
                    row[3] = dai.ToString();
                    // Rong
                    rong = Convert.ToInt32(txtRong.Text);
                    row[4] = rong.ToString();
                    // ARTID
                    ARTID = cbArt.SelectedValue.ToString();
                    row[5] = DBHelper.Lookup("ART", "Ten", "ArtID", ARTID);
                    // SonID
                    SonID = cbSon.SelectedValue.ToString();
                    row[6] = DBHelper.Lookup("Color", "Ten", "SonID", SonID);
                    // DVT
                    DVT = txtDVT.Text;
                    row[7] = DVT;
                    // Mieu ta
                    Mieuta = txtMieuta.Text;
                    row[8] = Mieuta;

                    // Modify Date
                    modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                    row[9] = modifyDate;

                    if (ten != "")
                    {
                        InsertItemQry += "UPDATE [Product] SET [Kyhieu] = '" + ten + "',[Dai] = " + dai + ",[Rong] = " + rong + ",[ArtID] = '" + ARTID + "',[SonID] = '" + SonID + "',[DVT] = '" + DVT + "',[Mieuta] = '" + Mieuta + "',[Ngaysua] = '" + modifyDate + "',[MaSP] = '" + MaSP + "' WHERE Barcode ='" + barcode + "';";
                    }

                    if (DBAccess.IsServerConnected())
                    {
                        if (InsertItemQry.Length > 5)
                        {
                            bool isExisted = DBHelper.CheckItemExist("Product", "Barcode", barcode);

                            if (isExisted)
                            {
                                bool isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                                if (isSuccess)
                                {

                                    currentPageNumber = 1;
                                    countPageSize();
                                    ClearTextBox();
                                    // Update datalist
                                    PopulateData(currentPageNumber, rowPerPage);
                                    MessageBox.Show("Sửa sản phẩm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Barcode không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
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
            
            foreach (DataGridViewRow row in dvgProduct.SelectedRows)
            {
                string barcode = row.Cells[0].Value.ToString();
                bool isStockExisted = DBHelper.CheckItemExist("Stock", "Barcode", barcode);
                if (!isStockExisted)
                {
                    string query = "DELETE FROM Product WHERE Barcode ='" + barcode + "';";
                    bool isSuccess = DBAccess.ExecuteQuery(query);
                    if (!isSuccess) return;

                    dvgProduct.Rows.Remove(row);
                    //PopulateData(1, 10);
                    int rowCount = dvgProduct.Rows.Count;
                    pageSize = rowCount / rowPerPage;
                    // if any row left after calculated pages, add one more page 
                    if (rowCount % rowPerPage > 0)
                        pageSize += 1;
                    txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPage.Text = "Tổng số:" + dvgProduct.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Không thể xóa, sản phẩm này còn trong kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            txtTen.Text = string.Empty;
        }

        private void ProductManagement1_Load(object sender, EventArgs e)
        {
            if (DBAccess.IsServerConnected())
            {
                GetAllData();
                PopulateData(currentPageNumber, rowPerPage);
                countPageSize();
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
        }

        private void PopulateData(int currentPageNumber, int rowPerPage)
        {
            
            int skipRecord = (currentPageNumber - 1) * rowPerPage;

            dvgProduct.DataSource = dtMain.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
            dvgProduct.Sort(dvgProduct.Columns["Ngày"], ListSortDirection.Descending);
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

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateData(currentPageNumber, rowPerPage);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                PopulateData(currentPageNumber, rowPerPage);
            }
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateData(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateData(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void dvgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dvgProduct.Rows[e.RowIndex];
                txtBarcode.Text = dgvRow.Cells[0].Value.ToString();
                txtTen.Text = dgvRow.Cells[1].Value.ToString();
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

        

        private void GetAllData()
        {
            string query = "SELECT Barcode, Kyhieu [Ký Hiệu], MASP [Mã Sản Phẩm], Dai [Dài], Rong [Rộng], ART.Ten [ART], Color.Ten [Sơn], DVT, Product.Mieuta [Miêu tả], Product.Ngaysua [Ngày] FROM [Product] Join ART on ART.ArtID = Product.ArtID join Color on Color.SonID = Product.SonID Order by Product.Ngaysua; ";
            dtMain = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                }
            }
            int rowCount = dtMain.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Tổng số:" + dtMain.Rows.Count.ToString();
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();

        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem);
            currentPageNumber = 1;
            PopulateData(currentPageNumber, rowPerPage);
            countPageSize();
        }

        private void countPageSize()
        {
            int rowCount = dtMain.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtDai.Text = string.Empty;
            txtRong.Text = string.Empty;
            txtMaSP.Text = string.Empty;
            txtMieuta.Text = string.Empty;
            txtDVT.Text = string.Empty;
            cbArt.SelectedIndex = -1;
            cbSon.SelectedIndex = -1;
            txtBarcode.Enabled = true;
        }
    }
}
