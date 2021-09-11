using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.MachineLearning;
using Accord.MachineLearning.Rules;
using BLL;

namespace GUI
{
    public partial class FrmThanhToan : Form
    {
        private string userName  ;
        ThanhToanBLL ttBLL = new ThanhToanBLL();
        DataTable dt = new DataTable();
        double tt = 0;
         
        public FrmThanhToan()
        {
            InitializeComponent();
        }
        public FrmThanhToan(string user)
        {
            InitializeComponent();
            this.userName = user;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaSP.Text.Trim().Length==0 || txtSL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if(ttBLL.getHangByMaHangBLL(txtMaSP.Text.Trim()).Rows.Count==0)
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại");
                }
                else
                {
                    //kiểm tra đủ số lượng
                    if(int.Parse(txtSL.Text) > int.Parse( ttBLL.getHangByMaHangBLL(txtMaSP.Text).Rows[0]["SoLuong"].ToString()))
                    {
                        MessageBox.Show("Sản phẩm này số lượng chỉ còn: " + ttBLL.getHangByMaHangBLL(txtMaSP.Text).Rows[0]["SoLuong"].ToString() + "");
                    }  
                    else
                    {

                        //nếu trùng mã thì add số lượng
                        if (dataGridViewThanhToan.Rows.Count != 0)
                        {


                            if (ktTrung(dataGridViewThanhToan, 0, txtMaSP.Text.Trim()) == 1)
                            {
                                int vt = vtTrung(dataGridViewThanhToan, 0, txtMaSP.Text.Trim());
                                int sl = int.Parse(dataGridViewThanhToan.Rows[vt].Cells[2].Value.ToString()) + int.Parse(txtSL.Text);
                                dataGridViewThanhToan.Rows.RemoveAt(vt);
                                
                                //Thêm sp vào dgv
                                dt.Rows.Add( ttBLL.getHangByMaHangBLL(txtMaSP.Text.Trim()).Rows[0]["MaHang"].ToString(), ttBLL.getHangByMaHangBLL(txtMaSP.Text).Rows[0]["TenHang"].ToString(), sl);
                                tt = tt + double.Parse(ttBLL.getHangByMaHangBLL(txtMaSP.Text.Trim()).Rows[0]["DonGia"].ToString()) * int.Parse(txtSL.Text.Trim());
                                label4.Text = tt.ToString();
                                label5.Text = "VND";
                                txtMaSP.Text = "";
                                txtSL.Text = "";
                                txtMaKH.Text = "";
                                
                            }
                            else
                            {
                               
                                //Thêm sp vào dgv
                                dt.Rows.Add( ttBLL.getHangByMaHangBLL(txtMaSP.Text).Rows[0]["MaHang"].ToString(), ttBLL.getHangByMaHangBLL(txtMaSP.Text).Rows[0]["TenHang"].ToString(), int.Parse(txtSL.Text));
                                tt = tt + double.Parse(ttBLL.getHangByMaHangBLL(txtMaSP.Text.Trim()).Rows[0]["DonGia"].ToString()) * int.Parse(txtSL.Text.Trim());
                                label4.Text = tt.ToString();
                                label5.Text = "VND";
                                txtMaSP.Text = "";
                                txtSL.Text = "";
                                txtMaKH.Text = "";
                            }    


                        }
                        else
                        {
                            
                            //Thêm sp vào dgv
                            dt.Rows.Add( ttBLL.getHangByMaHangBLL(txtMaSP.Text).Rows[0]["MaHang"].ToString(), ttBLL.getHangByMaHangBLL(txtMaSP.Text).Rows[0]["TenHang"].ToString(), int.Parse(txtSL.Text));
                            
                             tt =tt+ double.Parse(ttBLL.getHangByMaHangBLL(txtMaSP.Text.Trim()).Rows[0]["DonGia"].ToString())*int.Parse(txtSL.Text.Trim());
                            label4.Text=tt.ToString();
                            label5.Text = "VND";
                            txtMaSP.Text = "";
                            txtSL.Text = "";
                            txtMaKH.Text = "";
                        }
                        
                        
                    }
                }
            }
        }
        private int vtTrung(DataGridView dgv,int cell,string s)
        {
            int vt=0;
            for(int i = 0;i<dgv.Rows.Count;i++)
            {
                if(dgv.Rows[i].Cells[cell].Value.ToString().Trim()==s)
                {
                    vt = i;
                    
                }
                
            }
            return vt;     
        }
        private int ktTrung(DataGridView dgv, int cell, string s)
        {
            
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[cell].Value.ToString().Trim() == s)
                {
                    return 1;
                    

                }
                

            }
            return 0;
        }
        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            dt.Columns.Add("Mã Sản Phẩm", typeof(string));
            dt.Columns.Add("Tên Sản Phẩm", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dataGridViewThanhToan.ForeColor = Color.Black;
            dataGridViewThanhToan.AllowUserToAddRows = false;
            dataGridViewThanhToan.DataSource = dt;
            this.dataGridViewThanhToan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewThanhToan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            
            this.dataGridViewThanhToan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            int slR = dataGridViewThanhToan.RowCount;
            for (int i = slR; i>0;i--)
            {
                dataGridViewThanhToan.Rows.RemoveAt(i-1);
            }    
            txtMaSP.Text = "";
            txtSL.Text = "";
            txtMaKH.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {           
            if(dataGridViewThanhToan.Rows.Count==0)
            {
                MessageBox.Show("Không có sản phẩm nào để thanh toán");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn thanh toán?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string maTD = ttBLL.createMaHDTuDongDAL();

                    if (txtMaKH.Text.Trim().Length == 0)
                    {
                        //Thanh toán không nhập mã KH
                        //Thanh toán insert data vào bảng ctHD, insert mã td,mã sp,soluong,dongia,giamgia,thành tiền = soluongxdongia-giamgia
                        //update lại số lượng sp 
                        //update lại thành tiền của hd


                        if (ttBLL.addHoaDonKhongMaKHDBLL(maTD, DateTime.Now.ToString(), userName, null) == 1)
                        {

                            for (int i = 0; i < dataGridViewThanhToan.RowCount; i++)
                            {
                                int sl;
                                Int32.TryParse(dataGridViewThanhToan.Rows[i].Cells[2].Value.ToString(), out sl);
                                string mah = dataGridViewThanhToan.Rows[i].Cells[0].Value.ToString();
                                int dg = int.Parse(ttBLL.getHangByMaHangBLL(mah).Rows[0]["DonGia"].ToString());
                                int gg = int.Parse(ttBLL.getHangByMaHangBLL(mah).Rows[0]["GiamGia"].ToString());
                                int tt = (sl * dg) - gg;
                                if (ttBLL.addCTHDBLL(maTD, dataGridViewThanhToan.Rows[i].Cells[0].Value.ToString(), sl, dg.ToString(), gg.ToString(), tt.ToString()) == 1)
                                {
                                    if (ttBLL.updateSLBLL(int.Parse(ttBLL.getHangByMaHangBLL(mah).Rows[0]["SoLuong"].ToString()) - sl, mah) == 1)
                                    {
                                        double thanhtien;
                                        Double.TryParse(ttBLL.getHDByMaHDBLL(maTD).Rows[0]["ThanhTien"].ToString(), out thanhtien);
                                        if (ttBLL.updateThanhTienHDBLL((thanhtien + tt).ToString(), maTD) == 1)
                                        {
                                            
                                            
                                            lblThanhTien.Text = ttBLL.getHDByMaHDBLL(maTD).Rows[0]["ThanhTien"].ToString();
                                            lblThanhTien.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Thanh toán thất bại");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Thanh toán thất bại");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Thanh toán thất bại");
                                }
                            }
                            MessageBox.Show("Thanh toán thành công");

                        }
                        else
                        {
                            MessageBox.Show("Thanh toán thất bại");
                        }
                    }
                    else
                    {
                        //Thanh toán nhập mã KH
                        if (ttBLL.addHoaDonKhongMaKHDBLL(maTD, DateTime.Now.ToString(), userName, txtMaKH.Text) == 1)
                        {

                            for (int i = 0; i < dataGridViewThanhToan.RowCount; i++)
                            {
                                int sl;
                                Int32.TryParse(dataGridViewThanhToan.Rows[i].Cells[2].Value.ToString(), out sl);
                                string mah = dataGridViewThanhToan.Rows[i].Cells[0].Value.ToString();
                                int dg = int.Parse(ttBLL.getHangByMaHangBLL(mah).Rows[0]["DonGia"].ToString());
                                int gg = int.Parse(ttBLL.getHangByMaHangBLL(mah).Rows[0]["GiamGia"].ToString());
                                int tt = (sl * dg) - gg;
                                if (ttBLL.addCTHDBLL(maTD, dataGridViewThanhToan.Rows[i].Cells[0].Value.ToString(), sl, dg.ToString(), gg.ToString(), tt.ToString()) == 1)
                                {
                                    if (ttBLL.updateSLBLL(int.Parse(ttBLL.getHangByMaHangBLL(mah).Rows[0]["SoLuong"].ToString()) - sl, mah) == 1)
                                    {
                                        double thanhtien;
                                        Double.TryParse(ttBLL.getHDByMaHDBLL(maTD).Rows[0]["ThanhTien"].ToString(), out thanhtien);
                                        if (ttBLL.updateThanhTienHDBLL((thanhtien + tt).ToString(), maTD) == 1)
                                        {
                                            
                                            
                                            lblThanhTien.Text = ttBLL.getHDByMaHDBLL(maTD).Rows[0]["ThanhTien"].ToString();
                                            lblThanhTien.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Thanh toán thất bại");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Thanh toán thất bại");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Thanh toán thất bại");
                                }
                            }
                            MessageBox.Show("Thanh toán thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thanh toán thất bại");
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                //Thanh toán tiến hành insert 1 mã HD tự động vào HOADON,Ngày lập là ngày ht,mã nv lập là mã user đang đăng nhập
                //mã khách hàng có thể có hoặc không
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
               
                string ma = dataGridViewThanhToan.CurrentRow.Cells[0].Value.ToString();
                if (ma.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn 1 sản phẩm để xóa");
                }
                else
                {
                    dataGridViewThanhToan.Rows.RemoveAt(dataGridViewThanhToan.CurrentRow.Index);
                }
         
           
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnGoiY_Click(object sender, EventArgs e)
        {
            
            if(dataGridViewThanhToan.Rows.Count!=0)
            {
                int []a = new int[40];
                //có data
                for (int i = 0; i < dataGridViewThanhToan.RowCount; i++)
                {
                    string s;


                    string id = dataGridViewThanhToan.Rows[i].Cells[0].Value.ToString();
                    if(id.Trim().Length>6)
                    {
                         s = id.Substring(id.Trim().Length - 5, 5);
                    }
                    else
                    {
                         s = id.Substring(id.Trim().Length - 4, 4);
                    }    
                    
                    a[i] = int.Parse(s);
                }
                SortedSet<int>[] dataset =
{
                new SortedSet<int> { 1 , 2 ,3},
                new SortedSet<int> { 5,6 },
                new SortedSet<int> { 6,8,9 },
                new SortedSet<int> { 7,10,11 },
                new SortedSet<int> { 3,5,7,12,13},
                new SortedSet<int> {7,10,14,15 },
                new SortedSet<int> { 7,16},
                new SortedSet<int> { 1,4,17,18,19},
                new SortedSet<int> { 1,3,4,5,7,18,20,21},
                new SortedSet<int> {10,22,23},
                new SortedSet<int> {4,22},
                new SortedSet<int> {3,24,25},
                new SortedSet<int> {4,25},
                new SortedSet<int> {8,22},
                new SortedSet<int> {7,10},
                new SortedSet<int> {3,10,19},
                new SortedSet<int> {4,25},
                new SortedSet<int> {8,25},
                new SortedSet<int> {7,10},
                new SortedSet<int> {3,10,19},
                new SortedSet<int> {4,9,20,26},
                new SortedSet<int> {1,3,4,8,9,10,13,21,27,28,29},
                new SortedSet<int> {14,18},
                new SortedSet<int> {5},
                new SortedSet<int> {10,19,22,23 },
                new SortedSet<int> {4,25},
                new SortedSet<int> {14,17,23},
                new SortedSet<int> {14,18,30},
                new SortedSet<int> {10,18,27,31,32,33},
                new SortedSet<int> {7,10,24},
                new SortedSet<int> {7,8,13,23,24,31,34,35},
                new SortedSet<int> {18,31,32},
                new SortedSet<int> {10,23},
                new SortedSet<int> {25,34},
                new SortedSet<int> {14,27},
                new SortedSet<int> {4,7,8,9},
                new SortedSet<int> {1,3,7,17,},
                new SortedSet<int> {10,14,22,23},
                new SortedSet<int> {4,5,6,7,8,10,16,17,23,24,28,29,35},
                new SortedSet<int> {5,34},
                new SortedSet<int> {14,22,27},
                new SortedSet<int> {3,5,9,10,18,20,23},
                new SortedSet<int> {6},
                new SortedSet<int> {10,18},
                new SortedSet<int> {10},
                new SortedSet<int> {3,5,7,8,9,10,18,34},
                new SortedSet<int> {10,18,22},
                new SortedSet<int> {8,14,18},
                new SortedSet<int> {7,8,31,34},
                new SortedSet<int> {2,3,4,8,9,17,21,22,25,36},
                new SortedSet<int> {7,23,25},
                new SortedSet<int> {5,7,9,10},
                new SortedSet<int> {8,14,17},
                new SortedSet<int> {10,22,31,35},
                new SortedSet<int> {10,24,25},
                new SortedSet<int> {7,8,9,13,22,27},
                new SortedSet<int> {4,25},
                new SortedSet<int> {10,22},
                new SortedSet<int> {7,22,31},
                new SortedSet<int> {4,10,17,22,24},
                new SortedSet<int> {10,23,30},
                new SortedSet<int> {7},
                new SortedSet<int> {6,24},
                new SortedSet<int> {10,15},
                new SortedSet<int> {7,9,22},
                new SortedSet<int> {4,7,8,9,19},
                new SortedSet<int> {15},
                new SortedSet<int> {3,7,19},
                new SortedSet<int> {1,7,15,19,22,36,37},
                new SortedSet<int> {7,22,23},
                new SortedSet<int> {1,7,10,24},
                new SortedSet<int> {1,3,7},
                new SortedSet<int> {2,14,18,25,38},
                new SortedSet<int> {14,18,23,24},
                new SortedSet<int> {6,9},
                new SortedSet<int> {19},
                new SortedSet<int> {3,7,8,10,36,37},
                new SortedSet<int> {4,25},
                new SortedSet<int> {8,20},
                new SortedSet<int> {9,11,15,36,37,38 },
                new SortedSet<int> {18},
                new SortedSet<int> {5,10,15,22,35},
                new SortedSet<int> {6,7,11},
            };
                Apriori apriori = new Apriori(threshold: 3, confidence: 0);
                AssociationRuleMatcher<int> classifier = apriori.Learn(dataset);
                int[][] matches = classifier.Decide(a);
                //AssociationRule<int>[] rules = classifier.Rules;
                int sl = matches.Length;
                if(sl==0)
                {
                    MessageBox.Show("Không có gợi ý");
                }    
                else if(sl<3)
                {
                    MessageBox.Show("Các sản phẩm gợi ý: "+ ttBLL.getHangByMaHangBLL("SP000"+ matches[0][0].ToString()).Rows[0]["TenHang"].ToString() + "," + ttBLL.getHangByMaHangBLL("SP000" + matches[1][0].ToString()).Rows[0]["TenHang"].ToString() + "");
                }
                else
                {
                    MessageBox.Show("Các sản phẩm gợi ý: " + ttBLL.getHangByMaHangBLL("SP000" + matches[0][0].ToString()).Rows[0]["TenHang"].ToString() + "," + ttBLL.getHangByMaHangBLL("SP000" + matches[1][0].ToString()).Rows[0]["TenHang"].ToString() + "," + ttBLL.getHangByMaHangBLL("SP000" + matches[2][0].ToString()).Rows[0]["TenHang"].ToString() + "");
                } 
                    

            }
            else
            {
                MessageBox.Show("Không có sản phẩm để gợi ý");
            }

            
        }
    }
}
