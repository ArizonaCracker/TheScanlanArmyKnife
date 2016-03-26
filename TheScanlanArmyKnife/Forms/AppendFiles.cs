using System;
using System.IO;
using System.Windows.Forms;
using TheScanlanArmyKnife.Includes;

namespace TheScanlanArmyKnife.Forms
{
    public partial class AppendFiles : Form
    {
        CommonFunctions Common = new CommonFunctions();

        public AppendFiles()
        {
            InitializeComponent();
        }

        private void AppendFiles_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Common.ListFiles(txtFolderPath.Text, lstFiles);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            Common.Populate(lstFiles, txtFolderPath);
        }

    }
}
