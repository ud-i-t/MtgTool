using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTGTool.Model.MovieObjects
{
    class MovieText : MoviePictureBase
    {
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
        private int _fontSize = 20;
        public int FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
                RaisePropertyChanged(nameof(FontSize));
            }
        }
        private int _borderSize; 
        public int BorderSize
        {
            get
            {
                return _borderSize;
            }
            set
            {
                _borderSize = value;
                RaisePropertyChanged(nameof(BorderSize));
            }
        }

        public ObservableCollection<string> DisplayText { get; } = new ObservableCollection<string>();
    }
}
