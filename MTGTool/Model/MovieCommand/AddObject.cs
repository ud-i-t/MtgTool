using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model.MovieCommand
{
    class AddObject : IMovieCommand
    {
        MovieObjectImage _obj;
        public AddObject(MovieObjectImage obj)
        {
            _obj = obj;
        }

        public void Invoke()
        {
            _obj.Visible = true;
        }

        public override string ToString()
        {
            return $"カード追加";
        }
    }
}
