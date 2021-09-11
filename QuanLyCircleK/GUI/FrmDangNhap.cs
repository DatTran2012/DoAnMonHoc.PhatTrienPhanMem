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
    public partial class FrmDangNhap : Form
    {
        DangNhapBLL dnBLL = new DangNhapBLL();
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
           if(txtTK.Text.Trim().Length==0 || txtMK.Text.Trim().Length==0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }    
           else
            {
                if (dnBLL.getDataMaNVTenNVBLL(txtTK.Text).Rows[0]["MaNV"].ToString().Trim().Equals(txtTK.Text.Trim()) && dnBLL.getDataMaNVTenNVBLL(txtTK.Text).Rows[0]["MatKhau"].ToString().Trim().Equals(txtMK.Text))
                {



                    FrmMain frm = new FrmMain(txtTK.Text.Trim());
                    this.Hide();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }    
        }
        public delegate void delPassData(TextBox text);
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = true;
        }
    }
}
