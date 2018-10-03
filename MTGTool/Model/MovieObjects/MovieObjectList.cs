using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.MovieObjects
{
    class MovieObjectList : ObservableCollection<MovieObject>
    {
        public MovieObjectList()
        {
            MemoryStream data = new MemoryStream(File.ReadAllBytes(@"C: \Users\ud\source\repos\MTGTool\MTGTool\bin\Debug\Image\土地\島.png"));
            WriteableBitmap wbmp = new WriteableBitmap(BitmapFrame.Create(data));
            data.Close();

            var img = new MovieObject(wbmp) { X = 100, Y = 220 };
            Add(img);

            data = new MemoryStream(File.ReadAllBytes(@"C: \Users\ud\source\repos\MTGTool\MTGTool\bin\Debug\Image\土地\山.png"));
            wbmp = new WriteableBitmap(BitmapFrame.Create(data));
            data.Close();

            var img2 = new MovieObject(wbmp) { X = 180, Y = 240 };
            Add(img2);
        }
    }
}
