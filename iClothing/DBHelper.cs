using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iClothing
{
    class DBHelper
    {
        public static string Lookup(string tablename, string selectColumnName, string whereColumnName, string value)
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select " + selectColumnName + " FROM " + tablename + " WHERE " + whereColumnName + " = '" + value + "'";
            string resultLookup = string.Empty;
            dtnew = DBAccess.FillDataTable(query, dt);

            if (dtnew.Rows.Count > 0)
            {
                resultLookup = dtnew.Rows[0][0].ToString();
            }

            return resultLookup;
        }
        public static DataTable InsertDatatable(DataTable oldDt, List<DBModel> dbModel)
        {
            DataRow oRow = oldDt.NewRow();
            foreach (var item in dbModel)
            {
                if (item.type == "int")
                {
                    oRow[item.text] = Convert.ToInt32(item.value);
                }
                else if (item.type == "bool")
                {
                    oRow[item.text] = bool.Parse(item.value);
                }
                else
                {
                    oRow[item.text] = item.value;
                }
            }
            oldDt.Rows.Add(oRow);
            return oldDt;
        }

        public static DataTable UpdateDatatable(DataTable oldDt, DBModel modelWhere, List<DBModel> dbModelUpdate)
        {
            DataRow row = oldDt.Select(modelWhere.text + "=" + modelWhere.value, modelWhere.text).FirstOrDefault();
            if (row != null)
            {
                foreach (var column in dbModelUpdate)
                {
                    row[column.text] = column.value;
                }
            }
            return oldDt;
        }

        public static DataTable DeleteDatatable(DataTable oldDt, DBModel modelWhere)
        {
            DataRow row = oldDt.Select(modelWhere.text + "=" + modelWhere.value, modelWhere.text).FirstOrDefault();
            if (row != null)
            {
                oldDt.Rows.Remove(row);
            }
            return oldDt;
        }

        public static DataTable GetAllColor()
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select SonID, Ten FROM Color";
            dtnew = DBAccess.FillDataTable(query, dt);
            return dtnew;
        }
        public static DataTable GetAllType()
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select LoaiID, Ten FROM Type";
            dtnew = DBAccess.FillDataTable(query, dt);
            return dtnew;
        }

        public static DataTable GetAllArt()
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select ARTID, Ten FROM ART";
            dtnew = DBAccess.FillDataTable(query, dt);
            return dtnew;
        }

        public static DataTable GetAllCustomer()
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select KHID, HoTen FROM Customer";
            dtnew = DBAccess.FillDataTable(query, dt);
            return dtnew;
        }

        public static DataTable GetAllSupplier()
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select NhaccID, Ten FROM Supplier";
            dtnew = DBAccess.FillDataTable(query, dt);
            return dtnew;
        }

        public static DataTable GetAllProduct()
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select Barcode, Kyhieu FROM Product";
            dtnew = DBAccess.FillDataTable(query, dt);
            return dtnew;
        }

        public static DataTable GetAllRole()
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select RoleID, Ten FROM Roles";
            dtnew = DBAccess.FillDataTable(query, dt);
            return dtnew;
        }
        public static bool CheckItemExist(string tableName, string whereItem, string whereValue)
        {
            bool isExisted = false;
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select * FROM "+tableName+" WHERE "+whereItem+"='"+whereValue+"';";

            dtnew = DBAccess.FillDataTable(query, dt);
            if (dtnew!=null)
            {
                if (dtnew.Rows.Count > 0)
                {
                    isExisted = true;
                }
                
            }
            return isExisted;
        }

        public static bool isXong(string DonhangID)
        {
            bool isExisted = false;
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string query = "Select * FROM [Order] WHERE DonhangID ='" + DonhangID+"' AND Xong= 1;";
            dtnew = DBAccess.FillDataTable(query, dt);
            if (dtnew != null)
            {
                if (dtnew.Rows.Count > 0)
                {
                    isExisted = true;
                }

            }
            return isExisted;
        }

        public static string getStock(string kyhieu, string chuaInSL, string daInSL, string tPSL, string SPLoiSL)
        {
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            string result = string.Empty;
            bool isStock = false;
            int BTPChuaIn, BTPDaIN, TP, SPLoi;
            string query = "Select DISTINCT(NewProduct.Kyhieu) [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản Phẩm Lỗi], Stock.Mieuta [Miêu tả]  from Stock  join(SELECT Barcode, Kyhieu, MaSP from Product Group by Kyhieu, MaSP, Barcode)NewProduct on Stock.Barcode = NewProduct.Barcode join(SELECT Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluongcon ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluongcon ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluongcon ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluongcon ELSE 0 END)[Sản phẩm lỗi] FROM Stock  GROUP BY Barcode) New on New.Barcode = Stock.Barcode where NewProduct.Kyhieu = '" + kyhieu + "'";
            dtnew = DBAccess.FillDataTable(query, dt);
            if (dtnew != null)
            {
                if (dtnew.Rows.Count > 0)
                {
                    BTPChuaIn = Convert.ToInt32(dtnew.Rows[0][1].ToString());
                    BTPDaIN= Convert.ToInt32(dtnew.Rows[0][2].ToString());
                    TP = Convert.ToInt32(dtnew.Rows[0][3].ToString());
                    SPLoi = Convert.ToInt32(dtnew.Rows[0][4].ToString());
                    if (Convert.ToInt32(chuaInSL) <= BTPChuaIn && Convert.ToInt32(daInSL) <= BTPDaIN && Convert.ToInt32(tPSL) <= TP && Convert.ToInt32(SPLoiSL) <= SPLoi) isStock = true;
                    if (!isStock) result = "BTP Chưa in: " + BTPChuaIn + " BTP Đã in: " + BTPDaIN + " Thành Phẩm: " + TP + " Sản Phẩm Lỗi: " + SPLoi;
                }
                else
                {
                    result = "Không có sản phẩm này trong kho.";
                }
            }
            return result;
        }
    }
}
