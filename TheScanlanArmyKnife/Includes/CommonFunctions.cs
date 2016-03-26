using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheScanlanArmyKnife.Includes
{
    class CommonFunctions
    {
        public void ListFiles(string filePath, ListBox theListBox)
        {
            theListBox.Items.Clear();

            var dinfo = new DirectoryInfo(filePath);

            var files = dinfo.GetFiles("*.*");

            foreach (var file in files)
            {
                theListBox.Items.Add(file.Name);
            }
        }

        public void Populate(ListBox theListBox, TextBox theTextBox)
        {
            var folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                SelectedPath = theTextBox.Text
            };
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                theTextBox.Text = folderBrowserDialog.SelectedPath;
                ListFiles(theTextBox.Text, theListBox);
            }
        }
    }
}
