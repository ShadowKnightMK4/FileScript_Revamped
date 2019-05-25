using System;
using System.Collections.Generic;
using System.IO;
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
                TextBoxFilePath.Text = TargetFile;
            }
            else
            {
                Text = "Filescript Launcher: {Unspecified File System Target}";
                TextBoxFilePath.Text = "{Unspecified File System Target}";
            }
            MainForm_Resize(null, null);
            if (System.Diagnostics.Debugger.IsAttached == true)
            {
                TopMost = false;
            }
        }

        public string TargetFile { get; set; } = string.Empty;

        private void CommandMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ButtonChooseCommand_Click(object sender, EventArgs e)
        {
            CommandMenuStrip.Show(MousePosition.X, MousePosition.Y);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

            if (sender == null)
            {
                Width =  (int)Math.Floor(Width* 1.618 * 1.2);
                Height = (int)Math.Floor(Height * 1.2);
               // TextBoxFilePath.Width = Width;
               
            }
            else
            {
               // TextBoxFilePath.Width = Width;
            }
            TextBoxCommandName.Height = 32;
            TextBoxFilePath.Height = 32;
        }

        private void ButtonChooseFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxFilePath.Text))
            {
                openFileDialog1.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                if ((File.Exists(TextBoxFilePath.Text) == true) ||
                     (Directory.Exists(TextBoxFilePath.Text) == true))
                { 
                    openFileDialog1.FileName = TextBoxFilePath.Text;
                }
                else
                {
                    if (TextBoxFilePath.Text.Contains("$"))
                    {
                        string Expand; // and try again
                        Expand = ArgumentExpander.ExpandVars(TextBoxFilePath.Text);
                        if ((File.Exists(Expand) == true) ||
                        (Directory.Exists(Expand) == true))
                        {
                            openFileDialog1.FileName = Expand;
                        }
                        else
                        {
                            openFileDialog1.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        }
                    }
                }
            }

            if (Directory.Exists(openFileDialog1.FileName))
            {
                openFileDialog1.InitialDirectory = openFileDialog1.FileName;
                openFileDialog1.FileName= string.Empty;
                openFileDialog1.RestoreDirectory = true;
            }
            else
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    openFileDialog1.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
                    openFileDialog1.FileName = Path.GetFileName(openFileDialog1.FileName);
                    openFileDialog1.RestoreDirectory = true;
                }
                else
                {
                    openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.FileName = string.Empty;
                }

            }


            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            openFileDialog1.ShowDialog();
            
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            TextBoxFilePath.Text = openFileDialog1.FileName;
            openFileDialog1.FileOk -= OpenFileDialog1_FileOk;
        }

        private void PasteOnlyFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxCommandName.Text  = nameof(ToolFunctionCommand.SetClipboardFileName);
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxCommandName.Text = nameof(ToolFunctionCommand.SetClipboardFilePath);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Enum.TryParse(TextBoxCommandName.Text, out ToolFunctionCommand cmd))
            {
                if (cmd != ToolFunctionCommand.Nothing)
                {
                    ToolFunction.Invoke(cmd, TextBoxFilePath.Text);
                }
            }
            else
            {
                MessageBox.Show("Sorry. That command was not found. Please Select Another One");
            }
        }
    }
}
