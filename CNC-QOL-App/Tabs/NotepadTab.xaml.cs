﻿using System;
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
    /// Interaction logic for NotepadControl.xaml
    /// </summary>
    public partial class NotepadTab : UserControl
    {
        public Brush detachWindow_btn_brsh;
        public Brush detachWindowHover_btn_brsh;

        public bool detached;

        public NotepadTab()
        {
            InitializeComponent();

            //Get Colour/Brush Variables for Title Bar Buttons
            detachWindow_btn_brsh = DetachWindow_btn.Background;

            //Set Colour/Brush Variables for Title Bar Hover
            detachWindowHover_btn_brsh = new SolidColorBrush(Color.FromArgb(255, 63, 110, 175));
        }

        private void DetachWindow_btn_Click(object sender, RoutedEventArgs e)
        {
            if(detached != false)
            {
                DetachWindow_btn.Visibility = Visibility.Hidden;
                return;
            }

            SeperatedWindow container = new SeperatedWindow();
            Grid mainTab = (Grid)Application.Current.MainWindow.FindName("TabGrid");
            mainTab.Children.Remove(this);
            container.AttachTab(this);
            container.Show();
            detached = true;
            DetachWindow_btn.Visibility = Visibility.Hidden;


        }

        private void DetachWindow_btn_Hover_Enter(object sender, MouseEventArgs e)
        {
            DetachWindow_btn.Background = detachWindowHover_btn_brsh;
        }

        private void DetachWindow_btn_Hover_Leave(object sender, MouseEventArgs e)
        {
            DetachWindow_btn.Background = detachWindow_btn_brsh;
        }

    }
}
