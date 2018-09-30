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
            var actors = Repository.Get(typeof(ActorList)) as ActorList;
            var reimu = actors.First(x => x.Name == "霊夢");
            var sakuya = actors.First(x => x.Name == "咲夜");

            Add(new Message { Text = "アンタップ" , Actor = reimu});
            Add(new Message { Text = "アップキープ", Actor = sakuya });
            Add(new Message { Text = "ドロー" , Actor = reimu});
        }
    }
}
