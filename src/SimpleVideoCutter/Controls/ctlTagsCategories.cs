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


        
        private void ctlTagsCategories_Load(object sender, EventArgs e)
        {
            //List<string> tags = new List<string>() { "tag", "tag1", "tag2", "tag3", "tag4", "tag5", "tag6", "tag7", };
            radCheckedDropDownList1.DataSource = GetAllTags();
            //GetAllTags();

        }

        //cmd.CommandText = "INSERT INTO wordlist (word) 
        //           SELECT('word')
        //           WHERE NOT EXISTS
        //               (SELECT 1 FROM wordlist WHERE word = 'word');";



        //Add tags
        static void AddTagList(List<string> tagListFromAddTagsTextBox)
        {
           
            string dbFilePath = VideoCutterSettings.DatabasePath;
                      
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                connection.Open();

                foreach (string tagValue in tagListFromAddTagsTextBox)
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {                     
                        command.Parameters.AddWithValue("@Tag", tagValue);

                        command.CommandText = "SELECT count(*) FROM Tags WHERE Tag=@Tag";
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 0)
                        {
                            command.CommandText = "INSERT INTO Tags  (Tag) VALUES (@Tag)";
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
                }

                connection.Close();
            }
        }
        //updated
        static void AddTagList1(List<string> tagListFromAddTagsTextBox)
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

        private void radBtnAddTag_Click(object sender, EventArgs e)
        {
           
            //var person = new { Age = 34, Name = "John", Address = "Miami" };

        }

        private void radBtnAddTags_Click(object sender, EventArgs e)
        {
            if (radTextBoxCtlAddTags.Text.Length>0)
                {
                    //string tags = radTextBoxCtlAddTags.Text.Trim();
                    // string[] subs = s.Split(' ');
                    // string[] tagList = tags.Split(","); 
                    string s = radTextBoxCtlAddTags.Text.Trim(); //tags;
                    string[] values = s.Split(',').Select(sValue => sValue.Trim()).ToArray();

                // string[] values = commaSeparatedText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Create a List<string> from the array
             //   List<string> resultList = new List<string>(values);


                List<string> list = new List<string>(values.ToList());
                // var school = new
                //{
                //    Address = "Orlando",
                //    Contact = 1200,
                //    Employee = new { Id = 3, Name = "Tina" }
                //};

               // List<string> stringList = radTextBoxCtlAddTags.Text
               //.Split(',')
               //.Select(tags => tags.Trim()) // Remove leading and trailing spaces
               //.ToList();

                // Split the input text by commas and remove empty entries using LINQ
                List<string> tagsFromTextBox = radTextBoxCtlAddTags.Text
                    .Split(',')
                    .Select(entry => entry.Trim())  // Trim to remove leading/trailing spaces
                    .Where(entry => !string.IsNullOrWhiteSpace(entry))
                    .ToList();



                var pp = tagsFromTextBox;
                AddTagList1(pp);
                //radCheckedDropDownList1.DataSource = GetAllTags();
                Action safeRefresh = delegate { this.radCheckedDropDownList1.DataSource = GetAllTags(); };
                this.Invoke(safeRefresh);
                // Display the result (for demonstration purposes)
                radTextBoxCtlAddTags.Clear();


                //  AddTagList(list);


            }
        }


        //
    }
}
