using LibVLCSharp.Shared;
using SimpleVideoCutter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
//using TempControlTest;
namespace SimpleVideoCutter.TelerikForms
{
    public partial class RadMainForm : Telerik.WinControls.UI.RadForm
    {
        public RadMainForm()
        {
            InitializeComponent();
            TempControlTest.frmVideoTrimControls frmVideoTrimControls = new TempControlTest.frmVideoTrimControls();
            frmVideoTrimControls.Show();
       //frmVideoControls frmVideoControls = new frmVideoControls();
        }

        private void RadMainForm_Load(object sender, EventArgs e)
        {
            //radCommandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;


            InitVLC(); //initialize vlc and related controls
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            //string fileToLoadOnStartup = null;
            //string svcFolder = "SimpleVideoCutter";
            //string configFolder = Path.Combine(
            //    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), svcFolder);
            //var t = new SimpleVideoCutter.MainForm( fileToLoadOnStartup , configFolder);
            //t.Show();
            //MainForm mainForm = new MainForm(string fileToLoadOnStartup, string configFolder);
            //mainForm.Show();
        }


        //trim videos tab
        private void commandBarButton2_Click(object sender, EventArgs e)
        {
            radPageView1.SelectedPage = radPageViewPageTrimVideos;

           
        }
        public List<string> FullVideoPaths { get; set; } = new List<string>();
        private void radButton2_Click(object sender, EventArgs e)
        {
            FullVideoPaths.Clear();
            this.radOpenFolderDialogSelectVideos.OpenFolderDialogForm.ThemeName = "FluentDark";
            this.radOpenFolderDialogSelectVideos.MultiSelect = true;
            this.radOpenFolderDialogSelectVideos.ShowDialog(this);


            var x1 = radOpenFolderDialogSelectVideos.OpenFolderDialogForm.FileNames;
            var s = radOpenFolderDialogSelectVideos.FileName;
            var t = radOpenFolderDialogSelectVideos.FileNames;
            var cnt = t.Count();
            if (cnt > 0)
            {
                foreach (var item in radOpenFolderDialogSelectVideos.FileNames)
                {//todo use global settings for video extentions
                    string[] files = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories).Where(file => new string[] { ".avi", ".flv", ".mp4", ".mpg", ".mov" }.Contains(Path.GetExtension(file))).ToArray();
                    Array.Sort(files, (x, y) => DateTime.Compare(new FileInfo(x).LastWriteTime, new FileInfo(y).LastWriteTime));
                    FullVideoPaths.AddRange(files);
                }

            }
            Console.WriteLine(FullVideoPaths.Count);
            this.radCheckedListBox1.DataSource = FullVideoPaths;

        }

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {
            //radMenu1.BackColor = radPageViewPageAddFiles.BackColor;

            //RadMenuContentItem textBoxContentItem = new RadMenuContentItem();
            //RadTextBoxElement textBox = new RadTextBoxElement();
            //textBox.Text = "Enter text here";
            //textBox.MinSize = new Size(100, 0);
            //textBoxContentItem.ContentElement = textBox;
            //radMenu1.Items.Add(textBoxContentItem);
            //RadMenuContentItem buttonContentItem = new RadMenuContentItem();
            //RadButtonElement button = new RadButtonElement();
            //button.Text = "OK";
            ////button.Click += new EventHandler(button_Click);
            //buttonContentItem.ContentElement = button;
            //radMenu1.Items.Add(buttonContentItem);
        }

        private void radSplitButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
        }

        private void radTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            radPopupEditorVolume.Text= radTrackBar2.Value.ToString();
        }

        private void radPopupContainer2_Click(object sender, EventArgs e)
        {

        }

        private void radPopupContainer3_Click(object sender, EventArgs e)
        {

        }
        //  explorerControl1.ThemeName = "FluentDark";
        //  explorerControl1.MultiSelect = true;

      
        
        

        private void radMenuButtonItem3_Click(object sender, EventArgs e)
        {
            ShowHideProcessing();
        }

        private void ShowHideProcessing()
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                splitContainer1.Panel2Collapsed = false;
            }
            else if (splitContainer1.Panel2Collapsed == false)
            {
                splitContainer1.Panel2Collapsed = true;
            }
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
           
        }
