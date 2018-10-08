using GalaSoft.MvvmLight;
using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.ViewModel
{
    class PictureCanvasViewModel : ViewModelBase
    {
        public ObservableCollection<MovieObjectImage> Pictures { get; } = new ObservableCollection<MovieObjectImage>();

        public PictureCanvasViewModel()
        {
            MemoryStream data = new MemoryStream(File.ReadAllBytes(@"C: \Users\ud\source\repos\MTGTool\MTGTool\bin\Debug\Image\土地\島.png"));
            WriteableBitmap wbmp = new WriteableBitmap(BitmapFrame.Create(data));
            data.Close();
            var img = new MovieObjectImage(wbmp) { Visible = true };
            Pictures.Add(img);
        }
    }
}
