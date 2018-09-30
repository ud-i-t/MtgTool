using GalaSoft.MvvmLight;
using MTGTool.Model;
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
        public BitmapImage Character { get; set; }
        public BitmapImage MessageWindow { get; set; }

        private SelectedMessage _currentMsg;
        public string Name
        {
            get { return _currentMsg.message?.Text; }
        }

        public CanvasViewModel()
        {
            BackGround = Init("/Image/UI/背景.png");
            Character = Init("/Image/chara/sakuya1.png");
            MessageWindow = Init("/Image/UI/メッセージウインドウ.png");
            _currentMsg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
            _currentMsg.OnChange.Subscribe(_ => RaisePropertyChanged("Name"));
        }

        private BitmapImage Init(string path)
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + path);
            img.EndInit();
            return img; 
        }
    }
}
