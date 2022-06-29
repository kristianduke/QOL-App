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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainTab : UserControl
    {
        #region --- VARIABLES ---

        #region - BRUSHES -

        public Brush closeWindow_btn_brsh;
        public Brush closeWindowHover_btn_brsh;
        public Brush maxMinWindow_btn_brsh;
        public Brush maxMinWindowHover_btn_brsh;
        public Brush minimiseWindow_btn_brsh;
        public Brush minimiseWindowHover_btn_brsh;

        #endregion

        #endregion


        public MainTab()
        {
            InitializeComponent();

            var mainTab = new NavigationPanelTab();
            var notepadTab = new NavigationTabItemStruct("Notepad", new NotepadTab());
            var genericTab = new NavigationTabItemStruct("Test", new GenericTab());
            mainTab.Items = new List<NavigationTabItemStruct> { notepadTab, genericTab };
            mainTab.Title = "Favourites";

            NavigationPanel.Children.Add(mainTab);

            mainTab.UpdateItems();
        }

        public void AttachWindow(Control window)
        {
            TabGrid.Children.Clear();

            if (window.Parent != null) return;

            TabGrid.Children.Add(window);
        }

        public void DetachActiveWindow()
        {
            TabGrid.Children.Clear();
        }

        public Grid GetTabGrid()
        {
            return TabGrid;
        }
    }
}
