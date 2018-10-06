using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model.Group
{
    class ObjectGroupList : ObservableCollection<ObjectGroup>
    {
        public ObjectGroupList()
        {
            Add(new ObjectGroup());
        }
    }
}
