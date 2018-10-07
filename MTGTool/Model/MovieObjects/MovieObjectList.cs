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
        public void Init()
        {
            foreach(var obj in Items)
            {
                obj.Init();
            }
        }
    }
}
