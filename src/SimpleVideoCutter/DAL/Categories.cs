using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.DAL
{
    public class Categories
    {
        //todo split string here if needed
        //// List<string> tagsFromTextBox = "one,two,three, sdfsdf"
        //           .Split(',')
        //           .Select(entry => entry.Trim())  // Trim to remove leading/trailing spaces
        //           .Where(entry => !string.IsNullOrWhiteSpace(entry))
        //           .ToList();
        public void AddCategoryList(List<string> catListFromAddTagsTextBox)
        {

            string dbFilePath = VideoCutterSettings.DatabasePath;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (string tagValue in catListFromAddTagsTextBox)
                        {
                            using (SQLiteCommand command = connection.CreateCommand())
                            {
                                command.Parameters.AddWithValue("@Category", tagValue);

                                command.CommandText = "INSERT OR IGNORE INTO Categories (Category) VALUES (@Category)";
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine($"Inserted category: {tagValue}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error inserting category: {ex.Message}");
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

        public List<Cat> GetAllCategories()
        {
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    cn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Categories", cn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            var list = new List<Cat>();

                            while (rdr.Read())
                            {
                                if (!rdr.IsDBNull(1))
                                {
                                    list.Add(new Cat
                                    {
                                        Id = rdr.GetInt32(0),
                                        CategoryValue = rdr.GetString(1)
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
                Console.WriteLine("Error fetching categories: " + ex.Message, ex);
                throw new Exception("Error fetching categories: " + ex.Message, ex);
            }
        }

        public (List<Cat>, int) GetAllCategoriesWithRowCount()
        {
            List<Cat> categories = new List<Cat>();
            int rowCount = 0;

            try
            {
                using (SQLiteConnection cn = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    cn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Categories", cn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                if (!rdr.IsDBNull(1))
                                {
                                    categories.Add(new Cat
                                    {
                                        Id = rdr.GetInt32(0),
                                        CategoryValue = rdr.GetString(1)
                                    });
                                }
                            }
                        }
                    }

                    // Calculate the row count without fetching all records
                    using (SQLiteCommand countCmd = new SQLiteCommand("SELECT COUNT(*) FROM Categories", cn))
                    {
                        rowCount = Convert.ToInt32(countCmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or return an empty list
                Console.WriteLine("Error fetching categories: " + ex.Message, ex);
                throw new Exception("Error fetching categories: " + ex.Message, ex);
            }

            return (categories, rowCount);
        }

        public void UpdateCategory(string newCategory, int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE CAtegoriews SET Category = @NewCategory WHERE Id = @Id";
                        command.Parameters.AddWithValue("@NewCategory", newCategory);
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsUpdated = command.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            Console.WriteLine($"Updated category with ID {id} to '{newCategory}'.");
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
                Console.WriteLine("Error updating category: " + newCategory + id + ex.Message);
            }
        }


        //

    }
    public class Cat
    {
        public int Id { get; set; }
        public string CategoryValue { get; set; }
    }

}
