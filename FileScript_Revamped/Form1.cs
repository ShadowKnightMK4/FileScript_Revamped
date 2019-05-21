using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileScript_Revamped
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public ToolFunctionCommand Command = ToolFunctionCommand.Nothing;


        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TargetFile))
            {
                Text = string.Format("Filescript Launcher: {0}", TargetFile);
            }
            else
            {
                Text = "Filescript Launcher: {Unspecified File System Target}";
            }
        }

        public string TargetFile { get; set; } = string.Empty;

    }
}
