using GalaSoft.MvvmLight.Messaging;
using MTGTool.Messages;
using MTGTool.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
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


            //var mouseDown = Observable.FromEvent<MouseButtonEventHandler, MouseButtonEventArgs>(
            //    h => (s, e) => h(e),
            //    h => Items.MouseDown += h,
            //    h => Items.MouseDown -= h);

            //var mouseMove = Observable.FromEvent<MouseEventHandler, MouseEventArgs>(
            //    h => (s, e) => h(e),
            //    h => MouseMove += h,
            //    h => MouseMove -= h);

            //var mouseUp = Observable.FromEvent<MouseButtonEventHandler, MouseButtonEventArgs>(
            //    h => (s, e) => h(e),
            //    h => MouseUp += h,
            //    h => MouseUp -= h);

            //var dragOffset = new Point();
            //var target = new Image(); 
            //var drag = mouseMove
            //    .SkipUntil(mouseDown.Do(e => {
            //        CaptureMouse();
            //        target = e.OriginalSource as Image;
            //        dragOffset = e.GetPosition(target);
            //    }))
            //    .TakeUntil(mouseUp.Do(_ => ReleaseMouseCapture()))
            //    .Repeat();

            //drag.Select(e => e.GetPosition(null))
            //    .Subscribe(p => {
            //        target.Margin = new Thickness(p.X - dragOffset.X - target.ActualWidth / 2, p.Y - dragOffset.Y, 0 , 0);
            //        //Canvas.SetLeft(target, p.X - dragOffset.X);
            //        //Canvas.SetTop(target, p.Y - dragOffset.Y);
            //    });
        }

        private void Capture()
        {
            canvas.toImage(@"test.png", new PngBitmapEncoder());
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

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
