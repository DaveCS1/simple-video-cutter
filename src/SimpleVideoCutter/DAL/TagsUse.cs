using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;

namespace SimpleVideoCutter.DAL
{
   public class TagsUse
    {
        //start ctor
        public TagsUse()
        {

        }
        //end ctor

        //db = new DatabaseHelper($"Data Source={VideoCutterSettings.DatabasePath};Version=3;");


        public int AddTagListWithAffectedRows(List<string> tagListFromAddTagsTextBox)
        {
            int affectedRows = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        foreach (string tagValue in tagListFromAddTagsTextBox)
                        {
                            using (SQLiteCommand command = connection.CreateCommand())
                            {
                                command.Parameters.AddWithValue("@Tag", tagValue);

                                command.CommandText = "INSERT OR IGNORE INTO Tags (Tag) VALUES (@Tag)";
                                try
                                {
                                    affectedRows += command.ExecuteNonQuery();
                                    Console.WriteLine($"Inserted tag: {tagValue}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error inserting tag: {ex.Message}");
                                }
                            }
                        }

                        transaction.Commit();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return affectedRows;
        }







        /// <summary>
        /// Add Tags accepts list of string
        /// </summary>
        /// <param name="tagListFromAddTagsTextBox"></param>
        public void AddTagList(List<string> tagListFromAddTagsTextBox)
        {
            string dbFilePath = VideoCutterSettings.DatabasePath;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (string tagValue in tagListFromAddTagsTextBox)
                        {
                            using (SQLiteCommand command = connection.CreateCommand())
                            {
                                command.Parameters.AddWithValue("@Tag", tagValue);

                                command.CommandText = "INSERT OR IGNORE INTO Tags (Tag) VALUES (@Tag)";
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

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Transaction failed: {ex.Message}");
                    }
                }

                connection.Close();
            }
        }
       
        /// <summary>
        /// Gets a list of all tags
        /// </summary>
        /// <returns></returns>
        public List<Tag> GetAllTags()
        {
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    cn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Tags", cn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
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
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or return an empty list
                Console.WriteLine("Error fetching tags: " + ex.Message, ex);
                throw new Exception("Error fetching tags: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Tags with row count (var tags, int rowCount) = GetAllTagsWithRowCount();
        ///  Console.WriteLine($"Number of rows: {rowCount}");
        /// </summary>
        /// <returns> tuple tags row count</returns>
        public (List<Tag>, int) GetAllTagsWithRowCount()
        {
            List<Tag> tags = new List<Tag>();
            int rowCount = 0;

            try
            {
                using (SQLiteConnection cn = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    cn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Tags", cn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                if (!rdr.IsDBNull(1))
                                {
                                    tags.Add(new Tag
                                    {
                                        Id = rdr.GetInt32(0),
                                        TagValue = rdr.GetString(1)
                                    });
                                }
                            }
                        }
                    }

                    // Calculate the row count without fetching all records
                    using (SQLiteCommand countCmd = new SQLiteCommand("SELECT COUNT(*) FROM Tags", cn))
                    {
                        rowCount = Convert.ToInt32(countCmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or return an empty list
                Console.WriteLine("Error fetching tags: " + ex.Message, ex);
                throw new Exception("Error fetching tags: " + ex.Message, ex);
            }

            return (tags, rowCount);
        }


        /// <summary>
        /// Updates Tag  UpdateTag("NewTag", 1); new tag value and Id as parameters
        /// </summary>
        /// <param name = "newTag" ></ param >
        /// < param name="id"></param>
        public void UpdateTag(string newTag, int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Tags SET Tag = @NewTag WHERE Id = @Id";
                        command.Parameters.AddWithValue("@NewTag", newTag);
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsUpdated = command.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            Console.WriteLine($"Updated person with ID {id} to '{newTag}'.");
                        }
                        else
                        {
                            Console.WriteLine($"No records updated for ID {id}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or display an error message
                Console.WriteLine("Error updating tag: " + newTag + id + ex.Message);
            }
        }

        /// <summary>
        /// Update tag returns affected rows
        /// </summary>
        /// <param name="newTag"></param>
        /// <param name="id"></param>
        /// <returns> int of affected rows</returns>
        public int UpdateTagWithAffectedRows(string newTag, int id)
        {
            int rowsUpdated = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Tags SET Tag = @NewTag WHERE Id = @Id";
                        command.Parameters.AddWithValue("@NewTag", newTag);
                        command.Parameters.AddWithValue("@Id", id);

                        rowsUpdated = command.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            Console.WriteLine($"Updated tag with ID {id} to '{newTag}'.");
                        }
                        else
                        {
                            Console.WriteLine($"No records updated for ID {id}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or display an error message
                Console.WriteLine("Error updating tag: " + newTag + id + ex.Message);
            }

            return rowsUpdated;
        }







        /// <summary>
        /// Delete a tag by tag name
        /// </summary>
        /// <param name="tag"></param>
        public void DeleteItemByTag(string tag)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Tags WHERE Tag = @Tag";
                        command.Parameters.AddWithValue("@Tag", tag);

                        int rowsDeleted = command.ExecuteNonQuery();

                        if (rowsDeleted > 0)
                        {
                            Console.WriteLine($"Deleted item with tag '{tag}'.");
                        }
                        else
                        {
                            Console.WriteLine($"No records deleted for tag '{tag}'.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or display an error message
                Console.WriteLine("Error deleting item: " + tag + ex.Message);
            }
        }
        /// <summary>
        /// accepts a list of string which contains the tags to delete
        /// </summary>
        /// <param name="tagsToDelete"></param>
        /// <returns>int of affected rows</returns>
        public int DeleteItemsByTagsWithAffectedRows(List<string> tagsToDelete)
        {
            int totalRowsDeleted = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        foreach (string tag in tagsToDelete)
                        {
                            using (SQLiteCommand command = connection.CreateCommand())
                            {
                                command.CommandText = "DELETE FROM Tags WHERE Tag = @Tag";
                                command.Parameters.AddWithValue("@Tag", tag);

                                int rowsDeleted = command.ExecuteNonQuery();
                                totalRowsDeleted += rowsDeleted;

                                if (rowsDeleted > 0)
                                {
                                    Console.WriteLine($"Deleted item(s) with tag '{tag}'.");
                                }
                                else
                                {
                                    Console.WriteLine($"No records deleted for tag '{tag}'.");
                                }
                            }
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or display an error message
                Console.WriteLine("Error deleting items: " + ex.Message);
            }

            return totalRowsDeleted;
        }


    }

    public class Tag
    {
        public int Id { get; set; }
        public string TagValue { get; set; }
    }
}
