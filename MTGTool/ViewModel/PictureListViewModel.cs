using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.ViewModel
{
    class PictureListViewModel : ViewModelBase
    {
        private MaterialCollection _materials = Repository.Get(typeof(MaterialCollection)) as MaterialCollection;
        public ObservableCollection<BitmapSource> Pictures => _materials.Pictures;
    }
}
