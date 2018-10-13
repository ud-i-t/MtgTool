using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model
{
    class MaterialCollection : ViewModelBase
    {
        public ObservableCollection<BitmapSource> Pictures;
        public ObservableCollection<string> Musics;
        public ObservableCollection<string> SoundEffects;
    }
}
