using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.DAL
{
    [Serializable]
    public  class BookMarks
    {

        public BookMarks()
        {

        }
        public List<Bookmark> GetAllBookmarks()
        {
            List<Bookmark> bookmarks = new List<Bookmark>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM BookMark";

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bookmark bookmark = new Bookmark
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                Category = reader.GetString(2),
                                Tags = reader.GetString(3),
                                DateAdded = reader.GetString(4),
                                Importance = reader.GetInt32(5),
                                FileName = reader.GetString(6),
                                SubCategory = reader.GetString(7)
                            };

                            bookmarks.Add(bookmark);
                        }
                    }
                }
            }

            return bookmarks;
        }




        public void InsertBookmark(Bookmark bookmark)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO BookMark (Description, Category, Tags, DateAdded, Importance, FileName, SubCategory) " +
                                         "VALUES (@Description, @Category, @Tags, @DateAdded, @Importance, @FileName, @SubCategory)";
                    command.Parameters.AddWithValue("@Description", bookmark.Description);
                    command.Parameters.AddWithValue("@Category", bookmark.Category);
                    command.Parameters.AddWithValue("@Tags", bookmark.Tags);
                    //command.Parameters.AddWithValue("@DateAdded", bookmark.DateAdded);
                    command.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    command.Parameters.AddWithValue("@Importance", bookmark.Importance);
                    command.Parameters.AddWithValue("@FileName", bookmark.FileName);
                    command.Parameters.AddWithValue("@SubCategory", bookmark.SubCategory);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteBookmark(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=YourDatabasePath.db;Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM BookMark WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateBookmark(Bookmark bookmark)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=YourDatabasePath.db;Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE BookMark SET Description = @Description, Category = @Category, " +
                                         "Tags = @Tags, DateAdded = @DateAdded, Importance = @Importance, " +
                                         "FileName = @FileName, SubCategory = @SubCategory WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Description", bookmark.Description);
                    command.Parameters.AddWithValue("@Category", bookmark.Category);
                    command.Parameters.AddWithValue("@Tags", bookmark.Tags);
                    command.Parameters.AddWithValue("@DateAdded", bookmark.DateAdded);
                    command.Parameters.AddWithValue("@Importance", bookmark.Importance);
                    command.Parameters.AddWithValue("@FileName", bookmark.FileName);
                    command.Parameters.AddWithValue("@SubCategory", bookmark.SubCategory);
                    command.Parameters.AddWithValue("@Id", bookmark.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
        //
    }

    public class Bookmark
    {
        public int? Id { get; internal set; } = null;
        public string Description { get; internal set; }
        public string Category { get; internal set; }
        public string Tags { get; internal set; }
        public string DateAdded { get; internal set; }
        public int Importance { get; internal set; } = 1;
        public string SubCategory { get; internal set; }
        public string FileName { get; internal set; }

        //public string Description { get; set; }
        //public string FileName { get; set; }
        ////public List<string> Tags { get; set; }
        //public string Tags { get; set; }
        //////public List<string> Categories { get; set; }
        ///// <summary>
        //public string Categories { get; set; }
        //public string SubCategory { get; set; }
        ///// </summary>
        ////private string DateViewed { get; set; } = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        //public int Importance { get; set; } = 1;





    }
}
