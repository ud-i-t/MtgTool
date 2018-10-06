using GalaSoft.MvvmLight.Command;
using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.Model
{
    class Image
    {
        public BitmapSource Bitmap { get; private set; }

        public Image(BitmapSource bitmap)
        {
            Bitmap = bitmap;
        }

        private ICommand _mouseDownCommand;
        public ICommand MouseDownCommand
        {
            get
            {
                return _mouseDownCommand ??
                    (_mouseDownCommand = new RelayCommand(MouseDownExecute, () =>
                    {
                        var selectedObject = Repository.Get(typeof(SelectedObject)) as SelectedObject;
                        return selectedObject.SeletedImg == null;
                    }));
            }
        }

        private void MouseDownExecute()
        {

            var selectedObject = Repository.Get(typeof(SelectedObject)) as SelectedObject;
            var pos = Mouse.GetPosition(null);

            selectedObject.SeletedImg = new MovieObject(Bitmap)
            {
                X = (int)pos.X,
                Y = (int)pos.Y,
            };
        }
    }
}
