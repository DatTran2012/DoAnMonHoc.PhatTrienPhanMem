using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmLoai : Form
    {
        protected int co = 0;
        LoaiBLL lhBLL = new LoaiBLL();
        public FrmLoai()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaLoai.ReadOnly = true;
            txtMaLoai.Text = lhBLL.createMaLoaiTuDongBLL();
            txtTenLoai.Text = "";
            co = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaLoai.ReadOnly = true;
            co = 1;
            txtMaLoai.Text = dataGridViewLoai.CurrentRow.Cells[0].Value.ToString();
            txtTenLoai.Text = dataGridViewLoai.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = dataGridViewLoai.CurrentRow.Cells[0].Value.ToString();
            if (ma == null)
            {
                MessageBox.Show("Vui lòng chọn một loại hàng");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa loại sản phẩm này? Nếu xóa loại sản này sẽ xóa tất cả các sản phẩm thuộc loại này!", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //đếm số lượng sp của loại đó, nếu = 0 thì xóa loại, !=0 thì xóa hàng -> loại
                    if (lhBLL.countHangMaLoaiBLL(ma) == 0) // không có sp nào
                    {
                        if (lhBLL.deleteMaLoaiBLL(ma) == 1)
                        {
                            MessageBox.Show("Xóa thành công");
                            dataGridViewLoai.DataSource = lhBLL.getAllLoaiBLL();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                    else //có sp
                    {
                        if (lhBLL.deleteHangTheoMaLoaiBLL(ma) == 1)
                        {
                            if (lhBLL.deleteMaLoaiBLL(ma) == 1)
                            {
                                MessageBox.Show("Xóa thành công");
                                dataGridViewLoai.DataSource = lhBLL.getAllLoaiBLL();
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(co==0)
            {
                //code thêm
                if (txtTenLoai.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm mới một loại sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (lhBLL.addLoaiHangBLL(txtMaLoai.Text,txtTenLoai.Text) == 1)
                        {
                            MessageBox.Show("Thêm thành công");
                            paneLuuHuy.Hide();
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            btnXoa.Visible = true;
                            dataGridViewLoai.DataSource = lhBLL.getAllLoaiBLL();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                            paneLuuHuy.Show();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        paneLuuHuy.Show();
                    }
                }
            }
            else
            {
                //code lưu
                string ma = dataGridViewLoai.CurrentRow.Cells[0].Value.ToString();
                if (ma == null)
                {
                    MessageBox.Show("Vui lòng chọn một loại hàng");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa loại hàng này?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (lhBLL.updateLoaiHangBLL(txtTenLoai.Text, txtMaLoai.Text) == 1)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            paneLuuHuy.Hide();
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            btnXoa.Visible = true;
                            dataGridViewLoai.DataSource = lhBLL.getAllLoaiBLL();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại");
                            paneLuuHuy.Show();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        paneLuuHuy.Show();
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridViewLoai.DataSource = lhBLL.getTheoMaBLL(txtTimKiem.Text);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dataGridViewLoai.DataSource = lhBLL.getAllLoaiBLL();
        }

        private void FrmLoai_Load(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            lblMaLoai.Visible = false;
            lblTenLoai.Visible = false;
            dataGridViewLoai.ForeColor = Color.Black;
            dataGridViewLoai.DataSource = lhBLL.getAllLoaiBLL();
            this.dataGridViewLoai.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;           
            this.dataGridViewLoai.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridViewLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMaLoai.Visible = true;
            lblTenLoai.Visible = true;
            lblMaLoai.Text = dataGridViewLoai.CurrentRow.Cells[0].Value.ToString();
            lblTenLoai.Text = dataGridViewLoai.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtTenLoai_Leave(object sender, EventArgs e)
        {
            if (txtTenLoai.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTenLoai, "Vui lòng nhập tên loại");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
