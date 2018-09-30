using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model.Actors
{
    class ActorList : ObservableCollection<IActor>
    {
        public ActorList()
        {
            Add(new Actor("霊夢", "/Image/chara/霊夢01通常.png"));
            Add(new Actor("魔理沙", "/Image/chara/魔理沙01通常.png"));
            Add(new Actor("咲夜", "/Image/chara/sakuya1.png"));
        }
    }
}
