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

        public string StringStandardCleanup(string inputString)
        {
            //propers
            var workingString = inputString.ToLower();

            workingString = workingString.Trim();

            while (workingString.Contains("  "))
            {
                workingString = workingString.Replace("  ", " ");
            }

            workingString = workingString.Replace("( ", "(");
            workingString = workingString.Replace(" )", ")");
            workingString = workingString.Replace("[", string.Empty);
            workingString = workingString.Replace("]", string.Empty);
            workingString = workingString.Replace("_", " ");
            workingString = workingString.Replace("(v1.0)", string.Empty);
            workingString = workingString.Replace("(v2.0)", string.Empty);
            workingString = workingString.Replace("(v3.0)", string.Empty);
            workingString = workingString.Replace("(v4.0)", string.Empty);
            workingString = workingString.Replace("(v5.0)", string.Empty);
            workingString = workingString.Replace("(mobi)", string.Empty);
            workingString = workingString.Replace("--", "-");
            workingString = workingString.Replace("—", "-");
            workingString = workingString.Replace(" ,", ",");
            workingString = workingString.Replace("'S", "'s");
            workingString = workingString.Replace("'T", "'t");
            workingString = workingString.Replace(" .mp3", ".mp3");
            workingString = workingString.Replace(" .mobi", ".mobi");
            workingString = workingString.Replace(" .epub", ".epub");

            workingString = FormatProperCase(workingString);

            return workingString;
        }
    }
}
