using MTGTool.Model.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class Message : IMessage
    {
        public IActor Actor{ get; set; }
        private string _text;
        public string Text {
            get {
                return _text;
            }
            set {
                _text = value;
                _onChange.OnNext(this);
            }
        }
        public int Time { get; set; } = 3000;
        public int AutoTime => Text.Length * 200;

        private Subject<IMessage> _onChange = new Subject<IMessage>();
        public IObservable<IMessage> OnChange => _onChange.AsObservable();
    }
}
