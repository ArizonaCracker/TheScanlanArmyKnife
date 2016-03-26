using System.IO;
using System.Windows.Forms;

namespace TheScanlanArmyKnife.Includes
{
    public class DriveInformation
    {
        public static void GetDrives(ComboBox theComboBox)
        {
            theComboBox.Items.Clear();
            var theDrives = theComboBox.MaxDropDownItems = DriveInfo.GetDrives().Length;

            for (var index = 0; index < theDrives; index++)
            {
                var f = DriveInfo.GetDrives()[index];
                if (f.DriveType == DriveType.Fixed)
                    theComboBox.Items.Add(f);
            }
        }

        public static void GetFolders(string thePath, ListBox theListBox)
        {
            theListBox.Items.Clear();

            var dirs = Directory.GetDirectories(thePath);

            foreach (var dir in dirs)
            {
                theListBox.Items.Add(dir);
            }

        }
    }
}