namespace TheScanlanArmyKnife.Forms
{
    partial class FileRenaming
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
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.grpCase = new System.Windows.Forms.GroupBox();
            this.rdoUpper = new System.Windows.Forms.RadioButton();
            this.rdoLower = new System.Windows.Forms.RadioButton();
            this.rdoProper = new System.Windows.Forms.RadioButton();
            this.btnGo = new System.Windows.Forms.Button();
            this.rdoReplace = new System.Windows.Forms.RadioButton();
            this.rdoChangeCase = new System.Windows.Forms.RadioButton();
            this.rdoPadAll = new System.Windows.Forms.RadioButton();
            this.rdoChopText = new System.Windows.Forms.RadioButton();
            this.rdoRenameFile = new System.Windows.Forms.RadioButton();
            this.btnFixNameByAuthor = new System.Windows.Forms.Button();
            this.btnSwapNameTitleByAuthor = new System.Windows.Forms.Button();
            this.btnStripFolderName = new System.Windows.Forms.Button();
            this.btnStandardCleanup = new System.Windows.Forms.Button();
            this.btnStripLeadingNumeric = new System.Windows.Forms.Button();
            this.btnDirectoryToFile = new System.Windows.Forms.Button();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblOldText = new System.Windows.Forms.Label();
            this.lblNewText = new System.Windows.Forms.Label();
            this.chkFirstOnly = new System.Windows.Forms.CheckBox();
            this.chkAutoCleanup = new System.Windows.Forms.CheckBox();
            this.chkMoveFile = new System.Windows.Forms.CheckBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnUnfixableFiles = new System.Windows.Forms.Button();
            this.btnSwapNameTitleDirectory = new System.Windows.Forms.Button();
            this.btnFixNameDirectory = new System.Windows.Forms.Button();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.lblFilesDone = new System.Windows.Forms.Label();
            this.btnStripAuthorNamePeriods = new System.Windows.Forms.Button();
            this.btnSegregateAuthors = new System.Windows.Forms.Button();
            this.cboDriveList = new System.Windows.Forms.ComboBox();
            this.grpActions.SuspendLayout();
            this.grpCase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(912, 9);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(151, 20);
            this.btnFolder.TabIndex = 9;
            this.btnFolder.Text = "Pick Folder";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Enabled = false;
            this.txtFolderPath.Location = new System.Drawing.Point(610, 9);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(296, 20);
            this.txtFolderPath.TabIndex = 8;
            this.txtFolderPath.Text = "D:\\BookWorkingFolder";
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(610, 33);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.ScrollAlwaysVisible = true;
            this.lstFiles.Size = new System.Drawing.Size(680, 771);
            this.lstFiles.Sorted = true;
            this.lstFiles.TabIndex = 7;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.grpCase);
            this.grpActions.Controls.Add(this.btnGo);
            this.grpActions.Controls.Add(this.rdoReplace);
            this.grpActions.Controls.Add(this.rdoChangeCase);
            this.grpActions.Controls.Add(this.rdoPadAll);
            this.grpActions.Controls.Add(this.rdoChopText);
            this.grpActions.Controls.Add(this.rdoRenameFile);
            this.grpActions.Location = new System.Drawing.Point(9, 12);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(367, 176);
            this.grpActions.TabIndex = 10;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";
            // 
            // grpCase
            // 
            this.grpCase.Controls.Add(this.rdoUpper);
            this.grpCase.Controls.Add(this.rdoLower);
            this.grpCase.Controls.Add(this.rdoProper);
            this.grpCase.Location = new System.Drawing.Point(253, 62);
            this.grpCase.Name = "grpCase";
            this.grpCase.Size = new System.Drawing.Size(91, 88);
            this.grpCase.TabIndex = 26;
            this.grpCase.TabStop = false;
            this.grpCase.Text = "Case Choices";
            this.grpCase.Visible = false;
            // 
            // rdoUpper
            // 
            this.rdoUpper.AutoSize = true;
            this.rdoUpper.Location = new System.Drawing.Point(7, 64);
            this.rdoUpper.Name = "rdoUpper";
            this.rdoUpper.Size = new System.Drawing.Size(54, 17);
            this.rdoUpper.TabIndex = 2;
            this.rdoUpper.TabStop = true;
            this.rdoUpper.Text = "Upper";
            this.rdoUpper.UseVisualStyleBackColor = true;
            // 
            // rdoLower
            // 
            this.rdoLower.AutoSize = true;
            this.rdoLower.Location = new System.Drawing.Point(7, 42);
            this.rdoLower.Name = "rdoLower";
            this.rdoLower.Size = new System.Drawing.Size(54, 17);
            this.rdoLower.TabIndex = 1;
            this.rdoLower.TabStop = true;
            this.rdoLower.Text = "Lower";
            this.rdoLower.UseVisualStyleBackColor = true;
            // 
            // rdoProper
            // 
            this.rdoProper.AutoSize = true;
            this.rdoProper.Location = new System.Drawing.Point(7, 20);
            this.rdoProper.Name = "rdoProper";
            this.rdoProper.Size = new System.Drawing.Size(56, 17);
            this.rdoProper.TabIndex = 0;
            this.rdoProper.TabStop = true;
            this.rdoProper.Text = "Proper";
            this.rdoProper.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(253, 20);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(108, 23);
            this.btnGo.TabIndex = 11;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // rdoReplace
            // 
            this.rdoReplace.AutoSize = true;
            this.rdoReplace.Checked = true;
            this.rdoReplace.Location = new System.Drawing.Point(6, 145);
            this.rdoReplace.Name = "rdoReplace";
            this.rdoReplace.Size = new System.Drawing.Size(166, 17);
            this.rdoReplace.TabIndex = 15;
            this.rdoReplace.TabStop = true;
            this.rdoReplace.Text = "Replace Old With New For All";
            this.rdoReplace.UseVisualStyleBackColor = true;
            this.rdoReplace.CheckedChanged += new System.EventHandler(this.rdoReplace_CheckedChanged);
            // 
            // rdoChangeCase
            // 
            this.rdoChangeCase.AutoSize = true;
            this.rdoChangeCase.Location = new System.Drawing.Point(6, 114);
            this.rdoChangeCase.Name = "rdoChangeCase";
            this.rdoChangeCase.Size = new System.Drawing.Size(89, 17);
            this.rdoChangeCase.TabIndex = 14;
            this.rdoChangeCase.Text = "Change Case";
            this.rdoChangeCase.UseVisualStyleBackColor = true;
            this.rdoChangeCase.CheckedChanged += new System.EventHandler(this.rdoChangeCase_CheckedChanged);
            // 
            // rdoPadAll
            // 
            this.rdoPadAll.AutoSize = true;
            this.rdoPadAll.Location = new System.Drawing.Point(6, 83);
            this.rdoPadAll.Name = "rdoPadAll";
            this.rdoPadAll.Size = new System.Drawing.Size(102, 17);
            this.rdoPadAll.TabIndex = 13;
            this.rdoPadAll.Text = "Pad All With Old";
            this.rdoPadAll.UseVisualStyleBackColor = true;
            this.rdoPadAll.CheckedChanged += new System.EventHandler(this.rdoPadAll_CheckedChanged);
            // 
            // rdoChopText
            // 
            this.rdoChopText.AutoSize = true;
            this.rdoChopText.Location = new System.Drawing.Point(6, 52);
            this.rdoChopText.Name = "rdoChopText";
            this.rdoChopText.Size = new System.Drawing.Size(148, 17);
            this.rdoChopText.TabIndex = 12;
            this.rdoChopText.Text = "Chop Old Text Off All Files";
            this.rdoChopText.UseVisualStyleBackColor = true;
            this.rdoChopText.CheckedChanged += new System.EventHandler(this.rdoChopText_CheckedChanged);
            // 
            // rdoRenameFile
            // 
            this.rdoRenameFile.AutoSize = true;
            this.rdoRenameFile.Location = new System.Drawing.Point(6, 21);
            this.rdoRenameFile.Name = "rdoRenameFile";
            this.rdoRenameFile.Size = new System.Drawing.Size(84, 17);
            this.rdoRenameFile.TabIndex = 11;
            this.rdoRenameFile.Text = "Rename File";
            this.rdoRenameFile.UseVisualStyleBackColor = true;
            this.rdoRenameFile.CheckedChanged += new System.EventHandler(this.rdoRenameFile_CheckedChanged);
            // 
            // btnFixNameByAuthor
            // 
            this.btnFixNameByAuthor.Location = new System.Drawing.Point(391, 94);
            this.btnFixNameByAuthor.Name = "btnFixNameByAuthor";
            this.btnFixNameByAuthor.Size = new System.Drawing.Size(190, 23);
            this.btnFixNameByAuthor.TabIndex = 12;
            this.btnFixNameByAuthor.Text = "Reverse Name w/Comma By Author";
            this.btnFixNameByAuthor.UseVisualStyleBackColor = true;
            this.btnFixNameByAuthor.Click += new System.EventHandler(this.btnFixNameByAuthor_Click);
            // 
            // btnSwapNameTitleByAuthor
            // 
            this.btnSwapNameTitleByAuthor.Location = new System.Drawing.Point(391, 123);
            this.btnSwapNameTitleByAuthor.Name = "btnSwapNameTitleByAuthor";
            this.btnSwapNameTitleByAuthor.Size = new System.Drawing.Size(190, 23);
            this.btnSwapNameTitleByAuthor.TabIndex = 13;
            this.btnSwapNameTitleByAuthor.Text = "Swap Name/Title By Author";
            this.btnSwapNameTitleByAuthor.UseVisualStyleBackColor = true;
            this.btnSwapNameTitleByAuthor.Click += new System.EventHandler(this.btnSwapNameTitleByAuthor_Click);
            // 
            // btnStripFolderName
            // 
            this.btnStripFolderName.Location = new System.Drawing.Point(391, 152);
            this.btnStripFolderName.Name = "btnStripFolderName";
            this.btnStripFolderName.Size = new System.Drawing.Size(190, 23);
            this.btnStripFolderName.TabIndex = 14;
            this.btnStripFolderName.Text = "Strip Folder Name";
            this.btnStripFolderName.UseVisualStyleBackColor = true;
            this.btnStripFolderName.Click += new System.EventHandler(this.btnStripFolderName_Click);
            // 
            // btnStandardCleanup
            // 
            this.btnStandardCleanup.Location = new System.Drawing.Point(391, 181);
            this.btnStandardCleanup.Name = "btnStandardCleanup";
            this.btnStandardCleanup.Size = new System.Drawing.Size(190, 23);
            this.btnStandardCleanup.TabIndex = 15;
            this.btnStandardCleanup.Text = "Standard Cleanup";
            this.btnStandardCleanup.UseVisualStyleBackColor = true;
            this.btnStandardCleanup.Click += new System.EventHandler(this.btnStandardCleanup_Click);
            // 
            // btnStripLeadingNumeric
            // 
            this.btnStripLeadingNumeric.Location = new System.Drawing.Point(391, 210);
            this.btnStripLeadingNumeric.Name = "btnStripLeadingNumeric";
            this.btnStripLeadingNumeric.Size = new System.Drawing.Size(190, 23);
            this.btnStripLeadingNumeric.TabIndex = 16;
            this.btnStripLeadingNumeric.Text = "Strip Leading Numeric";
            this.btnStripLeadingNumeric.UseVisualStyleBackColor = true;
            this.btnStripLeadingNumeric.Click += new System.EventHandler(this.btnStripLeadingNumeric_Click);
            // 
            // btnDirectoryToFile
            // 
            this.btnDirectoryToFile.Location = new System.Drawing.Point(391, 239);
            this.btnDirectoryToFile.Name = "btnDirectoryToFile";
            this.btnDirectoryToFile.Size = new System.Drawing.Size(190, 23);
            this.btnDirectoryToFile.TabIndex = 17;
            this.btnDirectoryToFile.Text = "Directory To File";
            this.btnDirectoryToFile.UseVisualStyleBackColor = true;
            this.btnDirectoryToFile.Click += new System.EventHandler(this.btnDirectoryToFile_Click);
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(9, 212);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(367, 20);
            this.txtOld.TabIndex = 18;
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(9, 253);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(367, 20);
            this.txtNew.TabIndex = 19;
            // 
            // lblOldText
            // 
            this.lblOldText.AutoSize = true;
            this.lblOldText.Location = new System.Drawing.Point(9, 195);
            this.lblOldText.Name = "lblOldText";
            this.lblOldText.Size = new System.Drawing.Size(47, 13);
            this.lblOldText.TabIndex = 20;
            this.lblOldText.Text = "Old Text";
            // 
            // lblNewText
            // 
            this.lblNewText.AutoSize = true;
            this.lblNewText.Location = new System.Drawing.Point(9, 237);
            this.lblNewText.Name = "lblNewText";
            this.lblNewText.Size = new System.Drawing.Size(53, 13);
            this.lblNewText.TabIndex = 21;
            this.lblNewText.Text = "New Text";
            // 
            // chkFirstOnly
            // 
            this.chkFirstOnly.AutoSize = true;
            this.chkFirstOnly.Location = new System.Drawing.Point(391, 12);
            this.chkFirstOnly.Name = "chkFirstOnly";
            this.chkFirstOnly.Size = new System.Drawing.Size(128, 17);
            this.chkFirstOnly.TabIndex = 22;
            this.chkFirstOnly.Text = "First Occurrence Only";
            this.chkFirstOnly.UseVisualStyleBackColor = true;
            // 
            // chkAutoCleanup
            // 
            this.chkAutoCleanup.AutoSize = true;
            this.chkAutoCleanup.Location = new System.Drawing.Point(391, 38);
            this.chkAutoCleanup.Name = "chkAutoCleanup";
            this.chkAutoCleanup.Size = new System.Drawing.Size(121, 17);
            this.chkAutoCleanup.TabIndex = 23;
            this.chkAutoCleanup.Text = "Auto Name Cleanup";
            this.chkAutoCleanup.UseVisualStyleBackColor = true;
            // 
            // chkMoveFile
            // 
            this.chkMoveFile.AutoSize = true;
            this.chkMoveFile.Location = new System.Drawing.Point(391, 64);
            this.chkMoveFile.Name = "chkMoveFile";
            this.chkMoveFile.Size = new System.Drawing.Size(122, 17);
            this.chkMoveFile.TabIndex = 24;
            this.chkMoveFile.Text = "Move To Processed";
            this.chkMoveFile.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(9, 279);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(367, 523);
            this.txtOutput.TabIndex = 25;
            // 
            // btnUnfixableFiles
            // 
            this.btnUnfixableFiles.Location = new System.Drawing.Point(391, 268);
            this.btnUnfixableFiles.Name = "btnUnfixableFiles";
            this.btnUnfixableFiles.Size = new System.Drawing.Size(190, 23);
            this.btnUnfixableFiles.TabIndex = 26;
            this.btnUnfixableFiles.Text = "Find Unfixable Files";
            this.btnUnfixableFiles.UseVisualStyleBackColor = true;
            this.btnUnfixableFiles.Click += new System.EventHandler(this.btnUnfixableFiles_Click);
            // 
            // btnSwapNameTitleDirectory
            // 
            this.btnSwapNameTitleDirectory.Location = new System.Drawing.Point(391, 297);
            this.btnSwapNameTitleDirectory.Name = "btnSwapNameTitleDirectory";
            this.btnSwapNameTitleDirectory.Size = new System.Drawing.Size(190, 23);
            this.btnSwapNameTitleDirectory.TabIndex = 27;
            this.btnSwapNameTitleDirectory.Text = "Swap Name/Title Directory";
            this.btnSwapNameTitleDirectory.UseVisualStyleBackColor = true;
            this.btnSwapNameTitleDirectory.Click += new System.EventHandler(this.btnSwapNameTitleDirectory_Click);
            // 
            // btnFixNameDirectory
            // 
            this.btnFixNameDirectory.Location = new System.Drawing.Point(391, 326);
            this.btnFixNameDirectory.Name = "btnFixNameDirectory";
            this.btnFixNameDirectory.Size = new System.Drawing.Size(190, 23);
            this.btnFixNameDirectory.TabIndex = 28;
            this.btnFixNameDirectory.Text = "Reverse Name w/Comma Directory";
            this.btnFixNameDirectory.UseVisualStyleBackColor = true;
            this.btnFixNameDirectory.Click += new System.EventHandler(this.btnFixNameDirectory_Click);
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(391, 365);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(123, 13);
            this.lblFileCount.TabIndex = 29;
            this.lblFileCount.Text = "File Count - wipe on start";
            // 
            // lblFilesDone
            // 
            this.lblFilesDone.AutoSize = true;
            this.lblFilesDone.Location = new System.Drawing.Point(391, 388);
            this.lblFilesDone.Name = "lblFilesDone";
            this.lblFilesDone.Size = new System.Drawing.Size(126, 13);
            this.lblFilesDone.TabIndex = 30;
            this.lblFilesDone.Text = "Files Done - wipe on start";
            // 
            // btnStripAuthorNamePeriods
            // 
            this.btnStripAuthorNamePeriods.Location = new System.Drawing.Point(391, 419);
            this.btnStripAuthorNamePeriods.Name = "btnStripAuthorNamePeriods";
            this.btnStripAuthorNamePeriods.Size = new System.Drawing.Size(190, 23);
            this.btnStripAuthorNamePeriods.TabIndex = 31;
            this.btnStripAuthorNamePeriods.Text = "Strip Author Name Periods";
            this.btnStripAuthorNamePeriods.UseVisualStyleBackColor = true;
            this.btnStripAuthorNamePeriods.Click += new System.EventHandler(this.btnStripAuthorNamePeriods_Click);
            // 
            // btnSegregateAuthors
            // 
            this.btnSegregateAuthors.Location = new System.Drawing.Point(391, 448);
            this.btnSegregateAuthors.Name = "btnSegregateAuthors";
            this.btnSegregateAuthors.Size = new System.Drawing.Size(190, 23);
            this.btnSegregateAuthors.TabIndex = 32;
            this.btnSegregateAuthors.Text = "Segregate Authors";
            this.btnSegregateAuthors.UseVisualStyleBackColor = true;
            this.btnSegregateAuthors.Click += new System.EventHandler(this.btnSegregateAuthors_Click);
            // 
            // cboDriveList
            // 
            this.cboDriveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDriveList.FormattingEnabled = true;
            this.cboDriveList.Location = new System.Drawing.Point(1297, 32);
            this.cboDriveList.Name = "cboDriveList";
            this.cboDriveList.Size = new System.Drawing.Size(156, 21);
            this.cboDriveList.Sorted = true;
            this.cboDriveList.TabIndex = 33;
            // 
            // FileRenaming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1795, 832);
            this.Controls.Add(this.cboDriveList);
            this.Controls.Add(this.btnSegregateAuthors);
            this.Controls.Add(this.btnStripAuthorNamePeriods);
            this.Controls.Add(this.lblFilesDone);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.btnFixNameDirectory);
            this.Controls.Add(this.btnSwapNameTitleDirectory);
            this.Controls.Add(this.btnUnfixableFiles);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.chkMoveFile);
            this.Controls.Add(this.chkAutoCleanup);
            this.Controls.Add(this.chkFirstOnly);
            this.Controls.Add(this.lblNewText);
            this.Controls.Add(this.lblOldText);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.btnDirectoryToFile);
            this.Controls.Add(this.btnStripLeadingNumeric);
            this.Controls.Add(this.btnStandardCleanup);
            this.Controls.Add(this.btnStripFolderName);
            this.Controls.Add(this.btnSwapNameTitleByAuthor);
            this.Controls.Add(this.btnFixNameByAuthor);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.lstFiles);
            this.Name = "FileRenaming";
            this.Text = "FileRenaming";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FileRenaming_Load);
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            this.grpCase.ResumeLayout(false);
            this.grpCase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RadioButton rdoReplace;
        private System.Windows.Forms.RadioButton rdoChangeCase;
        private System.Windows.Forms.RadioButton rdoPadAll;
        private System.Windows.Forms.RadioButton rdoChopText;
        private System.Windows.Forms.RadioButton rdoRenameFile;
        private System.Windows.Forms.Button btnFixNameByAuthor;
        private System.Windows.Forms.Button btnSwapNameTitleByAuthor;
        private System.Windows.Forms.Button btnStripFolderName;
        private System.Windows.Forms.Button btnStandardCleanup;
        private System.Windows.Forms.Button btnStripLeadingNumeric;
        private System.Windows.Forms.Button btnDirectoryToFile;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblOldText;
        private System.Windows.Forms.Label lblNewText;
        private System.Windows.Forms.CheckBox chkFirstOnly;
        private System.Windows.Forms.CheckBox chkAutoCleanup;
        private System.Windows.Forms.CheckBox chkMoveFile;
        private System.Windows.Forms.GroupBox grpCase;
        private System.Windows.Forms.RadioButton rdoUpper;
        private System.Windows.Forms.RadioButton rdoLower;
        private System.Windows.Forms.RadioButton rdoProper;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnUnfixableFiles;
        private System.Windows.Forms.Button btnSwapNameTitleDirectory;
        private System.Windows.Forms.Button btnFixNameDirectory;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblFilesDone;
        private System.Windows.Forms.Button btnStripAuthorNamePeriods;
        private System.Windows.Forms.Button btnSegregateAuthors;
        private System.Windows.Forms.ComboBox cboDriveList;
    }
}