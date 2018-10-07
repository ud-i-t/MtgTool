using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class SelectedPallet : ViewModelBase
    {
        private ViewModelBase _pallet;
        public ViewModelBase Pallet {
            get
            {
                return _pallet;
            }
            set
            {
                _pallet = value;
                RaisePropertyChanged(nameof(Pallet));
            }
        }
    }
}
