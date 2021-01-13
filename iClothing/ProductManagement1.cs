using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
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
        public static string conn = "Data Source=" + ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
        public ProductManagement1()
        {
            InitializeComponent();
            cbPageSize.SelectedText = "10";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
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
                                //if (Convert.ToString(dt.Columns[5]).ToUpper() != "ART")
                                //{
                                //    MessageBox.Show("Invalid Items File");
                                //    btnSave.Enabled = false;
                                //    return;
                                //}

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
                                    ngaytao = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                                    ngaysua = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
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
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : ", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Khong Thành công, Số sản phẩm đã nhập : ", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                if (dvgProduct.DataSource != null)
                {
                    List<DBModel> dbModels = new List<DBModel>();
                    DBModel itemModel = new DBModel();
                    DataTable dtItem = (DataTable)(dvgProduct.DataSource);
                    int dai, rong;
                    string barcode, ten, ARTID, SonID, DVT, Mieuta, MaSP, createDate, modifyDate;
                    string InsertItemQry = "";
                    int count = 0;
                    var csv = new StringBuilder();
                    //foreach (DataRow dr in dtItem.Rows)
                    //{
                    // Barcode
                    barcode = txtBarcode.Text;
                    itemModel.text = "Barcode";
                    itemModel.value = barcode;
                    itemModel.type = "string";
                    dbModels.Add(itemModel);
                    // Ten
                    itemModel = new DBModel();
                    ten = txtTen.Text;
                    itemModel.text = "Kyhieu";
                    itemModel.type = "string";
                    itemModel.value = ten;
                    dbModels.Add(itemModel);
                    // Dai
                    itemModel = new DBModel();
                    dai = Convert.ToInt32(txtDai.Text);
                    itemModel.text = "Dai";
                    itemModel.type = "int";
                    itemModel.value = dai.ToString();
                    dbModels.Add(itemModel);
                    // Rong
                    itemModel = new DBModel();
                    rong = Convert.ToInt32(txtRong.Text);
                    itemModel.text = "Rong";
                    itemModel.value = rong.ToString();
                    itemModel.type = "int";
                    dbModels.Add(itemModel);
                    // ARTID
                    itemModel = new DBModel();
                    ARTID = cbArt.SelectedValue.ToString();
                    itemModel.text = "ArtID";
                    itemModel.value = ARTID;
                    itemModel.type = "string";
                    dbModels.Add(itemModel);
                    // SonID
                    itemModel = new DBModel();
                    SonID = cbSon.SelectedValue.ToString();
                    itemModel.text = "SonID";
                    itemModel.value = SonID;
                    itemModel.type = "string";
                    dbModels.Add(itemModel);
                    // DVT
                    itemModel = new DBModel();
                    DVT = txtDVT.Text;
                    itemModel.text = "DVT";
                    itemModel.value = DVT;
                    itemModel.type = "string";
                    dbModels.Add(itemModel);
                    // Mieu ta
                    itemModel = new DBModel();
                    Mieuta = txtMieuta.Text;
                    itemModel.text = "Mieuta";
                    itemModel.value = Mieuta;
                    itemModel.type = "string";
                    dbModels.Add(itemModel);
                    // MaSP
                    itemModel = new DBModel();
                    MaSP = txtMaSP.Text;
                    itemModel.text = "MaSP";
                    itemModel.value = MaSP;
                    itemModel.type = "string";
                    dbModels.Add(itemModel);
                    // Created Date
                    itemModel = new DBModel();
                    createDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    itemModel.text = "Ngaytao";
                    itemModel.value = createDate;
                    itemModel.type = "datetime";
                    dbModels.Add(itemModel);
                    // Modify Date
                    itemModel = new DBModel();
                    modifyDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    itemModel.text = "Ngaysua";
                    itemModel.value = modifyDate;
                    itemModel.type = "datetime";

                    dbModels.Add(itemModel);
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
                                    dtMain = DBHelper.InsertDatatable(dtMain, dbModels);
                                    currentPageNumber = 1;
                                    countPageSize();
                                    // Update datalist
                                    PopulateData(currentPageNumber, rowPerPage);
                                    MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Barcode da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBModel modelWhere = new DBModel();
            string barcode = txtBarcode.Text;

            if (!string.IsNullOrEmpty(barcode))
            {
                string query = "DELETE FROM Product WHERE Barcode ='" + barcode + "';";
                if (DBAccess.IsServerConnected())
                {
                    // Barcode
                    modelWhere.text = "Barcode";
                    modelWhere.value = barcode;
                    modelWhere.type = "string";

                    if (query.Length > 5)
                    {
                        bool isExisted = DBHelper.CheckItemExist("Product", "Barcode", barcode);

                        if (isExisted)
                        {
                            bool isSuccess = DBAccess.ExecuteQuery(query);
                            if (isSuccess)
                            {
                                dtMain = DBHelper.DeleteDatatable(dtMain, modelWhere);
                                currentPageNumber = 1;
                                countPageSize();
                                MessageBox.Show("Số sản phẩm đã nhập Thành công: ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            // Update datalist
                            PopulateData(currentPageNumber, rowPerPage);
                        }
                        else
                        {
                            MessageBox.Show("Barcode khong ton tai ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
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
            if (currentPageNumber > 0)
            {
                currentPageNumber -= 1;
                PopulateData(currentPageNumber, rowPerPage);
            }
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            currentPageNumber += 1;
            PopulateData(currentPageNumber, rowPerPage);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            currentPageNumber = pageSize;
            PopulateData(currentPageNumber, rowPerPage);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void dvgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dvgProduct.Rows[e.RowIndex];
                txtBarcode.Text = dgvRow.Cells[0].Value.ToString();
                txtTen.Text = dgvRow.Cells[1].Value.ToString();
                txtDai.Text = dgvRow.Cells[2].Value.ToString();
                txtRong.Text = dgvRow.Cells[3].Value.ToString();
                cbArt.Text = dgvRow.Cells[4].Value.ToString();
                cbArt.SelectedValue = dgvRow.Cells[4].Value.ToString();
                cbSon.Text = DBHelper.Lookup("Color", "Ten", "SonID", dgvRow.Cells[5].Value.ToString());
                cbSon.SelectedValue = dgvRow.Cells[5].Value.ToString();
                txtDVT.Text = dgvRow.Cells[6].Value.ToString();
                txtMieuta.Text = dgvRow.Cells[7].Value.ToString();
                txtMaSP.Text = dgvRow.Cells[10].Value.ToString();
                txtBarcode.Enabled = false;

                btnAdd.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        private void dvgProduct_FilterStringChanged(object sender, EventArgs e)
        {
            ADGV.AdvancedDataGridView fdgv = dvgProduct;
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
        }

        private void dvgProduct_SortStringChanged(object sender, EventArgs e)
        {
            ADGV.AdvancedDataGridView fdgv = dvgProduct;
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
                dvgProduct.Sort(dvgProduct.Columns[columnorder[0].Replace('[', ' ').Trim()], lds);
            }
        }

        private void GetAllData()
        {
            string query = "SELECT * FROM [Product] Order by " + currentOrderByItem + "; ";
            dtMain = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                }
            }
            lblTotalPage.Text = "Total rows:" + dtMain.Rows.Count.ToString();
            
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgProduct.DataSource != null)
                {
                    List<DBModel> dbModelsUpdate = new List<DBModel>();
                    DBModel itemModelUpdate = new DBModel();
                    DBModel modelWhere = new DBModel();
                    DataTable dtItem = (DataTable)(dvgProduct.DataSource);
                    int dai, rong;
                    string barcode, ten, ARTID, SonID, DVT, Mieuta, MaSP, createDate, modifyDate;
                    string InsertItemQry = "";
                    int count = 0;
                    var csv = new StringBuilder();
                    // Barcode
                    barcode = txtBarcode.Text;
                    modelWhere.text = "Barcode";
                    modelWhere.value = barcode;
                    modelWhere.type = "string";

                    // Ten
                    itemModelUpdate = new DBModel();
                    ten = txtTen.Text;
                    itemModelUpdate.text = "Kyhieu";
                    itemModelUpdate.value = ten;
                    itemModelUpdate.type = "string";
                    dbModelsUpdate.Add(itemModelUpdate);
                    // Dai
                    itemModelUpdate = new DBModel();
                    dai = Convert.ToInt32(txtDai.Text);
                    itemModelUpdate.text = "Dai";
                    itemModelUpdate.type = "int";
                    itemModelUpdate.value = dai.ToString();
                    dbModelsUpdate.Add(itemModelUpdate);
                    // Rong
                    itemModelUpdate = new DBModel();
                    rong = Convert.ToInt32(txtRong.Text);
                    itemModelUpdate.text = "Rong";
                    itemModelUpdate.value = rong.ToString();
                    itemModelUpdate.type = "int";
                    dbModelsUpdate.Add(itemModelUpdate);
                    // ARTID
                    itemModelUpdate = new DBModel();
                    ARTID = cbArt.SelectedValue.ToString();
                    itemModelUpdate.text = "ArtID";
                    itemModelUpdate.value = ARTID;
                    itemModelUpdate.type = "string";
                    dbModelsUpdate.Add(itemModelUpdate);
                    // SonID
                    itemModelUpdate = new DBModel();
                    SonID = cbSon.SelectedValue.ToString();
                    itemModelUpdate.text = "SonID";
                    itemModelUpdate.value = SonID;
                    itemModelUpdate.type = "string";
                    dbModelsUpdate.Add(itemModelUpdate);
                    // DVT
                    itemModelUpdate = new DBModel();
                    DVT = txtDVT.Text;
                    itemModelUpdate.text = "DVT";
                    itemModelUpdate.value = DVT;
                    itemModelUpdate.type = "string";
                    dbModelsUpdate.Add(itemModelUpdate);
                    // Mieu ta
                    itemModelUpdate = new DBModel();
                    Mieuta = txtMieuta.Text;
                    itemModelUpdate.text = "Mieuta";
                    itemModelUpdate.value = Mieuta;
                    itemModelUpdate.type = "string";
                    dbModelsUpdate.Add(itemModelUpdate);
                    // MaSP
                    itemModelUpdate = new DBModel();
                    MaSP = txtMaSP.Text;
                    itemModelUpdate.text = "MaSP";
                    itemModelUpdate.value = MaSP;
                    itemModelUpdate.type = "string";
                    dbModelsUpdate.Add(itemModelUpdate);
                    // Modify Date
                    itemModelUpdate = new DBModel();
                    modifyDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    itemModelUpdate.text = "Ngaysua";
                    itemModelUpdate.value = modifyDate;
                    itemModelUpdate.type = "datetime";
                    dbModelsUpdate.Add(itemModelUpdate);

                    if (ten != "")
                    {
                        InsertItemQry += "UPDATE [Product] SET [Kyhieu] = '"+ten+"',[Dai] = "+dai+",[Rong] = "+rong+",[ArtID] = '"+ARTID+"',[SonID] = '"+SonID+"',[DVT] = '"+DVT+"',[Mieuta] = '"+Mieuta+"',[Ngaysua] = '"+ modifyDate+"',[MaSP] = '"+MaSP+"' WHERE Barcode ='" + barcode + "';";
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
                                    dtMain = DBHelper.UpdateDatatable(dtMain, modelWhere, dbModelsUpdate);
                                    currentPageNumber = 1;
                                    countPageSize();
                                    MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Barcode khong ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    // Update datalist
                    PopulateData(currentPageNumber, rowPerPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            txtBarcode.Enabled = true;
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
