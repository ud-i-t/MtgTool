using GalaSoft.MvvmLight;
using MTGTool.Behavior;
using MTGTool.Model;
using MTGTool.Model.Group;
using MTGTool.Model.MovieObjects;
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

        
    }
}
