using System;
using System.Globalization;
using System.IO;
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

        public string FormatProperCase(string str)
        {
            char[] chars = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower()).ToCharArray();

            for (int i = 0; i + 1 < chars.Length; i++)
            {
                if ((chars[i].Equals('\'')) ||
                    (chars[i].Equals('-')))
                {
                    chars[i + 1] = Char.ToUpper(chars[i + 1]);
                }
            }
            return new string(chars);
        }
    }
}
