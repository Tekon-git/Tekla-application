using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using System.Windows.Input;

namespace GridBuilder.Infrastructure.Behaviours
{
    class WindowTitleBarDragBehavior : Behavior<UIElement>
    {
        private Window window;
        protected override void OnAttached()
        {
            window = AssociatedObject as Window ?? AssociatedObject.FindLogicalParent<Window>();
            AssociatedObject.MouseLeftButtonDown += OnMouseDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnMouseDown;
            window = null; 
        }

        protected void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1) return;
            window.DragMove();
        }
    }
}
