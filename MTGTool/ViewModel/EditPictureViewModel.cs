using GalaSoft.MvvmLight;
using MTGTool.Behavior;
using MTGTool.Model;
using MTGTool.Model.Group;
using MTGTool.Model.MovieObjects;
using MTGTool.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MTGTool.ViewModel
{
    class EditPictureViewModel : ViewModelBase
    {
        public SelectedPicture SelectedPicture { get; private set; } = Repository.Get(typeof(SelectedPicture)) as SelectedPicture;
        public FontList Fonts { get; set; } = Repository.Get(typeof(FontList)) as FontList;
    }
}
