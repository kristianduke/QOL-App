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
    /// Interaction logic for NavigationPanelTab.xaml
    /// </summary>
    public partial class NavigationPanelTab : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public bool active = true;

        private Image navigationImage;

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(NavigationPanelTab), new PropertyMetadata("Title_Placeholder"));

        public List<NavigationTabItemStruct> Items;

        public NavigationPanelTab()
        {
            InitializeComponent();
            this.DataContext = this;
            navigationImage = (Image)this.FindName("navigationTabIcon");
        }

        public void UpdateItems()
        {
            foreach (NavigationTabItemStruct item in Items)
            {
                var tempItem = new NavigationTabItem();
                tempItem.Title = item.name;
                itemStack.Children.Add(tempItem);
                tempItem.linkedControl = item.control;
            }
        }

        public void CloseTab()
        {
            itemStack.Children.Clear();
            navigationImage.Source = new BitmapImage(new Uri("Resources/outline_expand_more_white_48dp.png", UriKind.Relative));
            active = false;
        }

        public void OpenTab()
        {
            UpdateItems();
            navigationImage.Source = new BitmapImage(new Uri("Resources/outline_expand_less_white_48dp.png", UriKind.Relative));
            active = true;
        }

        private void navigationTab_MouseDown(object sender, MouseEventArgs e)
        {
            if (active)
            {
                CloseTab();
            } else
            {
                OpenTab();
            }
        }
    }

    public struct NavigationTabItemStruct
    {
        public readonly string name;
        public readonly UserControl control;

        public NavigationTabItemStruct(string name, UserControl control)
        {
            this.name = name;
            this.control = control;
        }
    }
}
