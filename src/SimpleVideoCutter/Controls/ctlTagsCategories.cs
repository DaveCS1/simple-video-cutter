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
    public partial class ctlTagsCategories : UserControl
    {
        public ctlTagsCategories()
        {
            InitializeComponent();
            ThemeResolutionService.ApplyThemeToControlTree(this, "FluentDark");
        }


        
        private void ctlTagsCategories_Load(object sender, EventArgs e)
        {
            List<string> tags = new List<string>() { "tag", "tag1", "tag2", "tag3", "tag4", "tag5", "tag6", "tag7", };
            radCheckedDropDownList1.DataSource = tags;
            
        }
    }
}
