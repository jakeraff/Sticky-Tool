using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CommandLine;
using CommandLine.Text;

namespace Sticky_Tool
{
    class Program
    {
        class Options
        {
            [Option("type", HelpText = "Specifies the executable to act on")]
            public string ExeType { get; set; }

            [Option("replace", HelpText = "Specifies if replace is needed and indicates the replacement file")]
            public string Replace { get; set; }

            [Option("restore", HelpText = "Specifies if restore is needed")]
            public bool Restore { get; set; }

            [Option("register", HelpText = "Registers the replacement executable as a program")]
            public bool Register { get; set; }
        }

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        [STAThread]
        static void Main(string[] args)
        {
            //Introduction
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (args.Count() == 0)
            {
                FreeConsole();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new gui());
            }

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Sticky Tool by Jacob Raffoul");
                    Console.WriteLine("Copyright  (c) 2023 Raffoul Technologies");
                    Console.WriteLine($"Version: {version}");
                    Console.WriteLine("Learn more at https://github.com/RaffTechAU/Sticky-Tool");
                    Console.WriteLine("--------------------");

                    if (o.ExeType == null || o.ExeType.ToString() == "")
                    {
                        Console.WriteLine();
                        Console.WriteLine("--type must be provided!");
                        Console.WriteLine();
                    }
                    else if (o.Replace != null && !(o.Restore))
                    {
                        try
                        {
                            if (!(o.ExeType.EndsWith(".exe")))
                            {
                                o.ExeType += ".exe";
                            }

                            if (!(Array.Exists(Methods.validTypes, element => element[0] == o.ExeType.ToString())))
                            {
                                throw new InvalidOperationException("Provided type is not valid!");
                            }

                            var realType = o.ExeType.ToString();
                            var realPath = Path.GetFullPath(o.Replace);

                            if (!(File.Exists(realPath)) || !(realPath.EndsWith(".exe")))
                            {
                                throw new FileNotFoundException("Provided filepath is not valid!");
                            }

                            Methods.Replace(realType, realPath);
                            Console.WriteLine();
                            Console.WriteLine($"Successfully replaced {realType} with {realPath}!");
                            Console.WriteLine();

                            if (o.Register)
                            {
                                Methods.Register(realType);
                                Console.WriteLine();
                                Console.WriteLine($"Successfully registered {realType} as a program!");
                                Console.WriteLine();
                            }
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine();
                            Console.WriteLine(err.Message);
                            Console.WriteLine();
                        }
                    }
                    else if (o.Restore && !(o.Register) && (o.Replace == "" || o.Replace == null))
                    {
                        try
                        {
                            if (!(o.ExeType.EndsWith(".exe"))) { o.ExeType += ".exe"; }

                            if (!(Array.Exists(Methods.validTypes, row => row[0] == o.ExeType.ToString())))
                            {
                                throw new InvalidOperationException("Provided type is not valid!");
                            }

                            var realType = o.ExeType.ToString();

                            Methods.Restore(realType);
                            Console.WriteLine();
                            Console.WriteLine($"Successfully restored {o.ExeType}!");
                            Console.WriteLine();
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine();
                            if (err.GetType().Name.ToString() == "ArgumentException")
                            {
                                Console.WriteLine("Nothing to restore!");
                            }
                            else
                            {
                                Console.WriteLine(err.Message); 
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Incorrect parameters provided. Please refer to --help");
                        Console.WriteLine();
                    }
                })
                .WithNotParsed<Options>(errs =>
                {
                    if (errs.Any(x => x.Tag == ErrorType.HelpRequestedError))
                    {
                        //do nothing
                    }
                    else if (errs.Any(x => x.Tag == ErrorType.VersionRequestedError))
                    {
                        //do nothing
                    }
                });
        }
    }
}
