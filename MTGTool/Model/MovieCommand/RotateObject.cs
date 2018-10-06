using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model.MovieCommand
{
    class RotateObject : IMovieCommand
    {
        MovieObject _obj;
        int _angle;
        public RotateObject(MovieObject obj, int angle)
        {
            _obj = obj;
            _angle = angle;
        }

        public void Invoke()
        {
            _obj.Angle += _angle;
            if (_obj.Angle >= 360) _obj.Angle -= 360;
            else if (_obj.Angle < 0) _obj.Angle += 360;
        }

        public override string ToString()
        {
            return $"オブジェクト回転{_angle}";
        }
    }
}
