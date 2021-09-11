using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmCaNhan : Form
    {
        //mã truyền từ form đăng nhập
        protected string maNV;
        protected string fileName = null;
        
        CaNhanBLL cnBLL = new CaNhanBLL();
        public FrmCaNhan()
        {
            InitializeComponent();
        }
        public FrmCaNhan(string user)
        {
            InitializeComponent();
            this.maNV = user;
        }
        
        private void btnThemAnhMoi_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
                string stringbyte = Convert.ToBase64String(converImgToByte(fileName));
                pictureBoxAVT.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxAVT.Image = ByteToImg(stringbyte);
                if (cnBLL.updateAnhBLL(converImgToByte(fileName), blMa.Text) == 1)
                {
                    MessageBox.Show("Thêm ảnh mới thành công");
                }
                else
                {
                    MessageBox.Show("Thêm ảnh mới thất bại");
                }
            }
            
            
        }
        private byte[] converImgToByte(string fileName)
        {
            FileStream fs;
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            panelDoiMatKhau.Show();
            txtMKHienTai.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
        }

        private void FrmCaNhan_Load(object sender, EventArgs e)
        {
            
            panelDoiMatKhau.Hide();
            blMa.Text = cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["MaNV"].ToString();
            lblTen.Text = cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["TenNV"].ToString();
            DateTime dateNS = Convert.ToDateTime(cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["NgaySinh"].ToString());
            lblNS.Text = dateNS.ToString("dd/MM/yyyy");           
            lblGioitinh.Text = cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["GioiTinh"].ToString();
            lblSDT.Text = cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["SDT"].ToString();
            lblDC.Text = cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["DiaChi"].ToString();
            DateTime dateNVL = Convert.ToDateTime(cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["NgayVaoLam"].ToString());
            lblNVL.Text = dateNVL.ToString("dd/MM/yyyy");
            lblCV.Text= cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["ChucVu"].ToString();
            lblTinhTrang.Text = getTinhTrang(int.Parse(cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["TinhTrang"].ToString()));
            try
            {
                ImageConverter Iconver = new ImageConverter();
                pictureBoxAVT.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxAVT.Image = (Image)Iconver.ConvertFrom(cnBLL.getDataMaNVTenNVBLL(maNV).Rows[0]["HinhAnh"]);
            }
            catch
            {
                pictureBoxAVT.Image = null;
            }
            txtMKHienTai.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }
        private string getTinhTrang(int tt)
        {
            if (tt == 1)
                return "Còn làm việc";
            else
            {
                return "Nghỉ làm việc";
            }
                    
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xác nhận thay đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    //kiểm tra mật khẩu hiện tại
                    string mk = cnBLL.getMaKhauBLL(blMa.Text);
                    if (mk.Trim().Equals(txtMKHienTai.Text.Trim()))
                    {
                        //kiểm tra mật khẩu mới
                        if (txtMatKhauMoi.Text.Trim().Equals(txtNhapLaiMatKhau.Text.Trim()))
                        {
                            if (cnBLL.updatePWBLL(txtNhapLaiMatKhau.Text, blMa.Text) == 1)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công");
                                panelDoiMatKhau.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Đổi mật khẩu thất bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không khớp");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng yêu cầu");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                panelDoiMatKhau.Show();
            }

               
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelDoiMatKhau.Hide();

        }

        private void txtMatKhauMoi_Leave(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.Trim().Length < 6 )
            {
                txtMatKhauMoi.Focus();
                errorProvider1.SetError(txtMatKhauMoi, "Mật khẩu phải dài hơn 5 kí tự");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtNhapLaiMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtNhapLaiMatKhau.Text.Trim().Length < 6)
            {
                txtNhapLaiMatKhau.Focus();
                errorProvider1.SetError(txtNhapLaiMatKhau, "Mật khẩu phải dài hơn 5 kí tự");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
