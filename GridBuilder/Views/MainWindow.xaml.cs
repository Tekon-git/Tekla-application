using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GridBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool StateMinimize = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_MinMaxStatePanel_Click(object sender, RoutedEventArgs e)
        {
            if(!StateMinimize)
            {
                Storyboard sb = this.FindResource("MinimizeStatePanel") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("MaximizeStatePanel") as Storyboard;
                sb.Begin();
            }
            StateMinimize = !StateMinimize;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(!(e.Key >= Key.D0 && e.Key <= Key.D9) && !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) &&
                e.Key != Key.Back && e.Key != Key.Decimal && e.Key != Key.Space && !(Keyboard.IsKeyDown(Key.LeftShift) &&
                e.Key !=Key.D8) && !(Keyboard.IsKeyDown(Key.RightShift) && e.Key != Key.D8) && e.Key != Key.Multiply)
            {
                e.Handled = true;
            }
            return;
        }
    }
}
