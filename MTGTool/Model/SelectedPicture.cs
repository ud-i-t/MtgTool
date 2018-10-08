using GalaSoft.MvvmLight;
using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class SelectedPicture : ViewModelBase
    {
        private MoviePicture _picture;
        public MoviePicture Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
                RaisePropertyChanged(nameof(Picture));
            }
        }
    }
}
