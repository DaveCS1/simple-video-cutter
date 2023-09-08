using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
            //string inputFilePath = @"C:\path\to\input.mp4";

            //// Output video file path
            //string outputFilePath = @"C:\path\to\output.mp4";
            if (File.Exists(testOutput))
            {
                File.Delete(testOutput);
            }

            //https://stackoverflow.com/questions/58188556/what-is-select-notmodn-500-doing-in-ffmpeg

            /*1

 In select=not(mod(n\,500)),

 select invokes the select video filter, which sends forward a frame if expression evaluates to non-zero, else discards it.

 mod(var,X) returns the modulus (remainder after division) of dividing var by X. In mod(n,500), n is the current frame's index, starting from zero, so this expression will evaluate to 0, 1, 2 ... 498, 499, 0, 1, 2, ... 498, 499, 0, 1, 2... for increasing n.

 not(expr) inverts the value of the expression contained inside the brackets - 0 if expr is non-zero and 1 if expr evaluates to zero. */


            string ffmpegCommand = $" -loglevel panic -y -i \"{testMediaPath}\" -frames 1 -q:v 1 -vf \"select=not(mod(n\\,100)),scale=220:160,tile=4x4\"  \"{testOutput}\"";

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
