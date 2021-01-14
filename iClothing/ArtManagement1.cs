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

namespace iClothing
{
    public partial class ArtManagement1 : UserControl
    {
        bool isSuccess = true;
        public ArtManagement1()
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

                                string ARTID, ten, ngaytao, ngaysua;
                                string InsertItemQry = "";
                                int count = 0;
                                string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

                            for (int i = 7; i < dt.Rows.Count; i++)
                            {

                                    ARTID = CommonHelper.RandomString(8);
                                    ten = Convert.ToString(dt.Rows[i][5]);
                                    ngaytao = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                                    ngaysua = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                                    if (ten != "")
                                    {
                                        InsertItemQry = "Insert into ART(ARTID,Ten,Mota, Ngaytao, NgaySua) Values ('" + ARTID + "','" + ten + "','" + "" + "','" + ngaysua + "','" + ngaytao + "')";
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
    }
}
