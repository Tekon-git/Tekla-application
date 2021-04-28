using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;

namespace GridBuilder.Infrastructure.Behaviours
{
    class CloseWindowBehavior : Behavior<Button>
    {
        protected override void OnAttached() => AssociatedObject.Click += OnButtonClick;

        protected override void OnDetaching() => AssociatedObject.Click -= OnButtonClick;

        private void OnButtonClick(object sender, RoutedEventArgs e) => (AssociatedObject.FindVisualRoot() as Window)?.Close();

    }
}
