using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheScanlanArmyKnife.Includes;

namespace TheScanlanArmyKnife.Forms
{
    public partial class DirectoryToXML : Form
    {
        CommonFunctions Common = new CommonFunctions();

        public DirectoryToXML()
        {
            InitializeComponent();
        }

        private void DirectoryToXML_Load(object sender, EventArgs e)
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
