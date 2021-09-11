using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using BLL;

namespace GUI
{
    public partial class FrmMain : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private string username;
        MainBLL mBLL = new MainBLL();
        public FrmMain()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            customizeDesing();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        public FrmMain(string user)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            customizeDesing();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.username = user;
        }
        
        private void customizeDesing()
        {
            panelsubNhanVien.Visible = false;
            panelsubHangHoa.Visible = false;
            panelsubBanHang.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelsubNhanVien.Visible == true)
                panelsubNhanVien.Visible = false;
            if (panelsubHangHoa.Visible == true)
                panelsubHangHoa.Visible = false;
            if (panelsubBanHang.Visible == true)
                panelsubBanHang.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible==false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color mauCam = Color.FromArgb(208, 62, 52); 
        }
        private void ActivevateButton(object senderBtn,Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(255, 238, 140, 1);
                //currentBtn.BackColor = Color.Red;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconChild.IconChar = currentBtn.IconChar;
                iconChild.IconColor = Color.FromArgb(255, 238, 140, 1);
            }    
        }
        

        private void DisableButton()
        {
            if(currentBtn != null)
            {
               
                currentBtn.BackColor = Color.FromArgb(208, 62, 52);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft ;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }    
        }
        
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
             ActivevateButton(sender, RGBColors.mauCam);
            showSubMenu(panelsubNhanVien);
            lbChild.Text = "Nhân Viên";

        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            ActivevateButton(sender, RGBColors.mauCam);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivevateButton(sender, RGBColors.mauCam);
            showSubMenu(panelsubHangHoa);
            lbChild.Text = "Hàng Hóa";
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivevateButton(sender, RGBColors.mauCam);
            showSubMenu(panelsubBanHang);
            lbChild.Text = "Bán Hàng";
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FrmQuanLy());
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            openChildForm(new FrmCaNhan(username));
        }
        public void funData(Label txtForm1)
        {
            label1.Text = txtForm1.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FrmNhaCungCap());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FrmLoai());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FrmSanPham());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivevateButton(sender, RGBColors.mauCam);
            hideSubMenu();
            openChildForm(new FrmKhachHang());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FrmThanhToan(username));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FrmHoaDon());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivevateButton(sender, RGBColors.mauCam);
            hideSubMenu();
            openChildForm(new FrmBaoCao());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivevateButton(sender, RGBColors.mauCam);
            hideSubMenu();
            openChildForm(new FrmBaoCao());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Reset();
            openChildForm(new FrmHome());
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconChild.IconChar = IconChar.Home;
            iconChild.IconColor = Color.White;
            lbChild.Text = "Home";
        }
        //
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg,int wParam,int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void openChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbChild.Text = childForm.Text;
                
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {           
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {           
        }

        private void panelTitleBar_DoubleClick(object sender, EventArgs e)
        {
        }

        private void panelTitleBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {                      
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {           
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)            
                WindowState = FormWindowState.Maximized;           
            else WindowState = FormWindowState.Normal;
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            openChildForm(new FrmHome());
            lblNameDangNhap.Text = mBLL.getNamebyUserBLL(username).Rows[0]["TenNV"].ToString();
            if(mBLL.getPhanQuyenBLL(username).Rows[0]["PhanQuyen"].ToString()=="1")
            {
                btnQuanLy.Visible = false;
                btnHangHoa.Visible = false;
                btnHoaDon.Visible = false;
                btnBaoCao.Visible = false;
            }    

        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            ActivevateButton(sender, RGBColors.mauCam);
            hideSubMenu();
            openChildForm(new FrmHoTro());
        }
    }
}
