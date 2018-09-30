using GalaSoft.MvvmLight;
using MTGTool.Model.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }

        public EditActorViewModel()
        {
            Actors = Repository.Get(typeof(ActorList)) as ActorList;
            Actor = Actors.First();
        }
    }
}
