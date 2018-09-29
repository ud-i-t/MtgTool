﻿using GalaSoft.MvvmLight;
using MTGTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.ViewModel
{
    class MessageListViewModel : ViewModelBase
    {
        public ObservableCollection<Message> MessageList { get; set; }

        public MessageListViewModel()
        {
            MessageList = Repository.Get(typeof(MessageList)) as MessageList;
        }
    }
}
