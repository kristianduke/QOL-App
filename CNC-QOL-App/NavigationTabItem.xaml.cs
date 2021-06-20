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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CNC_QOL_App
{
    /// <summary>
    /// Interaction logic for NavigationTabItem.xaml
    /// </summary>
    public partial class NavigationTabItem : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(NavigationTabItem), new PropertyMetadata("Tab_Item"));

        public Control linkedControl;

        public NavigationTabItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid mainTab = (Grid)Application.Current.MainWindow.FindName("TabGrid");

            if (!mainTab.Children.Contains(linkedControl) && linkedControl != null)
            {
                Grid.SetColumnSpan(linkedControl, 3);
                Grid.SetRowSpan(linkedControl, 3);

                mainTab.Children.Add(linkedControl);
            } else if(linkedControl != null)
            {
                Grid.SetColumnSpan(linkedControl, 1);
                Grid.SetRowSpan(linkedControl, 1);
                mainTab.Children.Remove(linkedControl);
            }
        }
    }
}
