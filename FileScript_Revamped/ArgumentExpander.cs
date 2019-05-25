using System;                                                                                                                                                                                                                                                                  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScript_Revamped
{

    public enum ArgumentExpanderSupported
    {

        //
        // Summary:
        //     The logical Desktop rather than the physical file system location.
        Desktop = 0,
        //
        // Summary:
        //     The directory that contains the user's program groups.
        Programs = 2,
        //
        // Summary:
        //     The directory that serves as a common repository for documents.
        Personal = 5,
        //
        // Summary:
        //     The My Documents folder.
        MyDocuments = 5,
        //
        // Summary:
        //     The directory that serves as a common repository for the user's favorite items.
        Favorites = 6,
        //
        // Summary:
        //     The directory that corresponds to the user's Startup program group.
        Startup = 7,
        //
        // Summary:
        //     The directory that contains the user's most recently used documents.
        Recent = 8,
        //
        // Summary:
        //     The directory that contains the Send To menu items.
        SendTo = 9,
        //
        // Summary:
        //     The directory that contains the Start menu items.
        StartMenu = 11,
        //
        // Summary:
        //     The My Music folder.
        MyMusic = 13,
        //
        // Summary:
        //     The file system directory that serves as a repository for videos that belong
        //     to a user. Added in the .NET Framework 4.
        MyVideos = 14,
        //
        // Summary:
        //     The directory used to physically store file objects on the desktop.
        DesktopDirectory = 16,
        //
        // Summary:
        //     The My Computer folder.
        MyComputer = 17,
        //
        // Summary:
        //     A file system directory that contains the link objects that may exist in the
        //     My Network Places virtual folder. Added in the .NET Framework 4.
        NetworkShortcuts = 19,
        //
        // Summary:
        //     A virtual folder that contains fonts. Added in the .NET Framework 4.
        Fonts = 20,
        //
        // Summary:
        //     The directory that serves as a common repository for document templates.
        Templates = 21,
        //
        // Summary:
        //     The file system directory that contains the programs and folders that appear
        //     on the Start menu for all users. This special folder is valid only for Windows
        //     NT systems. Added in the .NET Framework 4.
        CommonStartMenu = 22,
        //
        // Summary:
        //     A folder for components that are shared across applications. This special folder
        //     is valid only for Windows NT, Windows 2000, and Windows XP systems. Added in
        //     the .NET Framework 4.
        CommonPrograms = 23,
        //
        // Summary:
        //     The file system directory that contains the programs that appear in the Startup
        //     folder for all users. This special folder is valid only for Windows NT systems.
        //     Added in the .NET Framework 4.
        CommonStartup = 24,
        //
        // Summary:
        //     The file system directory that contains files and folders that appear on the
        //     desktop for all users. This special folder is valid only for Windows NT systems.
        //     Added in the .NET Framework 4.
        CommonDesktopDirectory = 25,
        //
        // Summary:
        //     The directory that serves as a common repository for application-specific data
        //     for the current roaming user.
        ApplicationData = 26,
        //
        // Summary:
        //     The file system directory that contains the link objects that can exist in the
        //     Printers virtual folder. Added in the .NET Framework 4.
        PrinterShortcuts = 27,
        //
        // Summary:
        //     The directory that serves as a common repository for application-specific data
        //     that is used by the current, non-roaming user.
        LocalApplicationData = 28,
        //
        // Summary:
        //     The directory that serves as a common repository for temporary Internet files.
        InternetCache = 32,
        //
        // Summary:
        //     The directory that serves as a common repository for Internet cookies.
        Cookies = 33,
        //
        // Summary:
        //     The directory that serves as a common repository for Internet history items.
        History = 34,
        //
        // Summary:
        //     The directory that serves as a common repository for application-specific data
        //     that is used by all users.
        CommonApplicationData = 35,
        //
        // Summary:
        //     The Windows directory or SYSROOT. This corresponds to the %windir% or %SYSTEMROOT%
        //     environment variables. Added in the .NET Framework 4.
        Windows = 36,
        //
        // Summary:
        //     The System directory.
        System = 37,
        //
        // Summary:
        //     The program files directory.On a non-x86 system, passing System.Environment.SpecialFolder.ProgramFiles
        //     to the System.Environment.GetFolderPath(System.Environment.SpecialFolder) method
        //     returns the path for non-x86 programs. To get the x86 program files directory
        //     on a non-x86 system, use the System.Environment.SpecialFolder.ProgramFilesX86
        //     member.
        ProgramFiles = 38,
        //
        // Summary:
        //     The My Pictures folder.
        MyPictures = 39,
        //
        // Summary:
        //     The user's profile folder. Applications should not create files or folders at
        //     this level; they should put their data under the locations referred to by System.Environment.SpecialFolder.ApplicationData.
        //     Added in the .NET Framework 4.
        UserProfile = 40,
        //
        // Summary:
        //     The Windows System folder. Added in the .NET Framework 4.
        SystemX86 = 41,
        //
        // Summary:
        //     The x86 Program Files folder. Added in the .NET Framework 4.
        ProgramFilesX86 = 42,
        //
        // Summary:
        //     The directory for components that are shared across applications.To get the x86
        //     common program files directory on a non-x86 system, use the System.Environment.SpecialFolder.ProgramFilesX86
        //     member.
        CommonProgramFiles = 43,
        //
        // Summary:
        //     The Program Files folder. Added in the .NET Framework 4.
        CommonProgramFilesX86 = 44,
        //
        // Summary:
        //     The file system directory that contains the templates that are available to all
        //     users. This special folder is valid only for Windows NT systems. Added in the
        //     .NET Framework 4.
        CommonTemplates = 45,
        //
        // Summary:
        //     The file system directory that contains documents that are common to all users.
        //     This special folder is valid for Windows NT systems, Windows 95, and Windows
        //     98 systems with Shfolder.dll installed. Added in the .NET Framework 4.
        CommonDocuments = 46,
        //
        // Summary:
        //     The file system directory that contains administrative tools for all users of
        //     the computer. Added in the .NET Framework 4.
        CommonAdminTools = 47,
        //
        // Summary:
        //     The file system directory that is used to store administrative tools for an individual
        //     user. The Microsoft Management Console (MMC) will save customized consoles to
        //     this directory, and it will roam with the user. Added in the .NET Framework 4.
        AdminTools = 48,
        //
        // Summary:
        //     The file system directory that serves as a repository for music files common
        //     to all users. Added in the .NET Framework 4.
        CommonMusic = 53,
        //
        // Summary:
        //     The file system directory that serves as a repository for image files common
        //     to all users. Added in the .NET Framework 4.
        CommonPictures = 54,
        //
        // Summary:
        //     The file system directory that serves as a repository for video files common
        //     to all users. Added in the .NET Framework 4.
        CommonVideos = 55,
        //
        // Summary:
        //     The file system directory that contains resource data. Added in the .NET Framework
        //     4.
        Resources = 56,
        //
        // Summary:
        //     The file system directory that contains localized resource data. Added in the
        //     .NET Framework 4.
        LocalizedResources = 57,
        //
        // Summary:
        //     This value is recognized in Windows Vista for backward compatibility, but the
        //     special folder itself is no longer used. Added in the .NET Framework 4.
        CommonOemLinks = 58,
        //
        // Summary:
        //     The file system directory that acts as a staging area for files waiting to be
        //     written to a CD. Added in the .NET Framework 4.
        CDBurning = 59,
        //
        //
        // Summery
        //      This returns UserProfile\\Onedrive
        OneDrive = 60
    };

    /// <summary>
    /// This class takes %Argument Text% input and expands 
    /// based on contents. One pay simple use Query to
    /// grab a value without parsing an argument
    /// </summary>
    public static class ArgumentExpander
    {
        readonly static Dictionary<string, ArgumentExpanderSupported> Env = new Dictionary<string, ArgumentExpanderSupported>();

        /// <summary>
        /// expand all vares to their value with query()
        /// Write it to Console.Writeline()
        /// </summary>
        public static void ShowEnv()
        {
            List<string> keys = Env.Keys.ToList();
            keys.Sort();
            for (int step = 0; step < keys.Count;step++)
            {
                Console.WriteLine(string.Format("${0} expands to {1}", keys[step], Query(Env[keys[step]])));
            }
            return;
        }
        public static void BuildEnv()
        {
            Env.Add("(windows)", ArgumentExpanderSupported.Windows);
            Env.Add("(system32)", ArgumentExpanderSupported.System);
            Env.Add("(userprofile)", ArgumentExpanderSupported.UserProfile);
            Env.Add("(desktop)", ArgumentExpanderSupported.Desktop);
            Env.Add("(admintools)", ArgumentExpanderSupported.AdminTools);
            Env.Add("(appdata)", ArgumentExpanderSupported.ApplicationData);
            Env.Add("(cdburn)", ArgumentExpanderSupported.CDBurning);
            Env.Add("(cookies)", ArgumentExpanderSupported.Cookies);
            Env.Add("(favorites)", ArgumentExpanderSupported.Favorites);
            Env.Add("(fonts)", ArgumentExpanderSupported.Fonts);
            Env.Add("(history)", ArgumentExpanderSupported.History);
            Env.Add("(internetcache)", ArgumentExpanderSupported.InternetCache);
            Env.Add("(internet cache)", ArgumentExpanderSupported.InternetCache);
            Env.Add("(localappdata)", ArgumentExpanderSupported.LocalApplicationData);
            Env.Add("(local appdata)", ArgumentExpanderSupported.LocalApplicationData);
            Env.Add("(localresouce)", ArgumentExpanderSupported.LocalizedResources);
            Env.Add("(local resouce)", ArgumentExpanderSupported.LocalizedResources);
            Env.Add("(my computer)", ArgumentExpanderSupported.MyComputer);
            Env.Add("(mycomputer)", ArgumentExpanderSupported.MyComputer);
            Env.Add("(my documents)", ArgumentExpanderSupported.MyDocuments);
            Env.Add("(mydocuments)", ArgumentExpanderSupported.MyDocuments);
            Env.Add("(my music)", ArgumentExpanderSupported.MyMusic);
            Env.Add("(mymusic)", ArgumentExpanderSupported.MyMusic);
            Env.Add("(my pictures)", ArgumentExpanderSupported.MyPictures);
            Env.Add("(mypictures)", ArgumentExpanderSupported.MyPictures);
            Env.Add("(my video)", ArgumentExpanderSupported.MyVideos);
            Env.Add("(myvideo)", ArgumentExpanderSupported.MyVideos);
            Env.Add("(network shortcuts)", ArgumentExpanderSupported.NetworkShortcuts);
            Env.Add("(networkshortcuts)", ArgumentExpanderSupported.NetworkShortcuts);
            Env.Add("(personal)", ArgumentExpanderSupported.Personal);
            Env.Add("(printer shortcuts)", ArgumentExpanderSupported.PrinterShortcuts);
            Env.Add("(printershortcuts)", ArgumentExpanderSupported.PrinterShortcuts);
            Env.Add("(program files)", ArgumentExpanderSupported.ProgramFiles);
            Env.Add("(program files X86)", ArgumentExpanderSupported.ProgramFilesX86);
            Env.Add("(programfilesX86)", ArgumentExpanderSupported.ProgramFilesX86);
            Env.Add("(programs)", ArgumentExpanderSupported.Programs);
            Env.Add("(recent)", ArgumentExpanderSupported.Recent);
            Env.Add("(resources)", ArgumentExpanderSupported.Resources);
            Env.Add("(sendto)", ArgumentExpanderSupported.SendTo);
            Env.Add("(startmenu)", ArgumentExpanderSupported.StartMenu);
            Env.Add("(startup)", ArgumentExpanderSupported.Startup);
            Env.Add("(system x86)", ArgumentExpanderSupported.SystemX86);
            Env.Add("(systemx86)", ArgumentExpanderSupported.SystemX86);
            Env.Add("(templates)", ArgumentExpanderSupported.Templates);
            Env.Add("(onedrive)", ArgumentExpanderSupported.OneDrive);
            
        }
        public static string ExpandVars(string Input)
        {
            StringBuilder ret = new StringBuilder();
            StringBuilder TokenParse = new StringBuilder();
            bool AmBuildingToken = false;

            for (int step = 0;step < Input.Length;step++)
            {
                if (AmBuildingToken)
                {
                    if (Input[step] == ')')
                    {
                        TokenParse.Append(Input[step]);
                        TokenParse.Replace(TokenParse.ToString(), TokenParse.ToString().ToLower());
                        AmBuildingToken = false;

                        if (Env.ContainsKey(TokenParse.ToString()))
                        {
                            ret.Append(Query(Env[TokenParse.ToString()]));
                        }
                        else
                        {
                            ret.Append(string.Empty);
                        }
                        
                        TokenParse.Clear();
                    }
                    else
                    {
                        TokenParse.Append(Input[step]);
                    }
                }
                else
                {
                    if (Input[step] == '$')
                    {
                        AmBuildingToken = true;
                    }
                    else
                    {
                        ret.Append(Input[step]);
                    }
                }
            }
            return ret.ToString();
        }

        public static string Query( ArgumentExpanderSupported Folder)
        {
            StringBuilder ret = new StringBuilder();
            switch (Folder)
            {
                case ArgumentExpanderSupported.CommonAdminTools:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonAdminTools);
                case ArgumentExpanderSupported.CommonApplicationData:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                case ArgumentExpanderSupported.CommonDesktopDirectory:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
                case ArgumentExpanderSupported.CommonDocuments:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                case ArgumentExpanderSupported.CommonMusic:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);
                case ArgumentExpanderSupported.CommonOemLinks:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonOemLinks);
                case ArgumentExpanderSupported.CommonPictures:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
                case ArgumentExpanderSupported.CommonProgramFiles:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
                case ArgumentExpanderSupported.CommonProgramFilesX86:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
                case ArgumentExpanderSupported.CommonPrograms:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                case ArgumentExpanderSupported.CommonStartup:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
                case ArgumentExpanderSupported.CommonTemplates:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates);
                case ArgumentExpanderSupported.CommonVideos:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
                case ArgumentExpanderSupported.AdminTools:
                    return Environment.GetFolderPath(Environment.SpecialFolder.AdminTools);
                case ArgumentExpanderSupported.ApplicationData:
                    return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                case ArgumentExpanderSupported.CDBurning:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CDBurning);
                case ArgumentExpanderSupported.CommonStartMenu:
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                case ArgumentExpanderSupported.Cookies:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
                case ArgumentExpanderSupported.Desktop:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                case ArgumentExpanderSupported.DesktopDirectory:
                    return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                case ArgumentExpanderSupported.Favorites:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
                case ArgumentExpanderSupported.Fonts:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
                case ArgumentExpanderSupported.History:
                    return Environment.GetFolderPath(Environment.SpecialFolder.History);
                case ArgumentExpanderSupported.InternetCache:
                    return Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                case ArgumentExpanderSupported.LocalApplicationData:
                    return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                case ArgumentExpanderSupported.LocalizedResources:
                    return Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources);
                case ArgumentExpanderSupported.MyComputer:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                case ArgumentExpanderSupported.MyDocuments:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                case ArgumentExpanderSupported.MyMusic:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                case ArgumentExpanderSupported.MyPictures:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                case ArgumentExpanderSupported.MyVideos:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                case ArgumentExpanderSupported.NetworkShortcuts:
                    return Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts);
                //case ArgumentExpanderSupported.Personal:
                //return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                case ArgumentExpanderSupported.PrinterShortcuts:
                    return Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts);
                case ArgumentExpanderSupported.ProgramFiles:
                    return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                case ArgumentExpanderSupported.ProgramFilesX86:
                    return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                case ArgumentExpanderSupported.Programs:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Programs);
                case ArgumentExpanderSupported.Recent:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Recent);
                case ArgumentExpanderSupported.SendTo:
                    return Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
                case ArgumentExpanderSupported.StartMenu:
                    return Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
                case ArgumentExpanderSupported.Startup:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                case ArgumentExpanderSupported.SystemX86:
                    return Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
                case ArgumentExpanderSupported.Templates:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Templates);
                case ArgumentExpanderSupported.Windows:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                case ArgumentExpanderSupported.UserProfile:
                    return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                case ArgumentExpanderSupported.System:
                    return Environment.GetFolderPath(Environment.SpecialFolder.System);
                case ArgumentExpanderSupported.OneDrive:
                    ret.Append(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                    if ( (ret[ret.Length-1] != '\\') || (ret[ret.Length-1] != '/'))
                    {
                        ret.Append('\\');
                    }
                    ret.Append("OneDrive");
                    break;
            }
            return ret.ToString();
        }
    }
}
