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
        private bool _windowVisible = true;
        public bool WindowVisible {
            get
            {
                return _windowVisible;
            }
            set
            {
                _windowVisible = value;
                RaisePropertyChanged(nameof(WindowVisible));
            }
        }

        private bool _pictureVisible = true;
        public bool PictureVisible
        {
            get
            {
                return _pictureVisible;
            }
            set
            {
                _pictureVisible = value;
                RaisePropertyChanged(nameof(PictureVisible));
            }
        }
    }
}
