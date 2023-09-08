using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace SimpleVideoCutter.TempControlTest
{
    public partial class FormCollage : Telerik.WinControls.UI.RadForm
    {
        private VideoView videoView1;
        private VideoView videoView2;
        private PictureBox collagePictureBox;
        private Button createCollageButton;
        public FormCollage()
        {
            InitializeComponent();
            Core.Initialize();
            videoView1 = new VideoView();
            videoView2 = new VideoView();
            collagePictureBox = new PictureBox();
            createCollageButton = new Button();

            InitializeComponents();
        }
       public string testMediaPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\testmedia\\test.mp4";
        public string testOutput { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\testmedia\\out.jpg";
        public string medaia2 { get; set; } = @"C:\Users\davec\Videos\undisputed disconnect.mp4";
        private void InitializeComponents()
        {
            var args = new List<string>(new string[] {
                "--play-and-pause",
                "--no-sub-autodetect-file",
            });
           var libVLC = new LibVLC(args.ToArray());
            // libVLC = new LibVLC(args.ToArray());

            //vlcControl1.MediaPlayer = new MediaPlayer(libVLC);
            //videoViewHover.MediaPlayer = new MediaPlayer(libVLC);
            // Set up the video views
        
        videoView1.MediaPlayer = new MediaPlayer(new Media(libVLC, testMediaPath));
            videoView2.MediaPlayer = new MediaPlayer(new Media(libVLC, medaia2));

            // Set the size and location of the video views
            videoView1.Size = new Size(320, 240);
            videoView2.Size = new Size(320, 240);
            videoView1.Location = new Point(10, 10);
            videoView2.Location = new Point(340, 10);

            // Set up the collage PictureBox
            collagePictureBox.Size = new Size(660, 240);
            collagePictureBox.Location = new Point(10, 260);

            // Set up the create collage button
            createCollageButton.Text = "Create Collage";
            createCollageButton.Size = new Size(100, 30);
            createCollageButton.Location = new Point(10, 520);
            createCollageButton.Click += CreateCollageButton_Click;

            // Add controls to the form
            Controls.Add(videoView1);
            Controls.Add(videoView2);
            Controls.Add(collagePictureBox);
            Controls.Add(createCollageButton);
        }

        private void CreateCollageButton_Click(object sender, EventArgs e)
        {
            // Capture frames from the video views
            
            var frame1 = videoView1.GetCurrentVideoFrame();
            var frame2 = videoView2.GetCurrentVideoFrame();

            // Create a collage by arranging frames side by side
            int collageWidth = frame1.Width + frame2.Width;
            int collageHeight = Math.Max(frame1.Height, frame2.Height);
            Bitmap collage = new Bitmap(collageWidth, collageHeight);

            using (Graphics g = Graphics.FromImage(collage))
            {
                g.DrawImage(frame1, 0, 0);
                g.DrawImage(frame2, frame1.Width, 0);
            }

            // Display the collage in the PictureBox
            collagePictureBox.Image = collage;
        }


        ///
    }
}
