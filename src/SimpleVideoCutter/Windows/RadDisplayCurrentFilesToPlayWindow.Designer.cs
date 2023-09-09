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
            this.radPageView = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            this.radListControl1 = new Telerik.WinControls.UI.RadListControl();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radBtnGenerateCollage = new Telerik.WinControls.UI.RadButton();
            this.radPicBoxGeneratedCollage = new Telerik.WinControls.UI.RadPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radBtnCollageZoomOut = new Telerik.WinControls.UI.RadButton();
            this.radBtnCollageZoomIn = new Telerik.WinControls.UI.RadButton();
            this.radLblRightClickForMore = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).BeginInit();
            this.radPageView.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnGenerateCollage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPicBoxGeneratedCollage)).BeginInit();
            this.radPicBoxGeneratedCollage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCollageZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCollageZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLblRightClickForMore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView
            // 
            this.radPageView.Controls.Add(this.radPageViewPage1);
            this.radPageView.Controls.Add(this.radPageViewPage2);
            this.radPageView.Controls.Add(this.radPageViewPage3);
            this.radPageView.DefaultPage = this.radPageViewPage1;
            this.radPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView.Location = new System.Drawing.Point(0, 0);
            this.radPageView.Name = "radPageView";
            this.radPageView.SelectedPage = this.radPageViewPage2;
            this.radPageView.Size = new System.Drawing.Size(892, 617);
            this.radPageView.TabIndex = 3;
            this.radPageView.ThemeName = "FluentDark";
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.radWaitingBar1);
            this.radPageViewPage1.Controls.Add(this.radListControl1);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(75F, 29F);
            this.radPageViewPage1.Location = new System.Drawing.Point(6, 36);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(880, 575);
            this.radPageViewPage1.Text = "Files In Use";
            this.radPageViewPage1.ToolTipText = "Files you are viewing in the main video cutter screen";
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
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // dotsRingWaitingBarIndicatorElement1
            // 
            this.dotsRingWaitingBarIndicatorElement1.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dotsRingWaitingBarIndicatorElement1.Name = "dotsRingWaitingBarIndicatorElement1";
            this.dotsRingWaitingBarIndicatorElement1.Text = "Creating Video Poster...";
            // 
            // radListControl1
            // 
            this.radListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radListControl1.ItemHeight = 24;
            this.radListControl1.Location = new System.Drawing.Point(0, 0);
            this.radListControl1.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.radListControl1.Name = "radListControl1";
            this.radListControl1.Size = new System.Drawing.Size(880, 575);
            this.radListControl1.TabIndex = 7;
            this.radListControl1.ThemeName = "FluentDark";
            this.radListControl1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radListControl1_SelectedIndexChanged);
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.radPicBoxGeneratedCollage);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(84F, 29F);
            this.radPageViewPage2.Location = new System.Drawing.Point(6, 36);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(880, 575);
            this.radPageViewPage2.Text = "Video Poster";
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
            this.radBtnGenerateCollage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnGenerateCollage.Image = global::SimpleVideoCutter.VideoControlIcons24.Card_Image;
            this.radBtnGenerateCollage.Location = new System.Drawing.Point(692, 1);
            this.radBtnGenerateCollage.Name = "radBtnGenerateCollage";
            this.radBtnGenerateCollage.Size = new System.Drawing.Size(137, 30);
            this.radBtnGenerateCollage.TabIndex = 4;
            this.radBtnGenerateCollage.Text = "Video Poster";
            this.radBtnGenerateCollage.ThemeName = "FluentDark";
            this.radBtnGenerateCollage.Click += new System.EventHandler(this.radBtnGenerateCollage_Click);
            // 
            // radPicBoxGeneratedCollage
            // 
            this.radPicBoxGeneratedCollage.Controls.Add(this.panel1);
            this.radPicBoxGeneratedCollage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPicBoxGeneratedCollage.Location = new System.Drawing.Point(0, 0);
            this.radPicBoxGeneratedCollage.Name = "radPicBoxGeneratedCollage";
            this.radPicBoxGeneratedCollage.Size = new System.Drawing.Size(880, 575);
            this.radPicBoxGeneratedCollage.SvgImageXml = null;
            this.radPicBoxGeneratedCollage.TabIndex = 0;
            this.radPicBoxGeneratedCollage.ThemeName = "FluentDark";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.radLblRightClickForMore);
            this.panel1.Controls.Add(this.radBtnCollageZoomOut);
            this.panel1.Controls.Add(this.radBtnCollageZoomIn);
            this.panel1.Location = new System.Drawing.Point(610, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 39);
            this.panel1.TabIndex = 0;
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // radBtnCollageZoomOut
            // 
            this.radBtnCollageZoomOut.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.radBtnCollageZoomOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.radBtnCollageZoomOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnCollageZoomOut.Location = new System.Drawing.Point(188, 0);
            this.radBtnCollageZoomOut.Name = "radBtnCollageZoomOut";
            this.radBtnCollageZoomOut.Size = new System.Drawing.Size(38, 39);
            this.radBtnCollageZoomOut.TabIndex = 1;
            this.radBtnCollageZoomOut.Text = "-";
            this.radBtnCollageZoomOut.ThemeName = "FluentDark";
            this.radBtnCollageZoomOut.Click += new System.EventHandler(this.radBtnCollageZoomOut_Click);
            this.radBtnCollageZoomOut.MouseHover += new System.EventHandler(this.radBtnCollageZoomOut_MouseHover);
            // 
            // radBtnCollageZoomIn
            // 
            this.radBtnCollageZoomIn.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.radBtnCollageZoomIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.radBtnCollageZoomIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnCollageZoomIn.Location = new System.Drawing.Point(226, 0);
            this.radBtnCollageZoomIn.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.radBtnCollageZoomIn.Name = "radBtnCollageZoomIn";
            this.radBtnCollageZoomIn.Size = new System.Drawing.Size(38, 39);
            this.radBtnCollageZoomIn.TabIndex = 2;
            this.radBtnCollageZoomIn.Text = "+";
            this.radBtnCollageZoomIn.ThemeName = "FluentDark";
            this.radBtnCollageZoomIn.Click += new System.EventHandler(this.radBtnCollageZoomIn_Click);
            this.radBtnCollageZoomIn.MouseHover += new System.EventHandler(this.radBtnCollageZoomIn_MouseHover);
            // 
            // radLblRightClickForMore
            // 
            this.radLblRightClickForMore.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLblRightClickForMore.Location = new System.Drawing.Point(20, 10);
            this.radLblRightClickForMore.Name = "radLblRightClickForMore";
            this.radLblRightClickForMore.Size = new System.Drawing.Size(162, 16);
            this.radLblRightClickForMore.TabIndex = 3;
            this.radLblRightClickForMore.Text = "Right Click Image For More Options";
            this.radLblRightClickForMore.ThemeName = "FluentDark";
            this.radLblRightClickForMore.Visible = false;
            // 
            // RadDisplayCurrentFilesToPlayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 617);
            this.Controls.Add(this.radBtnGenerateCollage);
            this.Controls.Add(this.radPageView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RadDisplayCurrentFilesToPlayWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "FluentDark";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RadDisplayCurrentFilesToPlayWindow_Load);
            this.SizeChanged += new System.EventHandler(this.RadDisplayCurrentFilesToPlayWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView)).EndInit();
            this.radPageView.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnGenerateCollage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPicBoxGeneratedCollage)).EndInit();
            this.radPicBoxGeneratedCollage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCollageZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCollageZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLblRightClickForMore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme1;
        private Telerik.WinControls.UI.RadPageView radPageView;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadListControl radListControl1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPictureBox radPicBoxGeneratedCollage;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadButton radBtnGenerateCollage;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton radBtnCollageZoomOut;
        private Telerik.WinControls.UI.RadButton radBtnCollageZoomIn;
        private Telerik.WinControls.UI.RadLabel radLblRightClickForMore;
    }
}
