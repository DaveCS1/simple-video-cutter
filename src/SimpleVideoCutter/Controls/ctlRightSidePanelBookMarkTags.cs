using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SimpleVideoCutter.Controls
{
    public partial class ctlRightSidePanelBookMarkTags : UserControl
    {
        public ctlRightSidePanelBookMarkTags()
        {
            InitializeComponent();
            ThemeResolutionService.ApplyThemeToControlTree(this, "FluentDark");
            radDropDdLstImportance.SelectedIndex = 0;
        }

        private void radCollapsiblePanel1_Collapsed(object sender, EventArgs e)
        {
            radCollapsiblePanel2.Visible = true;
            radCollapsiblePanel3.Visible = true;
            radTextBoxCtlDescription.Visible = true;
        }

        private void radCollapsiblePanel1_Expanded(object sender, EventArgs e)
        {
            radCollapsiblePanel2.Visible = false;
            radCollapsiblePanel3.Visible = false;
            radTextBoxCtlDescription.Visible = false;
        }

        private void radCollapsiblePanel2_Expanded(object sender, EventArgs e)
        {
            radCollapsiblePanel1.Visible = false;
            radCollapsiblePanel3.Visible = false;
            radTextBoxCtlDescription.Visible = false;
        }

        private void radCollapsiblePanel2_Collapsed(object sender, EventArgs e)
        {
            radCollapsiblePanel1.Visible = true;
            radCollapsiblePanel3.Visible = true;
            radTextBoxCtlDescription.Visible = true;
        }




        //
    }
}
