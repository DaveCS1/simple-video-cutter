using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.DAL
{
    public class AddTags
    {
        public List<Tag> tagsList()

        {
            using (SQLiteConnection cn = new SQLiteConnection("Data Source=" + VideoCutterSettings.DatabasePath + "; Version=3"))
            {

                cn.Open();
                var cmd = new SQLiteCommand(cn);

                cmd.CommandText = "Select * From Tags";

                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        var list = new List<Tag>();

                        while (rdr.Read())
                        {
                            if (!rdr.IsDBNull(1))
                            {
                                list.Add(new Tag
                                {
                                    Id = rdr.GetInt32(0),
                                    TagValue = rdr.GetString(1)

                                });

                            }

                        }

                        return list;

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message + ex.StackTrace);
                        return null;
                    }


                }

            }

        }
        public class Tag
        {
            public Tag()
            {

            }
            public int Id { get; set; }
            public string TagValue { get; set; }
        }
    }
    public class FileInformation
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public long FileSize { get; set; }
}

public class DatabaseManager
{
    private readonly string connectionString;
    public delegate void DatabaseOperationCompletedDelegate(bool success);
    public event DatabaseOperationCompletedDelegate DatabaseOperationCompleted;

    public DatabaseManager(string dbFilePath)
    {
        connectionString = $"Data Source={dbFilePath};Version=3;";
    }

    public async Task InsertFileAsync(FileInformation file)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            await connection.OpenAsync();

            using (SQLiteTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    string insertQuery = "INSERT INTO Files (FileName, FileSize) VALUES (@FileName, @FileSize);";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@FileName", file.FileName);
                        command.Parameters.AddWithValue("@FileSize", file.FileSize);

                        await command.ExecuteNonQueryAsync();
                    }

                    transaction.Commit();
                    OnDatabaseOperationCompleted(true);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    OnDatabaseOperationCompleted(false);
                    Console.WriteLine($"Error inserting file: {ex.Message}");
                }
            }
        }
    }

    protected virtual void OnDatabaseOperationCompleted(bool success)
    {
        DatabaseOperationCompleted?.Invoke(success);
    }
  }
    public class Test
{
    public void OnDatabaseOperationCompleted(bool success)
    {
        if (success)
        {
            Console.WriteLine("File information inserted successfully.");
        }
        else
        {
            Console.WriteLine("File information insertion failed.");
        }
        }





///////////
  static async Task CallerWasMain()
    {
        string dbFilePath = "sample.db"; // Specify your database file path
        string filePath = "sample.txt"; // Specify the file you want to insert
        FileInformation fileInfo = new FileInformation
        {
            FileName = Path.GetFileName(filePath),
            FileSize = new FileInfo(filePath).Length
        };

        var dbManager = new DatabaseManager(dbFilePath);
        var testClass = new Test();

        // Subscribe to the event
        dbManager.DatabaseOperationCompleted += testClass.OnDatabaseOperationCompleted;

        // Insert the file information into the database
        await dbManager.InsertFileAsync(fileInfo);
    }
    //////////



























}

  
}

