using GalaSoft.MvvmLight.Messaging;
using MTGTool.Messages;
using MTGTool.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTGTool.View
{
    /// <summary>
    /// MovieCanvas.xaml の相互作用ロジック
    /// </summary>
    public partial class MovieCanvas : UserControl
    {
        public MovieCanvas()
        {
            InitializeComponent();
            var vm = DataContext as MainViewModel;

            Messenger.Default.Register<CaptureMessage>(this, _ => Capture() );
        }

        private void Capture()
        {
            canvas.toImage(@"test.png", new PngBitmapEncoder());
        }
    }

    public static class CanvasExtensions
    {
        public static void toImage(this Canvas canvas, string path, BitmapEncoder encoder)
        {
            var size = new Size(canvas.Width, canvas.Height);
            canvas.Measure(size);
            canvas.Arrange(new Rect(size));

            var renderBitmap = new RenderTargetBitmap((int)size.Width,       
                                                      (int)size.Height,      
                                                      96.0d,                 
                                                      96.0d,                 
                                                      PixelFormats.Pbgra32);
            renderBitmap.Render(canvas);

            using (var os = new FileStream(path, FileMode.Create))
            {
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(os);
            }
        }
    }
}
