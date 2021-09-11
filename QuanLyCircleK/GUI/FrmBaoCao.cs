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
    public partial class FrmBaoCao : Form
    {
        BaoCaoBLL bcBLL = new BaoCaoBLL();
        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            double tt = 0;
            for(int i=0; i < bcBLL.getThanhTienBLL(dateTimePicker1.Value.ToString()).Rows.Count; i++)
            {
                double thanhtien;
                Double.TryParse(bcBLL.getThanhTienBLL(dateTimePicker1.Value.ToString()).Rows[i]["ThanhTien"].ToString(), out thanhtien);
                tt = tt + thanhtien;
            }
            label2.Text = tt.ToString();
            double ttThang = 0;
            for (int i = 0; i < bcBLL.getThanhTienByMonthBLL(int.Parse(dateTimePicker2.Value.Month.ToString())).Rows.Count; i++)
            {
                double thanhtienThang;
                Double.TryParse(bcBLL.getThanhTienByMonthBLL(int.Parse(dateTimePicker2.Value.Month.ToString())).Rows[i]["ThanhTien"].ToString(), out thanhtienThang);
                ttThang = ttThang + thanhtienThang;
            }
            label5.Text = ttThang.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            double tt = 0;
            for (int i = 0; i < bcBLL.getThanhTienBLL(dateTimePicker1.Value.ToString()).Rows.Count; i++)
            {
                double thanhtien;
                Double.TryParse(bcBLL.getThanhTienBLL(dateTimePicker1.Value.ToString()).Rows[i]["ThanhTien"].ToString(), out thanhtien);
                tt = tt + thanhtien;
            }
            label2.Text = tt.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
