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

        // 名前。
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

        // 挨拶コマンド。
        public ICommand GreetCommand
        {
            get
            {
                return _greetCommand ??
                    (_greetCommand = new RelayCommand(GreetCommandExecute, CanGreetCommandExecute));
            }
        }

        // 挨拶コマンドの実行。
        private void GreetCommandExecute()
        {
            var repo = Repository.Get(typeof(MessageList)) as MessageList;

            Task.Run(() =>
            {
                foreach (var m in repo)
                {
                    Name = m.Text;
                    Thread.Sleep(m.Time);
                }
            });
        }

        // 挨拶コマンドを実行できるか判定する。
        private bool CanGreetCommandExecute()
        {
            return true;
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(EditCommandExecute, CanEditCommandExecute));
            }
        }

        private void EditCommandExecute()
        {
        }

        private bool CanEditCommandExecute()
        {
            var msg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
            return msg.message != null;
        }


        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(AddCommandExecute, CanAddCommandExecute));
            }
        }

        private void AddCommandExecute()
        {
            var repo = Repository.Get(typeof(MessageList)) as MessageList;
            repo.Add(new Message());
        }

        private bool CanAddCommandExecute()
        {
            return true;
        }
    }
}