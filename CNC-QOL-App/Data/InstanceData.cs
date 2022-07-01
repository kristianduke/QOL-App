using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CNC_QOL_App
{
    public class InstanceData
    {
        //Main Tab, Opened on Start, Is set inside App.xaml.cs
        public static MainTab MainTab;

        // List of Main Windows.
        public static List<WindowFrame> SeperatedWindows = new List<WindowFrame>();

        public static Dictionary<UserControl, Type> Tabs = new Dictionary<UserControl, Type>();
    }
}
