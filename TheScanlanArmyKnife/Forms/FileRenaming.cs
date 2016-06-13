using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TheScanlanArmyKnife.Includes;

namespace TheScanlanArmyKnife.Forms
{
    public partial class FileRenaming : Form
    {
        readonly CommonFunctions _commonFunctions = new CommonFunctions();
        private bool _oldGroupVisible = true;
        private bool _newGroupVisible = true;
        private int _fileCount;
        private static readonly string _theDamnedHypen = " - ";
        private static readonly string _theDamnedSpace = " ";

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
            StripAuthorNamePeriods = 11,
            UnFixableFiles = 12,
            SwapNameTitleDirectory = 13,
            ReverseNameWithCommaDirectory = 14,
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
            PopulateDirectoryTree();

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
                thePosition = searchFor.LastIndexOf(_theDamnedSpace, StringComparison.Ordinal);
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
                        thePosition = theOldFileName.IndexOf(txtOld.Text, StringComparison.Ordinal);
                        if (thePosition != -1)
                        {
                            if (chkFirstOnly.Checked && thePosition != -1)
                            {
                                thePosition = theOldFileName.IndexOf(txtOld.Text, StringComparison.Ordinal);
                                theNewFileName = theOldFileName.Substring(0, thePosition) + txtNew.Text + theOldFileName.Substring(thePosition + 1, theOldFileName.Length - thePosition - 1);
                            }
                            else
                            {
                                // ReSharper disable once PossibleNullReferenceException
                                theNewFileName = theOldFileName.Replace(txtOld.Text, txtNew.Text);
                            }

                            theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                            RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        }
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
                            theNewFilePath = @"D:\BookWorkingNotFixable\" + workingString;

                            RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                        }

                        break;
                    #endregion
                    #region StripLeadingNumeric
                    case FileActions.StripLeadingNumeric:
                        theNewFileName = file.ToString();

                        var c = theNewFileName.Substring(0, 1);
                        while (c == " 0" || c == " 1" || c == " 2" || c == " 3" || c == " 4" || c == " 5" || c == " 6" || c == " 7" || c == " 8" || c == " 9")
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

                            theNewFileName = nameAuthor + _theDamnedHypen + nameBook + theExtension;
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

                        theNewFileName = nameAuthor + _theDamnedHypen + nameBook + theExtension;
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

