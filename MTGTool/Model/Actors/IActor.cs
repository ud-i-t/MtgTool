using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.Actors
{
    interface IActor
    {
        string Name { get; }
        BitmapImage Graphic { get; set; }
        IActor Clone();
        void ReloadImage();
    }
}
