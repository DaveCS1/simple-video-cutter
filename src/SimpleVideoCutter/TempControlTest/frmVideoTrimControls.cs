using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SimpleVideoCutter.TempControlTest
{
    public partial class frmVideoTrimControls : Telerik.WinControls.UI.RadForm
    {
        public frmVideoTrimControls()
        {
            InitializeComponent();
            radMenu1.BackColor = this.BackColor;
        }

        private void radMenu1_Click(object sender, EventArgs e)
        {

        }
    }
}
