namespace SimpleVideoCutter.Windows
{
    partial class RadTestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fluentDarkTheme1 = new Telerik.WinControls.Themes.FluentDarkTheme();
            this.ctlRightSidePanelBookMarkTags1 = new SimpleVideoCutter.Controls.ctlRightSidePanelBookMarkTags();
            this.ctlRightAddTagsCategoryNotes1 = new SimpleVideoCutter.Controls.ctlRightAddTagsCategoryNotes();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlRightSidePanelBookMarkTags1
            // 
            this.ctlRightSidePanelBookMarkTags1.Location = new System.Drawing.Point(505, 12);
            this.ctlRightSidePanelBookMarkTags1.Name = "ctlRightSidePanelBookMarkTags1";
            this.ctlRightSidePanelBookMarkTags1.Size = new System.Drawing.Size(345, 639);
            this.ctlRightSidePanelBookMarkTags1.TabIndex = 0;
            // 
            // ctlRightAddTagsCategoryNotes1
            // 
            this.ctlRightAddTagsCategoryNotes1.Location = new System.Drawing.Point(24, 12);
            this.ctlRightAddTagsCategoryNotes1.Name = "ctlRightAddTagsCategoryNotes1";
            this.ctlRightAddTagsCategoryNotes1.Size = new System.Drawing.Size(350, 700);
            this.ctlRightAddTagsCategoryNotes1.TabIndex = 1;
            // 
            // RadTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 728);
            this.Controls.Add(this.ctlRightAddTagsCategoryNotes1);
            this.Controls.Add(this.ctlRightSidePanelBookMarkTags1);
            this.Name = "RadTestForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadTestForm";
            this.ThemeName = "FluentDark";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctlRightSidePanelBookMarkTags ctlRightSidePanelBookMarkTags1;
        private Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme1;
        private Controls.ctlRightAddTagsCategoryNotes ctlRightAddTagsCategoryNotes1;
    }
}