                        thePosition = nameAuthor.LastIndexOf(_theDamnedSpace, StringComparison.Ordinal);
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
                    case FileActions.StripAuthorNamePeriods:
                        workingString = theOldFileName;
                        thePosition = workingString.IndexOf(" - ", StringComparison.Ordinal);
                        if (thePosition != -1)
                        {
                            workingString = workingString.Substring(0, thePosition).Replace(" - ", string.Empty);
                            if (workingString.IndexOf(".", StringComparison.Ordinal) != -1)
                            {
                                workingString = workingString.Replace(".", string.Empty);
                                theNewFileName = workingString + theOldFileName.Substring(thePosition, theOldFileName.Length - thePosition);
                                theNewFilePath = txtFolderPath.Text + @"\" + theNewFileName;
                                RenameSingleFile(theOldFilePath, theNewFilePath, forceFileRenaming);
                            }
                        }
                        break;
                    #endregion
                    #region StripFolderName
                    case FileActions.StripFolderName:
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
                    theNewFileName = theNewFileName.Replace(@"D:\BookWorkingFolder", @"D:\BookWorkingProcessed");
                File.Move(theOldFileName, theNewFileName);
                _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            }
            //txtOutput.Refresh();
        }

        private void btnDirectoryToFile_Click(object sender, EventArgs e)
        {
            var dinfo = new DirectoryInfo(txtFolderPath.Text);
            var files = dinfo.GetFiles("*.*");
            const string theFilename = @"C:\Temp\BookDirectory.txt";
            var sw = new StreamWriter(theFilename);
            var newLine = sw.NewLine;
            foreach (var file in files)
            {
                sw.Write(file + newLine);
            }
            sw.Flush();
            sw.Close();
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

        private void btnStripAuthorNamePeriods_Click(object sender, EventArgs e)
        {
            FileNameProcessing(FileActions.StripAuthorNamePeriods);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void btnSwapNameTitleDirectory_Click(object sender, EventArgs e)
        {
            /*
            var dinfo = new DirectoryInfo(txtFolderPath.Text);
            var files = dinfo.GetFiles("*.*");
            foreach (var file in files)
            {

            }
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
            */
            FileNameProcessing(FileActions.SwapNameTitleDirectory);
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOld.Text = lstFiles.SelectedItem.ToString();
            txtNew.Text = txtOld.Text;
        }

        private void btnSegregateAuthors_Click(object sender, EventArgs e)
        {
            var dinfo = new DirectoryInfo(txtFolderPath.Text);
            var files = dinfo.GetFiles("*.*");
            var authorNamesAll = new List<string>();
            var authorNamesSingular = new List<string>();

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var file in files)
            {
                var workingAuthorName = file.Name;
                var thePosition = workingAuthorName.IndexOf(" - ", StringComparison.Ordinal);
                // ReSharper disable once InvertIf
                if (thePosition != -1)
                {
                    workingAuthorName = workingAuthorName.Substring(0, thePosition).Trim();
                    if (!authorNamesSingular.Contains(workingAuthorName))
                        authorNamesSingular.Add(workingAuthorName);
                    authorNamesAll.Add(workingAuthorName);
                }
            }

            foreach (var authorName in authorNamesSingular)
            {
                if (GetNameCount(authorName, authorNamesAll) >= 5)
                {
                    if (authorName != "Anonymous")
                    {
                        var theDir = dinfo.CreateSubdirectory(authorName).ToString();
                        MoveBooks(authorName, theDir, txtFolderPath.Text, true);
                        CleanUpAuthorDirectory(theDir);
                    }
                }
            }
            _commonFunctions.ListFiles(txtFolderPath.Text, lstFiles);
            Refresh();
        }

        // ReSharper disable once ParameterTypeCanBeEnumerable.Local
        private static int GetNameCount(string searchingFor, List<string> authorNamesAll)
        {
            return authorNamesAll.Count(authorName => authorName == searchingFor);
        }

        private void CleanUpAuthorDirectory(string theAuthorPath)
        {
            var dinfo = new DirectoryInfo(theAuthorPath);
            var files = dinfo.GetFiles("*.*");
            var bookNamesSingular = new List<string>();
            var bookNamesAll = new List<string>();

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var file in files)
            {
                var workingBookName = file.Name;
                var thePosition = workingBookName.IndexOf(_theDamnedHypen, StringComparison.Ordinal);
                // ReSharper disable once InvertIf
                if (thePosition != -1)
                {
                    bookNamesAll.Add(workingBookName);
                    workingBookName = workingBookName.Substring(0, thePosition).Trim();

                    var c = workingBookName.Substring(workingBookName.Length - 3, 3);
                    if (c == " 01" || c == " 02" || c == " 03" || c == " 04" || c == " 05" || c == " 06" || c == " 07" || c == " 08" || c == " 09" || c == " 10")
                    {
                        workingBookName = workingBookName.Substring(0, workingBookName.Length - 3).Trim();
                    }
                    if (!bookNamesSingular.Contains(workingBookName))
                        bookNamesSingular.Add(workingBookName);
                }
            }

            foreach (var seriesName in bookNamesSingular)
            {
                if (SeriesCount(seriesName, bookNamesAll) >= 5)
                {
                    var theDir = dinfo.CreateSubdirectory(seriesName).ToString();
                    MoveBooks(seriesName, theDir, theAuthorPath, false);
                }
            }

        }

        private static int SeriesCount(string theName, List<string> allBookNames)
        {
            var theCount = 0;

            foreach (var element in allBookNames)
            {
                if (element.StartsWith(theName))
                    theCount++;
            }

            return theCount;
        }


        private static void MoveBooks(string theAuthorName, string theNewPath, string rootPath, bool putOnHyphen)
        {
            var dinfo = new DirectoryInfo(rootPath);
            var files = dinfo.GetFiles("*.*");
            var workingString = theAuthorName;
            // ReSharper disable TooWideLocalVariableScope
            string theNewPathName;
            string theNewFileName;
            // ReSharper restore TooWideLocalVariableScope

            if (putOnHyphen)
                workingString += _theDamnedHypen;

            foreach (var file in files)
            {
                if (file.Name.StartsWith(workingString))
                {
                    theNewFileName = file.Name.Substring(workingString.Length, file.Name.Length - workingString.Length).Trim();
                    if (theNewFileName.StartsWith("- "))
                        theNewFileName = theNewFileName.Substring(2, theNewFileName.Length - 2);
                    theNewPathName = theNewPath + @"\" + theNewFileName.Trim();
                    file.MoveTo(theNewPathName);
                }
            }
        }

        private void PopulateDirectoryTree()
        {
            //get a list of the drives
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                var di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    //set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady)
                    node.Nodes.Add(@"...");

                dirsTreeView.Nodes.Add(node);
            }
        }

        private void dirsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == @"..." && e.Node.Nodes[0].Tag == null)
                {
                    //lstFiles. = ;
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    var dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (var dir in dirs)
                    {
                        var di = new DirectoryInfo(dir);
                        var node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Any())
                                node.Nodes.Add(null, @"...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, @"DirectoryLister", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                    _commonFunctions.ListFiles(e.Node.FullPath, lstFiles);
                }
            }

        }
    }
}
