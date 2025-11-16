using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ThuVienQuanLySachCaNhan.BusinessLogic;
using ThuVienQuanLySachCaNhan.Models;

namespace ThuVienQuanLySachCaNhan
{
    public partial class BookEditForm : Form
    {
        private readonly BookService _bookService = new BookService();
        private Book _book;
        private string _coverPath = string.Empty;
        private string _filePath = string.Empty;

        public BookEditForm(Book book)
        {
            InitializeComponent();
            _book = book ?? throw new ArgumentNullException(nameof(book));
            LoadData();
            LoadTopics();
        }

        private void LoadTopics()
        {
            cbbTopic.Items.AddRange(new string[]
            {
                "Programming", "Fiction", "Science", "History",
                "Self-Help", "Business", "Other"
            });
        }

        private void LoadData()
        {
            txtTitle.Text = _book.Title;
            txtAuthor.Text = _book.Author;
            cbbTopic.Text = _book.Topic;
            txtPublisher.Text = _book.Publisher;
            if (_book.PublishDate.HasValue)
            {
                chkPublishDate.Checked = true;
                dtpPublish.Value = _book.PublishDate.Value;
                dtpPublish.Enabled = true;
            }
            else
            {
                chkPublishDate.Checked = false;
                dtpPublish.Enabled = false;
            }
            chkIsRead.Checked = _book.IsRead;
            nudRating.Value = _book.Rating;
            txtDesc.Text = _book.Description;
            txtNotes.Text = _book.Notes;

            // Hiển thị tên file
            if (!string.IsNullOrEmpty(_book.FilePath))
            {
                txtFileName.Text = Path.GetFileName(_book.FilePath);
                _filePath = _book.FilePath;
            }

            // Load ảnh bìa
            if (!string.IsNullOrEmpty(_book.CoverImagePath) && File.Exists(_book.CoverImagePath))
            {
                try
                {
                    pbCover.Image = Image.FromFile(_book.CoverImagePath);
                    _coverPath = _book.CoverImagePath;
                }
                catch { }
            }
        }

        private void chkPublishDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPublish.Enabled = chkPublishDate.Checked;
        }

        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _coverPath = dlg.FileName;
                    try
                    {
                        pbCover.Image = Image.FromFile(_coverPath);
                    }
                    catch
                    {
                        MessageBox.Show("Không thể tải ảnh bìa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRemoveCover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa ảnh bìa hiện tại?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                pbCover.Image = null;
                _coverPath = string.Empty;
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Books|*.pdf;*.epub|PDF|*.pdf|EPUB|*.epub|All|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _filePath = dlg.FileName;
                    txtFileName.Text = Path.GetFileName(_filePath);
                }
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa file đính kèm hiện tại?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtFileName.Text = string.Empty;
                _filePath = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            try
            {
                _book.Title = txtTitle.Text.Trim();
                _book.Author = txtAuthor.Text.Trim();
                _book.Topic = cbbTopic.Text;
                _book.Publisher = txtPublisher.Text.Trim();
                _book.PublishDate = dtpPublish.Enabled ? dtpPublish.Value.Date : (DateTime?)null;
                _book.IsRead = chkIsRead.Checked;
                _book.Rating = (int)nudRating.Value;
                _book.Description = txtDesc.Text.Trim();
                _book.Notes = txtNotes.Text.Trim();

                // Nếu chọn ảnh/file mới → xử lý copy
                string exeDir = Path.GetDirectoryName(Application.ExecutablePath);
                string appData = Path.Combine(exeDir, "AppData");
                string coverDir = Path.Combine(appData, "Covers");
                string fileDir = Path.Combine(appData, "Books");
                Directory.CreateDirectory(coverDir);
                Directory.CreateDirectory(fileDir);

                // Xử lý ảnh bìa mới
                if (!string.IsNullOrEmpty(_coverPath) && File.Exists(_coverPath))
                {
                    string ext = Path.GetExtension(_coverPath);
                    string newCoverName = $"cover_{Guid.NewGuid()}{ext}";
                    string savedCoverPath = Path.Combine(coverDir, newCoverName);
                    File.Copy(_coverPath, savedCoverPath, true);
                    _book.CoverImagePath = savedCoverPath;
                }

                // Xử lý file mới
                if (!string.IsNullOrEmpty(_filePath) && File.Exists(_filePath))
                {
                    string ext = Path.GetExtension(_filePath).ToLowerInvariant();
                    string newFileName = $"book_{Guid.NewGuid()}{ext}";
                    string savedFilePath = Path.Combine(fileDir, newFileName);
                    File.Copy(_filePath, savedFilePath, true);
                    _book.FilePath = savedFilePath;

                    var fi = new FileInfo(savedFilePath);
                    _book.FileSizeMB = (decimal)(fi.Length / (1024.0 * 1024.0));

                    if (ext == ".pdf")
                    {
                        _book.PageCount = GetPdfPageCount(savedFilePath);
                    }
                }

                _bookService.UpdateBook(_book);
                MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Hàm trích số trang PDF — copy từ BookService
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