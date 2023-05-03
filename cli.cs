using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace Sticky_Tool
{
    public class cli
    {
        static public void Main(string[] args)
        {
            /*
            if (args[0] == "--file"
            {

            } 
            var sethcPath = @"C:\windows\system32\sethc.exe";
            var sethcOldPath = @"C:\windows\system32\sethc.old";
            string filePath;

            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", @"/k takeown /f C:\Windows\System32\sethc.exe /a && icacls C:\Windows\System32\sethc.exe /grant EVERYONE:F /q /c && exit");
            processInfo.UseShellExecute = true;
            processInfo.Verb = "runas";
            try
            {
                Process.Start(processInfo);
            }
            catch (Win32Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            if (args.Length == 1 && args[0] == "--restore")
            {
                try
                {
                    if (File.Exists(sethcOldPath))
                    {
                        File.Delete(sethcPath);
                        File.Move(sethcOldPath, sethcPath);
                        Console.WriteLine("Successfully restored sethc.exe!");
                    }
                    else
                    {
                        Console.WriteLine("sethc.old not found. Nothing to restore.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            if (args.Length < 2 || args[0] != "--file")
                do
                {
                    Console.Write("Please enter the file path: ");
                    filePath = Console.ReadLine();
                }
                while (filePath == null);
            else
            {
                filePath = args[1];
            }

            try
            {
                if (File.Exists(sethcOldPath))
                {
                    File.Delete(sethcPath);
                }
                else
                {
                    File.Move(sethcPath, sethcOldPath);
                }

                File.Copy(filePath, sethcPath, true);

                Console.WriteLine("Successfully ran Sticky Tool!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            */
        }
    }
}