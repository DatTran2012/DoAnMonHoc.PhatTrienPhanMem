using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class DangNhapDAL
    {
        NHANVIENTableAdapter daNhanVien = new NHANVIENTableAdapter();
        DANGNHAPTableAdapter daDangNhap = new DANGNHAPTableAdapter();
        public DangNhapDAL()
        { }
        public DataTable getDataDNTheoMaDAL(string maNV)
        {
            return daDangNhap.GetDataByMaNVDN(maNV);
        }
        public string getMaKhauDAL(string ma)
        {
            return daDangNhap.GetDataByMaNVDN(ma).Rows[0]["MatKhau"].ToString();
        }
    }
}
