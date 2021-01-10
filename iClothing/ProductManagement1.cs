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
    }
}
