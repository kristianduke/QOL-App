using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CNC_QOL_App
{
    internal class WindowCreator
    {
        public static UserControl CreateWindow(UserControl control)
        {
            if (InstanceData.Tabs[control] == typeof(NotepadTab))
            {
                return new NotepadTab();
            } else
            {
                return null;
            }
        }
    }
}
