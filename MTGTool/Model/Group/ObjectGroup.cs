using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model.Group
{
    class ObjectGroup : ObservableCollection<MovieObject>
    {
        public int X { get; set; } = 100;
        public int Y { get; set; } = 100;
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 300;
    }
}
