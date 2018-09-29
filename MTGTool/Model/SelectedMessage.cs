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
        private Message _message;
        public Message message
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

        private Subject<Message> _onChange;
        public IObservable<Message> OnChange => _onChange.AsObservable();

        public SelectedMessage()
        {
            _onChange = new Subject<Message>();
        }
    }
}
