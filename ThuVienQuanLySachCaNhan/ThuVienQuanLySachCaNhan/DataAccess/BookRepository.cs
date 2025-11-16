using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ThuVienQuanLySachCaNhan.Models;

namespace ThuVienQuanLySachCaNhan.DataAccess
{
    public class BookRepository
    {
        private readonly string _connectionString;

        public BookRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public DataTable GetAllAsDataTable()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var adapter = new SqlDataAdapter("SELECT * FROM Books ORDER BY DateAdded DESC", conn);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public int Add(Book book)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Books (Title, Author, Topic, Publisher, PublishDate, 
                        FileSizeMB, PageCount, FilePath, CoverImagePath, Description, IsRead, Rating, Notes)
                    VALUES (@Title, @Author, @Topic, @Publisher, @PublishDate, 
                        @FileSizeMB, @PageCount, @FilePath, @CoverImagePath, @Description, @IsRead, @Rating, @Notes);
                    SELECT SCOPE_IDENTITY();", conn))
                {
                    cmd.Parameters.AddWithValue("@Title", book.Title ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Author", book.Author ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Topic", book.Topic ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PublishDate", book.PublishDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FileSizeMB", book.FileSizeMB ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageCount", book.PageCount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FilePath", book.FilePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CoverImagePath", book.CoverImagePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", book.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsRead", book.IsRead);
                    cmd.Parameters.AddWithValue("@Rating", book.Rating);
                    cmd.Parameters.AddWithValue("@Notes", book.Notes ?? (object)DBNull.Value);

                    var result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public void Update(Book book)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    UPDATE Books SET 
                        Title = @Title, Author = @Author, Topic = @Topic, Publisher = @Publisher,
                        PublishDate = @PublishDate, FileSizeMB = @FileSizeMB, PageCount = @PageCount,
                        FilePath = @FilePath, CoverImagePath = @CoverImagePath,
                        Description = @Description, IsRead = @IsRead, Rating = @Rating, Notes = @Notes
                    WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", book.Id);
                    cmd.Parameters.AddWithValue("@Title", book.Title ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Author", book.Author ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Topic", book.Topic ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PublishDate", book.PublishDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FileSizeMB", book.FileSizeMB ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageCount", book.PageCount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FilePath", book.FilePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CoverImagePath", book.CoverImagePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", book.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsRead", book.IsRead);
                    cmd.Parameters.AddWithValue("@Rating", book.Rating);
                    cmd.Parameters.AddWithValue("@Notes", book.Notes ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Books WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Book> Search(string keyword)
        {
            var books = new List<Book>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM Books 
                    WHERE Title LIKE @Keyword 
                       OR Author LIKE @Keyword 
                       OR Topic LIKE @Keyword
                    ORDER BY DateAdded DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(MapReaderToBook(reader));
                        }
                    }
                }
            }
            return books;
        }

        private Book MapReaderToBook(SqlDataReader reader)
        {
            int idOrdinal = reader.GetOrdinal("Id");
            int titleOrdinal = reader.GetOrdinal("Title");
            int authorOrdinal = reader.GetOrdinal("Author");
            int topicOrdinal = reader.GetOrdinal("Topic");
            int publisherOrdinal = reader.GetOrdinal("Publisher");
            int publishDateOrdinal = reader.GetOrdinal("PublishDate");
            int dateAddedOrdinal = reader.GetOrdinal("DateAdded");
            int fileSizeMBOrdinal = reader.GetOrdinal("FileSizeMB");
            int pageCountOrdinal = reader.GetOrdinal("PageCount");
            int filePathOrdinal = reader.GetOrdinal("FilePath");
            int coverImagePathOrdinal = reader.GetOrdinal("CoverImagePath");
            int descriptionOrdinal = reader.GetOrdinal("Description");
            int isReadOrdinal = reader.GetOrdinal("IsRead");
            int ratingOrdinal = reader.GetOrdinal("Rating");
            int notesOrdinal = reader.GetOrdinal("Notes");

            return new Book
            {
                Id = reader.GetInt32(idOrdinal),
                Title = reader.IsDBNull(titleOrdinal) ? string.Empty : reader.GetString(titleOrdinal),
                Author = reader.IsDBNull(authorOrdinal) ? string.Empty : reader.GetString(authorOrdinal),
                Topic = reader.IsDBNull(topicOrdinal) ? string.Empty : reader.GetString(topicOrdinal),
                Publisher = reader.IsDBNull(publisherOrdinal) ? string.Empty : reader.GetString(publisherOrdinal),
                PublishDate = reader.IsDBNull(publishDateOrdinal) ? (DateTime?)null : reader.GetDateTime(publishDateOrdinal),
                DateAdded = reader.GetDateTime(dateAddedOrdinal),
                FileSizeMB = reader.IsDBNull(fileSizeMBOrdinal) ? (decimal?)null : reader.GetDecimal(fileSizeMBOrdinal),
                PageCount = reader.IsDBNull(pageCountOrdinal) ? (int?)null : reader.GetInt32(pageCountOrdinal),
                FilePath = reader.IsDBNull(filePathOrdinal) ? string.Empty : reader.GetString(filePathOrdinal),
                CoverImagePath = reader.IsDBNull(coverImagePathOrdinal) ? string.Empty : reader.GetString(coverImagePathOrdinal),
                Description = reader.IsDBNull(descriptionOrdinal) ? string.Empty : reader.GetString(descriptionOrdinal),
                IsRead = reader.GetBoolean(isReadOrdinal),
                Rating = reader.IsDBNull(ratingOrdinal) ? 0 : reader.GetByte(ratingOrdinal),
                Notes = reader.IsDBNull(notesOrdinal) ? string.Empty : reader.GetString(notesOrdinal)
            };
        }
    }
}