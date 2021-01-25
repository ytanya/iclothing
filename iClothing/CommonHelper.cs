using System;
using System.Collections.Generic;
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

    }
}
