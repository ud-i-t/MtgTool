﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace MTGTool.Behavior
{
    class MainWindowClose : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Closed += this.WindowClosed;
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            (this.AssociatedObject.DataContext as IDisposable)?.Dispose();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Closed -= this.WindowClosed;
        }

    }
}
