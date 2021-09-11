using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmNhaCungCap : Form
    {
        protected int co = 0;
        NhaCungCapBLL nccBLL = new NhaCungCapBLL();
        public FrmNhaCungCap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaNCC.ReadOnly = true;
            txtMaNCC.Text = nccBLL.createMaNCCTuDongBLL();
            txtTenNCC.Text = "";
            txtDT.Text = "";
            txtDiaChi.Text = "";
            co = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaNCC.ReadOnly = true;
            co = 1;
            txtMaNCC.Text = dataGridViewNhaCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dataGridViewNhaCC.CurrentRow.Cells[1].Value.ToString();
            txtDT.Text = dataGridViewNhaCC.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridViewNhaCC.CurrentRow.Cells[3].Value.ToString();
            txtEditMoTa.Text = dataGridViewNhaCC.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = dataGridViewNhaCC.CurrentRow.Cells[0].Value.ToString();
            if (ma == null)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa nhà cung cấp? Nếu xóa nhà cung cấp này sẽ xóa tất cả các sản phẩm thuộc nhà cung cấp này!", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //đếm số lượng sp của nhà cc đó, nếu = 0 thì xóa ncc, !=0 thì xóa hang -> ncc
                    if(nccBLL.countHangMaNCCBLL(ma)==0) // không có sp nào
                    {
                        if (nccBLL.deleteNCCBLL(ma) == 1)
                        {
                            MessageBox.Show("Xóa thành công");
                            dataGridViewNhaCC.DataSource = nccBLL.getDataNCCBLL();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    } 
                    else //có sp
                    {
                        if (nccBLL.deleteHangTheoNCCBLL(ma) == 1)
                        {
                            if (nccBLL.deleteNCCBLL(ma) == 1)
                            {
                                MessageBox.Show("Xóa thành công");
                                dataGridViewNhaCC.DataSource = nccBLL.getDataNCCBLL();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            lblMaNCC.Visible = false;
            lblTenNCC.Visible = false;
            lblSDT.Visible = false;
            lblDiaChi.Visible = false;
            txtMoTa.Visible = false;
            dataGridViewNhaCC.ForeColor = Color.Black;
            dataGridViewNhaCC.AllowUserToAddRows = false;
            dataGridViewNhaCC.DataSource = nccBLL.getDataNCCBLL();
        }

        private void dataGridViewNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMaNCC.Visible = true;
            lblTenNCC.Visible = true;
            lblSDT.Visible = true;
            lblDiaChi.Visible = true;
            txtMoTa.Visible = true;
            lblMaNCC.Text = dataGridViewNhaCC.CurrentRow.Cells[0].Value.ToString();
            lblTenNCC.Text = dataGridViewNhaCC.CurrentRow.Cells[1].Value.ToString();
            lblSDT.Text = dataGridViewNhaCC.CurrentRow.Cells[2].Value.ToString();
            lblDiaChi.Text = dataGridViewNhaCC.CurrentRow.Cells[3].Value.ToString();
            txtMoTa.Text = dataGridViewNhaCC.CurrentRow.Cells[4].Value.ToString();
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex("^[0-9]+$", RegexOptions.Compiled);
            return regex.IsMatch(pText);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
                dataGridViewNhaCC.DataSource = nccBLL.getDataNCCTheoMa(txtTimKiem.Text);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dataGridViewNhaCC.DataSource = nccBLL.getDataNCCBLL();
        }

        private void txtMaNCC_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTenNCC_Leave(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTenNCC, "Vui lòng nhập họ và tên");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDiaChi_Leave(object sender, EventArgs e)
        {
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTenNCC, "Vui lòng nhập họ và tên");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDT_Leave(object sender, EventArgs e)
        {
            if (txtDT.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTenNCC, "Vui lòng nhập họ và tên");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            

            
            if (co == 0)
            {
                //code button thêm
                if (txtTenNCC.Text.Trim().Length == 0 || txtDT.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm mới nhà cung cấp?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (nccBLL.addNhaCungCapBLL(txtMaNCC.Text, txtTenNCC.Text, txtDT.Text, txtDiaChi.Text, txtEditMoTa.Text) == 1)
                        {
                            MessageBox.Show("Thêm thành công");
                            paneLuuHuy.Hide();
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            btnXoa.Visible = true;
                            dataGridViewNhaCC.DataSource = nccBLL.getDataNCCBLL();
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
                //code button sửa
                string ma = dataGridViewNhaCC.CurrentRow.Cells[0].Value.ToString();
                if (ma == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa nhà cung cấp?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if(nccBLL.updateNCCBLL(txtTenNCC.Text,txtDT.Text,txtDiaChi.Text,txtEditMoTa.Text,txtMaNCC.Text)==1)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            paneLuuHuy.Hide();
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            btnXoa.Visible = true;
                            dataGridViewNhaCC.DataSource = nccBLL.getDataNCCBLL();
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
    }
}
