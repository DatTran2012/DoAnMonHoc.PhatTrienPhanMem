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
    public partial class FrmKhachHang : Form
    {
        protected int co = 0;
        KhachHangDLL khBLL = new KhachHangDLL();
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridViewKhachHang.DataSource = khBLL.getKHByMaKHBLLL(txtTimKiem.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            lblMaKH.Visible = false;
            lblHoTenKH.Visible = false;
            lblDienThoai.Visible = false;
            lblDiemTL.Visible = false;         

            dataGridViewKhachHang.ForeColor = Color.Black;
            dataGridViewKhachHang.AllowUserToAddRows = false;

            dataGridViewKhachHang.DataSource = khBLL.getAllKHBLL();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dataGridViewKhachHang.DataSource = khBLL.getAllKHBLL();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = dataGridViewKhachHang.CurrentRow.Cells[0].Value.ToString();
            if (ma == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa khách hàng?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Xóa KH, nếu kh có hóa đơn thì update mã kh của HD về null -> xóa
                    if(khBLL.countHDofKHDAL(ma)==0)//không có hóa đơn nào
                    {
                        //xóa tt
                        if (khBLL.deleteKhachHangBLL(ma) == 1)
                        {
                            MessageBox.Show("Xóa thành công");
                            dataGridViewKhachHang.DataSource = khBLL.getAllKHBLL();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                    else//có hóa đơn
                    {
                        //update makh trong hd
                        if(khBLL.updateMaKHBLL(khBLL.getHDByMAHDBLL(ma).Rows[0]["MaHD"].ToString())==1)
                        {
                            if(khBLL.deleteKhachHangBLL(ma)==1)
                            {
                                MessageBox.Show("Xóa thành công");
                                dataGridViewKhachHang.DataSource = khBLL.getAllKHBLL();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaKH.ReadOnly = true;

            co = 1;
            txtMaKH.Text = dataGridViewKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dataGridViewKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtDT.Text = dataGridViewKhachHang.CurrentRow.Cells[2].Value.ToString();
            lblDiemTichLuy.Text= dataGridViewKhachHang.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaKH.ReadOnly = true;

            txtMaKH.Text = khBLL.createMaKHTuDongBLL();
            
            

            txtHoTen.Text = "";
            txtDT.Text = "";
            lblDiemTichLuy.Text = "0";
            

            co = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (co == 0)
            {
                //code thêm
                if (txtMaKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm mới một khách hàng?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (khBLL.addNewKHBLL(txtMaKH.Text, txtHoTen.Text,txtDT.Text,1,0) == 1)
                        {
                            MessageBox.Show("Thêm thành công");
                            paneLuuHuy.Hide();
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            btnXoa.Visible = true;
                            dataGridViewKhachHang.DataSource = khBLL.getAllKHBLL();
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
                string ma = dataGridViewKhachHang.CurrentRow.Cells[0].Value.ToString();
                if (ma == null)
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa khách hàng?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (khBLL.updateKHBLL(txtHoTen.Text, txtDT.Text,ma) == 1)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            paneLuuHuy.Hide();
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            btnXoa.Visible = true;
                            dataGridViewKhachHang.DataSource = khBLL.getAllKHBLL();
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

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMaKH.Visible = true;
            lblHoTenKH.Visible = true;
            lblDienThoai.Visible = true;
            lblDiemTL.Visible = true;
            lblMaKH.Text = dataGridViewKhachHang.CurrentRow.Cells[0].Value.ToString();
            lblHoTenKH.Text = dataGridViewKhachHang.CurrentRow.Cells[1].Value.ToString();
            lblDienThoai.Text = dataGridViewKhachHang.CurrentRow.Cells[2].Value.ToString();
            lblDiemTL.Text = dataGridViewKhachHang.CurrentRow.Cells[4].Value.ToString();
        }

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtHoTen, "Vui lòng nhập họ và tên");
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
                errorProvider1.SetError(txtDT, "Vui lòng nhập họ và tên");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
