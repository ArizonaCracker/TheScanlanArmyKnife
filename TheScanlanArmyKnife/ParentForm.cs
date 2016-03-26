using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheScanlanArmyKnife.Forms;

namespace TheScanlanArmyKnife
{
    public partial class ParentForm : Form
    {

        public ParentForm()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void appendFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllTheChildren();
            var newMdiChild = new AppendFiles {MdiParent = this};
            newMdiChild.Show();
        }

        private void directoryToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllTheChildren();
            var newMdiChild = new DirectoryToXML() { MdiParent = this };
            newMdiChild.Show();
        }

        private void fileRenamingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllTheChildren();
            var newMdiChild = new FileRenaming() { MdiParent = this };
            newMdiChild.Show();
        }

        private void mediaUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllTheChildren();
            var newMdiChild = new MediaUpload() { MdiParent = this };
            newMdiChild.Show();
        }

        private void passwordGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllTheChildren();
            var newMdiChild = new PasswordGenerator() { MdiParent = this };
            newMdiChild.Show();
        }


        private void CloseAllTheChildren()
        {
            foreach (var childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
