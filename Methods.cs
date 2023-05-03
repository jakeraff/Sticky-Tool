using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sticky_Tool
{
    public class Methods 
    {
        public static void Stick(String oldEXE, String newEXE)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + oldEXE);
            key.SetValue("Debugger", newEXE);
            key.Close();
        }

        public static void Restore(String oldEXE)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\"+oldEXE);
            key.DeleteValue("Debugger");
            key.Close();
        }
    }
}
