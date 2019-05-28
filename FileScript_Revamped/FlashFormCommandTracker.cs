using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScript_Revamped
{
    

    /*
     * describes a command in the checked listbox.
     * Pinned means always shows up.
     * in top 5 command list means it was a  command
     * used last 5.
     */
    public class FlashFormCommand
    {
        public ToolFunctionCommand Command;
        public bool InCommonCommandList;
        public bool Pinned;
    }

    public class FlashFormCommandTracker
    {

    }
}
