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
    public partial class FlashForm : Form
    {
        public FlashForm()
        {
            InitializeComponent();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FlashForm_Resize(object sender, EventArgs e)
        {
            Form f = (Form)sender;
            TabControlTopLevel.Width = f.Width;
            TabControlTopLevel.Height = f.Height - TabControlTopLevel.Top;
        }

        private void FlashForm_Load(object sender, EventArgs e)
        {
            Width += 1;
            Width -= 1;
        }
    }
}
