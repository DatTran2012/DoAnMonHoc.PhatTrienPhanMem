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
    public partial class FrmSanPham : Form
    {
        protected string fileName = "D:\\DA_PTPM\\QuanLyCircleK\\Photos\\logoCK.png";
        protected string fileNameUpdate = null;
        protected string NCC2 = "";
        protected string LH2 = "";
        protected int co = 0;
        HangBLL hBLL = new HangBLL();

        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridViewSanPham.DataSource = hBLL.getByMaHangBLL(txtTimKiem.Text);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dataGridViewSanPham.DataSource = hBLL.getAllHangBLL();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaSP.ReadOnly = true;
            cbbNhaCungCap2.DataSource = hBLL.getAllNCCBLL();
            cbbNhaCungCap2.DisplayMember = "TenNCC";
            cbbNhaCungCap2.ValueMember = "MaNCC";
            cbbLoai2.DataSource = hBLL.getAllLHBLL();
            cbbLoai2.DisplayMember = "TenLoaiHang";
            cbbLoai2.ValueMember = "MaLoaiHang";

            txtMaSP.Text = hBLL.createMaSPTuDongBLL();
            

            txtHoTen.Text = "";
            txtDVT.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtGiamGia.Text = "";
            txtMoTaEdit.Text = "";
            txtSoLuong.Text = "";

            pictureBoxBrowse.Image = null;

            co = 0;
            fileName = "D:\\DA_PTPM\\QuanLyCircleK\\Photos\\logoCK.png";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            paneLuuHuy.Show();
            cbbNhaCungCap2.DataSource = hBLL.getAllNCCBLL();
            cbbNhaCungCap2.DisplayMember = "TenNCC";
            cbbNhaCungCap2.ValueMember = "MaNCC";
            cbbLoai2.DataSource = hBLL.getAllLHBLL();
            cbbLoai2.DisplayMember = "TenLoaiHang";
            cbbLoai2.ValueMember = "MaLoaiHang";

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaSP.ReadOnly = true;
            co = 1;
            txtMaSP.Text = dataGridViewSanPham.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dataGridViewSanPham.CurrentRow.Cells[1].Value.ToString();
            cbbLoai2.SelectedText = hBLL.getLoaiHangByMaLoaiHangBLL(dataGridViewSanPham.CurrentRow.Cells[2].Value.ToString()).Rows[0]["TenLoaiHang"].ToString();
            txtDVT.Text = dataGridViewSanPham.CurrentRow.Cells[3].Value.ToString(); ;
            txtGiaBan.Text = dataGridViewSanPham.CurrentRow.Cells[4].Value.ToString();
            txtGiaNhap.Text = dataGridViewSanPham.CurrentRow.Cells[5].Value.ToString();
            txtGiamGia.Text = dataGridViewSanPham.CurrentRow.Cells[6].Value.ToString();
            cbbNhaCungCap2.SelectedText = hBLL.getNhaCCByMaNCCBLL(dataGridViewSanPham.CurrentRow.Cells[7].Value.ToString()).Rows[0]["TenNCC"].ToString();
            txtMoTaEdit.Text = dataGridViewSanPham.CurrentRow.Cells[8].Value.ToString();
            txtSoLuong.Text = dataGridViewSanPham.CurrentRow.Cells[9].Value.ToString();
            NCC2 = dataGridViewSanPham.CurrentRow.Cells[7].Value.ToString();
            LH2 = dataGridViewSanPham.CurrentRow.Cells[2].Value.ToString();
            try
            {
                ImageConverter Iconver = new ImageConverter();
                pictureBoxBrowse.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxBrowse.Image = (Image)Iconver.ConvertFrom(dataGridViewSanPham.CurrentRow.Cells[10].Value);
            }
            catch
            {
                pictureBoxBrowse.Image = null;
            }
            fileNameUpdate = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = dataGridViewSanPham.CurrentRow.Cells[0].Value.ToString();
            if (ma == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (hBLL.deleteSPBLL(ma) == 1)
                    {
                        
                            MessageBox.Show("Xóa thành công");
                            dataGridViewSanPham.DataSource = hBLL.getAllHangBLL();
                        
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (co == 0)
            {
                //code button thêm
                if (txtHoTen.Text.Trim().Length == 0 || txtDVT.Text.Trim().Length == 0 || txtGiaBan.Text.Trim().Length == 0 || txtGiaNhap.Text.Trim().Length == 0 || txtGiamGia.Text.Trim().Length == 0 || txtSoLuong.Text.Trim().Length == 0 || int.Parse(txtSoLuong.Text) >= 2147483640)
                {
                    MessageBox.Show("Vui lòng nhập đúng thông tin");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm mới sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (hBLL.addNewSPBLL(txtMaSP.Text, txtHoTen.Text,cbbLoai2.SelectedValue.ToString(),txtDVT.Text, txtGiaBan.Text, txtGiaNhap.Text, txtGiamGia.Text, cbbNhaCungCap2.SelectedValue.ToString(),txtMoTaEdit.Text, int.Parse(txtSoLuong.Text), converImgToByte(fileName)) == 1)
                        {
                            
                                MessageBox.Show("Thêm thành công");
                                paneLuuHuy.Hide();
                                btnThem.Visible = true;
                                btnSua.Visible = true;
                                btnXoa.Visible = true;
                                dataGridViewSanPham.DataSource = hBLL.getAllHangBLL();
                            
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
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

                string ma = dataGridViewSanPham.CurrentRow.Cells[0].Value.ToString();
                if (ma == null)
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa sản phẩm?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //không update ảnh
                        if (fileNameUpdate == null)
                        {
                            if (hBLL.updateSPKhongAnhBLL(txtHoTen.Text, LH2, txtDVT.Text, txtGiaBan.Text, txtGiaNhap.Text, txtGiamGia.Text, NCC2, txtMoTaEdit.Text,int.Parse(txtSoLuong.Text),ma) == 1)
                            {
                                
                                    MessageBox.Show("Cập nhật thành công");
                                    paneLuuHuy.Hide();
                                    btnThem.Visible = true;
                                    btnSua.Visible = true;
                                    btnXoa.Visible = true;
                                    dataGridViewSanPham.DataSource = hBLL.getAllHangBLL();
                                
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thất bại");
                            }
                        }
                        //update ảnh
                        else
                        {
                            if (hBLL.updateSPCoAnhBLL(txtHoTen.Text, LH2, txtDVT.Text, txtGiaBan.Text, txtGiaNhap.Text, txtGiamGia.Text, NCC2, txtMoTaEdit.Text, int.Parse(txtSoLuong.Text), converImgToByte(fileNameUpdate), ma) == 1)
                            {
                                
                                    MessageBox.Show("Cập nhật thành công");
                                    paneLuuHuy.Hide();
                                    btnThem.Visible = true;
                                    btnSua.Visible = true;
                                    btnXoa.Visible = true;
                                    dataGridViewSanPham.DataSource = hBLL.getAllHangBLL();
                                    lblMaSP.Text = dataGridViewSanPham.CurrentRow.Cells[0].Value.ToString();
                                    lblTenSP.Text = dataGridViewSanPham.CurrentRow.Cells[1].Value.ToString();
                                    lblLoai.Text = hBLL.getLoaiHangByMaLoaiHangBLL(dataGridViewSanPham.CurrentRow.Cells[2].Value.ToString()).Rows[0]["TenLoaiHang"].ToString();
                                    lblDVT.Text = dataGridViewSanPham.CurrentRow.Cells[3].Value.ToString(); ;
                                    lblGiaBan.Text = dataGridViewSanPham.CurrentRow.Cells[4].Value.ToString();
                                    lblGiaNhap.Text = dataGridViewSanPham.CurrentRow.Cells[5].Value.ToString();
                                    lblGiamGia.Text = dataGridViewSanPham.CurrentRow.Cells[6].Value.ToString();
                                    lblNhaCungCap.Text = hBLL.getNhaCCByMaNCCBLL(dataGridViewSanPham.CurrentRow.Cells[7].Value.ToString()).Rows[0]["TenNCC"].ToString();
                                    txtMoTa.Text = dataGridViewSanPham.CurrentRow.Cells[8].Value.ToString();
                                    lblSoLuong.Text = dataGridViewSanPham.CurrentRow.Cells[9].Value.ToString();
                                    try
                                    {
                                        ImageConverter Iconver = new ImageConverter();
                                        pictureBoxHinh.SizeMode = PictureBoxSizeMode.StretchImage;
                                        pictureBoxHinh.Image = (Image)Iconver.ConvertFrom(dataGridViewSanPham.CurrentRow.Cells[10].Value);
                                    }
                                    catch
                                    {
                                        pictureBoxHinh.Image = null;
                                    }


                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thất bại");
                            }
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //lấy ảnh
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
                fileNameUpdate = openFile.FileName; ;
            }
            //load lên pb
            string stringbyte = Convert.ToBase64String(converImgToByte(fileName));
            pictureBoxBrowse.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBrowse.Image = ByteToImg(stringbyte);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            cbbNhaCungCap1.DataSource = hBLL.getAllNCCBLL();
            cbbNhaCungCap1.DisplayMember = "TenNCC";
            cbbNhaCungCap1.ValueMember = "MaNCC";
            cbbLoai1.DataSource = hBLL.getAllLHBLL();
            cbbLoai1.DisplayMember = "TenLoaiHang";
            cbbLoai1.ValueMember = "MaLoaiHang";

            paneLuuHuy.Hide();

            lblMaSP.Visible = false;
            lblTenSP.Visible = false;
            lblLoai.Visible = false;
            lblDVT.Visible = false;
            lblGiaBan.Visible = false;
            lblGiaNhap.Visible = false;
            lblGiamGia.Visible = false;
            lblNhaCungCap.Visible = false;
            txtMoTa.Visible = false;
            lblSoLuong.Visible = false;
            txtMoTa.ReadOnly = true;
            dataGridViewSanPham.ForeColor = Color.Black;
            dataGridViewSanPham.AllowUserToAddRows = false;
            dataGridViewSanPham.DataSource = hBLL.getAllHangBLL();
        }

        private void cbbNhaCungCap1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewSanPham.DataSource = hBLL.getByMaNCCBLL(cbbNhaCungCap1.SelectedValue.ToString());
        }

        private void cbbLoai1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewSanPham.DataSource = hBLL.getByMaLoaiBLL(cbbLoai1.SelectedValue.ToString());
        }

        private void dataGridViewSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMaSP.Visible = true;
            lblTenSP.Visible = true;
            lblLoai.Visible = true;
            lblDVT.Visible = true;
            lblGiaBan.Visible = true;
            lblGiaNhap.Visible = true;
            lblGiamGia.Visible = true;
            lblNhaCungCap.Visible = true;
            txtMoTa.Visible = true;
            lblSoLuong.Visible = true;

            lblMaSP.Text = dataGridViewSanPham.CurrentRow.Cells[0].Value.ToString();
            lblTenSP.Text = dataGridViewSanPham.CurrentRow.Cells[1].Value.ToString();
            lblLoai.Text = hBLL.getLoaiHangByMaLoaiHangBLL(dataGridViewSanPham.CurrentRow.Cells[2].Value.ToString()).Rows[0]["TenLoaiHang"].ToString();
            lblDVT.Text = dataGridViewSanPham.CurrentRow.Cells[3].Value.ToString(); ;
            lblGiaBan.Text = dataGridViewSanPham.CurrentRow.Cells[4].Value.ToString();
            lblGiaNhap.Text = dataGridViewSanPham.CurrentRow.Cells[5].Value.ToString();
            lblGiamGia.Text = dataGridViewSanPham.CurrentRow.Cells[6].Value.ToString();
            lblNhaCungCap.Text = hBLL.getNhaCCByMaNCCBLL(dataGridViewSanPham.CurrentRow.Cells[7].Value.ToString()).Rows[0]["TenNCC"].ToString();
            txtMoTa.Text = dataGridViewSanPham.CurrentRow.Cells[8].Value.ToString();
            lblSoLuong.Text = dataGridViewSanPham.CurrentRow.Cells[9].Value.ToString();
            try
            {
                ImageConverter Iconver = new ImageConverter();
                pictureBoxHinh.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxHinh.Image = (Image)Iconver.ConvertFrom(dataGridViewSanPham.CurrentRow.Cells[10].Value);
            }
            catch
            {
                pictureBoxHinh.Image = null;
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

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtHoTen, "Vui lòng nhập thông tin");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDVT_Leave(object sender, EventArgs e)
        {
            if (txtDVT.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtDVT, "Vui lòng nhập thông tin");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtGiaBan_Leave(object sender, EventArgs e)
        {
            if (txtGiaBan.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtGiaBan, "Vui lòng nhập thông tin");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtGiaNhap_Leave(object sender, EventArgs e)
        {
            if (txtGiaNhap.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtGiaNhap, "Vui lòng nhập thông tin");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtGiamGia_Leave(object sender, EventArgs e)
        {
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtGiamGia, "Vui lòng nhập thông tin");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtMoTaEdit_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Trim().Length == 0 )
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập thông tin");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbbLoai2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LH2 = cbbLoai2.SelectedValue.ToString();
        }

        private void cbbNhaCungCap2_SelectedIndexChanged(object sender, EventArgs e)
        {
            NCC2 = cbbNhaCungCap2.SelectedValue.ToString();
        }
    }
}
