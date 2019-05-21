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
            this.TextBoxFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TextBoxCommandDescription = new System.Windows.Forms.TextBox();
            this.TextBoxCommandName = new System.Windows.Forms.TextBox();
            this.ButtonChooseCommand = new System.Windows.Forms.Button();
            this.ButtonChooseFile = new System.Windows.Forms.Button();
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
            this.button1.Location = new System.Drawing.Point(1561, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 78);
            this.button1.TabIndex = 1;
            this.button1.Text = "Do";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TextBoxCommandDescription
            // 
            this.TextBoxCommandDescription.Location = new System.Drawing.Point(34, 265);
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
            this.ButtonChooseCommand.Location = new System.Drawing.Point(1794, 51);
            this.ButtonChooseCommand.Name = "ButtonChooseCommand";
            this.ButtonChooseCommand.Size = new System.Drawing.Size(304, 82);
            this.ButtonChooseCommand.TabIndex = 4;
            this.ButtonChooseCommand.Text = "Choose Command";
            this.ButtonChooseCommand.UseVisualStyleBackColor = true;
            // 
            // ButtonChooseFile
            // 
            this.ButtonChooseFile.Location = new System.Drawing.Point(1540, 265);
            this.ButtonChooseFile.Name = "ButtonChooseFile";
            this.ButtonChooseFile.Size = new System.Drawing.Size(151, 73);
            this.ButtonChooseFile.TabIndex = 5;
            this.ButtonChooseFile.Text = "...";
            this.ButtonChooseFile.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2136, 652);
            this.Controls.Add(this.ButtonChooseFile);
            this.Controls.Add(this.ButtonChooseCommand);
            this.Controls.Add(this.TextBoxCommandName);
            this.Controls.Add(this.TextBoxCommandDescription);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBoxFilePath);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
    }
}

