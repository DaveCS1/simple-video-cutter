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
            try
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
                                    SubCategory = reader.GetString(7),
                                    Notes = reader.GetString(8)
                                };

                                bookmarks.Add(bookmark);
                            }
                        }
                    }
                }

                return bookmarks;
            }
            catch (Exception ex)
            {

                Console.WriteLine(  ex.Message + ex.StackTrace + ex.InnerException);
                return null;
            }
        }




        public void InsertBookmark(Bookmark bookmark)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT OR IGNORE INTO BookMark (Description, Category, Tags, DateAdded, Importance, FileName, SubCategory) " +
                                         "VALUES (@Description, @Category, @Tags, @DateAdded, @Importance, @FileName, @SubCategory)";
                    command.Parameters.AddWithValue("@Description", bookmark.Description);
                    command.Parameters.AddWithValue("@Category", bookmark.Category);
                    command.Parameters.AddWithValue("@Tags", bookmark.Tags);
                    //command.Parameters.AddWithValue("@DateAdded", bookmark.DateAdded);
                    command.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    command.Parameters.AddWithValue("@Importance", bookmark.Importance);
                    command.Parameters.AddWithValue("@FileName", bookmark.FileName);
                    command.Parameters.AddWithValue("@SubCategory", bookmark.SubCategory);
                    command.Parameters.AddWithValue("@Notes", bookmark.Notes);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteBookmark(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
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
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
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
                    command.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                    command.Parameters.AddWithValue("@Importance", bookmark.Importance);
                    command.Parameters.AddWithValue("@FileName", bookmark.FileName);
                    command.Parameters.AddWithValue("@SubCategory", bookmark.SubCategory);
                    command.Parameters.AddWithValue("@Id", bookmark.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
       
    //update with orginal values
    // Update
    /// <summary>
    /// Accepts original bookmark to retain values and the new bookmark
    /// </summary>
    /// <param name="originalBookMark"></param>
    /// <param name="updatedBookMark"></param>
    /// <returns></returns>
    public bool UpdateBookMarkWithOriginalValues(Bookmark originalBookMark, Bookmark updatedBookMark)
    {
        using (SQLiteConnection connection = new SQLiteConnection($"Data Source={VideoCutterSettings.DatabasePath};Version=3;"))
            {
            connection.Open();

            using (SQLiteTransaction transaction = connection.BeginTransaction())
            {
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                        //todo maybe need to look at notes param  added last check
                    command.CommandText = @"UPDATE BookMark
                                            SET Description = @UpdatedDescription, Category = @UpdatedCategory,
                                                Tags = @UpdatedTags, DateAdded = @UpdatedDateAdded,
                                                Importance = @UpdatedImportance, FileName = @UpdatedFileName,
                                                SubCategory = @UpdatedSubCategory, Notes=@UpdatedNotes
                                            WHERE Id = @OriginalId
                                              AND Description = @OriginalDescription
                                              AND Category = @OriginalCategory
                                              AND Tags = @OriginalTags
                                              AND DateAdded = @OriginalDateAdded
                                              AND Importance = @OriginalImportance
                                              AND FileName = @OriginalFileName
                                              AND SubCategory = @OriginalSubCategory AND Notes = @OriginalNotes";

                    command.Parameters.AddWithValue("@UpdatedDescription", updatedBookMark.Description);
                    command.Parameters.AddWithValue("@UpdatedCategory", updatedBookMark.Category);
                    command.Parameters.AddWithValue("@UpdatedTags", updatedBookMark.Tags);
                    command.Parameters.AddWithValue("@UpdatedDateAdded", updatedBookMark.DateAdded);//todo may need  DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                        command.Parameters.AddWithValue("@UpdatedImportance", updatedBookMark.Importance);
                    command.Parameters.AddWithValue("@UpdatedFileName", updatedBookMark.FileName);
                    command.Parameters.AddWithValue("@UpdatedSubCategory", updatedBookMark.SubCategory);
                        command.Parameters.AddWithValue("@UpdatedNotes", updatedBookMark.Notes);



                        command.Parameters.AddWithValue("@OriginalId", originalBookMark.Id);
                    command.Parameters.AddWithValue("@OriginalDescription", originalBookMark.Description);
                    command.Parameters.AddWithValue("@OriginalCategory", originalBookMark.Category);
                    command.Parameters.AddWithValue("@OriginalTags", originalBookMark.Tags);
                    command.Parameters.AddWithValue("@OriginalDateAdded", originalBookMark.DateAdded);
                    command.Parameters.AddWithValue("@OriginalImportance", originalBookMark.Importance);
                    command.Parameters.AddWithValue("@OriginalFileName", originalBookMark.FileName);
                    command.Parameters.AddWithValue("@OriginalSubCategory", originalBookMark.SubCategory);
                        command.Parameters.AddWithValue("@OriginalNotes", originalBookMark.Notes);
                        int rowsUpdated = command.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }


        //end
    }




    public class Bookmark
    {
        public Int32? Id { get; internal set; } = null;
        public string Description { get; internal set; }
        public string Category { get; internal set; }
        public string Tags { get; internal set; }
        public string DateAdded { get; internal set; }
        public Int32 Importance { get; internal set; } = 1;
        public string SubCategory { get; internal set; }
        public string FileName { get; internal set; }
        public string Notes { get; internal set; }

    }
}
