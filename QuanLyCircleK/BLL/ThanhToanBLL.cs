using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class ThanhToanBLL
    {
        ThanhToanDAL ttDAL = new ThanhToanDAL();
        public ThanhToanBLL()
        { }
        public string createMaHDTuDongDAL()
        {
            return ttDAL.createMaHDTuDongDAL();
        }
        public DataTable getHangByMaHangBLL(string ma)
        {
            return ttDAL.getHangByMaHangDAL(ma);
        }
        public int addHoaDonKhongMaKHDBLL(string mahd, string ngaylap, string manv, string makh)
        {
            return ttDAL.addHoaDonKhongMaKHDAL(mahd, ngaylap, manv, makh);
        }
        public int addCTHDBLL(string hd, string h, int sl, string dongia, string giagia, string thanhtien)
        {
            return ttDAL.addCTHDDAL(hd, h, sl, dongia, giagia, thanhtien);
        }
        public int updateSLBLL(int sl, string masp)
        {
            return ttDAL.updateSLDAL(sl, masp);
        }
        public int updateThanhTienHDBLL(string thanhtien, string mahd)
        {
            return ttDAL.updateThanhTienHDDAL(thanhtien, mahd);
        }
        public DataTable getHDByMaHDBLL(string mahd)
        {
            return ttDAL.getHDByMaHDDAL(mahd);
        }
        public DataTable getDiemTLBLL(string maKH)
        {
            return ttDAL.getDiemTL(maKH);
        }
    }
}
