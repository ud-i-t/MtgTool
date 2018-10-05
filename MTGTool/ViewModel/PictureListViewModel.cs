using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTGTool.ViewModel
{
    class PictureListViewModel : ViewModelBase
    {
        public ObservableCollection<Image> Pictures { get; } = new ObservableCollection<Image>();

        public PictureListViewModel()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"Image");
            IEnumerable<System.IO.FileInfo> files =
                di.EnumerateFiles("*.png", System.IO.SearchOption.AllDirectories);

            //ファイルを列挙する
            foreach (System.IO.FileInfo f in files)
            {
                MemoryStream data = new MemoryStream(File.ReadAllBytes(f.FullName));
                WriteableBitmap wbmp = new WriteableBitmap(BitmapFrame.Create(data));
                data.Close();
                Pictures.Add(new Image(wbmp));
            }
        }

        
    }
}
