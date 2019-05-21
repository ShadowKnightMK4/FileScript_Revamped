using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
namespace FileScript_Revamped
{
    public enum ToolFunctionCommand
    {
        //
        // Launch Explorer pointed to this file object
        //
        Explore = 0,
        //
        // Launch cmd.exe with CD set to this file's folder
        //
        LaunchCmdWithSetCurrentDirectory = 1,
        //
        // same as other except explite "runas" for UAC prompt
        //
        AdminLaunchCmdWithSetCurrentDirectory = 2,
        /// <summary>
        /// set clipboard to "C:\\Windows\\" when passed "C:\\Windows\\notepad.exe"
        /// </summary>
        SetClipboardFilePath = 3,
        /// <summary>
        /// Set clipboard to "Notepad.exe" when passed "C:\\Windows\\notepad.exe"
        /// </summary>
        SetClipboardFileName  = 4,
        SetClipboardFileNameNoExt = 5,
        SetClipboardCompleteLocation = 6,
        SetClipboardQuotedCompletePath = 7,
        SetClipboardQuotedCodeCompletePath = 8,
        FindMe= 9,
        ExtrasMenu = 10,
        CopyToLocalOneDrive = 11,
        CreateJunctionFromHere = 12,
        CreateHardLinkFromHere = 13,
        Nothing = 14
    }

    public static class ToolFunction
    {
        readonly static string  ExploreCmd = "\"$(WINDOWS)\\explorer.exe\"";
        readonly static string LaunchCmdPrompt = "\"$(system32)\\cmd.exe\"";
        readonly static string LaunchCmdPromptArgString = "/K cd {0}";
        public static void LaunchExternCommand(string App, string Args, bool UseShell, string verb="")
        {
            using (Process Target = new Process())
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                Target.StartInfo = processStartInfo;
                Target.StartInfo.FileName = App;
                Target.StartInfo.Arguments = Args;

                Target.StartInfo.UseShellExecute = UseShell;
                if (UseShell)
                {
                    Target.StartInfo.Verb = verb;
                }
                try
                {
                    Target.Start();
                }
                catch (System.ComponentModel.Win32Exception e)
                {
                    MessageBox.Show(string.Format("{0}, {1}", Target.StartInfo.FileName, e.Message));
                }
                finally
                {

                }
            }
        }

        static void LaunchCmd(string Target, bool TryAdmin)
        {
            StringBuilder cmd;
            string CmdArg;
            string NewTarget;
                
            if (string.IsNullOrEmpty(Target))
            {
                return;
            }
            if (File.Exists(Target))
            {
                NewTarget = Path.GetDirectoryName(Target);
            }
            else
            {
                if (Directory.Exists(Target))
                {
                    NewTarget = Target;
                }
                else
                {
                    NewTarget = string.Empty;
                }
            }
            if (NewTarget.Equals(string.Empty))
            {
                MessageBox.Show(string.Format("{0} Does not appear to exist. . .", Target));
            }
            else
            {
                cmd = new StringBuilder();
                cmd.AppendFormat(ArgumentExpander.ExpandVars(LaunchCmdPrompt), NewTarget, string.Empty);
                CmdArg = string.Format(LaunchCmdPromptArgString, Path.GetDirectoryName( ArgumentExpander.ExpandVars(Target)));
                if (TryAdmin)
                {
                    LaunchExternCommand(cmd.ToString(), CmdArg, true, "runas");
                }
                else
                {
                    LaunchExternCommand(cmd.ToString(), CmdArg, true);
                }

            }
        }
        static void CopyFile(string target, string source)
        {
            try
            {
                File.Copy(source, target, true);
            }
            catch (IOException e)
            {
                MessageBox.Show(string.Format("There was an error copying {0} to target {1}. Error Message {2}", source, target, e.Message));
            }
            
        }

        static void CopyToOneDrive(string source)
        {
            StringBuilder Target = new StringBuilder();
            if (File.Exists(source))
            {
                Target.Append(ArgumentExpander.Query(ArgumentExpanderSupported.OneDrive));
                if (Target[Target.Length] != '\\')
                {
                    Target.Append('\\');
                }
                Target.Append(Path.GetFileName(source));
                CopyFile(Target.ToString(), source);
            }

            
        }
        enum SetClipBoardMode
        {
            OnlyFileName = 1,
            FileLocation = 2,
            FileNameNoExt = 3,
            QuotedCompleteFileName = 4,
            QuotedCompleteFileNamewithSlash = 5,
            CompleteFileName = 6
        }

