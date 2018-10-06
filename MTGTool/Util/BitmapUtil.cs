using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MTGTool.Util
{
    static class BitmapUtil
    {
        public static BitmapImage GetImage(string path)
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(path);
            img.EndInit();
            return img;
        }

        public static BitmapSource Rotation(this BitmapSource source, int angle)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var transformedBitmap = new TransformedBitmap();
            transformedBitmap.BeginInit();
            transformedBitmap.Source = source;
            transformedBitmap.Transform = new RotateTransform(90);
            transformedBitmap.EndInit();
            return transformedBitmap;
        }
    }
}
