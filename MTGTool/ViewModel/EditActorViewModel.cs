using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MTGTool.Model.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MTGTool.ViewModel
{
    class EditActorViewModel : ViewModelBase
    {
        public ActorList Actors { get; }

        private IActor _actor;
        public IActor Actor
        {
            get
            {
                return _actor;
            }
            set
            {
                _actor = value;
                RaisePropertyChanged("Actor");

                if (value == null) return;
                EditedActor = value.Clone();
            }
        }

        private IActor _editedActor;
        public IActor EditedActor
        {
            get
            {
                return _editedActor;
            }
            set
            {
                _editedActor = value;
                RaisePropertyChanged("EditedActor");
            }
        }


        public EditActorViewModel()
        {
            Actors = Repository.Get(typeof(ActorList)) as ActorList;
        }

        private ICommand _selectImgCommand;
        public ICommand SelectImgCommand
        {
            get
            {
                return _selectImgCommand ??
                    (_selectImgCommand = new RelayCommand(SelectImgCommandExecute, CanSelectImgCommandExecute));
            }
        }

        private void SelectImgCommandExecute()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "画像を選択";
            dialog.Filter = "画像(*.png)|*.png";
            if (dialog.ShowDialog() != DialogResult.OK) return;

            EditedActor.Graphic = Util.BitmapUtil.GetImage(dialog.FileName);
            RaisePropertyChanged("EditedActor");
        }

        private bool CanSelectImgCommandExecute()
        {
            return true;
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return _submitCommand ??
                    (_submitCommand = new RelayCommand(SubmitCommandExecute, CanSubmitCommandExecute));
            }
        }

        private void SubmitCommandExecute()
        {
            int insertPos = Actors.IndexOf(Actor);
            Actors.Remove(Actor);
            Actors.Insert(insertPos, _editedActor);
            Actor = _editedActor;
        }

        private bool CanSubmitCommandExecute()
        {
            return true;
        }
    }
}
