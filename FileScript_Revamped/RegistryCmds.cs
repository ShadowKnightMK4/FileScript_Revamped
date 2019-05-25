using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace FileScript_Revamped
{
    class RegistryCmds
    {
        public string CreateShellCommand(string BaseApp, int ArgCount, bool AppendExtram, string baseFlag)
        {
            StringBuilder ret = new StringBuilder();
            if (BaseApp.Contains('\"'))
            {
                ret.Append(BaseApp);
            }
            else
            {
                if (BaseApp.Contains(' '))
                {
                    ret.AppendFormat("\"{0}\"", BaseApp);
                }
                else
                {
                    ret.Append(BaseApp);
                }
            }

            if (AppendExtram)
            {
                ret.Append(" ");

                for (int step = 1; step <= ArgCount; step++)
                {
                    ret.AppendFormat("%{0}", step);
                }
            }
            ret.AppendFormat(" {0}", baseFlag);



            return ret.ToString();
        }

        public bool RemoveCommand(string BaseName, string FileExt="*")
        {
            bool ok = false;
            bool Exists = false;
            using (RegistryKey CLASSES_ROOT = Registry.ClassesRoot)
            {
                using (RegistryKey TargetFileHandler = CLASSES_ROOT.OpenSubKey(string.Format("{0}\\shell", FileExt), true))
                {
                    using (RegistryKey Victim = TargetFileHandler.OpenSubKey(BaseName, true))
                    {
                        Exists = true;
                    }
                    if (Exists)
                    {
                        TargetFileHandler.DeleteSubKeyTree(BaseName,false);
                    }
                }
            }
                return ok;
        }
        /// <summary>
        /// Installs a New Shell command under the shell menu.
        /// 
        /// </summary>
        /// <param name="BaseName">The name of the command as it will appear</param>
        /// <param name="Cmd">the app and its arguments that appear</param>
        /// <param name="FileExt">where to store the command. Default is * 'All Files'</param>
        /// <returns>true on ok, false if it failed</returns>
        public bool InstallCommand(string BaseName, string Cmd, string FileExt="*")
        {
            bool ok = false;
            using (RegistryKey CLASS_ROOT = Registry.ClassesRoot)
            {
                using (RegistryKey TargetFileHandler = CLASS_ROOT.CreateSubKey(string.Format("{0}\\shell",FileExt), true))
                {
                    using (RegistryKey CommandName = TargetFileHandler.CreateSubKey(BaseName))
                    {
                        using (RegistryKey CommandKey = CommandName.CreateSubKey("command", true))
                        {
                            CommandKey.SetValue(string.Empty, Cmd);
                            ok = true;
                        }
                    }
                }
            }
            return ok;
        }
    }
}
