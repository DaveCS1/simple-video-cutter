namespace SimpleVideoCutter.Windows
{
    partial class RadDisplayCurrentFilesToPlayWindow
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
            this.radChkedLbox = new Telerik.WinControls.UI.RadCheckedListBox();
            this.radLblVideosToViewCurrentlyCount = new Telerik.WinControls.UI.RadLabel();
            this.radListControl1 = new Telerik.WinControls.UI.RadListControl();
            ((System.ComponentModel.ISupportInitialize)(this.radChkedLbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLblVideosToViewCurrentlyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radChkedLbox
            // 
            this.radChkedLbox.AutoScroll = true;
            this.radChkedLbox.GroupItemSize = new System.Drawing.Size(200, 28);
            this.radChkedLbox.ItemSize = new System.Drawing.Size(200, 28);
            this.radChkedLbox.Location = new System.Drawing.Point(12, 40);
            this.radChkedLbox.Name = "radChkedLbox";
            this.radChkedLbox.SelectLastAddedItem = false;
            this.radChkedLbox.Size = new System.Drawing.Size(802, 93);
            this.radChkedLbox.TabIndex = 0;
            this.radChkedLbox.ThemeName = "FluentDark";
            // 
            // radLblVideosToViewCurrentlyCount
            // 
            this.radLblVideosToViewCurrentlyCount.Location = new System.Drawing.Point(22, 13);
            this.radLblVideosToViewCurrentlyCount.Name = "radLblVideosToViewCurrentlyCount";
            this.radLblVideosToViewCurrentlyCount.Size = new System.Drawing.Size(55, 18);
            this.radLblVideosToViewCurrentlyCount.TabIndex = 1;
            this.radLblVideosToViewCurrentlyCount.Text = "radLabel1";
            this.radLblVideosToViewCurrentlyCount.ThemeName = "FluentDark";
            // 
            // radListControl1
            // 
            this.radListControl1.ItemHeight = 24;
            this.radListControl1.Location = new System.Drawing.Point(22, 154);
            this.radListControl1.Name = "radListControl1";
            this.radListControl1.Size = new System.Drawing.Size(772, 345);
            this.radListControl1.TabIndex = 2;
            this.radListControl1.ThemeName = "FluentDark";
            // 
            // RadDisplayCurrentFilesToPlayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 530);
            this.Controls.Add(this.radListControl1);
            this.Controls.Add(this.radLblVideosToViewCurrentlyCount);
            this.Controls.Add(this.radChkedLbox);
            this.Name = "RadDisplayCurrentFilesToPlayWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RadDisplayCurrentFilesToPlayWindow";
            this.ThemeName = "FluentDark";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.radChkedLbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLblVideosToViewCurrentlyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme1;
        private Telerik.WinControls.UI.RadCheckedListBox radChkedLbox;
        private Telerik.WinControls.UI.RadLabel radLblVideosToViewCurrentlyCount;
        private Telerik.WinControls.UI.RadListControl radListControl1;
    }
}
