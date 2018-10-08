using GalaSoft.MvvmLight;
using MTGTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.ViewModel
{
    class EditPictureViewModel : ViewModelBase
    {
        public SelectedPicture SelectedPicture { get; private set; } = Repository.Get(typeof(SelectedPicture)) as SelectedPicture;
    }
}
