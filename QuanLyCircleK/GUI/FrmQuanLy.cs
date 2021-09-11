using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmQuanLy : Form
    {
        protected string fileName = "D:\\DA_PTPM\\QuanLyCircleK\\Photos\\avt.png";
        protected string fileNameUpdate = null;
        protected int co = 0;
        QuanLyBLL qlBLL = new QuanLyBLL();
        
        public FrmQuanLy()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            lblMaNV.Visible = false;
            lblHoTen.Visible = false;
            lblNgaySinh.Visible = false;
            lblGioiTinh.Visible = false;
            lblDienThoai.Visible = false;
            lblDiaChi.Visible = false;
            lblNgayVaoLam.Visible = false;
            lblChucVu.Visible = false;

            dataGridViewNhanVien.ForeColor = Color.Black;
            dataGridViewNhanVien.AllowUserToAddRows = false;
            
            dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienBLL();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaNV.ReadOnly = true;

            txtMaNV.Text = qlBLL.createMaNhanVienTuDongBLL();
            cbbChucVu.Text = "Nhân viên";
            rdoNam.Checked = true;

            txtHoTen.Text = "";
            txtDT.Text = "";
            txtDiaChi.Text = "";
            pictureBoxBrowse.Image = null;

            co = 0;
            fileName = "D:\\DA_PTPM\\QuanLyCircleK\\Photos\\avt.png";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Show();

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            txtMaNV.ReadOnly = true;

            co = 1;
            txtMaNV.Text = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dataGridViewNhanVien.CurrentRow.Cells[1].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(dataGridViewNhanVien.CurrentRow.Cells[2].Value.ToString());
            string gt = dataGridViewNhanVien.CurrentRow.Cells[3].Value.ToString();
            if (gt == "Nam")
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
            txtDT.Text = dataGridViewNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridViewNhanVien.CurrentRow.Cells[5].Value.ToString();
            dtpNgayVL.Value = Convert.ToDateTime(dataGridViewNhanVien.CurrentRow.Cells[6].Value.ToString());
            cbbChucVu.SelectedItem = dataGridViewNhanVien.CurrentRow.Cells[7].Value.ToString();
            try
            {
                ImageConverter Iconver = new ImageConverter();
                pictureBoxBrowse.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxBrowse.Image = (Image)Iconver.ConvertFrom(dataGridViewNhanVien.CurrentRow.Cells[9].Value);
            }
            catch
            {
                pictureBoxBrowse.Image = null;
            }
            fileNameUpdate = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //btnThem.Visible = true;
            //btnSua.Visible = true;
            //btnXoa.Visible = true;



            if (co == 0)
            {
                //code button thêm
                if (txtHoTen.Text.Trim().Length == 0 || txtDT.Text.Trim().Length == 0 || txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm nhân viên?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (qlBLL.addNhanVienBLL(txtMaNV.Text, txtHoTen.Text, dtpNgaySinh.Value.ToString(), ktgioiTinh(rdoNam), txtDT.Text, txtDiaChi.Text, dtpNgayVL.Value.ToString(), cbbChucVu.SelectedItem.ToString(), 1, converImgToByte(fileName)) == 1)
                        {
                            if (qlBLL.addAccountBLL(txtMaNV.Text, "123", phanquyen(cbbChucVu.SelectedItem.ToString()), 1) == 1)
                            {
                                MessageBox.Show("Thêm thành công");
                                paneLuuHuy.Hide();
                                btnThem.Visible = true;
                                btnSua.Visible = true;
                                btnXoa.Visible = true;
                                dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienBLL();
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại");
                            }
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
                
                string ma = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
                if(ma==null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa nhân viên?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //không update ảnh
                        if (fileNameUpdate == null)
                        {
                            if (qlBLL.updateNhanVienKhongAnhBLL(txtHoTen.Text, dtpNgaySinh.Value.ToString(), ktgioiTinh(rdoNam), txtDT.Text, txtDiaChi.Text, dtpNgayVL.Value.ToString(), cbbChucVu.SelectedItem.ToString(), txtMaNV.Text) == 1)
                            {
                                if(qlBLL.updatePQTheoCVBLL(phanquyen(cbbChucVu.SelectedItem.ToString()),txtMaNV.Text,qlBLL.getMKByMaNVBLL(txtMaNV.Text))==1)
                                {
                                    MessageBox.Show("Cập nhật thành công");
                                    paneLuuHuy.Hide();
                                    btnThem.Visible = true;
                                    btnSua.Visible = true;
                                    btnXoa.Visible = true;
                                    dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienBLL();
                                }
                                else
                                {
                                    MessageBox.Show("Cập nhật thất bại");
                                }    
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thất bại");
                            }
                        }
                        //update ảnh
                        else
                        {
                            if (qlBLL.updateNhanVienCoAnhBLL(txtHoTen.Text, dtpNgaySinh.Value.ToString(), ktgioiTinh(rdoNam), txtDT.Text, txtDiaChi.Text, dtpNgayVL.Value.ToString(), cbbChucVu.SelectedItem.ToString(), converImgToByte(fileNameUpdate), txtMaNV.Text) == 1)
                            {
                                if (qlBLL.updatePQTheoCVBLL(phanquyen(cbbChucVu.SelectedItem.ToString()), txtMaNV.Text, qlBLL.getMKByMaNVBLL(txtMaNV.Text)) == 1)
                                {
                                    MessageBox.Show("Cập nhật thành công");
                                    paneLuuHuy.Hide();
                                    btnThem.Visible = true;
                                    btnSua.Visible = true;
                                    btnXoa.Visible = true;
                                    dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienBLL();
                                    lblMaNV.Text = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
                                    lblHoTen.Text = dataGridViewNhanVien.CurrentRow.Cells[1].Value.ToString();
                                    DateTime dateNS = Convert.ToDateTime(dataGridViewNhanVien.CurrentRow.Cells[2].Value.ToString());
                                    lblNgaySinh.Text = dateNS.ToString("dd/MM/yyyy");
                                    lblGioiTinh.Text = dataGridViewNhanVien.CurrentRow.Cells[3].Value.ToString();
                                    lblDienThoai.Text = dataGridViewNhanVien.CurrentRow.Cells[4].Value.ToString();
                                    lblDiaChi.Text = dataGridViewNhanVien.CurrentRow.Cells[5].Value.ToString();
                                    DateTime dateNVL = Convert.ToDateTime(dataGridViewNhanVien.CurrentRow.Cells[6].Value.ToString());
                                    lblNgayVaoLam.Text = dateNVL.ToString("dd/MM/yyyy");
                                    lblChucVu.Text = dataGridViewNhanVien.CurrentRow.Cells[7].Value.ToString();
                                    try
                                    {
                                        ImageConverter Iconver = new ImageConverter();
                                        pictureBoxHinh1.SizeMode = PictureBoxSizeMode.StretchImage;
                                        pictureBoxHinh1.Image = (Image)Iconver.ConvertFrom(dataGridViewNhanVien.CurrentRow.Cells[9].Value);
                                    }
                                    catch
                                    {
                                        pictureBoxHinh1.Image = null;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Cập nhật thất bại");
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
        private int phanquyen(string cv)
        {
            if (cv == "Nhân viên")
                return 1;
            else return 0;
        }
        private string ktgioiTinh(RadioButton rdo)
        {
            if (rdo.Checked == true)
            {
                return "Nam";
            }
            else return "Nữ";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            paneLuuHuy.Hide();

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
            if(ma==null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa nhân viên?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if(qlBLL.deleteAccountBLL(ma) == 1) 
                    {
                        if(qlBLL.deleteNhanVienBLL(ma) == 1)
                        {
                            MessageBox.Show("Xóa thành công");
                            dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienBLL();
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
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }    
        }

        private void lblHoTen_Click(object sender, EventArgs e)
        {

        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex("^[0-9]+$", RegexOptions.Compiled);
            return regex.IsMatch(pText);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(IsNumber(txtTimKiem.Text))
            {
                dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienTheoMaBLL(txtTimKiem.Text);
            }
            else
            {
                dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienTheoTenBLL(txtTimKiem.Text);
            }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dataGridViewNhanVien.DataSource = qlBLL.getDataNhanVienBLL();
        }

        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMaNV.Visible = true;
            lblHoTen.Visible = true;
            lblNgaySinh.Visible = true;
            lblGioiTinh.Visible = true;
            lblDienThoai.Visible = true;
            lblDiaChi.Visible = true;
            lblNgayVaoLam.Visible = true;
            lblChucVu.Visible = true;

            lblMaNV.Text = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
            lblHoTen.Text = dataGridViewNhanVien.CurrentRow.Cells[1].Value.ToString();
            DateTime dateNS = Convert.ToDateTime(dataGridViewNhanVien.CurrentRow.Cells[2].Value.ToString());
            lblNgaySinh.Text = dateNS.ToString("dd/MM/yyyy");
            lblGioiTinh.Text = dataGridViewNhanVien.CurrentRow.Cells[3].Value.ToString();
            lblDienThoai.Text = dataGridViewNhanVien.CurrentRow.Cells[4].Value.ToString();
            lblDiaChi.Text = dataGridViewNhanVien.CurrentRow.Cells[5].Value.ToString();
            DateTime dateNVL = Convert.ToDateTime(dataGridViewNhanVien.CurrentRow.Cells[6].Value.ToString());
            lblNgayVaoLam.Text = dateNVL.ToString("dd/MM/yyyy");
            lblChucVu.Text = dataGridViewNhanVien.CurrentRow.Cells[7].Value.ToString();
            try
            {
                ImageConverter Iconver = new ImageConverter();
                pictureBoxHinh1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxHinh1.Image = (Image)Iconver.ConvertFrom(dataGridViewNhanVien.CurrentRow.Cells[9].Value);
            }
            catch
            {
                pictureBoxHinh1.Image = null;
            }
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
                errorProvider1.SetError(txtDT, "Vui lòng nhập số điện thoại");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDiaChi_Leave(object sender, EventArgs e)
        {
            if (txtDT.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtDT, "Vui lòng nhập địa chỉ");
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
