using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MTGTool.Model.MovieObjects
{
    class MovieText : MoviePictureBase
    {
        private string _text;
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
        private FontFamily _font = Fonts.SystemFontFamilies.First(x => x.FamilyNames.Any(y => y.Value == "メイリオ"));
        public FontFamily Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
                RaisePropertyChanged(nameof(Font));
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

        public MovieText()
        {
            Text = "新規テキスト";
        }
    }
}
