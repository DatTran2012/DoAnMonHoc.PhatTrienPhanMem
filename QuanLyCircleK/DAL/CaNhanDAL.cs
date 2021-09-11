using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class CaNhanDAL
    {
        NHANVIENTableAdapter daNhanVien = new NHANVIENTableAdapter();
        DANGNHAPTableAdapter daDangNhap = new DANGNHAPTableAdapter();
        public CaNhanDAL()
        { }
        public DataTable getDataNhanVienTheoMaDAL(string maNV)
        {
            return daNhanVien.GetDataByMaNV(maNV);
        }
        public int updateAnhDAL(byte[] anh,string ma)
        {
            return daNhanVien.UpdateAnh(anh, ma);
        }
        public string getMaKhauDAL(string ma)
        {
            return daDangNhap.GetDataByMaNV(ma).Rows[0]["MatKhau"].ToString();
        }
        public int updatePWDAL(string mk,string ma)
        {
            return daDangNhap.UpdateNewPassword(mk, ma);
        }
    }
}
