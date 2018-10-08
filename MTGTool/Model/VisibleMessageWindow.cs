using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class VisibleMessageWindow : ViewModelBase
    {
        private bool _visible = true;
        public bool Visible {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                RaisePropertyChanged(nameof(Visible));
            }
        }
    }
}
