using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.Behavior;
using MTGTool.Model.Group;
using MTGTool.Model.MovieCommand;
using MTGTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.MovieObjects
{
    class MovieObject : ViewModelBase
    {
        public ObservableCollection<MovieObjectImage> Images { get; } = new ObservableCollection<MovieObjectImage>();

        private Subject<MovieObject> _onChange = new Subject<MovieObject>();
        public IObservable<MovieObject> OnChange => _onChange.AsObservable();

        public MovieObject()
        {
            Description = new DropAcceptDescription();
            Description.DragOver += Description_DragOver;
            Description.DragDrop += Description_DragDrop;
        }

        public void Init()
        {
            foreach (var obj in Images)
            {
                obj.Visible = false;
                obj.Angle = 0;
            }
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
            if (!args.Data.GetDataPresent(typeof(Image))) return;
            var data = args.Data.GetData(typeof(Image)) as Image;
            if (data == null) return;
            var fe = args.OriginalSource as FrameworkElement;
            if (fe == null) return;
            var target = fe.DataContext as MovieObjectImage;
            if (target == null) return;

            var img = new MovieObjectImage(data.Bitmap) { Visible = true };
            var currentMsg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
            currentMsg.message.AddCommand(new MovieCommand.AddObject(img));

            Images.Insert(0, img);
        }

        private void Description_DragOver(DragEventArgs args)
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
    }
}
