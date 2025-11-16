using System;

namespace ThuVienQuanLySachCaNhan.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public string Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal? FileSizeMB { get; set; }
        public int? PageCount { get; set; }
        public string FilePath { get; set; }
        public string CoverImagePath { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }

        public Book()
        {
            Title = string.Empty;
            Author = string.Empty;
            Topic = string.Empty;
            Publisher = string.Empty;
            FilePath = string.Empty;
            CoverImagePath = string.Empty;
            Description = string.Empty;
            Notes = string.Empty;
        }
    }
}