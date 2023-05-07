using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sticky_Tool
{
    public class Methods 
    {

        public static string[][] validTypes = new string[][] {
            new string[] { "sethc.exe","Sticky Keys" },
            new string[] { "utilman.exe","Accessibility UI" },
            new string[] { "narrator.exe","Narrator" },
            new string[] { "magnify.exe","Magnifier" },
            new string[] { "osk.exe","On-Screen Keyboard" }
        };

        private static string regPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\";
        private static string saveDir = @"C:\Windows";
        private static string instPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";

        public static void Replace(String oldEXE, String newEXE)
        {
            File.Copy(newEXE, $@"{saveDir}\Sticky-{oldEXE}", true);
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(regPath + oldEXE);
            key.SetValue("Debugger", saveDir + @"\Sticky-" + oldEXE);
            key.Close();
        }

        public static void Register(String oldEXE)
        {
            
            var fileCMD = $@"del {saveDir}\Sticky-{oldEXE} /F /Q";
            var regCMD = $"REG DELETE \"HKEY_LOCAL_MACHINE\\{regPath}{oldEXE}\" /V Debugger /F";
            var pgmCMD = $"REG DELETE \"HKEY_LOCAL_MACHINE\\{instPath}Sticky-{oldEXE}\" /F";

            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(instPath + "Sticky-" + oldEXE);

            key.SetValue("DisplayIcon", saveDir + @"\Sticky-" + oldEXE);
            key.SetValue("DisplayName", @"Sticky-" + oldEXE);
            key.SetValue("HelpLink", "https://github.com/rafftechau/sticky-tool");
            key.SetValue("InstallLocation", @"C:\Windows");
            key.SetValue("NoModify", 1, RegistryValueKind.DWord);
            key.SetValue("NoRepair", 1, RegistryValueKind.DWord);
            key.SetValue("Publisher", "Jacob Raffoul");
            key.SetValue("UninstallString", $"cmd /c {fileCMD} & {regCMD} & {pgmCMD}");

            key.Close();
        }

        public static void Restore(String oldEXE)
        {
            File.Delete(saveDir+@"\Sticky-"+oldEXE);
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regPath + oldEXE, true);
            key.DeleteValue("Debugger");
            key.Close();

            if (Registry.LocalMachine.OpenSubKey(instPath + "Sticky-" + oldEXE) != null)
            {
                Registry.LocalMachine.DeleteSubKeyTree(instPath + "Sticky-" + oldEXE);
            }
        }
    }
}
