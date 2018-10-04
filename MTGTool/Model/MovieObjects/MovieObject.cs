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

        private ICommand _mouseDownCommand;
        public ICommand MouseDownCommand
        {
            get
            {
                return _mouseDownCommand ??
                    (_mouseDownCommand = new RelayCommand(MouseDownExecute, () => true));
            }
        }


        private void MouseDownExecute()
        {
            Console.Write("down");
        }
    }
}
