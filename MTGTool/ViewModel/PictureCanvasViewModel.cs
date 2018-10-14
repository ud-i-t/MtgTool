using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.Behavior;
using MTGTool.Model;
using MTGTool.Model.Group;
using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.ViewModel
{
    class PictureCanvasViewModel : ViewModelBase
    {
        public MoviePictureList Pictures { get; } = Repository.Get(typeof(MoviePictureList)) as MoviePictureList;
        public VisibleMessageWindow Visible { get; } = Repository.Get(typeof(VisibleMessageWindow)) as VisibleMessageWindow;

        public PictureCanvasViewModel()
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
            if (!args.Data.GetDataPresent(typeof(WriteableBitmap))) return;
            var data = args.Data.GetData(typeof(WriteableBitmap)) as BitmapSource;
            if (data == null) return;
            var fe = args.OriginalSource as FrameworkElement;
            if (fe == null) return;

            var img = new MoviePicture(data);
            Pictures.Add(img);
        }

        private void Description_DragOver(System.Windows.DragEventArgs args)
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
        }
    }
}
