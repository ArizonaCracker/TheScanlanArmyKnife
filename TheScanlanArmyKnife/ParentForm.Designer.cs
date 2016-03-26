namespace TheScanlanArmyKnife
{
    partial class ParentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.appendFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileRenamingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1795, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appendFilesToolStripMenuItem,
            this.directoryToXMLToolStripMenuItem,
            this.fileRenamingToolStripMenuItem,
            this.mediaUploadToolStripMenuItem,
            this.passwordGeneratorToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(68, 20);
            this.FileMenu.Text = "&Click Me!";
            this.FileMenu.Click += new System.EventHandler(this.fileMenu_Click);
            // 
            // appendFilesToolStripMenuItem
            // 
            this.appendFilesToolStripMenuItem.Name = "appendFilesToolStripMenuItem";
            this.appendFilesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.appendFilesToolStripMenuItem.Text = "Append Files";
            this.appendFilesToolStripMenuItem.Click += new System.EventHandler(this.appendFilesToolStripMenuItem_Click);
            // 
            // directoryToXMLToolStripMenuItem
            // 
            this.directoryToXMLToolStripMenuItem.Name = "directoryToXMLToolStripMenuItem";
            this.directoryToXMLToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.directoryToXMLToolStripMenuItem.Text = "Directory To XML";
            this.directoryToXMLToolStripMenuItem.Click += new System.EventHandler(this.directoryToXMLToolStripMenuItem_Click);
            // 
            // fileRenamingToolStripMenuItem
            // 
            this.fileRenamingToolStripMenuItem.Name = "fileRenamingToolStripMenuItem";
            this.fileRenamingToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.fileRenamingToolStripMenuItem.Text = "File Renaming";
            this.fileRenamingToolStripMenuItem.Click += new System.EventHandler(this.fileRenamingToolStripMenuItem_Click);
            // 
            // mediaUploadToolStripMenuItem
            // 
            this.mediaUploadToolStripMenuItem.Name = "mediaUploadToolStripMenuItem";
            this.mediaUploadToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.mediaUploadToolStripMenuItem.Text = "Media Upload";
            this.mediaUploadToolStripMenuItem.Click += new System.EventHandler(this.mediaUploadToolStripMenuItem_Click);
            // 
            // passwordGeneratorToolStripMenuItem
            // 
            this.passwordGeneratorToolStripMenuItem.Name = "passwordGeneratorToolStripMenuItem";
            this.passwordGeneratorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.passwordGeneratorToolStripMenuItem.Text = "Password Generator";
            this.passwordGeneratorToolStripMenuItem.Click += new System.EventHandler(this.passwordGeneratorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 810);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1795, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1795, 832);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ParentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScanlanArmyKnife";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem appendFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryToXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileRenamingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}



