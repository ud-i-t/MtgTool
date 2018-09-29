using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class MessageList : ObservableCollection<Message>
    {
        public MessageList() : base()
        {
            Add(new Message { Text = "アンタップ" });
            Add(new Message { Text = "アップキープ" });
            Add(new Message { Text = "ドロー" });
        }
    }
}
