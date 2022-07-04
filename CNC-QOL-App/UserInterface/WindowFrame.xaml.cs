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
using System.Windows.Shapes;

namespace CNC_QOL_App
{
    /// <summary>
    /// Interaction logic for SeperatedWindow.xaml
    /// </summary>
    public partial class WindowFrame : Window
    {
        #region --- VARIABLES ---

        public string windowTitle = "";

        #region - BRUSHES -

        public Brush closeWindow_btn_brsh;
        public Brush closeWindowHover_btn_brsh;
        public Brush maxMinWindow_btn_brsh;
        public Brush maxMinWindowHover_btn_brsh;
        public Brush minimiseWindow_btn_brsh;
        public Brush minimiseWindowHover_btn_brsh;
        public Brush pinWindow_btn_brsh;
        public Brush pinWindowHover_btn_brsh;

        #endregion

        #endregion

        public WindowFrame(string title)
        {
            InitializeComponent();

            windowTitle = title;

            //Get Colour/Brush Variables for Title Bar Buttons
            closeWindow_btn_brsh = closeWindow_btn.Background;
            maxMinWindow_btn_brsh = maxMinWindow_btn.Background;
            minimiseWindow_btn_brsh = minimiseWindow_btn.Background;
            pinWindow_btn_brsh = pinWindow_btn.Background;

            //Set Colour/Brush Variables for Title Bar Hover
            closeWindowHover_btn_brsh = new SolidColorBrush(Color.FromArgb(255, 224, 66, 66));
            maxMinWindowHover_btn_brsh = new SolidColorBrush(Color.FromArgb(255, 203, 137, 59));
            minimiseWindowHover_btn_brsh = new SolidColorBrush(Color.FromArgb(255, 100, 162, 77));
            pinWindowHover_btn_brsh = new SolidColorBrush(Color.FromArgb(255, 164, 66, 187));

            this.Title = windowTitle;
            Title_txt.Text = windowTitle;
        }

        public void AttachTab(Control control)
        {
            if(WindowContent.Children.Count > 0)
            {
                if (WindowContent.Children[0].GetType() == typeof(NotepadTab))
                {
                    ((NotepadTab)WindowContent.Children[0]).detached = false;
                }
            }

            WindowContent.Children.Clear();
            WindowContent.Children.Add(control);
        }

        public void DestroyWindow()
        {
            if (WindowContent.Children[0].GetType() == typeof(NotepadTab))
            {
                ((NotepadTab)WindowContent.Children[0]).detached = false;
            }

            WindowContent.Children.Clear();
            InstanceData.SeperatedWindows.Remove(this);
            this.Close();
        }

        public Control GetTab()
        {
            if (WindowContent.Children.Count <= 0) return null;

            return (Control)WindowContent.Children[0];
        }

        #region --- INTERACTION EVENTS ---

        #region - TITLE BAR EVENTS -

        private void GripBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Point point = Mouse.GetPosition(this);
                Point screenPoint = PointToScreen(point);

                if (this.WindowState == WindowState.Maximized) // Prevents Window Being Seperated From Cursor when Unmaximized if Grabbed.
                {
                    this.Top = screenPoint.Y - 10;
                    this.Left = screenPoint.X - (this.Width / 2);
                }

                this.WindowState = WindowState.Normal;
                this.DragMove();
            }
        }

        #region Window_PinMinMaxClose_BtnActions

        private void CloseWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Children.Clear();
           
            this.Close();
        }

        private void CloseWindow_btn_Hover_Enter(object sender, MouseEventArgs e)
        {
            closeWindow_btn.Background = closeWindowHover_btn_brsh;
        }

        private void CloseWindow_btn_Hover_Leave(object sender, MouseEventArgs e)
        {
            closeWindow_btn.Background = closeWindow_btn_brsh;
        }

        private void MaxMinWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void MaxMinWindow_btn_Hover_Enter(object sender, MouseEventArgs e)
        {
            maxMinWindow_btn.Background = maxMinWindowHover_btn_brsh;
        }

        private void MaxMinWindow_btn_Hover_Leave(object sender, MouseEventArgs e)
        {
            maxMinWindow_btn.Background = maxMinWindow_btn_brsh;
        }
        private void MinimiseWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void MinimiseWindow_btn_Hover_Enter(object sender, MouseEventArgs e)
        {
            minimiseWindow_btn.Background = minimiseWindowHover_btn_brsh;
        }

        private void MinimiseWindow_btn_Hover_Leave(object sender, MouseEventArgs e)
        {
            minimiseWindow_btn.Background = minimiseWindow_btn_brsh;
        }

        private void PinWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            if(this.Topmost == false)
            {
                pinWindow_btn_img.Source = new BitmapImage(new Uri("Resources/pin_filled.png", UriKind.Relative));
                this.Topmost = true;
            } else
            {
                pinWindow_btn_img.Source = new BitmapImage(new Uri("Resources/pin_unfilled.png", UriKind.Relative));
                this.Topmost = false;
            }
        }
        private void PinWindow_btn_Hover_Enter(object sender, MouseEventArgs e)
        {
            pinWindow_btn.Background = pinWindowHover_btn_brsh;
        }

        private void PinWindow_btn_Hover_Leave(object sender, MouseEventArgs e)
        {
            pinWindow_btn.Background = pinWindow_btn_brsh;
        }

        #endregion

        #endregion

        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(6);
                titleBar_bdr.CornerRadius = new CornerRadius(0, 0,
                    titleBar_bdr.CornerRadius.BottomRight, titleBar_bdr.CornerRadius.BottomLeft);
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(0);
                titleBar_bdr.CornerRadius = new CornerRadius(7, 7,
                    titleBar_bdr.CornerRadius.BottomRight, titleBar_bdr.CornerRadius.BottomLeft);
            }
        }

        #endregion
    }
}
