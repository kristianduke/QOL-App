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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GripBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                Point point = Mouse.GetPosition(this);
                Point screenPoint = PointToScreen(point);
                this.Top = screenPoint.Y - 10;
                this.Left = screenPoint.X - (this.Width / 2);
                this.WindowState = WindowState.Normal;
                this.DragMove();
            }
        }

        private void closeWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maxMinWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            } else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {  
            if(this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(6);
                titleBar_bdr.CornerRadius = new CornerRadius(0, 0, 
                    titleBar_bdr.CornerRadius.BottomRight, titleBar_bdr.CornerRadius.BottomLeft);
            } else
            {
                this.BorderThickness = new System.Windows.Thickness(0);
                titleBar_bdr.CornerRadius = new CornerRadius(7, 7, 
                    titleBar_bdr.CornerRadius.BottomRight, titleBar_bdr.CornerRadius.BottomLeft);
            }
        }

        private void minimiseWindow_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
