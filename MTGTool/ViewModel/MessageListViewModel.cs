using GalaSoft.MvvmLight;
using MTGTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTGTool.ViewModel
{
    class MessageListViewModel : ViewModelBase
    {
        public ObservableCollection<Message> MessageList { get; set; }

        private Message _isSelected;
        public Message IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                SelectedMessage.message = _isSelected;
            }
        }
        public SelectedMessage SelectedMessage { get; set; }

        public MessageListViewModel()
        {
            MessageList = Repository.Get(typeof(MessageList)) as MessageList;
            SelectedMessage = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
        }
    }
}
