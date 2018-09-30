using GalaSoft.MvvmLight;
using MTGTool.Model;
using MTGTool.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.ViewModel
{
    class CanvasViewModel : ViewModelBase
    {
        public BitmapImage BackGround { get; set; }
        public BitmapImage Character => _currentMsg.message?.Actor.Graphic;
        public BitmapImage MessageWindow { get; set; }

        private SelectedMessage _currentMsg;
        public string Name
        {
            get { return _currentMsg.message?.Text; }
        }

        public CanvasViewModel()
        {
            BackGround = BitmapUtil.GetImage("/Image/UI/背景.png");
            MessageWindow = BitmapUtil.GetImage("/Image/UI/メッセージウインドウ.png");
            _currentMsg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
            _currentMsg.OnChange.Subscribe(_ => {
                RaisePropertyChanged("Name");
                RaisePropertyChanged("Character");
            });
        }

       
    }
}
