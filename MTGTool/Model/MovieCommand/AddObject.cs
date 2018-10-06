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
        MovieObject _obj;
        public AddObject(MovieObject obj)
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
