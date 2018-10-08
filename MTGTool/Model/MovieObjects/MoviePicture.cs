using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.MovieObjects
{
    class MoviePicture : ViewModelBase
    {
        private int _angle;
        public int Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
                RaisePropertyChanged(nameof(Angle));
            }
        }
        private int _x;
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                RaisePropertyChanged(nameof(X));
            }
        }
        private int _y;
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }
        private int _scale;
        public int Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                RaisePropertyChanged(nameof(Scale));
            }
        }
        public BitmapSource Bitmap { get; private set; }
        public int CenterX => Bitmap.PixelWidth / 2;
        public int CenterY => Bitmap.PixelHeight / 2;

        public MoviePicture(BitmapSource bitmap)
        {
            Bitmap = bitmap;
            Angle = 0;
        }
    }
}
