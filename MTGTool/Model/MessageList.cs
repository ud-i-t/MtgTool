using MTGTool.Model.Actors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class MessageList : ObservableCollection<IMessage>
    {
        public MessageList() : base()
        {
            var reimu = new Actor("霊夢", "/Image/chara/霊夢01通常.png");
            var sakuya = new Actor("咲夜", "/Image/chara/sakuya1.png");

            Add(new Message { Text = "アンタップ" , Actor = reimu});
            Add(new Message { Text = "アップキープ", Actor = sakuya });
            Add(new Message { Text = "ドロー" , Actor = reimu});
        }
    }
}
