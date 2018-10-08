using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTGTool.Model.MovieObjects
{
    class MoviePictureBase : ViewModelBase
    {
        private int _angle;
        public int Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
                RaisePropertyChanged(nameof(Angle));
            }
        }
        private int _x;
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                RaisePropertyChanged(nameof(X));
            }
        }
        private int _y;
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }
        private int _scale;
        public int Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                RaisePropertyChanged(nameof(Scale));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand<object>(angle =>
                    {
                        var selectedObj = Repository.Get(typeof(SelectedPicture)) as SelectedPicture;
                        selectedObj.Picture = this;

                        var pallet = Repository.Get(typeof(SelectedPallet)) as SelectedPallet;
                        pallet.Pallet = new EditPictureViewModel();
                    }
                    , _ => true));
            }
        }
    }
}
