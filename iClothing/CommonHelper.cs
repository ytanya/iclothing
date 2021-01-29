using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iClothing
{
    public class CommonHelper
    {
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string pool = "0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static void showDialog(string message, Color bgColor)
        {
            DialogForm form = new DialogForm(message, bgColor);
            form.Show();
        }

        public static byte[] imageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static DataTable MergeRange(DataTable dest, DataTable table, int startIndex, int length)
        {
            DataTable result = new DataTable();
            List<string> matchingColumns = new List<string>();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                // Only copy columns with the same name and type
                string columnName = table.Columns[i].ColumnName;
                if (dest.Columns.Contains(columnName))
                {
                    if (dest.Columns[columnName].DataType == table.Columns[columnName].DataType)
                    {
                        matchingColumns.Add(columnName);
                    }
                }

            }

            for (int i = 0; i < length; i++)
            {
                int row = i + startIndex;
                DataRow destRow = result.NewRow();
                foreach (string column in matchingColumns)
                {
                    destRow[column] = table.Rows[row][column];
                }
                result.Rows.Add(destRow);
            }

            return result;
        }
    }
}
