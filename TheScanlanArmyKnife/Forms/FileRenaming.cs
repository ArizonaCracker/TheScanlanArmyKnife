using System;
using System.IO;
using System.Windows.Forms;
using TheScanlanArmyKnife.Includes;

namespace TheScanlanArmyKnife.Forms
{
    public partial class FileRenaming : Form
    {
        readonly CommonFunctions _commonFunctions = new CommonFunctions();
        private bool _oldGroupVisible = true;
        private bool _newGroupVisible = true;

        private enum FileActions
        {
            RenameFile = 1,
            ChopText = 2,
            PadText = 3,
            ChangeCase = 4,
            ReplaceText = 5,
            ReverseNameWithComma = 6,
            SwapNameTitle = 7,
            StripFolderName = 8,
            StandardCleanup = 9,
            StripLeadingNumeric = 10,
            DirectoryToFile = 11,
            UnFixableFiles = 12
        }


        public FileRenaming()
        {
            InitializeComponent();
        }

        private void FileRenaming_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            ClearOutputBox();
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

            //take care of txtOld
            txtOld.Text = string.Empty;
            txtOld.Visible = _oldGroupVisible;
            lblOldText.Visible = txtOld.Visible;

            //take care of txtNew
            txtNew.Text = string.Empty;
            txtNew.Visible = _newGroupVisible;
            lblNewText.Visible = txtNew.Visible;

            ClearOutputBox();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            _commonFunctions.Populate(lstFiles, txtFolderPath);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearOutputBox();

            if (rdoRenameFile.Checked || rdoReplace.Checked)
            {
                //need both text boxes filled out for these
                if (txtOld.Text == string.Empty || txtNew.Text == string.Empty)
                {
                    txtOutput.Text = @"Ya might try putting in something to do...";
                }
                if (rdoRenameFile.Checked)
                {
                    FileNameProcessing(FileActions.RenameFile);
                }
                else if (rdoReplace.Checked)
                {
                    FileNameProcessing(FileActions.ReplaceText);
                }
            }
            else if (rdoChopText.Checked || rdoPadAll.Checked)
            {
                //need both text boxes filled out for these
                if (txtOld.Text == string.Empty)
                {
                    txtOutput.Text = @"Ya might try putting in something to do...";
                }
                else if (rdoChopText.Checked)
                {
                    FileNameProcessing(FileActions.ChopText);
                }
                else if (rdoPadAll.Checked)
                {
                    FileNameProcessing(FileActions.PadText);
                }
            }
            else if (rdoChangeCase.Checked)
            {
                FileNameProcessing(FileActions.ChangeCase);
            }
            else
                txtOutput.Text = @"Ya might try picking something to do...";
        }

        private void ClearOutputBox()
        {
            txtOutput.Text = string.Empty;
        }

        private void FileNameProcessing(FileActions theAction)
        {
            var dinfo = new DirectoryInfo(txtFolderPath.Text);
            var files = dinfo.GetFiles("*.*");

            // ReSharper disable TooWideLocalVariableScope
            string theOldFileName = null;
            string theNewFileName = null;
            // ReSharper restore TooWideLocalVariableScope

            // ReSharper disable once SimplifyConditionalTernaryExpression
            var forceFileRenaming = (theAction == FileActions.ChangeCase) ? true : false;

            if (theAction == FileActions.RenameFile)
            {
                theOldFileName = txtFolderPath.Text + @"\" + txtOld.Text;
                theNewFileName = txtFolderPath.Text + @"\" + txtNew.Text;
                RenameSingleFile(theOldFileName, theNewFileName, false);
                return;
            }

            foreach (var file in files)
            {
                //always the same
                theOldFileName = txtFolderPath.Text + @"\" + file;

                switch (theAction)
                {
                    case FileActions.PadText:
                    //take txtOld.Text and pad all filenames with text
                        theNewFileName = txtFolderPath.Text + @"\" + txtOld.Text + file;
                        RenameSingleFile(theOldFileName, theNewFileName, forceFileRenaming);
                        break;
                    case FileActions.ChopText:
                    //take txtOld.Text and strip that from all filenames
                        theNewFileName = file.ToString();
                        theNewFileName = theNewFileName.Remove(0, txtOld.TextLength);
                        theNewFileName = txtFolderPath.Text + @"\" + theNewFileName;
                        RenameSingleFile(theOldFileName, theNewFileName, forceFileRenaming);
                        break;
                    case FileActions.ChangeCase:
                        //Upper, Lower and Proper case filenames

                        if (rdoProper.Checked)
                            theNewFileName = _commonFunctions.FormatProperCase(file.ToString());
                        else if (rdoUpper.Checked)
                            theNewFileName = file.ToString().ToUpper();
                        else if (rdoLower.Checked)
                            theNewFileName = file.ToString().ToLower();

                        theNewFileName = txtFolderPath.Text + @"\" + theNewFileName;
                        RenameSingleFile(theOldFileName, theNewFileName, forceFileRenaming);
                        break;
                    case FileActions.ReplaceText:
                        break;
                    case FileActions.ReverseNameWithComma:
                        break;
                    case FileActions.SwapNameTitle:
                        break;
                    case FileActions.StripFolderName:
                        break;
                    case FileActions.StandardCleanup:
                        break;
                    case FileActions.StripLeadingNumeric:
                        break;
                    case FileActions.DirectoryToFile:
                        break;
                    case FileActions.UnFixableFiles:
                        var workingString = file.ToString();

                        if (workingString.Contains(" - ") == false)
                        {
                            //always the same
                            theNewFileName = @"D:\BookWorkingFolder\NotFixable\" + workingString;
                            RenameSingleFile(theOldFileName, theNewFileName, forceFileRenaming);
                        }

                        break;
                }
            }
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            txtOutput.Refresh();
        }

        private void RenameSingleFile(string theOldFileName, string theNewFileName, bool forceNameChange)
        {
            if (File.Exists(theNewFileName) && forceNameChange == false)
            {
                txtOutput.Text += @"Destination File Exists...";
            }
            else
            {
                if (chkMoveFile.Checked)
                    theNewFileName = theNewFileName.Replace(@"D:\BookWorkingFolder", @"D:\BookWorkingFolder\Processed");
                File.Move(theOldFileName, theNewFileName);
                _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            }
            txtOutput.Refresh();
        }

        private void btnDirectoryToFile_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.DirectoryToFile);
        }

        private void btnStripLeadingNumeric_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.StripLeadingNumeric);
        }

        private void btnStandardCleanup_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.StandardCleanup);
        }

        private void btnStripFolderName_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.StripFolderName);
        }

        private void btnSwapNameTitle_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.SwapNameTitle);
        }

        private void btnFixName_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.ReverseNameWithComma);
        }

        private void btnUnfixableFiles_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.UnFixableFiles);
        }
    }
}
