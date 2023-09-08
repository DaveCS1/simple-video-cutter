using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter.Util
{
  public  class tile
    {

        public tile()
        {
            ConvertButton_Click();

        }
        public string testMediaPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\testmedia\\test.mp4";
        public string testOutput { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\testmedia\\out.png";
        private void ConvertButton_Click()
        {
            // Input video file path
            string inputFilePath = @"C:\path\to\input.mp4";

            // Output video file path
            string outputFilePath = @"C:\path\to\output.mp4";

            // FFmpeg command
            //  string ffmpegCommand = $"-i \"{inputFilePath}\" \"{outputFilePath}\"";
            //-loglevel panic -y -i \"2.mp4\" -frames 1 -q:v 1 -vf \"select=not(mod(n\\,4)),scale=180:140,tile=6x6\" video_preview1_new9_8a.jpg
            string ffmpegCommand = $" -loglevel panic -y -i \"{testMediaPath}\" -frames 1 -q:v 1 -vf \"select=not(mod(n\\,4)),scale=180:140,tile=6x6\"  \"{testOutput}\"";

            // Create a new process start info
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "c:\\ffmpeg\\ffmpeg.exe", // Replace with the actual path to ffmpeg.exe
                Arguments = ffmpegCommand,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Create and start the process
            Process process = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (s, args) => Console.WriteLine(args.Data);
            process.ErrorDataReceived += (s, args) => Console.WriteLine(args.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            MessageBox.Show("Conversion completed!");
        }
    }
}
