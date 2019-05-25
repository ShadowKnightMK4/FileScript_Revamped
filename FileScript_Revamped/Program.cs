using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace FileScript_Revamped
{

    static class Program
    {
        // extract and display the UsageText.txt file
        static void Usage()
        {
            var TargetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FileScript_Revamped.UsageText.txt");

            if (TargetStream != null)
            {
                using (var stdout = Console.OpenStandardOutput())
                {
                    TargetStream.CopyTo(stdout);
                    TargetStream.Flush();
                }
            }
            else
            {
                Console.WriteLine("Error: Could not load Usage text from resources. UsageText.txt not found");
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // the first non self non '/' command 
            // beocmes this.
            string TargetFileObject;
            ArgumentExpander.BuildEnv();

            TargetFileObject = string.Empty;

            for (int step= 0; step < args.Length;step++)
            {
                //if (step.Equals(0))
                {
                  //  TargetFileObject = ArgumentExpander.ExpandVars(args[step]);
                }
                //else
                {
                    switch (args[step].ToLower().Replace('-','/'))
                    {
                        case "/target":
                        case "/t":
                            if (step+1 >= args.Length)
                            {
                                Console.WriteLine("Error: Encounted end of argument list looking for /target [File System Item]");
                                break;
                            }
                            else
                            {
                                step++;
                                TargetFileObject = args[step];
                            }
                            break;
                        case "/usage":
                        case "/help":
                        case "/?":
                            Usage();
                            break;
                        case "/showenv":
                                ArgumentExpander.ShowEnv();
                            break;
                        case "/install":
                            break;
                        case "/uninstall":
                            break;
                        case "/extras":
                            {
                                ToolFunction.Invoke(ToolFunctionCommand.ExtrasMenu, TargetFileObject);
                                break;
                            }
                        case "/filename":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.SetClipboardFileName, TargetFileObject);
                                break;
                            }
                        case "/filepath":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.SetClipboardFilePath, TargetFileObject);
                                break;
                            }
                        case "/cfilename":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.SetClipboardCompleteLocation, TargetFileObject);
                                break;
                            }
                        case "/quotedfilename":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.SetClipboardQuotedCodeCompletePath, TargetFileObject);
                                break;
                            }
                        case "/codefriendlyfilename":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.SetClipboardQuotedCodeCompletePath, TargetFileObject);
                                break;
                            }
                        case "/findme":
                            ToolFunction.Invoke(ToolFunctionCommand.FindMe, TargetFileObject);
                            break;
                        case "/explore":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.Explore, TargetFileObject);
                                break;
                            }
                        case "/command.com":
                        case "/cmd":
                        case "/prompt":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.LaunchCmdWithSetCurrentDirectory, TargetFileObject);
                                break;
                            }
                        case "/admincmd":
                        case "/cmdadmin":
                            {
                                if (string.IsNullOrEmpty(TargetFileObject))
                                {
                                    Console.WriteLine(string.Format("{0} needs a target file system item. Fizzles....", args[step]));
                                    break;
                                }

                                ToolFunction.Invoke(ToolFunctionCommand.AdminLaunchCmdWithSetCurrentDirectory, TargetFileObject);
                                break;
                            }
                          
                        default:
                            //MessageBox.Show(string.Format("Unknown Command {0}", args[step]));
                            Console.WriteLine(string.Format("Unknown Command {0}", args[step]));
                            break;
                    }

                }
            }
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            return;
        }
    }
}
