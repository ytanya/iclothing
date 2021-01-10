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
        private DataTable dt = new DataTable();
        private DataTable dtnew = new DataTable();
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
                                    ARTID = Lookup("ART","ARTID", "Ten",Convert.ToString(dt.Rows[i][5]));
                                    SonID = Lookup("Color", "SonID", "Ten", Convert.ToString(dt.Rows[i][6]));
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

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        
        string Lookup(string tablename, string columnName, string refColumnName, string value)
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select " + columnName + " FROM " + tablename +" WHERE "+ refColumnName + " = '" + value+"'";
            string resultLookup = string.Empty;
            dtnew = DBAccess.FillDataTable(query, dt);

                    if (dtnew.Rows.Count > 0)
                    {
                        resultLookup = dtnew.Rows[0][0].ToString();
                    }

                    return resultLookup;
        }

        private void ProductManagement1_Load(object sender, EventArgs e)
        {
            if (DBAccess.IsServerConnected())
            {
                //PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
            }
        }

        //private void PopulateData(int currentPageNumber, int rowPerPage, string orderbyItem)
        //{
        //    int skipRecord = currentPageNumber - 1;
        //    if (skipRecord != 0) skipRecord = currentPageNumber * rowPerPage;
        //    string query = "SELECT * FROM Product Order by " + orderbyItem + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
        //    dt = new DataTable();
        //    dtnew = new DataTable();
        //    using (SqlCeConnection connection = new SqlCeConnection(conn))
        //    {
        //        using (SqlCeCommand command = new SqlCeCommand(query, connection))
        //        {
        //            SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);
        //            dtnew.Merge(dt);

        //            dvgProduct.DataSource = dtnew;
        //            lblTotalPage.Text = dtnew.Rows.Count.ToString();
        //        }
        //    }
        //    //dtnew = DBAccess.FillDataTable(query, dt);

        //    //dvgProduct.DataSource = dtnew;
        //    int rowCount = dtnew.Rows.Count;
        //    pageSize = rowCount / rowPerPage;
        //    // if any row left after calculated pages, add one more page 
        //    if (rowCount % rowPerPage > 0)
        //        pageSize += 1;
        //    lblTotalPage.Text = "Total rows:" + dtnew.Rows.Count.ToString();
        //    DisablePagingButton(currentPageNumber, pageSize);
        //}

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
            //PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            currentPageNumber -= 1;
            //PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            currentPageNumber += 1;
            //PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            currentPageNumber = pageSize;
            //PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
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
                txtBarcode.Enabled = false;
                txtTen.Text = dgvRow.Cells[1].Value.ToString();
                txtMieuta.Text = dgvRow.Cells[2].Value.ToString();
                btnSave.Enabled = false;
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
    }
}
