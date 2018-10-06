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

namespace MTGTool.Model.Group
{
    class ObjectGroup : ViewModelBase
    {
        public int X { get; set; } = 100;
        public int Y { get; set; } = 100;
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 300;
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

        private void Description_DragDrop(System.Windows.DragEventArgs args)
        {
            if (!args.Data.GetDataPresent(typeof(Image))) return;
            var data = args.Data.GetData(typeof(Image)) as Image;
            if (data == null) return;
            var fe = args.OriginalSource as FrameworkElement;
            if (fe == null) return;
            var target = fe.DataContext as ObjectGroup;
            if (target == null) return;

            MovieObjects.Add(new MovieObject(data.Bitmap) { Visible = true });
        }

        private void Description_DragOver(System.Windows.DragEventArgs args)
        {
            if (args.AllowedEffects.HasFlag(DragDropEffects.Copy))
            {
                if (args.Data.GetDataPresent(typeof(Image)))
                {
                    return;
                }
            }
            args.Effects = DragDropEffects.None;
        }

        internal void Add(MovieObject img)
        {
            MovieObjects.Add(img);
        }
    }
}
