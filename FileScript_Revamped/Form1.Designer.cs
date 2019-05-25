namespace FileScript_Revamped
{
    partial class MainForm
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
            this.TextBoxFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TextBoxCommandDescription = new System.Windows.Forms.TextBox();
            this.TextBoxCommandName = new System.Windows.Forms.TextBox();
            this.ButtonChooseCommand = new System.Windows.Forms.Button();
            this.ButtonChooseFile = new System.Windows.Forms.Button();
            this.CommandMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteOnlyFileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNameNoExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quotedCompleteFIleNameLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCStyleFileNameLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enironemntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchAdminCommonPromptToTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchCommandPromptToTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createHardlinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createJunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTo0sOneDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CommandMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxFilePath
            // 
            this.TextBoxFilePath.Location = new System.Drawing.Point(22, 57);
            this.TextBoxFilePath.Multiline = true;
            this.TextBoxFilePath.Name = "TextBoxFilePath";
            this.TextBoxFilePath.Size = new System.Drawing.Size(1435, 78);
            this.TextBoxFilePath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1686, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 78);
            this.button1.TabIndex = 1;
            this.button1.Text = "Do";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TextBoxCommandDescription
            // 
            this.TextBoxCommandDescription.Location = new System.Drawing.Point(22, 307);
            this.TextBoxCommandDescription.Multiline = true;
            this.TextBoxCommandDescription.Name = "TextBoxCommandDescription";
            this.TextBoxCommandDescription.Size = new System.Drawing.Size(1423, 190);
            this.TextBoxCommandDescription.TabIndex = 2;
            // 
            // TextBoxCommandName
            // 
            this.TextBoxCommandName.Location = new System.Drawing.Point(22, 184);
            this.TextBoxCommandName.Name = "TextBoxCommandName";
            this.TextBoxCommandName.Size = new System.Drawing.Size(1435, 44);
            this.TextBoxCommandName.TabIndex = 3;
            // 
            // ButtonChooseCommand
            // 
            this.ButtonChooseCommand.Location = new System.Drawing.Point(1945, 53);
            this.ButtonChooseCommand.Name = "ButtonChooseCommand";
            this.ButtonChooseCommand.Size = new System.Drawing.Size(304, 82);
            this.ButtonChooseCommand.TabIndex = 4;
            this.ButtonChooseCommand.Text = "Choose Command";
            this.ButtonChooseCommand.UseVisualStyleBackColor = true;
            this.ButtonChooseCommand.Click += new System.EventHandler(this.ButtonChooseCommand_Click);
            // 
            // ButtonChooseFile
            // 
            this.ButtonChooseFile.Location = new System.Drawing.Point(1476, 54);
            this.ButtonChooseFile.Name = "ButtonChooseFile";
            this.ButtonChooseFile.Size = new System.Drawing.Size(151, 73);
            this.ButtonChooseFile.TabIndex = 5;
            this.ButtonChooseFile.Text = "...";
            this.ButtonChooseFile.UseVisualStyleBackColor = true;
            this.ButtonChooseFile.Click += new System.EventHandler(this.ButtonChooseFile_Click);
            // 
            // CommandMenuStrip
            // 
            this.CommandMenuStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.CommandMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardToolStripMenuItem,
            this.enironemntToolStripMenuItem,
            this.diskToolStripMenuItem});
            this.CommandMenuStrip.Name = "CommandMenuStrip";
            this.CommandMenuStrip.Size = new System.Drawing.Size(390, 160);
            this.CommandMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.CommandMenuStrip_Opening);
            // 
            // clipboardToolStripMenuItem
            // 
            this.clipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteOnlyFileNameToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.fileNameNoExtensionToolStripMenuItem,
            this.completeFilePathToolStripMenuItem,
            this.quotedCompleteFIleNameLocationToolStripMenuItem,
            this.cCStyleFileNameLocationToolStripMenuItem});
            this.clipboardToolStripMenuItem.Name = "clipboardToolStripMenuItem";
            this.clipboardToolStripMenuItem.Size = new System.Drawing.Size(420, 52);
            this.clipboardToolStripMenuItem.Text = "Copy to Clipboard";
            // 
            // pasteOnlyFileNameToolStripMenuItem
            // 
            this.pasteOnlyFileNameToolStripMenuItem.Name = "pasteOnlyFileNameToolStripMenuItem";
            this.pasteOnlyFileNameToolStripMenuItem.Size = new System.Drawing.Size(783, 54);
            this.pasteOnlyFileNameToolStripMenuItem.Text = "File Name Alone";
            this.pasteOnlyFileNameToolStripMenuItem.Click += new System.EventHandler(this.PasteOnlyFileNameToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(783, 54);
            this.copyToolStripMenuItem.Text = "File Location Alone";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // fileNameNoExtensionToolStripMenuItem
            // 
            this.fileNameNoExtensionToolStripMenuItem.Name = "fileNameNoExtensionToolStripMenuItem";
            this.fileNameNoExtensionToolStripMenuItem.Size = new System.Drawing.Size(783, 54);
            this.fileNameNoExtensionToolStripMenuItem.Text = "File Name no Extension";
            // 
            // completeFilePathToolStripMenuItem
            // 
            this.completeFilePathToolStripMenuItem.Name = "completeFilePathToolStripMenuItem";
            this.completeFilePathToolStripMenuItem.Size = new System.Drawing.Size(783, 54);
            this.completeFilePathToolStripMenuItem.Text = "Complete File Name + Location";
            // 
            // quotedCompleteFIleNameLocationToolStripMenuItem
            // 
            this.quotedCompleteFIleNameLocationToolStripMenuItem.Name = "quotedCompleteFIleNameLocationToolStripMenuItem";
            this.quotedCompleteFIleNameLocationToolStripMenuItem.Size = new System.Drawing.Size(783, 54);
            this.quotedCompleteFIleNameLocationToolStripMenuItem.Text = "Quoted Complete FIle Name + Location";
            // 
            // cCStyleFileNameLocationToolStripMenuItem
            // 
            this.cCStyleFileNameLocationToolStripMenuItem.Name = "cCStyleFileNameLocationToolStripMenuItem";
            this.cCStyleFileNameLocationToolStripMenuItem.Size = new System.Drawing.Size(783, 54);
            this.cCStyleFileNameLocationToolStripMenuItem.Text = "C/C++ Style File Name + Location";
            // 
            // enironemntToolStripMenuItem
            // 
            this.enironemntToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreTargetToolStripMenuItem,
            this.launchAdminCommonPromptToTargetToolStripMenuItem,
            this.launchCommandPromptToTargetToolStripMenuItem});
            this.enironemntToolStripMenuItem.Name = "enironemntToolStripMenuItem";
            this.enironemntToolStripMenuItem.Size = new System.Drawing.Size(420, 52);
            this.enironemntToolStripMenuItem.Text = "Shell";
            // 
            // exploreTargetToolStripMenuItem
            // 
            this.exploreTargetToolStripMenuItem.Name = "exploreTargetToolStripMenuItem";
            this.exploreTargetToolStripMenuItem.Size = new System.Drawing.Size(809, 54);
            this.exploreTargetToolStripMenuItem.Text = "Explore Target";
            // 
            // launchAdminCommonPromptToTargetToolStripMenuItem
            // 
            this.launchAdminCommonPromptToTargetToolStripMenuItem.Name = "launchAdminCommonPromptToTargetToolStripMenuItem";
            this.launchAdminCommonPromptToTargetToolStripMenuItem.Size = new System.Drawing.Size(809, 54);
            this.launchAdminCommonPromptToTargetToolStripMenuItem.Text = "Launch Admin Common Prompt to Target";
            // 
            // launchCommandPromptToTargetToolStripMenuItem
            // 
            this.launchCommandPromptToTargetToolStripMenuItem.Name = "launchCommandPromptToTargetToolStripMenuItem";
            this.launchCommandPromptToTargetToolStripMenuItem.Size = new System.Drawing.Size(809, 54);
            this.launchCommandPromptToTargetToolStripMenuItem.Text = "Launch Command Prompt to Target";
            // 
            // diskToolStripMenuItem
            // 
            this.diskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createHardlinkToolStripMenuItem,
            this.createJunctionToolStripMenuItem,
            this.copyTo0sOneDriveToolStripMenuItem});
            this.diskToolStripMenuItem.Name = "diskToolStripMenuItem";
            this.diskToolStripMenuItem.Size = new System.Drawing.Size(420, 52);
            this.diskToolStripMenuItem.Text = "Disk";
            // 
            // createHardlinkToolStripMenuItem
            // 
            this.createHardlinkToolStripMenuItem.Name = "createHardlinkToolStripMenuItem";
            this.createHardlinkToolStripMenuItem.Size = new System.Drawing.Size(597, 54);
            this.createHardlinkToolStripMenuItem.Text = "Create Hardlink";
            // 
            // createJunctionToolStripMenuItem
            // 
            this.createJunctionToolStripMenuItem.Name = "createJunctionToolStripMenuItem";
            this.createJunctionToolStripMenuItem.Size = new System.Drawing.Size(597, 54);
            this.createJunctionToolStripMenuItem.Text = "Create Junction";
            // 
            // copyTo0sOneDriveToolStripMenuItem
            // 
            this.copyTo0sOneDriveToolStripMenuItem.Name = "copyTo0sOneDriveToolStripMenuItem";
            this.copyTo0sOneDriveToolStripMenuItem.Size = new System.Drawing.Size(597, 54);
            this.copyTo0sOneDriveToolStripMenuItem.Text = "Copy to {0}\'s Local OneDrive";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2364, 597);
            this.Controls.Add(this.ButtonChooseFile);
            this.Controls.Add(this.ButtonChooseCommand);
            this.Controls.Add(this.TextBoxCommandName);
            this.Controls.Add(this.TextBoxCommandDescription);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBoxFilePath);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.CommandMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxFilePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextBoxCommandDescription;
        private System.Windows.Forms.TextBox TextBoxCommandName;
        private System.Windows.Forms.Button ButtonChooseCommand;
        private System.Windows.Forms.Button ButtonChooseFile;
        private System.Windows.Forms.ContextMenuStrip CommandMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteOnlyFileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileNameNoExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quotedCompleteFIleNameLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCStyleFileNameLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enironemntToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchAdminCommonPromptToTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchCommandPromptToTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createHardlinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createJunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTo0sOneDriveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

