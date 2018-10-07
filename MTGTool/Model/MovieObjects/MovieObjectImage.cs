using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.Behavior;
using MTGTool.Model.Group;
using MTGTool.Model.MovieCommand;
using MTGTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.MovieObjects
{
    class MovieObjectImage : ViewModelBase
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

        private bool _visible;
        public bool Visible
        {
            get
            {
                return _visible;
            }
            internal set
            {
                _visible = value;
                RaisePropertyChanged(nameof(Visible));
            }
        }

        private string _text = string.Empty;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                DisplayText.Clear();
                foreach (var t in _text.Split('\n'))
                {
                    DisplayText.Add(t);
                }
            }
        }

        public ObservableCollection<string> DisplayText { get; } = new ObservableCollection<string>();
        public BitmapSource Bitmap { get; private set; }
        public int CenterX => Bitmap.PixelWidth / 2;
        public int CenterY => Bitmap.PixelHeight / 2;
        private SelectedMessage _selectedMsg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;

        public MovieObjectImage(BitmapSource bitmap)
        {
            Bitmap = bitmap;
            Angle = 0;
        }

        private ICommand _textChangeCommand;
        public ICommand TextChangeCommand
        {
            get
            {
                return _textChangeCommand ??
                    (_textChangeCommand = new RelayCommand<object>(angle =>
                    {
                        var selectedObj = Repository.Get(typeof(SelectedObjectImage)) as SelectedObjectImage;
                        selectedObj.SeletedImg = this;

                        var pallet = Repository.Get(typeof(SelectedPallet)) as SelectedPallet;
                        pallet.Pallet = new EditCardTextViewModel();
                    }
                    , _ => true));
            }
        }

        private ICommand _rotateCommand;
        public ICommand RotateCommand
        {
            get
            {
                return _rotateCommand ??
                    (_rotateCommand = new RelayCommand<object>(angle =>
                    {
                        _selectedMsg.message.AddCommand(new RotateObject(this, int.Parse(angle.ToString())));
                    }
                    , _ => true));
            }
        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommand<object>(angle =>
                    {
                        _selectedMsg.message.AddCommand(new RemoveObject(this));
                    }
                    , _ => true));
            }
        }
    }
}
