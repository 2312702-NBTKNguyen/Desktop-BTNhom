using System;
using System.Drawing;   
using System.IO;
using System.Windows.Forms;
using ThuVienQuanLySachCaNhan.BusinessLogic;
using ThuVienQuanLySachCaNhan.Models;

namespace ThuVienQuanLySachCaNhan
{
    public partial class BookAddForm : Form
    {
        private readonly BookService _bookService = new BookService();
        private string _coverPath = string.Empty;
        private string _filePath = string.Empty;

        public BookAddForm()
        {
            InitializeComponent();
            LoadTopics();
            chkPublishDate_CheckedChanged(null, EventArgs.Empty);
        }

        private void LoadTopics()
        {
            cbbTopic.Items.AddRange(new string[]
            {
                "Programming", "Fiction", "Science", "History",
                "Self-Help", "Business", "Other"
            });
            cbbTopic.SelectedIndex = 0;
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
                var book = new Book
                {
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Topic = cbbTopic.Text,
                    Publisher = txtPublisher.Text.Trim(),
                    PublishDate = dtpPublish.Enabled ? dtpPublish.Value.Date : (DateTime?)null,
                    IsRead = chkIsRead.Checked,
                    Rating = (int)nudRating.Value,
                    Description = txtDesc.Text.Trim(),
                    Notes = txtNotes.Text.Trim()
                };

                _bookService.AddBook(book, _coverPath, _filePath);
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}