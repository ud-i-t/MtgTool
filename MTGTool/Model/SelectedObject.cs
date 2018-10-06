using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model
{
    class SelectedObject
    {
        private MovieObject _selectedObject;
        public MovieObject SeletedImg {
            get
            {
                return _selectedObject;
            }
            set
            {
                _selectedObject = value;
                _onChange.OnNext(this);
            }
        }

        private Subject<SelectedObject> _onChange = new Subject<SelectedObject>();
        public IObservable<SelectedObject> OnChange => _onChange.AsObservable(); 
    }
}
