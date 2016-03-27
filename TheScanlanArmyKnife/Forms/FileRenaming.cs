using System;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using TheScanlanArmyKnife.Includes;

namespace TheScanlanArmyKnife.Forms
{
    public partial class FileRenaming : Form
    {
        readonly CommonFunctions _commonFunctions = new CommonFunctions();
        private bool _oldGroupVisible = true;
        private bool _newGroupVisible = true;
        private int _fileCount = 0;

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
            lblFileCount.Text = string.Empty;
            lblFilesDone.Text = string.Empty;
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
            var firstName = string.Empty;
            var lastName = string.Empty;
            var workingString = string.Empty;
            // ReSharper disable TooWideLocalVariableScope
            string theOldFileName = null;
            string theOldFilePath = null;
            string theNewFileName = null;
            string theNewFilePath = null;
            // ReSharper restore TooWideLocalVariableScope
            // ReSharper restore RedundantAssignment
            var searchFor = string.Empty;
            int thePosition;

            lstFiles.Items.Clear();
            lstFiles.BeginUpdate();

            _fileCount = files.Length;
            lblFileCount.Text = _fileCount.ToString();
            lblFileCount.Refresh();

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

            #region ReverseNameWithCommaByAuthor
            if (theAction == FileActions.ReverseNameWithCommaByAuthor)
            {
                thePosition = txtOld.Text.IndexOf(" - ", StringComparison.Ordinal);
                searchFor = txtOld.Text.Substring(0, thePosition).Trim();
                thePosition = searchFor.LastIndexOf(" ", StringComparison.Ordinal);
                if (thePosition == -1)
                {
                    txtOutput.Text = @"No space in Author Name...";
                    lstFiles.EndUpdate();
                    return;
                }

                firstName = searchFor.Substring(0, thePosition).Trim();
                lastName = searchFor.Substring(thePosition, searchFor.Length - thePosition).Trim();
            }
            #endregion

            _fileCount = 0;
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
                        theExtension = file.Extension;
                        workingString = file.ToString();
                        workingString = workingString.Replace(theExtension, string.Empty);
                        theNewFileName = _commonFunctions.StringStandardCleanup(workingString) + theExtension.ToLower();
                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;

                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region UnFixableFiles
                    case FileActions.UnFixableFiles:
                        workingString = file.ToString();

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
                        workingString = file.ToString();
                        workingString = workingString.Replace(theExtension, string.Empty);
                        thePosition = workingString.LastIndexOf(" - ", StringComparison.Ordinal);

                        nameAuthor = workingString.Substring(thePosition, workingString.Length - thePosition);
                        nameAuthor = nameAuthor.Substring(2, nameAuthor.Length - 2).Trim();
                        nameBook = workingString.Substring(0, thePosition);

                        theNewFileName = nameAuthor + " - " + nameBook + theExtension;
                        theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                        RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        break;
                    #endregion
                    #region ReverseNameWithCommaByAuthor
                    case FileActions.ReverseNameWithCommaByAuthor:
                        if (file.ToString().StartsWith(searchFor))
                        {
                            nameBook = file.ToString().Replace(searchFor, string.Empty);

                            theNewFileName = lastName + ", " + firstName + nameBook;
                            theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                            RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        }


                        break;
                    #endregion
                    #region ReverseNameWithCommaDirectory
                    case FileActions.ReverseNameWithCommaDirectory:
                        workingString = theOldFileName;
                        thePosition = workingString.IndexOf(" - ", StringComparison.Ordinal);
                        nameAuthor = workingString.Substring(0, thePosition).Trim();
                        nameBook = workingString.Substring(thePosition, workingString.Length - thePosition);

                        thePosition = nameAuthor.LastIndexOf(" ", StringComparison.Ordinal);
                        if (thePosition != -1)
                        {
                            firstName = nameAuthor.Substring(0, thePosition).Trim();
                            lastName = nameAuthor.Substring(thePosition, nameAuthor.Length - thePosition).Trim();

                            theNewFileName = lastName + ", " + firstName + nameBook;
                            theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                            RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        }
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
                _fileCount++;
                lblFilesDone.Text = _fileCount.ToString();
                lblFilesDone.Refresh();
            }
            txtOutput.Refresh();
            lstFiles.EndUpdate();
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
            //txtOutput.Refresh();
        }

        private void btnDirectoryToFile_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.DirectoryToFile);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void btnFixNameByAuthor_Click(object sender, EventArgs e)
        {
            if (txtOld.Text.Length == 0)
                txtOutput.Text = @"Try picking an author to do....";
            else
            {
                FileNameProcessing(FileActions.ReverseNameWithCommaByAuthor);
                _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
                Refresh();
            }
        }

        private void btnStripLeadingNumeric_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.StripLeadingNumeric);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void btnStandardCleanup_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.StandardCleanup);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void btnStripFolderName_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.StripFolderName);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void btnFixNameDirectory_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.ReverseNameWithCommaDirectory);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void btnUnfixableFiles_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.UnFixableFiles);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void btnSwapNameTitleByAuthor_Click(object sender, EventArgs e)
        {
            if (txtOld.Text.Length == 0)
                txtOutput.Text = @"Try picking an author to do....";
            else
            {
                FileNameProcessing(FileActions.SwapNameTitleByAuthor);
                _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
                Refresh();
            }
        }

        private void btnSwapNameTitleDirectory_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.SwapNameTitleDirectory);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOld.Text = lstFiles.SelectedItem.ToString();
            txtNew.Text = txtOld.Text;
        }

    }
}
