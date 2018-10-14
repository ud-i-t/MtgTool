using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MTGTool.Model
{
    class MaterialCollection : ViewModelBase
    {
        public ObservableCollection<BitmapSource> Pictures = new ObservableCollection<BitmapSource>();
        public ObservableCollection<string> Musics = new ObservableCollection<string>();
        public ObservableCollection<string> SoundEffects = new ObservableCollection<string>();

        public MaterialCollection()
        {
            DirectoryInfo di = new DirectoryInfo(@"Image");
            IEnumerable<FileInfo> files =
                di.EnumerateFiles("*.png", SearchOption.AllDirectories);

            //ファイルを列挙する
            foreach (var f in files)
            {
                MemoryStream data = new MemoryStream(File.ReadAllBytes(f.FullName));
                WriteableBitmap wbmp = new WriteableBitmap(BitmapFrame.Create(data));
                data.Close();
                wbmp.Freeze();
                Pictures.Add(wbmp);
            }
        }
    }
}
