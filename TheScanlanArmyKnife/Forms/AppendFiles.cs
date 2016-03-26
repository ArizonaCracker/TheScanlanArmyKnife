using System;
using System.IO;
using System.Windows.Forms;

namespace TheScanlanArmyKnife.Forms
{
    public partial class AppendFiles : Form
    {
        public AppendFiles()
        {
            InitializeComponent();
        }

        private void AppendFiles_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Includes.DriveInformation.GetDrives(cboDriveList);
            cboDriveList.SelectedIndex = 0;
            Includes.DriveInformation.GetFolders(cboDriveList.SelectedItem.ToString(), lstDirectories);
        }


        private void cboDriveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Includes.DriveInformation.GetFolders(cboDriveList.SelectedItem.ToString(), lstDirectories);
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
