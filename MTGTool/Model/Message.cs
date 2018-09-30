using MTGTool.Model.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.Model
{
    class Message : IMessage
    {
        public IActor Actor{ get; set; }
        public string Text { get; set; }
        public int Time { get; set; } = 1000;
    }
}
