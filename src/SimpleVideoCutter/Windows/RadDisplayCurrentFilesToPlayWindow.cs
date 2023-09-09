using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
namespace SimpleVideoCutter.Windows
{
    public partial class RadDisplayCurrentFilesToPlayWindow : Telerik.WinControls.UI.RadForm
    {
       
        public string videoDirectory { get; set; }
        private string videoFileName;
        //private string fullVideoPath;
        public RadDisplayCurrentFilesToPlayWindow(IList<string> list, string videoDirectorya) //propery in mainform set when videochange event is fired
        {
            videoDirectory = videoDirectorya;
            if (videoDirectory == null)
            {
                MessageBox.Show("param null");
            }
            InitializeComponent();
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

        private void radBtnGenerateCollage_Click(object sender, EventArgs e)
        {
            var collage = new Util.tile(Path.Combine(videoDirectory,videoFileName));

            collage.CallbackEvent += CallbackHandler;

            collage.fullpath = Path.Combine(videoDirectory, videoFileName);
            //Image.FromFile
            
            var img = collage.ConvertButton_Click(Path.Combine(videoDirectory, videoFileName));
           
            //if (File.Exists(img))
            //{
            //    this.radPicBoxGeneratedCollage.Image = Image.FromFile(img);
            //}
            //else
            //{
            //    MessageBox.Show("image not done");
            //}
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


        private void CallbackHandler(string message)
    {
        Console.WriteLine($"Received callback: {message}");
            if (File.Exists(message))
            {
                this.radPicBoxGeneratedCollage.Image = Image.FromFile(message);
            }
            else
            {
                MessageBox.Show("image not done");
            }

            // Do something with the callback result
        }
  }

    //
}

