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

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(NavigationPanelTab), new PropertyMetadata("Title_Placeholder"));

        public List<NavigationTabItemStruct> Items;

        public NavigationPanelTab()
        {
            InitializeComponent();
            this.DataContext = this;
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
