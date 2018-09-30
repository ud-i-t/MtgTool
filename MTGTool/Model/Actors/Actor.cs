using MTGTool.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.Actors
{
    class Actor : IActor
    {
        public string Name { get; set; }
        public BitmapImage Graphic { get; set; }

        public Actor(string name, string filePath)
        {
            Name = name;
            Graphic = BitmapUtil.GetImage(filePath);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
