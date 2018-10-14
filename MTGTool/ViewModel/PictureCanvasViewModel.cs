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

        public PictureCanvasViewModel()
        {
//            MemoryStream data = new MemoryStream(File.ReadAllBytes(@"C: \Users\ud\source\repos\MTGTool\MTGTool\bin\Debug\Image\土地\島.png"));
//            WriteableBitmap wbmp = new WriteableBitmap(BitmapFrame.Create(data));
//            data.Close();
//            var img = new MoviePicture(wbmp) {
//                X = 100,
//                Y = 100
//            };
//            Pictures.Add(img);

//            Pictures.Add(new MovieText()
//            {
//                Text = @"葉を食むって言ってるくらいだから多分草食なんだろう。可愛いな。
//飛行のクリーチャーを尻尾でベチンベチン
//叩き落してくれる頼れる飛行対策だぜ。",
//            });

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