        static void SetClipboard(string Target, SetClipBoardMode Mode)
        {
            string clippy;
            switch (Mode)
            {
                case SetClipBoardMode.FileLocation:
                    clippy = Path.GetDirectoryName(Target);
                    break;
                case SetClipBoardMode.FileNameNoExt:
                    clippy = Path.GetFileNameWithoutExtension(Target);
                    break;
                case SetClipBoardMode.OnlyFileName:
                    clippy = Path.GetFileName(Target);
                    break;
                case SetClipBoardMode.CompleteFileName:
                    clippy = Target;
                    break;
                case SetClipBoardMode.QuotedCompleteFileName:
                    {
                        clippy = "\"" + Target + "\"";
                        break;
                    }
                case SetClipBoardMode.QuotedCompleteFileNamewithSlash:
                    {
                        StringBuilder ret = new StringBuilder();
                        ret.Append("\"");
                        for (int step = 0; step < Target.Length; step++)
                        {
                            if (Target[step] == '\\')
                            {
                                ret.Append("\\\\");
                            }
                            else
                            {
                                ret.Append(Target[step]);
                            }
                        }
                        ret.Append("\"");
                        clippy = ret.ToString();
                        break;
                    }
                default:
                    clippy = string.Empty;
                    break;
            }

            Clipboard.SetText(clippy);
        }
        /// <summary>
        /// if Target is a file, launch explorer to file
        /// if target is a folder, launch explorer to open said folder
        /// </summary>
        /// <param name="Target"></param>
        static void Explore(string Target)
        {
            StringBuilder NewTarget = new StringBuilder();
            string ShellCmd = ArgumentExpander.ExpandVars(ExploreCmd);
            bool FileMode = false;
            if (File.Exists(Target) == false)
            {
                if (Directory.Exists(Target) == false)
                {
                    MessageBox.Show(string.Format("Error: {0} not found", Target));
                }
                else
                {
                    FileMode = false;
                }
            }
            else
            {
                FileMode = true;
            }

            if (FileMode )
            {
                NewTarget.Append(Path.GetDirectoryName(Target));
            }
            else
            {
                NewTarget.Append(NewTarget);
            }
            LaunchExternCommand(ShellCmd, NewTarget.ToString(), false);
        }
        public static void Invoke(ToolFunctionCommand cmd, string Target)
        {
            try
            {
                switch (cmd)
                {
                    case ToolFunctionCommand.LaunchCmdWithSetCurrentDirectory:
                        LaunchCmd(Target, false);
                        break;
                    case ToolFunctionCommand.AdminLaunchCmdWithSetCurrentDirectory:
                        LaunchCmd(Target, true);
                        break;
                    case ToolFunctionCommand.SetClipboardCompleteLocation:
                        SetClipboard(Target, SetClipBoardMode.CompleteFileName);
                        break;
                    case ToolFunctionCommand.SetClipboardFileName:
                        SetClipboard(Target, SetClipBoardMode.OnlyFileName);
                        break;
                    case ToolFunctionCommand.SetClipboardFileNameNoExt:
                        SetClipboard(Target, SetClipBoardMode.FileNameNoExt);
                        break;
                    case ToolFunctionCommand.SetClipboardFilePath:
                        SetClipboard(Target, SetClipBoardMode.FileLocation);
                        break;
                    case ToolFunctionCommand.SetClipboardQuotedCodeCompletePath:
                        SetClipboard(Target, SetClipBoardMode.QuotedCompleteFileNamewithSlash);
                        break;
                    case ToolFunctionCommand.SetClipboardQuotedCompletePath:
                        SetClipboard(Target, SetClipBoardMode.QuotedCompleteFileName);
                        break;
                    case ToolFunctionCommand.CreateHardLinkFromHere:
                        break;
                    case ToolFunctionCommand.CreateJunctionFromHere:
                        break;
                    case ToolFunctionCommand.CopyToLocalOneDrive:
                        CopyToOneDrive(Target);
                        break;
                    case ToolFunctionCommand.Explore:
                        Explore(Target);
                        break;
                    case ToolFunctionCommand.ExtrasMenu:
                    case ToolFunctionCommand.FindMe:
                        Explore(Process.GetCurrentProcess().MainModule.FileName);
                        return;
                    default:
                        throw new NotImplementedException(cmd.ToString());
                }

            }
            catch (NotImplementedException)
            {
                MessageBox.Show(string.Format("Error: cmd {0} is not immplemented", cmd.ToString()));
            }
        }
    }
}
