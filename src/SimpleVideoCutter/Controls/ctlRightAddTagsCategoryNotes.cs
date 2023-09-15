using SimpleVideoCutter.DAL;
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
    public partial class ctlRightAddTagsCategoryNotes : UserControl
    {
        //private TagsUse tagsData;
        public ctlRightAddTagsCategoryNotes()
        {
            InitializeComponent();
            ThemeResolutionService.ApplyThemeToControlTree(this, "FluentDark");
            radDDListImportance.SelectedIndex = 0;
           
        }

        private void radPanel1_Initialized(object sender, EventArgs e)
        {

        }

        private void ctlRightAddTagsCategoryNotes_Load(object sender, EventArgs e)
        {
            
            //DAL.TagsUse tagsUse= new DAL.TagsUse();
            //tagsData = tagsUse;
            //LoadTags();
        }
        private void LoadTags()
        {
            //radCheckedDropDownListTags.DataSource = tagsData.GetAllTags().OrderBy(t=>t);

        }

        private void radDDListImportance_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            var t = ((Telerik.WinControls.UI.RadDropDownList)sender).SelectedItem;

        }
    }
}
