using GalaSoft.MvvmLight;
using MTGTool.Model;
using MTGTool.Model.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.ViewModel
{
    class EditMessageViewModel : ViewModelBase
    {
        public SelectedMessage Msg { get; set; }
        public ActorList Actors { get; private set; }

        public EditMessageViewModel()
        {
            Actors = Repository.Get(typeof(ActorList)) as ActorList;

            Msg = Repository.Get(typeof(SelectedMessage)) as SelectedMessage;
            Msg.OnChange.Subscribe(_ => RaisePropertyChanged("Msg"));
        }
    }
}
