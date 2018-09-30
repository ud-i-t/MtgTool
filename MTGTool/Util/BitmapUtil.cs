using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Util
{
    static class BitmapUtil
    {
        public static BitmapImage GetImage(string path)
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + path);
            img.EndInit();
            return img;
        }
    }
}
