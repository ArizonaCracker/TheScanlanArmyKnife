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
    public partial class FileRenaming : Form
    {
        CommonFunctions Common = new CommonFunctions();
        private bool _oldGroupVisible = true;
        private bool _newGroupVisible = true;

        public FileRenaming()
        {
            InitializeComponent();
        }

        private void FileRenaming_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Common.ListFiles(txtFolderPath.Text, lstFiles);
        }

        private void rdoChangeCase_CheckedChanged(object sender, EventArgs e)
        {
            _oldGroupVisible = false;
            _newGroupVisible = false;
            RadioButtonChanged(true);
        }

        private void rdoRenameFile_CheckedChanged(object sender, EventArgs e)
        {
            _oldGroupVisible = true;
            _newGroupVisible = true;
            RadioButtonChanged(false);
        }

        private void rdoChopText_CheckedChanged(object sender, EventArgs e)
        {
            _oldGroupVisible = true;
            _newGroupVisible = false;
            RadioButtonChanged(false);
        }

        private void rdoPadAll_CheckedChanged(object sender, EventArgs e)
        {
            _oldGroupVisible = true;
            _newGroupVisible = false;
            RadioButtonChanged(false);
        }

        private void rdoReplace_CheckedChanged(object sender, EventArgs e)
        {
            _oldGroupVisible = true;
            _newGroupVisible = true;
            RadioButtonChanged(false);
        }

        private void RadioButtonChanged(bool caseVisible)
        {
            grpCase.Visible = caseVisible;
            txtOld.Text = string.Empty;
            txtNew.Text = string.Empty;

            txtOld.Visible = _oldGroupVisible;
            lblOldText.Visible = txtOld.Visible;

            txtNew.Visible = _newGroupVisible;
            lblNewText.Visible = txtNew.Visible;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            Common.Populate(lstFiles, txtFolderPath);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (rdoRenameFile.Checked)
            {
            }

            if (rdoChopText.Checked)
            {
            }

            if (rdoPadAll.Checked)
            {
            }

            if (rdoChangeCase.Checked)
            {
            }

            if (rdoReplace.Checked)
            {
            }
        }
    }
}
