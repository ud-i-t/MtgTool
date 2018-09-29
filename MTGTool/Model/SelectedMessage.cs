using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class SelectedMessage
    {
        private IMessage _message;
        public IMessage message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                _onChange.OnNext(message);
            }
        }

        private Subject<IMessage> _onChange;
        public IObservable<IMessage> OnChange => _onChange.AsObservable();

        public SelectedMessage()
        {
            _onChange = new Subject<IMessage>();
        }
    }
}
