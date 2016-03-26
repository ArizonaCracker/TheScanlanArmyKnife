namespace TheScanlanArmyKnife.Forms
{
    partial class AppendFiles
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
            this.cboDriveList = new System.Windows.Forms.ComboBox();
            this.lblDrives = new System.Windows.Forms.Label();
            this.lstDirectories = new System.Windows.Forms.ListBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cboDriveList
            // 
            this.cboDriveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDriveList.FormattingEnabled = true;
            this.cboDriveList.Location = new System.Drawing.Point(12, 26);
            this.cboDriveList.Name = "cboDriveList";
            this.cboDriveList.Size = new System.Drawing.Size(216, 21);
            this.cboDriveList.Sorted = true;
            this.cboDriveList.TabIndex = 0;
            this.cboDriveList.SelectedIndexChanged += new System.EventHandler(this.cboDriveList_SelectedIndexChanged);
            // 
            // lblDrives
            // 
            this.lblDrives.AutoSize = true;
            this.lblDrives.Location = new System.Drawing.Point(12, 9);
            this.lblDrives.Name = "lblDrives";
            this.lblDrives.Size = new System.Drawing.Size(37, 13);
            this.lblDrives.TabIndex = 1;
            this.lblDrives.Text = "Drives";
            // 
            // lstDirectories
            // 
            this.lstDirectories.FormattingEnabled = true;
            this.lstDirectories.Location = new System.Drawing.Point(15, 53);
            this.lstDirectories.Name = "lstDirectories";
            this.lstDirectories.Size = new System.Drawing.Size(213, 706);
            this.lstDirectories.TabIndex = 3;
            this.lstDirectories.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(234, 53);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(453, 706);
            this.lstFiles.TabIndex = 4;
            // 
            // AppendFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1795, 832);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lstDirectories);
            this.Controls.Add(this.lblDrives);
            this.Controls.Add(this.cboDriveList);
            this.Name = "AppendFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AppendFiles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppendFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDriveList;
        private System.Windows.Forms.Label lblDrives;
        private System.Windows.Forms.ListBox lstDirectories;
        private System.Windows.Forms.ListBox lstFiles;
    }
}