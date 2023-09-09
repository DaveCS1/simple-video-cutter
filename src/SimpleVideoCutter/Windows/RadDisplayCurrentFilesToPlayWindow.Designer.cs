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
            this.radLblVideosToViewCurrentlyCount = new Telerik.WinControls.UI.RadLabel();
            this.radPageView = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radListControl1 = new Telerik.WinControls.UI.RadListControl();
            this.radChkedLbox = new Telerik.WinControls.UI.RadCheckedListBox();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPicBoxGeneratedCollage = new Telerik.WinControls.UI.RadPictureBox();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radBtnGenerateCollage = new Telerik.WinControls.UI.RadButton();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.radLblVideosToViewCurrentlyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).BeginInit();
            this.radPageView.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChkedLbox)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPicBoxGeneratedCollage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnGenerateCollage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            // radPageView
            // 
            this.radPageView.Controls.Add(this.radPageViewPage1);
            this.radPageView.Controls.Add(this.radPageViewPage2);
            this.radPageView.Controls.Add(this.radPageViewPage3);
            this.radPageView.Location = new System.Drawing.Point(2, 37);
            this.radPageView.Name = "radPageView";
            this.radPageView.SelectedPage = this.radPageViewPage1;
            this.radPageView.Size = new System.Drawing.Size(837, 491);
            this.radPageView.TabIndex = 3;
            this.radPageView.ThemeName = "FluentDark";
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.radWaitingBar1);
            this.radPageViewPage1.Controls.Add(this.radListControl1);
            this.radPageViewPage1.Controls.Add(this.radChkedLbox);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(119F, 29F);
            this.radPageViewPage1.Location = new System.Drawing.Point(6, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(825, 449);
            this.radPageViewPage1.Text = "radPageViewPage1";
            // 
            // radListControl1
            // 
            this.radListControl1.ItemHeight = 24;
            this.radListControl1.Location = new System.Drawing.Point(0, 45);
            this.radListControl1.Name = "radListControl1";
            this.radListControl1.Size = new System.Drawing.Size(821, 400);
            this.radListControl1.TabIndex = 7;
            this.radListControl1.ThemeName = "FluentDark";
            this.radListControl1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radListControl1_SelectedIndexChanged);
            // 
            // radChkedLbox
            // 
            this.radChkedLbox.AutoScroll = true;
            this.radChkedLbox.GroupItemSize = new System.Drawing.Size(200, 28);
            this.radChkedLbox.ItemSize = new System.Drawing.Size(200, 28);
            this.radChkedLbox.Location = new System.Drawing.Point(-6, 3);
            this.radChkedLbox.Name = "radChkedLbox";
            this.radChkedLbox.SelectLastAddedItem = false;
            this.radChkedLbox.Size = new System.Drawing.Size(827, 36);
            this.radChkedLbox.TabIndex = 6;
            this.radChkedLbox.ThemeName = "FluentDark";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.radPicBoxGeneratedCollage);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(119F, 29F);
            this.radPageViewPage2.Location = new System.Drawing.Point(6, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(825, 449);
            this.radPageViewPage2.Text = "radPageViewPage2";
            // 
            // radPicBoxGeneratedCollage
            // 
            this.radPicBoxGeneratedCollage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPicBoxGeneratedCollage.Location = new System.Drawing.Point(0, 0);
            this.radPicBoxGeneratedCollage.Name = "radPicBoxGeneratedCollage";
            this.radPicBoxGeneratedCollage.Size = new System.Drawing.Size(825, 449);
            this.radPicBoxGeneratedCollage.SvgImageXml = null;
            this.radPicBoxGeneratedCollage.TabIndex = 0;
            this.radPicBoxGeneratedCollage.ThemeName = "FluentDark";
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.ItemSize = new System.Drawing.SizeF(119F, 29F);
            this.radPageViewPage3.Location = new System.Drawing.Point(6, 36);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(825, 449);
            this.radPageViewPage3.Text = "radPageViewPage3";
            // 
            // radBtnGenerateCollage
            // 
            this.radBtnGenerateCollage.Location = new System.Drawing.Point(665, 1);
            this.radBtnGenerateCollage.Name = "radBtnGenerateCollage";
            this.radBtnGenerateCollage.Size = new System.Drawing.Size(137, 30);
            this.radBtnGenerateCollage.TabIndex = 4;
            this.radBtnGenerateCollage.Text = "Video Poster";
            this.radBtnGenerateCollage.ThemeName = "FluentDark";
            this.radBtnGenerateCollage.Click += new System.EventHandler(this.radBtnGenerateCollage_Click);
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Location = new System.Drawing.Point(0, 0);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(837, 449);
            this.radWaitingBar1.TabIndex = 0;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.ThemeName = "FluentDark";
            this.radWaitingBar1.WaitingIndicators.Add(this.dotsRingWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.radWaitingBar1.WaitingSpeed = 50;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing;
            // 
            // dotsRingWaitingBarIndicatorElement1
            // 
            this.dotsRingWaitingBarIndicatorElement1.Name = "dotsRingWaitingBarIndicatorElement1";
            // 
            // RadDisplayCurrentFilesToPlayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 530);
            this.Controls.Add(this.radBtnGenerateCollage);
            this.Controls.Add(this.radPageView);
            this.Controls.Add(this.radLblVideosToViewCurrentlyCount);
            this.Name = "RadDisplayCurrentFilesToPlayWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RadDisplayCurrentFilesToPlayWindow";
            this.ThemeName = "FluentDark";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RadDisplayCurrentFilesToPlayWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLblVideosToViewCurrentlyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).EndInit();
            this.radPageView.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChkedLbox)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPicBoxGeneratedCollage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnGenerateCollage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme1;
        private Telerik.WinControls.UI.RadLabel radLblVideosToViewCurrentlyCount;
        private Telerik.WinControls.UI.RadPageView radPageView;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadListControl radListControl1;
        private Telerik.WinControls.UI.RadCheckedListBox radChkedLbox;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPictureBox radPicBoxGeneratedCollage;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadButton radBtnGenerateCollage;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement1;
    }
}
