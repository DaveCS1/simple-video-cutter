
namespace SimpleVideoCutter.Controls
{
    partial class ctlTagsCategories
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radPageViewTagsCategories = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPageAddCategoriesAndTags = new Telerik.WinControls.UI.RadPageViewPage();
            this.radBtnAddTag = new Telerik.WinControls.UI.RadButton();
            this.radTextBoxControl1 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radCheckedDropDownList1 = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.radPageViewPageAddTag = new Telerik.WinControls.UI.RadPageViewPage();
            this.radBtnAddTags = new Telerik.WinControls.UI.RadButton();
            this.radTextBoxCtlAddTags = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewTagsCategories)).BeginInit();
            this.radPageViewTagsCategories.SuspendLayout();
            this.radPageViewPageAddCategoriesAndTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAddTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).BeginInit();
            this.radPageViewPageAddTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAddTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxCtlAddTags)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageViewTagsCategories
            // 
            this.radPageViewTagsCategories.Controls.Add(this.radPageViewPageAddCategoriesAndTags);
            this.radPageViewTagsCategories.Controls.Add(this.radPageViewPageAddTag);
            this.radPageViewTagsCategories.Controls.Add(this.radPageViewPage3);
            this.radPageViewTagsCategories.DefaultPage = this.radPageViewPageAddCategoriesAndTags;
            this.radPageViewTagsCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageViewTagsCategories.Location = new System.Drawing.Point(0, 0);
            this.radPageViewTagsCategories.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.radPageViewTagsCategories.Name = "radPageViewTagsCategories";
            this.radPageViewTagsCategories.SelectedPage = this.radPageViewPageAddTag;
            this.radPageViewTagsCategories.Size = new System.Drawing.Size(920, 640);
            this.radPageViewTagsCategories.TabIndex = 0;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageViewTagsCategories.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Auto;
            // 
            // radPageViewPageAddCategoriesAndTags
            // 
            this.radPageViewPageAddCategoriesAndTags.Controls.Add(this.radBtnAddTag);
            this.radPageViewPageAddCategoriesAndTags.Controls.Add(this.radTextBoxControl1);
            this.radPageViewPageAddCategoriesAndTags.Controls.Add(this.radCheckedDropDownList1);
            this.radPageViewPageAddCategoriesAndTags.ItemSize = new System.Drawing.SizeF(112F, 28F);
            this.radPageViewPageAddCategoriesAndTags.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPageAddCategoriesAndTags.Name = "radPageViewPageAddCategoriesAndTags";
            this.radPageViewPageAddCategoriesAndTags.Size = new System.Drawing.Size(899, 592);
            this.radPageViewPageAddCategoriesAndTags.Text = "radPageViewPage1";
            // 
            // radBtnAddTag
            // 
            this.radBtnAddTag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnAddTag.Image = global::SimpleVideoCutter.VideoControlIcons24.Save_WF;
            this.radBtnAddTag.Location = new System.Drawing.Point(667, 162);
            this.radBtnAddTag.Name = "radBtnAddTag";
            this.radBtnAddTag.Size = new System.Drawing.Size(137, 30);
            this.radBtnAddTag.TabIndex = 5;
            this.radBtnAddTag.Text = "Done";
            this.radBtnAddTag.ThemeName = "FluentDark";
            this.radBtnAddTag.Click += new System.EventHandler(this.radBtnAddTag_Click);
            // 
            // radTextBoxControl1
            // 
            this.radTextBoxControl1.EmbeddedLabelText = "Add Tag- Add  multiple tags with , (comma) - Car,House,Pet, Boat";
            this.radTextBoxControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBoxControl1.Location = new System.Drawing.Point(107, 72);
            this.radTextBoxControl1.Name = "radTextBoxControl1";
            this.radTextBoxControl1.ShowClearButton = true;
            this.radTextBoxControl1.ShowEmbeddedLabel = true;
            this.radTextBoxControl1.Size = new System.Drawing.Size(697, 40);
            this.radTextBoxControl1.TabIndex = 4;
            this.radTextBoxControl1.ThemeName = "FluentDark";
            // 
            // radCheckedDropDownList1
            // 
            this.radCheckedDropDownList1.DisplayMember = "TagValue";
            this.radCheckedDropDownList1.DropDownAnimationEnabled = true;
            this.radCheckedDropDownList1.Location = new System.Drawing.Point(107, 118);
            this.radCheckedDropDownList1.Name = "radCheckedDropDownList1";
            this.radCheckedDropDownList1.Size = new System.Drawing.Size(697, 24);
            this.radCheckedDropDownList1.TabIndex = 3;
            this.radCheckedDropDownList1.ThemeName = "FluentDark";
            // 
            // radPageViewPageAddTag
            // 
            this.radPageViewPageAddTag.Controls.Add(this.radBtnAddTags);
            this.radPageViewPageAddTag.Controls.Add(this.radTextBoxCtlAddTags);
            this.radPageViewPageAddTag.ItemSize = new System.Drawing.SizeF(112F, 28F);
            this.radPageViewPageAddTag.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPageAddTag.Name = "radPageViewPageAddTag";
            this.radPageViewPageAddTag.Size = new System.Drawing.Size(899, 592);
            this.radPageViewPageAddTag.Text = "radPageViewPage2";
            // 
            // radBtnAddTags
            // 
            this.radBtnAddTags.Image = global::SimpleVideoCutter.VideoControlIcons24.Save_WF;
            this.radBtnAddTags.Location = new System.Drawing.Point(660, 118);
            this.radBtnAddTags.Name = "radBtnAddTags";
            this.radBtnAddTags.Size = new System.Drawing.Size(137, 30);
            this.radBtnAddTags.TabIndex = 6;
            this.radBtnAddTags.Text = "Add Tags";
            this.radBtnAddTags.Click += new System.EventHandler(this.radBtnAddTags_Click);
            // 
            // radTextBoxCtlAddTags
            // 
            this.radTextBoxCtlAddTags.EmbeddedLabelText = "Add Tag- Add  multiple tags with , (comma) - Car,House,Pet, Boat";
            this.radTextBoxCtlAddTags.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBoxCtlAddTags.Location = new System.Drawing.Point(100, 62);
            this.radTextBoxCtlAddTags.Name = "radTextBoxCtlAddTags";
            this.radTextBoxCtlAddTags.ShowClearButton = true;
            this.radTextBoxCtlAddTags.ShowEmbeddedLabel = true;
            this.radTextBoxCtlAddTags.Size = new System.Drawing.Size(697, 40);
            this.radTextBoxCtlAddTags.TabIndex = 5;
            this.radTextBoxCtlAddTags.ThemeName = "FluentDark";
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.ItemSize = new System.Drawing.SizeF(112F, 28F);
            this.radPageViewPage3.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(899, 592);
            this.radPageViewPage3.Text = "radPageViewPage3";
            // 
            // ctlTagsCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPageViewTagsCategories);
            this.Name = "ctlTagsCategories";
            this.Size = new System.Drawing.Size(920, 640);
            this.Load += new System.EventHandler(this.ctlTagsCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewTagsCategories)).EndInit();
            this.radPageViewTagsCategories.ResumeLayout(false);
            this.radPageViewPageAddCategoriesAndTags.ResumeLayout(false);
            this.radPageViewPageAddCategoriesAndTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAddTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).EndInit();
            this.radPageViewPageAddTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAddTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxCtlAddTags)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageViewTagsCategories;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPageAddCategoriesAndTags;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPageAddTag;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadButton radBtnAddTag;
        private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl1;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList1;
        private Telerik.WinControls.UI.RadButton radBtnAddTags;
        private Telerik.WinControls.UI.RadTextBoxControl radTextBoxCtlAddTags;
    }
}
