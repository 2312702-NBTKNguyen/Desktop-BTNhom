using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThuVienQuanLySachCaNhan.BusinessLogic;
using ThuVienQuanLySachCaNhan.Models;

namespace ThuVienQuanLySachCaNhan
{
    public partial class MainForm : Form
    {
        private readonly BookService _bookService = new BookService();
        private BindingSource _bindingSource = new BindingSource();
        private DataTable _dataTable;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            dgvSach.CellContentClick += dgvSach_CellContentClick;
            dgvSach.SelectionChanged += dgvSach_SelectionChanged;
            tsbSuaTT.Click += tsbSuaTT_Click;
            tsbXoaSach.Click += tsbXoaSach_Click;
            tsbLamMoi.Click += (s, e) => LoadBooks();
            thêmThủCôngToolStripMenuItem.Click += (s, e) => OpenAddBookForm();
            // Redirect "Thêm từ File" to same add form (remove separate import behavior)
            thêmTừFileToolStripMenuItem.Click += (s, e) => OpenAddBookForm();

            cbbTimKiem.TextChanged += (s, e) => ApplySearchFilter();
            cbbTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ApplySearchFilter();
                    e.SuppressKeyPress = true;
                }
            };
            btnTimKiem.Click += (s, e) => ApplySearchFilter();
            btnTimKiemNangCao.Click += (s, e) => ApplySearchFilter(); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadBooks();
        }

        private void SetupDataGridView()
        {
            dgvSach.AutoGenerateColumns = false;
            dgvSach.Columns.Clear();

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                DataPropertyName = "Title",
                HeaderText = "Tiêu đề",
                Width = 200
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Author",
                DataPropertyName = "Author",
                HeaderText = "Tác giả",
                Width = 120
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Topic",
                DataPropertyName = "Topic",
                HeaderText = "Chủ đề",
                Width = 100
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Publisher",
                DataPropertyName = "Publisher",
                HeaderText = "Nhà xuất bản",
                Width = 120
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PublishDate",
                DataPropertyName = "PublishDate",
                HeaderText = "Ngày XB",
                Width = 90,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateAdded",
                DataPropertyName = "DateAdded",
                HeaderText = "Ngày nhập",
                Width = 120,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PageCount",
                DataPropertyName = "PageCount",
                HeaderText = "Số trang",
                Width = 60
            });

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FileSizeMB",
                DataPropertyName = "FileSizeMB",
                HeaderText = "Dung lượng (MB)",
                Width = 80,
                DefaultCellStyle = { Format = "N2" }
            });

            var existingIsReadCol = dgvSach.Columns["IsRead"];
            if (existingIsReadCol != null)
            {
                dgvSach.Columns.Remove(existingIsReadCol);
            }
            dgvSach.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsRead",
                DataPropertyName = "IsRead",
                HeaderText = "Đã đọc",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            foreach (string colName in new[] { "FilePath", "CoverImagePath", "Description", "Notes" })
            {
                dgvSach.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = colName,
                    DataPropertyName = colName,
                    Visible = false
                });
            }
        }

        private void LoadBooks()
        {
            try
            {
                var table = _bookService.GetAllBooks();
                _dataTable = table; 

                _bindingSource.DataSource = table;
                dgvSach.DataSource = _bindingSource;

                SetupDataGridView(); 
                UpdateStatus($"Tổng: {table.Rows.Count} sách");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus(string text)
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new Action(() => UpdateStatus(text)));
                return;
            }

            var label = statusStrip1.Items["lblStatus"] as ToolStripStatusLabel;
            if (label == null)
            {
                label = new ToolStripStatusLabel { Name = "lblStatus" };
                statusStrip1.Items.Add(label);
            }
            label.Text = text;
        }

        private void OpenAddBookForm()
        {
            using (var form = new BookAddForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
        }

        private Book GetSelectedBook()
        {
            if (dgvSach.SelectedRows.Count ==0) return null;
            var row = dgvSach.SelectedRows[0];

            if (row.DataBoundItem is Book b1)
            {
                return b1;
            }
            else if (row.DataBoundItem is DataRowView drv)
            {
                try
                {
                    return new Book
                    {
                        Id = Convert.ToInt32(drv["Id"]),
                        Title = drv["Title"]?.ToString() ?? string.Empty,
                        Author = drv["Author"]?.ToString() ?? string.Empty,
                        Topic = drv["Topic"]?.ToString() ?? string.Empty,
                        Publisher = drv["Publisher"]?.ToString() ?? string.Empty,
                        PublishDate = drv["PublishDate"] as DateTime?,
                        DateAdded = drv["DateAdded"] == null ? DateTime.MinValue : Convert.ToDateTime(drv["DateAdded"]),
                        FileSizeMB = drv["FileSizeMB"] as decimal?,
                        PageCount = drv["PageCount"] as int?,
                        FilePath = drv["FilePath"]?.ToString() ?? string.Empty,
                        CoverImagePath = drv["CoverImagePath"]?.ToString() ?? string.Empty,
                        Description = drv["Description"]?.ToString() ?? string.Empty,
                        IsRead = drv["IsRead"] == null ? false : Convert.ToBoolean(drv["IsRead"]),
                        Rating = drv["Rating"] is DBNull ?0 : Convert.ToInt32(drv["Rating"]),
                        Notes = drv["Notes"]?.ToString() ?? string.Empty
                    };
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count >0)
            {
                var row = dgvSach.SelectedRows[0];
                Book book = null;

                if (row.DataBoundItem is Book b1)
                {
                    book = b1;
                }
                else if (row.DataBoundItem is DataRowView drv)
                {
                    book = new Book
                    {
                        Id = Convert.ToInt32(drv["Id"]),
                        Title = drv["Title"].ToString(),
                        Author = drv["Author"].ToString(),
                        Topic = drv["Topic"].ToString(),
                        Publisher = drv["Publisher"].ToString(),
                        PublishDate = drv["PublishDate"] as DateTime?,
                        DateAdded = Convert.ToDateTime(drv["DateAdded"]),
                        FileSizeMB = drv["FileSizeMB"] as decimal?,
                        PageCount = drv["PageCount"] as int?,
                        FilePath = drv["FilePath"].ToString(),
                        CoverImagePath = drv["CoverImagePath"].ToString(),
                        Description = drv["Description"].ToString(),
                        IsRead = Convert.ToBoolean(drv["IsRead"]),
                        Rating = drv["Rating"] is DBNull ?0 : Convert.ToInt32(drv["Rating"]),
                        Notes = drv["Notes"].ToString()
                    };
                }

                if (book != null)
                {
                    DisplayBookDetail(book);
                }
            }
        }

        private void DisplayBookDetail(Book book)
        {
            pnlTTSach.Controls.Clear();
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                AutoScroll = true
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            void AddRow(string label, string value)
            {
                tlp.RowCount++;
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                var lbl = new Label
                {
                    Text = label,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    AutoSize = true,
                    Margin = new Padding(0, 2, 5, 2)
                };
                var val = new Label
                {
                    Text = string.IsNullOrEmpty(value) ? "—" : value,
                    AutoSize = true,
                    Margin = new Padding(0, 2, 0, 2)
                };

                tlp.Controls.Add(lbl, 0, tlp.RowCount - 1);
                tlp.Controls.Add(val, 1, tlp.RowCount - 1);
            }

            AddRow("Tác giả:", book.Author);
            AddRow("Chủ đề:", book.Topic);
            AddRow("NXB:", book.Publisher);
            AddRow("Ngày XB:", book.PublishDate?.ToString("dd/MM/yyyy") ?? "—");
            AddRow("Ngày nhập:", book.DateAdded.ToString("dd/MM/yyyy HH:mm"));
            AddRow("Số trang:", book.PageCount?.ToString() ?? "—");
            AddRow("Dung lượng:", book.FileSizeMB.HasValue ? $"{book.FileSizeMB:F2} MB" : "—");

            var chkIsRead = new CheckBox
            {
                Text = "Đã đọc",
                Checked = book.IsRead,
                AutoSize = true,
                Margin = new Padding(0, 2, 0, 2),
                Enabled = false 
            };
            tlp.RowCount++;
            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.Controls.Add(new Label { Text = "Trạng thái:", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true }, 0, tlp.RowCount - 1);
            tlp.Controls.Add(chkIsRead, 1, tlp.RowCount - 1);

            pnlTTSach.Controls.Add(tlp);
            pictureBox2.Image?.Dispose();
            pictureBox2.Image = null;
            pictureBox2.BackColor = Color.White;
            pictureBox2.BorderStyle = BorderStyle.None;

            if (!string.IsNullOrEmpty(book.CoverImagePath) && File.Exists(book.CoverImagePath))
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(book.CoverImagePath);
                }
                catch { }
            }
        }
        private void tsbXoaSach_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvSach.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sách để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string titles = string.Join("\n• ",
                selectedRows.Cast<DataGridViewRow>()
                    .Select(r => (r.DataBoundItem as Book)?.Title)
                    .Where(t => !string.IsNullOrEmpty(t))
                    .Take(5)); 

            string message = selectedRows.Count == 1
                ? $"Bạn có chắc muốn xóa sách:\n• {titles}?"
                : $"Bạn có chắc muốn xóa {selectedRows.Count} sách đã chọn?\n\n{titles}{(selectedRows.Count > 5 ? "\n..." : "")}";

            if (MessageBox.Show(message, "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        var book = row.DataBoundItem as Book;
                        if (book != null)
                        {
                            _bookService.DeleteBook(book.Id, book.CoverImagePath, book.FilePath);
                        }
                    }
                    LoadBooks();
                    MessageBox.Show($"Đã xóa {selectedRows.Count} sách.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sách: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void tsbSuaTT_Click(object sender, EventArgs e)
        {
            var book = GetSelectedBook();
            if (book == null)
            {
                MessageBox.Show("Vui lòng chọn sách để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new BookEditForm(book))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSach.Columns["IsRead"].Index && e.RowIndex >= 0)
            {
                var book = dgvSach.Rows[e.RowIndex].DataBoundItem as Book;
                if (book != null)
                {
                    book.IsRead = !book.IsRead; 
                    _bookService.UpdateBook(book);
                }
            }
        }

        private void pnlTTSach_Paint(object sender, PaintEventArgs e)
        {

        }
        private string BuildFilter(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            input = input.Trim();
            if (input.StartsWith("\"") && input.EndsWith("\""))
            {
                var exact = input.Trim('"').Replace("'", "''");
                return $"(Title LIKE '%{exact}%' OR Author LIKE '%{exact}%' OR Topic LIKE '%{exact}%')";
            }
            if (input.Contains(" AND ") || input.Contains(" OR "))
            {
                var parts = input.Split(new[] { " AND ", " OR " }, StringSplitOptions.RemoveEmptyEntries);
                var ops = new List<string>();
                foreach (var part in input.Split(' '))
                {
                    if (part == "AND" || part == "OR") ops.Add(part);
                }

                var filters = new List<string>();
                foreach (var part in parts)
                {
                    var clean = part.Trim().Replace("'", "''");
                    filters.Add($"(Title LIKE '%{clean}%' OR Author LIKE '%{clean}%' OR Topic LIKE '%{clean}%')");
                }

                var result = filters[0];
                for (int i = 0; i < ops.Count && i < filters.Count - 1; i++)
                {
                    result += $" {ops[i]} {filters[i + 1]}";
                }
                return result;
            }
            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var conditions = new List<string>();
            foreach (var word in words)
            {
                var clean = word.Replace("'", "''");
                conditions.Add($"(Title LIKE '%{clean}%' OR Author LIKE '%{clean}%' OR Topic LIKE '%{clean}%')");
            }
            return string.Join(" AND ", conditions); 
        }

        private void cbbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ApplySearchFilter()
        {
            if (_dataTable == null) return;

            try
            {
                var filter = BuildFilter(cbbTimKiem.Text);
                _bindingSource.Filter = filter;
                UpdateStatus($"Tìm thấy: {_bindingSource.Count} sách");
            }
            catch
            {
                _bindingSource.Filter = string.Empty;
            }
        }
    }
    public static class DataRowViewExtensions
    {
        public static Book ToBook(this DataRowView drv)
        {
            return new Book
            {
                Id = Convert.ToInt32(drv["Id"]),
                Title = drv["Title"].ToString(),
                Author = drv["Author"].ToString(),
                Topic = drv["Topic"].ToString(),
                Publisher = drv["Publisher"].ToString(),
                PublishDate = drv["PublishDate"] as DateTime?,
                DateAdded = Convert.ToDateTime(drv["DateAdded"]),
                FileSizeMB = drv["FileSizeMB"] as decimal?,
                PageCount = drv["PageCount"] as int?,
                FilePath = drv["FilePath"].ToString(),
                CoverImagePath = drv["CoverImagePath"].ToString(),
                Description = drv["Description"].ToString(),
                IsRead = Convert.ToBoolean(drv["IsRead"]),
                Rating = drv["Rating"] is DBNull ? 0 : Convert.ToInt32(drv["Rating"]),
                Notes = drv["Notes"].ToString()
            };
        }
    }
}