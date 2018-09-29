using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MTGTool.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTGTool.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _name = "";

        // ���O�B
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private ICommand _greetCommand;

        // ���A�R�}���h�B
        public ICommand GreetCommand
        {
            get
            {
                return _greetCommand ??
                    (_greetCommand = new RelayCommand(GreetCommandExecute, CanGreetCommandExecute));
            }
        }

        // ���A�R�}���h�̎��s�B
        private void GreetCommandExecute()
        {
            var repo = Repository.Get(typeof(MessageList)) as MessageList;
            repo.Add(new Message() { Text = "First Main" });

            Task.Run(() =>
            {
                foreach (var m in repo)
                {
                    Name = m.Text;
                    Thread.Sleep(m.Time);
                }
            });
        }

        // ���A�R�}���h�����s�ł��邩���肷��B
        private bool CanGreetCommandExecute()
        {
            return true;
        }
    }
}