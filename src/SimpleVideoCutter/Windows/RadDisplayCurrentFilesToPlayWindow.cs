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
       
        public string videoDirectory { get; set; }
        private string videoFileName;
        //private string fullVideoPath;
        public RadDisplayCurrentFilesToPlayWindow(IList<string> list, string videoDirectorya) //propery in mainform set when videochange event is fired
        {
           

           
            InitializeComponent();

 videoDirectory = videoDirectorya;
            if (videoDirectory == null)
            {
                MessageBox.Show("param null");
            }

            radListControl1.DataSource = list;
            this.radLblVideosToViewCurrentlyCount.Text = String.Format("Number Of Videos In Directory  {0}", list.Count);
           
        }

        private void radListControl1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //Util.tile tile = new Util.tile(inputVideoFullPath);

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
                //this.radWaitingBar1.Visible = true;
                //this.radWaitingBar1.StartWaiting();

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
                radPageView.SelectedPage = radPageViewPage2;
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
    }

    //
}

