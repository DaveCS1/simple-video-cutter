using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.DAL
{
  public  class ScanComputerForVideosAddToDB
    {
    }
    //
}
//chat gpt
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

public class VideoFileContext : DbContext
{
    public DbSet<VideoFileInfo> VideoFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=videoFiles.db");
}

public class VideoFileInfo
{
    public int Id { get; set; }
    public string FilePath { get; set; }
}

class Program
{
    static async Task Main()
    {
        string startDirectory = "C:\\"; // Starting directory (you can change it)
        List<string> videoExtensions = new List<string>
        {
            ".mp4", ".mkv", ".avi", ".mov", ".wmv", ".flv", ".webm"
        };

        using (var context = new VideoFileContext())
        {
            await context.Database.EnsureCreatedAsync();
            List<VideoFileInfo> videoFiles = new List<VideoFileInfo>();

            await ScanForVideoFilesAsync(startDirectory, videoExtensions, videoFiles);

            context.VideoFiles.AddRange(videoFiles);
            await context.SaveChangesAsync();

            Console.WriteLine("Video files found and stored in the database:");
            foreach (var videoFile in videoFiles)
            {
                Console.WriteLine(videoFile.FilePath);
            }
        }
    }

    static async Task ScanForVideoFilesAsync(string directory, List<string> videoExtensions, List<VideoFileInfo> videoFiles)
    {
        try
        {
            string[] files = await Task.Run(() => Directory.GetFiles(directory));
            foreach (string file in files)
            {
                if (videoExtensions.Contains(Path.GetExtension(file).ToLower()))
                {
                    videoFiles.Add(new VideoFileInfo { FilePath = file });
                }
            }

            string[] subdirectories = await Task.Run(() => Directory.GetDirectories(directory));
            foreach (string subdirectory in subdirectories)
            {
                await ScanForVideoFilesAsync(subdirectory, videoExtensions, videoFiles);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Unauthorized access in directory '{directory}': {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error scanning directory '{directory}': {ex.Message}");
        }
    }
}




//
We create a VideoFileInfo class to represent video file information and a VideoFileContext class for interacting with the SQLite database using Entity Framework Core.

The Main method initializes the database and performs the scan. The results are stored in the database and printed to the console.

The ScanForVideoFilesAsync function scans directories and adds video file information to the videoFiles list. If errors occur during directory traversal, they are caught and displayed, but the scanning continues for other directories.

Make sure to modify the database connection string and adjust the starting directory and video extensions to match your requirements.