using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CNC_QOL_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WindowFrame mainWindow = new WindowFrame();
            InstanceData.SeperatedWindows.Add(mainWindow);

            MainTab mainTab = new MainTab();

            InstanceData.MainTab = mainTab;

            mainWindow.WindowContent.Children.Add(mainTab);
            mainWindow.Show();
        }
    }
}
