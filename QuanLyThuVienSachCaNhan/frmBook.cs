using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThuVienSachCaNhan
{
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
            
        }

        private void btnTimKiemNangCao_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void cbbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            cbbTimKiem.Text = "Tìm kiếm (VD: Tiêu đề, tác giả,...). Nhấp vào bánh răng bên trái để tìm kiếm nâng cao";
            cbbTimKiem.ForeColor = Color.Gray;

            cbbTimKiem.Enter += (s, ev) =>
            {
                if (cbbTimKiem.Text == "Tìm kiếm (VD: Tiêu đề, tác giả,...). Nhấp vào bánh răng bên trái để tìm kiếm nâng cao")
                {
                    cbbTimKiem.Text = "";
                    cbbTimKiem.ForeColor = Color.Black;
                }
            };

            cbbTimKiem.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(cbbTimKiem.Text))
                {
                    cbbTimKiem.Text = "Tìm kiếm (VD: Tiêu đề, tác giả,...). Nhấp vào bánh răng bên trái để tìm kiếm nâng cao";
                    cbbTimKiem.ForeColor = Color.Gray;
                }
            };
        }
    }
}
