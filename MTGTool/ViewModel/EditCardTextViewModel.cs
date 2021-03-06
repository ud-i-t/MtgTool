﻿using GalaSoft.MvvmLight;
using MTGTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool.ViewModel
{
    class EditCardTextViewModel : ViewModelBase
    {
        public SelectedObjectImage Object { get; private set; }

        public EditCardTextViewModel()
        {
            Object = Repository.Get(typeof(SelectedObjectImage)) as SelectedObjectImage;
        }
    }
}
