﻿using System;
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
    }
}
