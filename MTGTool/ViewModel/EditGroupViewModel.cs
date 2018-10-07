using GalaSoft.MvvmLight;
using MTGTool.Model.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.ViewModel
{
    class EditGroupViewModel : ViewModelBase
    {
        public ObjectGroupList ObjectGroups { get; private set; }

        private ObjectGroup _selectedGroup; 
        public ObjectGroup SelectedGroup
        {
            get {
                return _selectedGroup;
            }

            set
            {
                _selectedGroup = value;
                RaisePropertyChanged(nameof(SelectedGroup));
            }
        }

        public EditGroupViewModel()
        {
            ObjectGroups = Repository.Get(typeof(ObjectGroupList)) as ObjectGroupList;
        }
    }
}
