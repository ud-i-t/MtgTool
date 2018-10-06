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
                _bind?.Dispose();
                _selectedObject = value;
                _onChange.OnNext(this);

                if (_selectedObject != null) _bind = _selectedObject.OnChange.Subscribe(_ => _onChange.OnNext(this));
            }
        }
        IDisposable _bind;

        private Subject<SelectedObject> _onChange = new Subject<SelectedObject>();
        public IObservable<SelectedObject> OnChange => _onChange.AsObservable(); 
    }
}
