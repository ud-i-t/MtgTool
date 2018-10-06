using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.MovieObjects
{
    class MovieObject
    {
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
                _onChange.OnNext(this);
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
                _onChange.OnNext(this);
            }
        }
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
                _onChange.OnNext(this);
            }
        }
        public BitmapSource Bitmap { get; private set; }
        public int CenterX => (int)(X + Bitmap.Width / 2);
        public int CenterY => (int)(Y + Bitmap.Height / 2);

        private Subject<MovieObject> _onChange = new Subject<MovieObject>();
        public IObservable<MovieObject> OnChange => _onChange.AsObservable();

        public MovieObject(BitmapSource bitmap)
        {
            Bitmap = bitmap;
            Angle = 0;
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


        private ICommand _rotateCommand;
        public ICommand RotateCommand
        {
            get
            {
                return _rotateCommand ??
                    (_rotateCommand = new RelayCommand(() => Angle = 90, () => true));
            }
        }
    }
}
