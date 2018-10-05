﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.Model;
using MTGTool.Model.MovieObjects;
using MTGTool.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.ViewModel
{
    class CanvasViewModel : ViewModelBase
    {
        public BitmapImage BackGround { get; set; }
        public BitmapImage Character => _currentMsg.message?.Actor.Graphic;
        public string Name =>_currentMsg.message?.Actor.Name;
        public string Message => _currentMsg.message?.Text;
        public BitmapImage MessageWindow { get; set; }
        public MovieObjectList Images { get; set; }

        private SelectedMessage _currentMsg;

        public CanvasViewModel()
        {
            BackGround = BitmapUtil.GetImage(@"C:\Users\ud\source\repos\MTGTool\MTGTool\bin\Debug\Image\UI\背景.png");
            MessageWindow = BitmapUtil.GetImage(@"C:\Users\ud\source\repos\MTGTool\MTGTool\bin\Debug\Image\UI\メッセージウインドウ.png");
            _currentMsg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
            _currentMsg.OnChange.Subscribe(_ => {
                RaisePropertyChanged("Name");
                RaisePropertyChanged("Message");
                RaisePropertyChanged("Character");
            });

            Images = Repository.Get(typeof(MovieObjectList)) as MovieObjectList;
        }

        private ICommand _mouseMoveCommand;
        public ICommand MouseMoveCommand
        {
            get
            {
                return _mouseMoveCommand ??
                    (_mouseMoveCommand = new RelayCommand(MouseMoveExecute, () => true));
            }
        }

        private void MouseMoveExecute()
        {
            Console.Write("move");
        }

        private ICommand _mouseUpCommand;
        public ICommand MouseUpCommand
        {
            get
            {
                return _mouseUpCommand ??
                    (_mouseUpCommand = new RelayCommand(MouseUpExecute, () => true));
            }
        }

        private void MouseUpExecute()
        {
            var img = Repository.Get(typeof(SelectedObject)) as SelectedObject;
            if (img.SeletedImg == null) return;

            Images.Add(new MovieObject(img.SeletedImg.Bitmap));
        }
    }
}
