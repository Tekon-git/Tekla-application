using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;

namespace GridBuilder.Infrastructure.Behaviours
{
    class WindowStateChangeBehavior : Behavior<Button>
    {
        
        protected override void OnAttached() => AssociatedObject.Click += OnButtonClick;

        protected override void OnDetaching() => AssociatedObject.Click -= OnButtonClick;

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;
            switch(window.WindowState)
            {
                case WindowState.Normal:
                    window.WindowState = WindowState.Minimized;
                    break;
            }
        }

    }
}

