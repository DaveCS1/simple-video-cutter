using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
namespace SimpleVideoCutter.DAL
{
    public class ManageTags
    {
    }


   public class Tag
    {
        public int Id { get; set; }
        public string TagValue { get; set; }
    }

   public class DatabaseHelper
    {
        private readonly IDbConnection dbConnection;

        public DatabaseHelper(string connectionString)
        {
            dbConnection = new SQLiteConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            if (dbConnection.State != ConnectionState.Open)
                dbConnection.Open();
            return dbConnection;
        }
    }
   
   public class AdoNetCRUDSample
    {
        private readonly DatabaseHelper db;

        public AdoNetCRUDSample()
        {
            db = new DatabaseHelper($"Data Source={VideoCutterSettings.DatabasePath};Version=3;");
        }

        public void CreateTag(Tag tag)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Tags (TagValue) VALUES (@TagValue)";
                        command.Parameters.Add(new SQLiteParameter("@TagValue", tag.TagValue));
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tag created successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating tag: {ex.Message}");
                }
            }
        }

        public Tag GetTag(int id)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM Tags WHERE Id = @Id";
                        command.Parameters.Add(new SQLiteParameter( "@Id", id));

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Tag
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    TagValue = reader["TagValue"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting tag: {ex.Message}");
                }
            }

            return null;
        }

        public void UpdateTag(Tag tag)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Tags SET TagValue = @TagValue WHERE Id = @Id";
                        command.Parameters.Add(new SQLiteParameter("@Id", tag.Id));
                        command.Parameters.Add(new SQLiteParameter("@TagValue", tag.TagValue));
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tag updated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating tag: {ex.Message}");
                }
            }
        }

        public void DeleteTag(int id)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Tags WHERE Id = @Id";
                        command.Parameters.Add(new SQLiteParameter("@Id", id));
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tag deleted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting tag: {ex.Message}");
                }
            }
        }
    }

    class Program
    {
        static void boby()
        {
            // Provide the path to your SQLite database file
            //string dbFilePath = "YourDatabase.db";
            AdoNetCRUDSample adoNetCrud = new AdoNetCRUDSample();

            // Create a tag
            adoNetCrud.CreateTag(new Tag { TagValue = "ExampleTag" });

            // Read a tag
            var tag = adoNetCrud.GetTag(1);
            if (tag != null)
            {
                Console.WriteLine($"Tag: ID={tag.Id}, TagValue={tag.TagValue}");
            }

            // Update a tag
            tag.TagValue = "UpdatedTag";
            adoNetCrud.UpdateTag(tag);

            // Delete a tag
            adoNetCrud.DeleteTag(1);
        }

        ///list of tags
        ///

        static void AddTagList(List<string> tagValues1)
        {
            // Provide the path to your SQLite database file
            string dbFilePath = "YourDatabase.db";

            // List of strings to insert
            List<string> tagValues = new List<string>
        {
            "Tag1",
            "Tag2",
            "Tag3"
        };

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();

                foreach (string tagValue in tagValues)
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO YourTable (TagValue) VALUES (@TagValue)";
                        command.Parameters.AddWithValue("@TagValue", tagValue);

                        try
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine($"Inserted tag: {tagValue}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inserting tag: {ex.Message}");
                        }
                    }
                }

                connection.Close();
            }
        }

        //
    }
  
}
