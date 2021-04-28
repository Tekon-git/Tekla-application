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

namespace GridBuilder.UserControls
{
    /// <summary>
    /// Interaction logic for PanelDropDownList.xaml
    /// </summary>
    public partial class PanelDropDownList : UserControl
    {

        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText",
            typeof(string), typeof(PanelDropDownList), new PropertyMetadata(null));
        public string HeaderText
        {
            get 
            {
                return (string)GetValue(HeaderTextProperty);
            }
            set
            {
                SetValue(HeaderTextProperty, value);
            }
        }
        public object AdditionalContent
        {
            get
            {
                return (object)GetValue(AdditionalContentProperty);
            }
            set
            {
                SetValue(AdditionalContentProperty, value);
            }

        }
        public static readonly DependencyProperty AdditionalContentProperty = DependencyProperty.Register("AdditionalContent", typeof(object), typeof(PanelDropDownList),
            new PropertyMetadata(null));

        private bool StateMinimize = false;
        public PanelDropDownList()
        {

            InitializeComponent();
            DataContext = this;
        }

        private void btn_MinMaxStatePanel_Click(object sender, RoutedEventArgs e)
        {
            if (!StateMinimize)
            {
                Storyboard sb = this.FindResource("MinimizeStatePanel") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("MaximaizeStatePanel") as Storyboard;
                sb.Begin();
            }
            StateMinimize = !StateMinimize;
        }
    }
}
