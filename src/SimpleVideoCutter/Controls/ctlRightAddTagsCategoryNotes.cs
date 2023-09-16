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
        private TagsUse tagsData;
        private Categories categoriesData;
        private SubCategories subCategoriesData;

        public int importance { get; set; }
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

            DAL.TagsUse tagsUse = new DAL.TagsUse();
            tagsData = tagsUse;
            DAL.Categories categories = new DAL.Categories();
            categoriesData = categories;
            DAL.SubCategories subCategories = new DAL.SubCategories();
            subCategoriesData = subCategories;
           
            LoadTagsAndCategories();
        }
        private void LoadTagsAndCategories()
        {           
            radCheckedDropDownListTags.DataSource = tagsData.GetAllTags();
            radDDListCategory.DataSource = categoriesData.GetAllCategories();
            radCheckedDropDownListSubCategories.DataSource = subCategoriesData.GetAllSubCategories();
 //var t = new { Bill = "test" };
           

        }

        private void radDDListImportance_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //todo refactor importance everywhere
            importance= ((Telerik.WinControls.UI.RadDropDownList)sender).SelectedIndex +1;
        
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DAL.Categories categories = new DAL.Categories();
            categoriesData = categories;

            List<string> tagsFromTextBox = "one,two,three, sdfsdf"
                   .Split(',')
                   .Select(entry => entry.Trim())  // Trim to remove leading/trailing spaces
                   .Where(entry => !string.IsNullOrWhiteSpace(entry))
                   .ToList();

            //tagsData.AddTagList(tagsFromTextBox);

            categories.AddCategoryList(tagsFromTextBox);
        }

        private void AddBookMark()
        {
            BookMarks bookMark = new BookMarks();
            bookMark.InsertBookmark(new Bookmark() 
            { 
           //
            
            
            });
            //bookMark.Categories = Category; //txtCategory.Text.Trim(); //categoryList;
            //bookMark.SubCategory = SubCategory;

            //bookMark.Tags = txtTags.Text.Trim();
            //bookMark.Description = txtDescription.Text.Trim();
            //bookMark.Importance = Convert.ToInt32(cboImportance.SelectedIndex + 1);

            ////bookMark.FileName = fileBeingPlayed;
            //bookMark.FileName = lnkFilePath.Text;
            //bookMark.AddBookMark(bookMark);

            //lblBookMarkStatus.Text = "Bookmark Added";
            ////puyt back    lnkFilePath.Text = fileBeingPlayed;
            //chkBookMarkAdded.Checked = true;

        }


    }
}
