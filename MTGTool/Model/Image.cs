using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model
{
    class Image
    {
        public BitmapSource Bitmap { get; private set; }

        public Image(BitmapSource bitmap)
        {
            Bitmap = bitmap;
        }
    }
}
