namespace FileScript_Revamped
{
    partial class FlashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabControlTopLevel = new System.Windows.Forms.TabControl();
            this.TabPageLanding = new System.Windows.Forms.TabPage();
            this.TabPageContextCommands = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.TabControlTopLevel.SuspendLayout();
            this.TabPageLanding.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlTopLevel
            // 
            this.TabControlTopLevel.Controls.Add(this.TabPageLanding);
            this.TabControlTopLevel.Controls.Add(this.TabPageContextCommands);
            this.TabControlTopLevel.Location = new System.Drawing.Point(12, 24);
            this.TabControlTopLevel.Name = "TabControlTopLevel";
            this.TabControlTopLevel.SelectedIndex = 0;
            this.TabControlTopLevel.Size = new System.Drawing.Size(1818, 575);
            this.TabControlTopLevel.TabIndex = 0;
            // 
            // TabPageLanding
            // 
            this.TabPageLanding.Controls.Add(this.checkedListBox1);
            this.TabPageLanding.Controls.Add(this.label2);
            this.TabPageLanding.Controls.Add(this.button1);
            this.TabPageLanding.Controls.Add(this.label1);
            this.TabPageLanding.Controls.Add(this.textBox1);
            this.TabPageLanding.Location = new System.Drawing.Point(12, 58);
            this.TabPageLanding.Name = "TabPageLanding";
            this.TabPageLanding.Size = new System.Drawing.Size(1794, 505);
            this.TabPageLanding.TabIndex = 0;
            this.TabPageLanding.Text = "Landing Page";
            this.TabPageLanding.UseVisualStyleBackColor = true;
            // 
            // TabPageContextCommands
            // 
            this.TabPageContextCommands.Location = new System.Drawing.Point(12, 58);
            this.TabPageContextCommands.Name = "TabPageContextCommands";
            this.TabPageContextCommands.Size = new System.Drawing.Size(1794, 505);
            this.TabPageContextCommands.TabIndex = 1;
            this.TabPageContextCommands.Text = "Edit Context Commands";
            this.TabPageContextCommands.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(983, 44);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target file or Folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1028, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = ". . .";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Commonly used Commands";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(27, 196);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(994, 238);
            this.checkedListBox1.TabIndex = 5;
            // 
            // FlashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1860, 599);
            this.Controls.Add(this.TabControlTopLevel);
            this.Name = "FlashForm";
            this.Text = "FlashForm";
            this.Load += new System.EventHandler(this.FlashForm_Load);
            this.Resize += new System.EventHandler(this.FlashForm_Resize);
            this.TabControlTopLevel.ResumeLayout(false);
            this.TabPageLanding.ResumeLayout(false);
            this.TabPageLanding.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlTopLevel;
        private System.Windows.Forms.TabPage TabPageLanding;
        private System.Windows.Forms.TabPage TabPageContextCommands;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList imageList1;
    }
}