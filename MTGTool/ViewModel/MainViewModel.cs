using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MTGTool.Model;
using MTGTool.Model.Actors;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
        public Thickness _palletMargin = new Thickness(1600, 0, 0, -10);
        public Thickness PalletMargin {
            get {
                return _palletMargin;
            }
            set
            {
                _palletMargin = value;
                RaisePropertyChanged("PalletMargin");
            }
        }

        private ViewModelBase _pallet;
        public ViewModelBase Pallet
        {
            get
            {
                return _pallet;
            }
            set
            {
                _pallet = value;
                RaisePropertyChanged("Pallet");
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
            var list = Repository.Get(typeof(MessageList)) as MessageList;
            var current = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;

            Task.Run(() =>
            {
                foreach (var m in list)
                {
                    current.message = m;
                    Thread.Sleep(m.Time);
                }
                current.message = list.First();
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
            Pallet = new EditMessageViewModel();
            ShowPallet();
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
            var actors = Repository.Get(typeof(ActorList)) as ActorList;
            repo.Add(new Message() { Actor = actors.First()});
        }

        private bool CanAddCommandExecute()
        {
            return true;
        }

        private ICommand _actorCommand;
        public ICommand ActorCommand
        {
            get
            {
                return _actorCommand ??
                    (_actorCommand = new RelayCommand(ActorCommandExecute, CanActorCommandExecute));
            }
        }

        private void ActorCommandExecute()
        {
            Pallet = new EditActorViewModel();
            ShowPallet();
        }

        private bool CanActorCommandExecute()
        {
            return true;
        }

        private void ShowPallet()
        {
            PalletMargin = new Thickness(1000, 0, 0, -10);
        }
    }
}