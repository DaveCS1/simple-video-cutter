using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.Util
{
  public  class CreateVideoPoster
    {
        //private Bitmap collageImage;

        public CreateVideoPoster()
        {
            //CreateCollage();
            CreateCollageButton_Click();
        }
        public string testMediaPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\testmedia\\test.mp4";
        public string testOutput { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\testmedia\\out.jpg";
        private void CreateCollageButton_Click()
        {
            // Replace with the path to your input video file
            string inputVideoPath = testMediaPath;

            // Replace with the path where you want to save the collage image
            string outputImagePath = testOutput;

            // Command to capture frames from the video
            string ffmpegCommand = $"-i \"{inputVideoPath}\" -vf \"fps=1\" frame%d.png";

            try
            {
                using (Process ffmpegProcess = new Process())
                {
                    ffmpegProcess.StartInfo.FileName = "c:\\ffmpeg\\ffmpeg.exe"; // Replace with the path to your FFmpeg executable
                    ffmpegProcess.StartInfo.Arguments = ffmpegCommand;
                    ffmpegProcess.StartInfo.UseShellExecute = false;
                    ffmpegProcess.StartInfo.RedirectStandardOutput = true;
                    ffmpegProcess.StartInfo.CreateNoWindow = true;

                    ffmpegProcess.Start();
                    ffmpegProcess.WaitForExit();
                }

                // Create the collage by arranging frames
                CollageImages("frame", 4, 4, outputImagePath);

                // Load and display the collage image
                if (File.Exists(outputImagePath))
                {
                    Image collageImage = Image.FromFile(outputImagePath);
                   // pictureBox.Image = collageImage;
                }
            }
            catch (Exception )
            {
                //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to create a collage from images with a specified naming pattern
        private void CollageImages(string imageNamePrefix, int columns, int rows, string outputImagePath)
        {
            int imageWidth = 300 / columns;
            int imageHeight = 300 / rows;
            int totalImages = columns * rows;

            Bitmap collage = new Bitmap(600,600);

            using (Graphics g = Graphics.FromImage(collage))
            {
                g.Clear(Color.White);

                for (int i = 1; i <= totalImages; i++)
                {
                    string imagePath = $"{imageNamePrefix}{i}.png";
                    if (File.Exists(imagePath))
                    {
                        using (Image image = Image.FromFile(imagePath))
                        {
                            int x = ((i - 1) % columns) * imageWidth;
                            int y = ((i - 1) / columns) * imageHeight;
                            g.DrawImage(image, x, y, imageWidth, imageHeight);
                        }
                    }
                }
            }

            collage.Save(outputImagePath, System.Drawing.Imaging.ImageFormat.Png);
        }











        //private void CreateCollage()
        //{
        //    string inputVideoPath = testMediaPath; // Replace with your input video file
        //    string outputImagePath = testOutput; // Output collage image path

        //    // Define the number of frames in the collage (e.g., 4x2 grid)
        //    int rows = 2;
        //    int cols = 4;
        //    int totalFrames = rows * cols;

        //    // Ensure the output image folder exists
        //    string outputFolder = Path.GetDirectoryName(outputImagePath);
        //    if (!Directory.Exists(outputFolder))
        //    {
        //        Directory.CreateDirectory(outputFolder);
        //    }

        //    // Use FFmpeg to extract frames from the video
        //    string ffmpegCommand = $"-i \"{inputVideoPath}\" -vf fps=fps=1/{totalFrames} frame%d.png";

        //    using (Process ffmpegProcess = new Process())
        //    {
        //        ffmpegProcess.StartInfo.FileName = "c:\\ffmpeg\\ffmpeg.exe"; // Replace with the path to your FFmpeg executable
        //        ffmpegProcess.StartInfo.Arguments = ffmpegCommand;
        //        ffmpegProcess.StartInfo.UseShellExecute = false;
        //        ffmpegProcess.StartInfo.RedirectStandardOutput = true;
        //        ffmpegProcess.StartInfo.CreateNoWindow = true;

        //        ffmpegProcess.Start();
        //        ffmpegProcess.WaitForExit();
        //    }

        //    // Create a collage image using System.Drawing
        //    using (Bitmap collageImage = new Bitmap(cols * 160, rows * 90)) // Adjust dimensions as needed
        //    using (Graphics graphics = Graphics.FromImage(collageImage))
        //    {
        //        graphics.Clear(Color.White);

        //        for (int i = 1; i <= totalFrames; i++)
        //        {
        //            string frameImagePath = $"frame{i}.png";
        //            if (File.Exists(frameImagePath))
        //            {
        //                using (Bitmap frame = new Bitmap(frameImagePath))
        //                {
        //                    int x = ((i - 1) % cols) * frame.Width;
        //                    int y = ((i - 1) / cols) * frame.Height;

        //                    graphics.DrawImage(frame, x, y, frame.Width, frame.Height);
        //                }
        //            }
        //        }
        //        // Save the collage image
        //        collageImage.Save(outputImagePath, ImageFormat.Jpeg);

        //    }

        //    // Save the collage image
        //    //collageImage.Save(outputImagePath, ImageFormat.Jpeg);

        //    // Clean up temporary frame images
        //    for (int i = 1; i <= totalFrames; i++)
        //    {
        //        string frameImagePath = $"frame{i}.png";
        //        if (File.Exists(frameImagePath))
        //        {
        //            File.Delete(frameImagePath);
        //        }
        //    }
        //    Process.Start(outputImagePath);
        //    //MessageBox.Show("Collage created and saved!");
        //}
    }
}
//    }
//}


