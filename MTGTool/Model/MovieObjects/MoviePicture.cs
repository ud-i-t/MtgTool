using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.MovieObjects
{
    class MoviePicture : MoviePictureBase
    {
        public BitmapSource Bitmap { get; private set; }
        public int CenterX => Bitmap.PixelWidth / 2;
        public int CenterY => Bitmap.PixelHeight / 2;

        public MoviePicture(BitmapSource bitmap)
        {
            Bitmap = bitmap;
        }
    }
}
