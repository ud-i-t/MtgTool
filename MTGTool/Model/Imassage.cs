using MTGTool.Model.Actors;
using MTGTool.Model.MovieCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    interface IMessage
    {
        string Text { get; set; }
        int Time { get; set; }
        int AutoTime { get; }
        IActor Actor { get; }
        IObservable<IMessage> OnChange { get; }
        void AddCommand(IMovieCommand command);
    }
}
