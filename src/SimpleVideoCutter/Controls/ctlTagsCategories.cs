using SimpleVideoCutter.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SimpleVideoCutter.Controls
{
    public partial class ctlTagsCategories : UserControl
    {
        public ctlTagsCategories()
        {
            InitializeComponent();
            ThemeResolutionService.ApplyThemeToControlTree(this, "FluentDark");
        }


        private  DatabaseHelper db;
        private void ctlTagsCategories_Load(object sender, EventArgs e)
        {
            radCheckedDropDownList1.DataSource = GetAllTags();
            db = new DatabaseHelper($"Data Source={VideoCutterSettings.DatabasePath};Version=3;");
        }

    

      /// <summary>
      /// Add Tag(s) accepts list of strings which is a comma seperated list of strings, the tags.
      /// </summary>
      /// <param name="tagListFromAddTagsTextBox"></param>
        static void AddTagList(List<string> tagListFromAddTagsTextBox)
        {
            string dbFilePath = VideoCutterSettings.DatabasePath;
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
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

     
        public List<Tag> GetAllTags()
        {
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection("Data Source=" + VideoCutterSettings.DatabasePath + "; Version=3"))
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

        private void radBtnAddTag_Click(object sender, EventArgs e)
        {
           
            //var person = new { Age = 34, Name = "John", Address = "Miami" };

        }

        private void radBtnAddTags_Click(object sender, EventArgs e)
        {
            if (radTextBoxCtlAddTags.Text.Length>0)
                {
                  
                //    string s = radTextBoxCtlAddTags.Text.Trim(); //tags;
                //    string[] values = s.Split(',').Select(sValue => sValue.Trim()).ToArray();

                //List<string> list = new List<string>(values.ToList());
                           

                // Split the input text by commas and remove empty entries using LINQ
                List<string> tagsFromTextBox = radTextBoxCtlAddTags.Text
                    .Split(',')
                    .Select(entry => entry.Trim())  // Trim to remove leading/trailing spaces
                    .Where(entry => !string.IsNullOrWhiteSpace(entry))
                    .ToList();
              
                AddTagList1(tagsFromTextBox);
                //radCheckedDropDownList1.DataSource = GetAllTags();
                Action safeRefresh = delegate { this.radCheckedDropDownList1.DataSource = GetAllTags(); };
                this.Invoke(safeRefresh);
                // Display the result (for demonstration purposes)
                radTextBoxCtlAddTags.Clear();
            }
        }
        /// <summary>
        /// Updates Tag  UpdateTag("NewTag", 1); new tag value and Id as parameters
        /// </summary>
        /// <param name="newTag"></param>
        /// <param name="id"></param>
        public void UpdateTag(string newTag, int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + VideoCutterSettings.DatabasePath + "; Version=3"))
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
                Console.WriteLine("Error updating tag: " + newTag + id  + ex.Message);
            }
        }

        //

        /// <summary>
        /// Delete a tag by tag name
        /// </summary>
        /// <param name="tag"></param>
        public void DeleteItemByTag(string tag)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + VideoCutterSettings.DatabasePath + "; Version=3"))
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

        //
        //
    }
}
