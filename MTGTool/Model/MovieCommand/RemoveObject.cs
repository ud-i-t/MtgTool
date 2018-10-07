using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model.MovieCommand
{
    class RemoveObject : IMovieCommand
    {
        MovieObjectImage _obj;
        public RemoveObject(MovieObjectImage obj)
        {
            _obj = obj;
        }

        public void Invoke()
        {
            _obj.Visible = false;
        }

        public override string ToString()
        {
            return $"カード削除";
        }
    }
}
