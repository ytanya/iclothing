using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlServerCe;

namespace iClothing
{
    public partial class StockManagement : UserControl
    {
        Thread delayedCalculationThread;
        int delay = 0;
        string conn = DBAccess.ConnectionString;
        DataTable dtMain = new DataTable();
        string pathCSV = System.AppDomain.CurrentDomain.BaseDirectory + "taphoaviet.csv";
        public StockManagement()
        {
            InitializeComponent();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            dtMain = new DataTable();
            CalculateAfterStopTyping();
        }

        private void CalculateAfterStopTyping()
        {
            delay += 30;
            if (delayedCalculationThread != null && delayedCalculationThread.IsAlive)
                return;

            delayedCalculationThread = new Thread(() =>
            {
                while (delay >= 20)
                {
                    delay = delay - 20;
                    try
                    {
                        Thread.Sleep(20);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    string id = txtBarcode.Text;
                    if (DBAccess.IsServerConnected())
                    {
                        string query = "Select TonkhoID, Product.Kyhieu, Type.Ten, Stock.Mieuta, Soluongcon, Stock.Ngaytao  from Stock join Product on Stock.Barcode = Product.Barcode join Type on Type.LoaiID = Stock.LoaiID where Stock.Barcode = '" + id + "'; ";

                        using (SqlCeConnection connection = new SqlCeConnection(conn))
                        {
                            using (SqlCeCommand command = new SqlCeCommand(query, connection))
                            {
                                SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                dtMain.Merge(dt);

                                dvgStock.DataSource = dtMain;

                            }
                        }
                    }
                    

                    txtBarcode.Text = string.Empty;

                }));
            });

            delayedCalculationThread.Start();
        }
    }
}
