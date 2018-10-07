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
            Add(new ObjectGroup() {
                Name = "自分の場",
                Width = 900,
                Height = 100,
                X = 40,
                Y = 270,
            });
            Add(new ObjectGroup()
            {
                Name = "相手の場",
                Width = 900,
                Height = 100,
                X = 40,
                Y = 140,
                Angle = 180,
            });
        }
    }
}
