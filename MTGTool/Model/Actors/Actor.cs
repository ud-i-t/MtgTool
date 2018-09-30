using MTGTool.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model.Actors
{
    [Serializable()]
    class Actor : IActor
    {
        public string Name { get; set; }

        [NonSerialized()]
        private BitmapImage _graphic;
        public BitmapImage Graphic
        {
            get {
                return _graphic;
            }
            set
            {
                _graphic = value;
                _filePath = _graphic.UriSource.ToString();
            }
        }
        private string _filePath;

        public Actor(string name, string filePath)
        {
            _filePath = filePath;
            Name = name;
            ReloadImage();
        }

        public override string ToString()
        {
            return Name;
        }

        public IActor Clone()
        {
            return new Actor(Name, _filePath);
        }

        public void ReloadImage()
        {
            if (_filePath == "") return;
            Graphic = BitmapUtil.GetImage(_filePath);
        }
    }
}
