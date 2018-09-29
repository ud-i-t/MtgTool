using GalaSoft.MvvmLight;
using MTGTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.ViewModel
{
    class EditMessageViewModel : ViewModelBase
    {
        private SelectedMessage _msg = new SelectedMessage();
        public SelectedMessage Msg
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
                RaisePropertyChanged("Msg");
            }
        }
    }
}
