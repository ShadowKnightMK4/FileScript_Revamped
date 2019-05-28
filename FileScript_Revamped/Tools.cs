using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
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
        /// Set clipboard to "Notepad.exe" when passed "C:\Windows\notepad.exe"
        /// </summary>
        SetClipboardFileName = 4,
        /// <summary>
        /// Set clipboard to "Notepad" from C:\Windows\notepad.exe"
        /// </summary>
        SetClipboardFileNameNoExt = 5,
        /// <summary>
        /// Set clipboard to "C:\Windows\notepad.exe" from "C:\Windows\notepad.exe"
        /// </summary>
        SetClipboardCompleteLocation = 6,
        /// <summary>
        /// encase C:\\Windows\\notepad.exe in \" \" and set clipboard to this
        /// </summary>
        SetClipboardQuotedCompletePath = 7,
        /// <summary>
        /// set clipboard to C/c++/C# friendly filepath string
        /// </summary>
        SetClipboardQuotedCodeCompletePath = 8,
        /// <summary>
        /// Explore and set it to FileScript's location
        /// </summary>
        FindMe = 9,
        /// <summary>
        /// launch the extras GUI menu
        /// </summary>
        ExtrasMenu = 10,
        /// <summary>
        /// Copy to local one drive in the logged on user's userprofile
        /// this resolves to $(UserProfile)\Onedrive
        /// </summary>
        CopyToLocalOneDrive = 11,

        CreateJunctionFromHere = 12,
        CreateHardLinkFromHere = 13,
        // do nothing
        Nothing = 14,
        /// <summary>
        /// if target is a file, zip it as file.zip
        /// if target is a folder zip its contents recursively as folder.zip
        /// </summary>
        ZipContents = 15,
        /// <summary>
        /// extra the target zip with folder structure intact
        /// </summary>
        UnZipContents = 16

    }

    public static class ToolFunction
    {
        static readonly string ExploreCmd;
        static readonly string LaunchCmdPrompt;
        static readonly string LaunchCmdPromptArgString;

    
        static ToolFunction()
        {
            ExploreCmd = "\"$(WINDOWS)\\explorer.exe\"";
            LaunchCmdPrompt = "\"$(system32)\\cmd.exe\"";
            LaunchCmdPromptArgString = "/K cd {0}";
        }

        static void UnZipCommand(string Zip)
        {
            int EntryCount = 0;
            bool OkToKeepGoing = false;
            StringBuilder TargetTempFolder = new StringBuilder(GetTempFileLocation());
            StringBuilder FinalFolder = new StringBuilder();

            if (!Zip.Contains(Path.VolumeSeparatorChar))
            {
                FinalFolder.Append(Directory.GetCurrentDirectory());
            }
            else
            {
                FinalFolder.Append(Path.GetDirectoryName(Zip));
            }

            if (FinalFolder.Length != 0)
            {
                if (FinalFolder[FinalFolder.Length - 1] != Path.DirectorySeparatorChar)
                {
                    FinalFolder.Append(Path.DirectorySeparatorChar);

                }
            } 

            if  (File.Exists(TargetTempFolder.ToString()))
            {
                File.Delete(TargetTempFolder.ToString());
                if (TargetTempFolder[TargetTempFolder.Length - 1] != Path.DirectorySeparatorChar)
                {
                    TargetTempFolder.Append(Path.DirectorySeparatorChar);
                }
                TargetTempFolder.Append(Path.GetFileNameWithoutExtension(Zip));
                Directory.CreateDirectory(TargetTempFolder.ToString());

                try
                {
                    using (FileStream Input = File.OpenRead(Zip))
                    {
                        using (ZipArchive Arch = new ZipArchive(Input, ZipArchiveMode.Read))
                        {
                            Arch.ExtractToDirectory(TargetTempFolder.ToString());
                            OkToKeepGoing = true;
                            EntryCount = Arch.Entries.Count;
                        }
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {

                    // if it's all good. Move the resulst to the target.
                    if (OkToKeepGoing)
                    {

                        //try
                        
                            {
                                if (EntryCount > 0)
                                {
                                    string[] Info = Directory.GetFiles(TargetTempFolder.ToString());
                                    StringBuilder RootBased = new StringBuilder();
                                    foreach (string SingleFile in Info)
                                    {
                                        RootBased.Clear();
                                        RootBased.Append(FinalFolder.ToString());
                                        if (RootBased[RootBased.Length-1] != Path.DirectorySeparatorChar)
                                        {
                                            RootBased.Append(Path.DirectorySeparatorChar);
                                        }
                                        if (Directory.Exists(RootBased.ToString()) == false)
                                        {
                                            try
                                            {
                                                Directory.CreateDirectory(RootBased.ToString());
                                            }
                                            catch (UnauthorizedAccessException)
                                            {
                                                Console.WriteLine("Could not completely extract zip file " + Zip);
                                                Console.WriteLine("Access Denied at " + RootBased.ToString());
                                                break;
                                            }
                                        }
                                        RootBased.Append(SingleFile.Substring(TargetTempFolder.Length));
                                        try
                                        {
                                            if ((SafeMode == true) && (File.Exists(RootBased.ToString())))
                                            {
                                                Console.WriteLine(string.Format("Error: Unable to extra {0} to {1}. Reason is target already exists and SafeMode is on", SingleFile, RootBased.ToString()));
                                            }
                                            else
                                            {
                                            bool OkMove = false;
                                                if (File.Exists(RootBased.ToString()))
                                                {
                                                    try
                                                    {
                                                        File.Delete(RootBased.ToString());
                                                        OkMove = true;
                                                    }
                                                    catch (IOException)
                                                    {
                                                        // can't delete. 
                                                        OkMove = false;
                                                    }
                                                }
                                                else
                                                {
                                                    OkMove = true;
                                                }
                                                if (OkMove == true)
                                                {
                                                    File.Move(SingleFile, RootBased.ToString());
                                                    Console.WriteLine("Extracted to " + RootBased.ToString());
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Unable to move " + SingleFile + " to final location of " + RootBased.ToString());
                                                }
                                            }
                                        }
                                        catch (UnauthorizedAccessException)
                                        {
                                            Console.WriteLine("Access Denied when moving to " + RootBased.ToString());
                                            continue;
                                        }
                                        catch (IOException e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        
                                    }

                                    if (Directory.Exists(FinalFolder.ToString()))
                                    {
                                     if (ShowResults)
                                        Explore(FinalFolder.ToString());
                                    }
                                }
                            }
                        
                        
                    }

                    // now clean up temp folder
                    Directory.Delete(TargetTempFolder.ToString(),true);
                }


            }
            else
            {
                Console.WriteLine("Error: Could not extract zip. Reason being failed to setup tempoary storage");
            }
        }
        public static void LaunchExternCommand(string App, string Args, bool UseShell, string verb = "", string WorkingDir = "")
        {
            using (Process Target = new Process())
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                Target.StartInfo = processStartInfo;
                Target.StartInfo.FileName = App;
                Target.StartInfo.Arguments = Args;

                Target.StartInfo.UseShellExecute = UseShell;
                if (string.IsNullOrEmpty(WorkingDir) == false)
                {
                    Target.StartInfo.WorkingDirectory = WorkingDir;
                }
                else
                {
                    Target.StartInfo.WorkingDirectory = string.Empty;
                }
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
            if (string.IsNullOrEmpty(NewTarget))
            {
                MessageBox.Show(string.Format("{0} Does not appear to exist. . .", Target));
            }
            else
            {
                cmd = new StringBuilder();
                cmd.AppendFormat(ArgumentExpander.ExpandVars(LaunchCmdPrompt), NewTarget, string.Empty);
                CmdArg = string.Format(LaunchCmdPromptArgString, Path.GetDirectoryName(ArgumentExpander.ExpandVars(Target)));
                if (TryAdmin)
                {
                    LaunchExternCommand(cmd.ToString(), CmdArg, true, "runas", Target);
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

            if (FileMode)
            {
                NewTarget.Append(Path.GetDirectoryName(Target));
            }
            else
            {
                NewTarget.Append(Target);
            }
            LaunchExternCommand(ShellCmd, NewTarget.ToString(), false);
        }

        static string GetTempFileLocation()
        {
            StringBuilder ret = new StringBuilder();

            ret.Append(Path.GetTempFileName());

            return ret.ToString();
        }


        static void ZipCmd(string Target)
        {

            StringBuilder TargetName = new StringBuilder();
            bool isFolder = false;
            if (File.Exists(Target))
            {
               // isFolder = false;
            }
            else
            {
                if (Directory.Exists(Target))
                {
                 //   isFolder = true;
                }
                else
                {
                    Console.WriteLine(string.Format("Warning: Can't detected if {0} exists. You possible do not have required access to this file", Target));
                    return;
                }
            }

            TargetName.Append(Path.GetDirectoryName(Target));
            if (TargetName.Length > 0)
            {
                if (TargetName[TargetName.Length - 1] != '\\')
                {
                    TargetName.Append('\\');
                }
            }
            else
            {

            }

            if (Target.Contains(Path.VolumeSeparatorChar) == false)
            {
                TargetName.Append(Directory.GetCurrentDirectory());
                if (TargetName.Length > 0)
                {
                    if (TargetName[TargetName.Length - 1] != Path.DirectorySeparatorChar)
                    {
                        TargetName.Append(Path.DirectorySeparatorChar);
                    }
                }
            }

            {
                TargetName.Append(Path.GetFileNameWithoutExtension(Target));
            }

            if (TargetName[TargetName.Length - 1] != '.')
            {
                TargetName.Append('.');
            }
            TargetName.Append("zip");

            if (isFolder == false)
            {
              
                string tempTarget = GetTempFileLocation();
                var stream = File.Open(tempTarget, FileMode.OpenOrCreate);
                try
                {
                    if (stream != null)
                    {
                        using (ZipArchive TargetZip = new ZipArchive(stream, ZipArchiveMode.Create))
                        {
                            try
                            {
                                ZipArchiveEntry Entry = TargetZip.CreateEntryFromFile(Target, Path.GetFileName(Target));
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("Error creating zip." + e.Message);
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Error creating archive at " + TargetName.ToString());
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error creating archive at " + TargetName.ToString());
                    Console.WriteLine("Reason is " + e.Message);
                }

                try
                {

                    File.Move(tempTarget, TargetName.ToString());
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access denied at " + TargetName.ToString());
                    Console.WriteLine("Contents will be abvalable at " + tempTarget);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error finalizing zip. Reason " + e.Message);
                    Console.WriteLine("Contents will be abvalable at " + tempTarget);
                }



            }
            if (isFolder == true)
            {
                bool OK = false;
                string tempTarget = GetTempFileLocation();
                try
                {
                    if (File.Exists(tempTarget))
                    {
                        File.Delete(tempTarget);
                    }
                    ZipFile.CreateFromDirectory(Target, tempTarget);
                    OK = true;
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine("Could create zip file. Reason " + e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Could create zip file. Reason " + e.Message);
                }
                finally
                {
                    if (OK == true)
                    {
                        bool MoveOk = false;
                        try
                        {
                            File.Move(tempTarget, TargetName.ToString());
                            MoveOk = true;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("Access Denied. Can't move " + tempTarget + " to " + TargetName.ToString());
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("There was an error finializing zip. Error message is " + e.Message);
                        }
                        finally
                        {
                            if (MoveOk == false)
                            {
                                Console.WriteLine("There was an error creating file at " + TargetName.ToString());
                                Console.WriteLine("The that file's contents is stored at " + tempTarget);
                            }
                            else
                            {
                                if (ShowResults)
                                {
                                    Explore(TargetName.ToString());
                                }
                            }
                        }
                    }
                }
            }


            
        }


        public static void Invoke(ToolFunctionCommand cmd, string Target)
        {
            if (SafeMode == true)
            {
                Console.WriteLine("Safemode is on. No files you specify will be forcibly overwritten");
            }
            if (SafeMode == false)
            {
                Console.WriteLine("Safemode is off. If you specify a file that already exists to be written to, it will be overwritten");
            }
            try
            {
                switch (cmd)
                {
                    case ToolFunctionCommand.Nothing:
                        break;
                    case ToolFunctionCommand.ZipContents:
                        ZipCmd(Target);
                        break;
                    case ToolFunctionCommand.UnZipContents:
                        UnZipCommand(Target);
                        break;
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
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        using (MainForm Extras = new MainForm())
                        {
                            Extras.TargetFile = Target;
                            Application.Run(Extras);
                        }
                        break;
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


        /*
         * If true then Files you specific won't be overwritten 
         * If false then yes they will.
         * 
         * Does not apply to tempory items that the software creates.
         */
        public static bool SafeMode = true;

        /// <summary>
        /// should an active have a result in adjusting afile (move, create, ect..)
        /// and results in a new file, Explore the new file's location
        /// </summary>
        public static bool ShowResults = false;

    }

}
