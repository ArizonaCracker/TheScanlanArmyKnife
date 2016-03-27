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
            ReverseNameWithCommaByAuthor = 6,
            SwapNameTitleByAuthor = 7,
            StripFolderName = 8,
            StandardCleanup = 9,
            StripLeadingNumeric = 10,
            DirectoryToFile = 11,
            UnFixableFiles = 12,
            SwapNameTitleDirectory = 13,
            ReverseNameWithCommaDirectory = 14
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
            bool forceFileRenaming;
            // ReSharper disable RedundantAssignment
            var nameBook = string.Empty;
            var nameAuthor = string.Empty;
            var theExtension = string.Empty;
            // ReSharper restore RedundantAssignment
            var searchFor = string.Empty;
            int thePosition;

            // ReSharper disable TooWideLocalVariableScope
            // ReSharper disable RedundantAssignment
            string theOldFileName = null;
            string theOldFilePath = null;
            string theNewFileName = null;
            string theNewFilePath = null;
            // ReSharper restore RedundantAssignment
            // ReSharper restore TooWideLocalVariableScope

            if (theAction == FileActions.ChangeCase || theAction == FileActions.StandardCleanup)
                forceFileRenaming = true;
            else
                forceFileRenaming = false;

            #region RenameFile
            if (theAction == FileActions.RenameFile)
            {
                theOldFilePath = txtFolderPath.Text + @"\" + txtOld.Text;
                theNewFilePath = txtFolderPath.Text + @"\" + txtNew.Text;
                RenameSingleFile(theOldFilePath, theNewFilePath, false);
                return;
            }
            #endregion

            #region SwapNameTitleByAuthor
            if (theAction == FileActions.SwapNameTitleByAuthor)
            {
                thePosition = txtOld.Text.LastIndexOf(" - ", StringComparison.Ordinal);
                searchFor = txtOld.Text.Substring(thePosition, txtOld.Text.Length - thePosition);
            }
            #endregion 

            foreach (var file in files)
            {
                //always the same
                theOldFileName = file.ToString();
                theOldFilePath = txtFolderPath.Text + @"\" + theOldFileName;

                switch (theAction)
                {
                    #region PadText
                    case FileActions.PadText:
                        //take txtOld.Text and pad all filenames with text
                        theNewFileName = txtOld.Text + file;
                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;

                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region ChopText
                    case FileActions.ChopText:
                        //take txtOld.Text and strip that from all filenames
                        theNewFileName = file.ToString();
                        theNewFileName = theNewFileName.Remove(0, txtOld.TextLength);
                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;

                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region ChangeCase
                    case FileActions.ChangeCase:
                        //Upper, Lower and Proper case filenames

                        if (rdoProper.Checked)
                            theNewFileName = _commonFunctions.FormatProperCase(file.ToString());
                        else if (rdoUpper.Checked)
                            theNewFileName = file.ToString().ToUpper();
                        else if (rdoLower.Checked)
                            theNewFileName = file.ToString().ToLower();

                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;

                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region ReplaceText
                    case FileActions.ReplaceText:
                        if (!chkMoveFile.Checked)
                            forceFileRenaming = true;
                        // ReSharper disable once PossibleNullReferenceException
                        theNewFileName = theOldFileName.Replace(txtOld.Text, txtNew.Text);

                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region StandardCleanup
                    case FileActions.StandardCleanup:
                        theNewFileName = _commonFunctions.StringStandardCleanup(file.ToString());
                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;

                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region UnFixableFiles
                    case FileActions.UnFixableFiles:
                        var workingString = file.ToString();

                        if (workingString.Contains(" - ") == false)
                        {
                            //always the same
                            theNewFilePath = @"D:\BookWorkingFolder\NotFixable\" + workingString;

                            RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        }

                        break;
                    #endregion
                    #region StripLeadingNumeric
                    case FileActions.StripLeadingNumeric:
                        theNewFileName = file.ToString();

                        var c = theNewFileName.Substring(0, 1);
                        while (c == "0" || c == "1" || c == "2" || c == "3" || c == "4" || c == "5" || c == "6" || c == "7" || c == "8" || c == "9")
                        {
                            theNewFileName = theNewFileName.Remove(0, 1);
                            c = theNewFileName.Substring(0, 1);
                        }

                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region SwapNameTitleByAuthor
                    case FileActions.SwapNameTitleByAuthor:
                        if (file.ToString().Contains(searchFor))
                        {
                            theExtension = file.Extension;
                            nameAuthor = searchFor.Replace(theExtension, string.Empty);
                            nameAuthor = nameAuthor.Replace(" - ", string.Empty);
                            nameBook = file.ToString().Replace(searchFor, string.Empty);

                            theNewFileName = nameAuthor + " - " + nameBook + theExtension;
                            theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                            RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        }
                        break;
                    #endregion
                    #region SwapNameTitleDirectory
                    case FileActions.SwapNameTitleDirectory:
                        theExtension = file.Extension;
                        var working = file.ToString().Replace(theExtension, string.Empty);
                        thePosition = working.LastIndexOf(" - ", StringComparison.Ordinal);

                        nameAuthor = working.Substring(thePosition, working.Length - thePosition);
                        nameAuthor = nameAuthor.Substring(2, nameAuthor.Length - 2).Trim();
                        nameBook = working.Substring(0, thePosition);

                        theNewFileName = nameAuthor + " - " + nameBook + theExtension;
                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region ReverseNameWithCommaByAuthor
                    case FileActions.ReverseNameWithCommaByAuthor:

                        break;
                    #endregion
                    #region ReverseNameWithCommaDirectory
                    case FileActions.ReverseNameWithCommaDirectory:

                        break;
                    #endregion
                    #region StripFolderName
                    case FileActions.StripFolderName:
                        break;
                    #endregion
                    #region DirectoryToFile
                    case FileActions.DirectoryToFile:
                        break;
                        #endregion
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

        private void btnFixNameByAuthor_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.ReverseNameWithCommaByAuthor);
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

        private void btnFixNameDirectory_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.ReverseNameWithCommaDirectory);
        }

        private void btnUnfixableFiles_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.UnFixableFiles);
        }

        private void btnSwapNameTitleByAuthor_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.SwapNameTitleByAuthor);
        }

        private void btnSwapNameTitleDirectory_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.SwapNameTitleDirectory);
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOld.Text = lstFiles.SelectedItem.ToString();
            txtNew.Text = txtOld.Text;
        }

    }
}
