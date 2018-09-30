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
                _disposable?.Dispose();
                _message = value;
                _disposable = _message.OnChange.Subscribe(x => _onChange.OnNext(x));
                _onChange.OnNext(message);
            }
        }

        private IDisposable _disposable;

        private Subject<IMessage> _onChange = new Subject<IMessage>();
        public IObservable<IMessage> OnChange => _onChange.AsObservable();
    }
}
