using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheScanlanArmyKnife.Forms
{
    public partial class MediaUpload : Form
    {
        public MediaUpload()
        {
            InitializeComponent();
        }

        private void MediaUpload_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}
