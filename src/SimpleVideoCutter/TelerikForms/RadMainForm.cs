using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SimpleVideoCutter.TelerikForms
{
    public partial class RadMainForm : Telerik.WinControls.UI.RadForm
    {
        public RadMainForm()
        {
            InitializeComponent();
        }

        private void RadMainForm_Load(object sender, EventArgs e)
        {
            //radCommandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      
        }
        //  explorerControl1.ThemeName = "FluentDark";
        //  explorerControl1.MultiSelect = true;
    }
}