// InitVLC();   //loads VLC assemblies, initializes  and starts up sample video
      
        private void radToggleButton1_ToggleStateChanging(object sender, StateChangingEventArgs args)
        {
            if (!(toggleButtonPlayPause.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On))
            {
                //radToggleButton1.ImageIndex = 4;
                //label1.Text = "Button Toggled On";
            }
            else
            {
                toggleButtonPlayPause.ImageIndex = 3;
                //label1.Text = "Button Toggled Off";
            }
        }

        private void toolStripButtonPlabackPlayPause_Click(object sender, EventArgs e)
        {

        }

        private void toolStripPlayback_Click(object sender, EventArgs e)
        {

        }

      

        private void radMenu1_Click(object sender, EventArgs e)
        {

        }
        #region ButtonClickEvents

        private void commandBarBtnAddVideos_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnMovePreviousVideo_Click(object sender, EventArgs e)
        {
            OpenPrevFileInDirectory();
        }
        #endregion

        private void btnMoveNextVideo_Click(object sender, EventArgs e)
        {
            OpenNextFileInDirectory();
        }

        private void btnCutStart_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
                SetSelectionAtCurrentPositionTillTheEnd();
            else
                SetStartAtCurrentPosition();
        }

        private void btnCutEnd_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
                SetSelectionFromTheBeginningTillCurrentPosition();
            else
                SetEndAtCurrentPosition();
        }

        private void btnPlayRange_Click(object sender, EventArgs e)
        {
            PlaySelection();
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            ClearAllSelections();
        }

        private void btnPerformCut_Click(object sender, EventArgs e)
        {
            EnqeueNewTask();
        }

        private void commandBarBtnSettings_Click(object sender, EventArgs e)
        {
            formSettings.ShowSettingsDialog();
                ResizePreview();
        }

        private void commandBarBtnHelpDemos_Click(object sender, EventArgs e)
        {
            using (var about = new AboutBox())
            {
                about.ShowDialog();
            }
        }

        private void RadMainForm_Shown(object sender, EventArgs e)
        {
            EnsureFFmpegConfigured();

            taskProcessor.Start();
            //EnableButtons();

            if (fileToLoadOnStartup != null)
            {
                OpenFile(fileToLoadOnStartup);
            }
        }

        /// <summary>
        /// Double click timeline at start and end position to set start/end times. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoCutterTimeline1_DoubleClick(object sender, EventArgs e)
        {

            //todo make sure timeline has item, button should be disabled anyway - move to partial
            try
            {
                if (!videoCutterTimeline1.NewSelectionStartRegistered)
                {
                    SetStartAtCurrentPosition();
                }
                else
                {
                    SetEndAtCurrentPosition();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace); //temp
                //todo log any error
            }

        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGoToTrimSelectionStart_Click(object sender, EventArgs e)
        {
            GoToSelectionStart();
        }

        private void btnGoToSelectionEnd_Click(object sender, EventArgs e)
        {
            GoToSelectionEnd();
        }

        private void btnTimeLineZoomOut_Click(object sender, EventArgs e)
        {
            videoCutterTimeline1.ZoomOut();
        }

        private void btnTimeLineZoomAuto_Click(object sender, EventArgs e)
        {           
            videoCutterTimeline1.ZoomAuto();
        }

        private void btnTimeLineCurrent_Click(object sender, EventArgs e)
        {
            videoCutterTimeline1.GoToCurrentPosition();
        }

        private void btnVideoGoForward10Seconds_Click(object sender, EventArgs e)
        {

            //vlcControl1?.MediaPlayer?.SetRate(1.5f);
           // AdjustPlaybackSpeed(vlcControl1?.MediaPlayer, 1.0f); // Normal speed (1x)
            AdjustPlaybackSpeedByIncrement(vlcControl1?.MediaPlayer, vlcControl1.MediaPlayer.Rate);
        }
        #region GeneralVideoPlaybackSpeed
        //static void AdjustPlaybackSpeed(MediaPlayer mediaPlayer, float speedFactor)
        //{
        //    mediaPlayer.SetRate(speedFactor);
        //}
        // Custom function to adjust playback speed of a MediaPlayer instance
        //static  void AdjustPlaybackSpeed(MediaPlayer mediaPlayer, float speedFactor, int test)
        //{
        //    mediaPlayer.SetRate(speedFactor);
        //}

        // Custom function to adjust playback speed in increments of 0.25x with a maximum of 4x
        private void AdjustPlaybackSpeedByIncrement(MediaPlayer mediaPlayer, float speedIncrement)
        {
            // Get the current playback rate
            float currentRate = mediaPlayer.Rate;

            // Calculate the new rate with the increment
            float newRate = currentRate + 0.25f;// speedIncrement;

            // Ensure the new rate is within the allowed range (0.25x to 4x)
            newRate = Math.Max(0.25f, Math.Min(4.0f, newRate));

            // Set the new rate
            mediaPlayer.SetRate(newRate);
        }

        private void toggleButtonPlayPause_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void toggleButtonPlayPause_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (!(toggleButtonPlayPause.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)) //ToggleState.On))
            {
                toggleButtonPlayPause.ImageIndex = 0;
                //label1.Text = "Button Toggled On";
            }
            else
            {
                toggleButtonPlayPause.ImageIndex = 1;
                //label1.Text = "Button Toggled Off";
            }
        }
        #endregion

        //
    }
}
