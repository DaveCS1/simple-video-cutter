using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.DAL
{
   public class SubCategories
    {
        public List<SubCat> GetAllSubCategories()
        {
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    cn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM SubCategories", cn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            var list = new List<SubCat>();

                            while (rdr.Read())
                            {
                                if (!rdr.IsDBNull(1))
                                {
                                    list.Add(new SubCat
                                    {
                                        Id = rdr.GetInt32(0),
                                        SubCategoryValue = rdr.GetString(1)
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

        //todo split string here if needed
        //// List<string> tagsFromTextBox = "one,two,three, sdfsdf"
        //           .Split(',')
        //           .Select(entry => entry.Trim())  // Trim to remove leading/trailing spaces
        //           .Where(entry => !string.IsNullOrWhiteSpace(entry))
        //           .ToList();
        public void AddSubCategoryList(List<string> subCatListFromAddTagsTextBox)
        {

            
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (string subCategoryValue in subCatListFromAddTagsTextBox)
                        {
                            using (SQLiteCommand command = connection.CreateCommand())
                            {
                                command.Parameters.AddWithValue("@SubCategory", subCategoryValue);

                                command.CommandText = "INSERT OR IGNORE INTO SubCategories (SubCategory) VALUES (@SubCategory)";
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine($"Inserted subcategory: {subCategoryValue}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error inserting subcategory: {ex.Message}");
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
        public void AddSubCategory(string subCategoryValue)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand command = connection.CreateCommand())
                        {
                            command.Parameters.AddWithValue("@SubCategory", subCategoryValue);

                            command.CommandText = "INSERT OR IGNORE INTO SubCategories (SubCategory) VALUES (@SubCategory)";
                            try
                            {
                                command.ExecuteNonQuery();
                                Console.WriteLine($"Inserted subcategory: {subCategoryValue}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error inserting subcategory: {ex.Message}");
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

        public void UpdateSubCategory(string newSubCategory, int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE SubCategories SET SubCategory = @NewSubCategory WHERE Id = @Id";
                        command.Parameters.AddWithValue("@NewSubCategory", newSubCategory);
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsUpdated = command.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            Console.WriteLine($"Updated sub category with ID {id} to '{newSubCategory}'.");
                        }
                        else
                        {
                            Console.WriteLine($"No records updated for sub category ID {id}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., throw, log, or display an error message
                Console.WriteLine("Error updating category: " + newSubCategory + id + ex.Message);
            }
        }
        public void DeleteSubCategory(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM SubCategories WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteAllSubCategories()
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE * FROM SubCategories";
                   
                    command.ExecuteNonQuery();
                }
            }
        }

        //end
    }
    public class SubCat
    {
        public int Id { get; set; }
        public string SubCategoryValue { get; set; }
    }
}
