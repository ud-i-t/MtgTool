using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.MovieObjects
{
    class MovieObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public BitmapSource Bitmap { get; private set; }

        public MovieObject(BitmapSource bitmap)
        {
            Bitmap = bitmap;
        }

        private ICommand _captureCommand;
        public ICommand CaptureCommand
        {
            get
            {
                return _captureCommand ??
                    (_captureCommand = new RelayCommand(CaptureCommandExecute, CanCaptureCommandExecute));
            }
        }

        private void CaptureCommandExecute()
        {
            Console.Write("hoge");
        }

        private bool CanCaptureCommandExecute()
        {
            return true;
        }
    }
}
