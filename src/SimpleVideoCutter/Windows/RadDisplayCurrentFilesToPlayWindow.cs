using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using Telerik.WinControls.UI;

namespace SimpleVideoCutter.Windows
{
    public partial class RadDisplayCurrentFilesToPlayWindow : Telerik.WinControls.UI.RadForm
    {
       //TODO REFACTOR everything here
        public string videoDirectory { get; set; }
        private string videoFileName;
        //private string fullVideoPath;
        public RadDisplayCurrentFilesToPlayWindow(IList<string> list, string videoDirectorya) //propery in mainform set when videochange event is fired
        {
           

           
            InitializeComponent();

 videoDirectory = videoDirectorya;
            if (videoDirectory == null)
            {
                MessageBox.Show("no video directory selected");
            }

            radListControl1.DataSource = list;
            //this.radLblVideosToViewCurrentlyCount.Text = String.Format("Number Of Videos In Directory  {0}", list.Count);
            this.radPageViewPage1.Title= String.Format("Number Of Videos In Directory  {0}", list.Count);
            this.radPageViewPage2.Enabled = false;
            this.Text = "Files Being Viewed In Main Editor - " + videoDirectory;
        }

        private void radListControl1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //Util.tile tile = new Util.tile(inputVideoFullPath);


           radPageViewPage2.Enabled = false;


            if (((Telerik.WinControls.UI.RadListElement)sender).SelectedValue !=null)
            {
                var selectedVideo=  ((Telerik.WinControls.UI.RadListElement)sender).SelectedValue;
                var fullPath = videoDirectory + selectedVideo;
                videoFileName = ((Telerik.WinControls.UI.RadListElement)sender).SelectedValue.ToString();
            }
       
        }

        private async void radBtnGenerateCollage_Click(object sender, EventArgs e)
        {
            try
            {
              var collageImage = Path.GetFileNameWithoutExtension(Path.Combine(videoDirectory, videoFileName)) + ".jpg";
                if (File.Exists(collageImage))
                {
                    
                    this.radPicBoxGeneratedCollage.Image = Image.FromFile(collageImage);
                    radPageView.SelectedPage = radPageViewPage2;
                    this.radPageViewPage2.Enabled = true;
                    return;
                }
                radWaitingBar1.InvokeIfRequired(() =>
                {
                    radWaitingBar1.Visible = true;
                    radWaitingBar1.StartWaiting();
                });
                var collage = new Util.tile(Path.Combine(videoDirectory, videoFileName));

                collage.CallbackEvent += CallbackHandler;

                collage.fullpath = Path.Combine(videoDirectory, videoFileName);
                //Image.FromFile

                await collage.ConvertButton_Click(Path.Combine(videoDirectory, videoFileName));

                //if (File.Exists(img))
                //{
                //    this.radPicBoxGeneratedCollage.Image = Image.FromFile(img);
                //}
                //else
                //{
                //    MessageBox.Show("image not done");
                //}
            }
            catch (Exception ex)
            {
                this.radWaitingBar1.StopWaiting();
                this.radWaitingBar1.Visible = false;
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

        }
        public string MyProperty { get; set; }
        //Receiver receiver = new Receiver();

        // Subscribe to the callback event
        //receiver.CallbackEvent += CallbackHandler;

        // Call the function in Receiver
        //receiver.PerformAction();

        // You can do other work here while waiting for the callback
        //Console.WriteLine("Doing some other work...");

        // You can wait for the callback using a signal or other mechanisms

        private void waitingbar()
        {
            RadWaitingBar radWaitingBar = new RadWaitingBar();
            radWaitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Dash;
            radWaitingBar.WaitingDirection = ProgressOrientation.Left;
            this.Controls.Add(radWaitingBar);
        }





        private void CallbackHandler(string message)
    {
            this.radWaitingBar1.StopWaiting();
            this.radWaitingBar1.Visible = false;
            Console.WriteLine($"Received callback: {message}");
            if (File.Exists(message))
            {
                this.radPicBoxGeneratedCollage.Image = Image.FromFile(message);
                radPageView.SelectedPage= radPageViewPage2;
                this.radPageViewPage2.Enabled = true;
            }
            else
            {
                MessageBox.Show("image not done");
            }

            // Do something with the callback result
        }

        private void RadDisplayCurrentFilesToPlayWindow_Load(object sender, EventArgs e)
        {
            this.radWaitingBar1.Visible = false;
             this.radWaitingBar1.StopWaiting();
        }

        private void radBtnCollageZoomIn_Click(object sender, EventArgs e)
        {
            this.radPicBoxGeneratedCollage.ZoomProperties.ZoomIn();
        }

        private void radBtnCollageZoomOut_Click(object sender, EventArgs e)
        {
            this.radPicBoxGeneratedCollage.ZoomProperties.ZoomOut();
        }

        private void radBtnCollageZoomOut_MouseHover(object sender, EventArgs e)
        {
            radLblRightClickForMore.Visible = true;
        }

        private void radBtnCollageZoomIn_MouseHover(object sender, EventArgs e)
        {
            radLblRightClickForMore.Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            radLblRightClickForMore.Visible = false;
        }

        private void RadDisplayCurrentFilesToPlayWindow_SizeChanged(object sender, EventArgs e)
        {
            this.radWaitingBar1.Width = this.Width - 10;
        }

        private void radPicBoxGeneratedCollage_ContextMenuOpening(object sender, CancelEventArgs e)
        {
            this.radPicBoxGeneratedCollage.ContextMenuDropDown.Items.Remove(this.radPicBoxGeneratedCollage.ContextMenuProperties.CutItem);
            this.radPicBoxGeneratedCollage.ContextMenuDropDown.Items.Remove(this.radPicBoxGeneratedCollage.ContextMenuProperties.OpenItem);
            this.radPicBoxGeneratedCollage.ContextMenuDropDown.Items.Remove(this.radPicBoxGeneratedCollage.ContextMenuProperties.RemoveItem);

        }
    }
 }

    //


