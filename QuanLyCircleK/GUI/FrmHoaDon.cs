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
    public partial class FrmHoaDon : Form
    {
        HoaDonBLL hdBLL = new HoaDonBLL();
        public FrmHoaDon()
        {
            InitializeComponent();
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.ForeColor = Color.Black;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvCTHD.ForeColor = Color.Black;
            dgvCTHD.AllowUserToAddRows = false;
            dgvHoaDon.DataSource = hdBLL.getDataHDBLL();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = hdBLL.GetDataByNgayLapBLL(dateTimePicker1.Value.ToString());
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCTHD.DataSource = hdBLL.GetDataCTHDByMaHDBLL(dgvHoaDon.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
