using GalaSoft.MvvmLight;
using MTGTool.Behavior;
using MTGTool.Model.MovieObjects;
using MTGTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.Group
{
    class ObjectGroup : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
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

        private int _width;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                RaisePropertyChanged(nameof(Width));
                RaisePropertyChanged(nameof(DisplayWidth));
            }
        }
        public double DisplayWidth => Width / Scale;

        private int _height;
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                RaisePropertyChanged(nameof(Height));
                RaisePropertyChanged(nameof(DisplayHeight));
            }
        }
        public double DisplayHeight => Height / Scale;

        private double _scale = 0.25;
        public double Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                RaisePropertyChanged(nameof(Scale));

            }
        }

        private double _angle;
        public double Angle
        {
            get { return _angle; }
            set
            {
                _angle = value;
                RaisePropertyChanged(nameof(Angle));

            }
        }
        public ObservableCollection<MovieObject> MovieObjects { get; } = new ObservableCollection<MovieObject>();

        public ObjectGroup()
        {
            Description = new DropAcceptDescription();
            Description.DragOver += Description_DragOver;
            Description.DragDrop += Description_DragDrop;
        }

        private DropAcceptDescription _description;
        public DropAcceptDescription Description
        {
            get { return this._description; }
            set
            {
                if (this._description == value)
                {
                    return;
                }
                this._description = value;
                this.RaisePropertyChanged(nameof(Description));
            }
        }

        private void Description_DragDrop(DragEventArgs args)
        {
            if (!args.Data.GetDataPresent(typeof(WriteableBitmap))) return;
            var data = args.Data.GetData(typeof(WriteableBitmap)) as BitmapSource;
            if (data == null) return;
            var fe = args.OriginalSource as FrameworkElement;
            if (fe == null) return;
            var target = fe.DataContext as ObjectGroup;
            if (target == null) return;

            var obj = new MovieObject();
            var img = new MovieObjectImage(data) { Visible = true };
            obj.Images.Add(img);
            var currentMsg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
            currentMsg.message.AddCommand(new MovieCommand.AddObject(img));

            var objList = Repository.Get(typeof(MovieObjectList)) as MovieObjectList;
            objList.Add(obj);
            MovieObjects.Add(obj);
        }

        private void Description_DragOver(DragEventArgs args)
        {
            if (!args.AllowedEffects.HasFlag(DragDropEffects.Copy))
            {
                args.Effects = DragDropEffects.None;
                return;
            }
            if (!args.Data.GetDataPresent(typeof(WriteableBitmap)))
            {
                args.Effects = DragDropEffects.None;
                return;
            }
            var fe = args.OriginalSource as FrameworkElement;
            if (fe == null)
            {
                args.Effects = DragDropEffects.None;
                return;
            }
            //var target = fe.DataContext as ObjectGroup;
            //if (target == null) {
            //    args.Effects = DragDropEffects.None;
            //    return;
            //}
        }

        internal void Add(MovieObject img)
        {
            MovieObjects.Add(img);
        }
    }
}
