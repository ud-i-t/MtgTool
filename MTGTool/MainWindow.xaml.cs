using MTGTool.Model;
using MTGTool.Model.Actors;
using MTGTool.Model.Group;
using MTGTool.Model.MovieObjects;
using MTGTool.Model.System;
using MTGTool.View;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTGTool
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);

            Repository.Load();
            Repository.Set(typeof(FontList), new FontList());
            Repository.Set(typeof(VisibleMessageWindow), new VisibleMessageWindow());
            Repository.Set(typeof(SelectedPallet), new SelectedPallet());
            Repository.Set(typeof(SelectedMessage), new SelectedMessage());
            Repository.Set(typeof(SelectedObjectImage), new SelectedObjectImage());
            Repository.Set(typeof(SelectedPicture), new SelectedPicture());
            Repository.Set(typeof(Model.MessageList), new Model.MessageList());
            Repository.Set(typeof(MovieObjectList), new MovieObjectList());
            Repository.Set(typeof(MoviePictureList), new MoviePictureList());
            Repository.Set(typeof(ObjectGroupList), new ObjectGroupList());
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var reader1 = new AudioFileReader("cyrf_comeback.mp3"))
            using (var reader2 = new AudioFileReader("cyrf_crossroad_advanced.mp3"))
            {
                var trimmed = new OffsetSampleProvider(reader1)
                {
                    DelayBy = TimeSpan.FromSeconds(10),
                };
                var mixer = new MixingSampleProvider(new ISampleProvider[] { trimmed, reader2 });
                WaveFileWriter.CreateWaveFile16("mixed.wav", mixer);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var subWindow = new MaterialView();
            subWindow.ShowDialog();
        }
    }
}
