using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace MTGTool.Behavior
{
    class MouseOverBehaviour : Behavior<Border>
    {
        static Brush Brush = new SolidColorBrush(Colors.GreenYellow);
        static Brush Transparent = new SolidColorBrush(Colors.Transparent);

        /// <summary>
        /// 初期化
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.MouseEnter += EnterHandler;
            this.AssociatedObject.MouseLeave += LeaveHandler;
            base.OnAttached();
        }

        /// <summary>
        /// 後始末
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseEnter -= EnterHandler;
            this.AssociatedObject.MouseLeave -= LeaveHandler;
            base.OnDetaching();
        }

        private void EnterHandler(object sender, EventArgs e)
        {
            var target = sender as Border;
            if (target == null) return;

            target.BorderBrush = Brush;
        }

        private void LeaveHandler(object sender, EventArgs e)
        {
            var target = sender as Border;
            if (target == null) return;

            target.BorderBrush = Transparent;
        }
    }
}
