using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ThuVienQuanLySachCaNhan.DataAccess;
using ThuVienQuanLySachCaNhan.Models;

namespace ThuVienQuanLySachCaNhan.BusinessLogic
{
    public class BookService
    {
        private readonly BookRepository _repo = new BookRepository();
        public DataTable GetAllBooks()
        {
            return _repo.GetAllAsDataTable();
        }

        public int AddBook(Book book, string coverSourcePath = null, string fileSourcePath = null)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Tiêu đề sách không được để trống.");

            string exeDir = Path.GetDirectoryName(Application.ExecutablePath);
            string appData = Path.Combine(exeDir, "AppData");
            string coverDir = Path.Combine(appData, "Covers");
            string fileDir = Path.Combine(appData, "Books");
            Directory.CreateDirectory(coverDir);
            Directory.CreateDirectory(fileDir);

            if (!string.IsNullOrEmpty(coverSourcePath) && File.Exists(coverSourcePath))
            {
                string ext = Path.GetExtension(coverSourcePath);
                string newCoverName = $"cover_{Guid.NewGuid()}{ext}";
                string savedCoverPath = Path.Combine(coverDir, newCoverName);
                File.Copy(coverSourcePath, savedCoverPath, true);
                book.CoverImagePath = savedCoverPath;
            }

            if (!string.IsNullOrEmpty(fileSourcePath) && File.Exists(fileSourcePath))
            {
                string ext = Path.GetExtension(fileSourcePath).ToLowerInvariant();
                string newFileName = $"book_{Guid.NewGuid()}{ext}";
                string savedFilePath = Path.Combine(fileDir, newFileName);
                File.Copy(fileSourcePath, savedFilePath, true);
                book.FilePath = savedFilePath;

                var fi = new FileInfo(savedFilePath);
                book.FileSizeMB = (decimal)(fi.Length / (1024.0 * 1024.0));

                if (ext == ".pdf")
                {
                    book.PageCount = GetPdfPageCount(savedFilePath);
                }
            }

            return _repo.Add(book);
        }

        public void UpdateBook(Book book)
        {
            if (book.Id <= 0)
                throw new ArgumentException("Id sách không hợp lệ.");
            _repo.Update(book);
        }

        public void DeleteBook(int id, string coverPath = null, string filePath = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(coverPath) && File.Exists(coverPath))
                    File.Delete(coverPath);
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch { }

            _repo.Delete(id);
        }

        public List<Book> SearchBooks(string keyword)
        {
            return _repo.Search(keyword);
        }

        private int GetPdfPageCount(string pdfPath)
        {
            if (!File.Exists(pdfPath)) return 0;
            try
            {
                using (var fs = new FileStream(pdfPath, FileMode.Open, FileAccess.Read))
                using (var reader = new BinaryReader(fs))
                {
                    if (fs.Length > 10 * 1024 * 1024) return 0;
                    var buffer = reader.ReadBytes((int)fs.Length);
                    var text = System.Text.Encoding.UTF8.GetString(buffer);
                    int pos = text.IndexOf("/Type /Pages");
                    if (pos < 0) return 0;
                    int countPos = text.IndexOf("/Count ", pos);
                    if (countPos < 0) return 0;
                    string remaining = text.Substring(countPos + 7);
                    var match = System.Text.RegularExpressions.Regex.Match(remaining, @"^\s*(\d+)");
                    if (match.Success && int.TryParse(match.Groups[1].Value, out int count))
                        return count;
                }
            }
            catch { }
            return 0;
        }
    }
}