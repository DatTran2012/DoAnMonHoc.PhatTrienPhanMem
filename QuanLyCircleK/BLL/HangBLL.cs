using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class HangBLL
    {
        HangDAL hDAL = new HangDAL();
        public HangBLL()
        { }
        public DataTable getAllNCCBLL()
        {
            return hDAL.getAllNCCDAL();
        }
        public DataTable getAllLHBLL()
        {
            return hDAL.getAllLHDAL();
        }
        public DataTable getAllHangBLL()
        {
            return hDAL.getAllHangDAL();
        }
        public DataTable getByMaHangBLL(string ma)
        {
            return hDAL.getByMaHangDAL(ma);
        }
        public DataTable getByMaLoaiBLL(string ma)
        {
            return hDAL.getByMaLoaiDAL(ma);
        }
        public DataTable getByMaNCCBLL(string ma)
        {
            return hDAL.getByMaNCCDAL(ma);
        }
        public DataTable getNhaCCByMaNCCBLL(string ma)
        {
            return hDAL.getNhaCCByMaNCCDAL(ma);
        }
        public DataTable getLoaiHangByMaLoaiHangBLL(string ma)
        {
            return hDAL.getLoaiHangByMaLoaiHangDAL(ma);
        }
        public string createMaSPTuDongBLL()
        {
            return hDAL.createMaSPTuDongDAL();
        }
        public int addNewSPBLL(string ma, string ten, string ml, string dvt, string dongia, string gianhap, string giamgia, string mancc, string mota, int sl, byte[] hinh)
        {
            return hDAL.addNewSPDAL(ma, ten, ml, dvt, dongia, gianhap, giamgia, mancc, mota, sl, hinh);
        }
        public int updateSPKhongAnhBLL(string ten, string ml, string dvt, string dongia, string gianhap, string giamgia, string mancc, string mota, int sl, string ma)
        {
            return hDAL.updateSPKhongAnhDAL(ten, ml, dvt, dongia, gianhap, giamgia, mancc, mota, sl, ma);
        }
        public int updateSPCoAnhBLL(string ten, string ml, string dvt, string dongia, string gianhap, string giamgia, string mancc, string mota, int sl, byte[] anh, string ma)
        {
            return hDAL.updateSPCoAnhDAL(ten, ml, dvt, dongia, gianhap, giamgia, mancc, mota, sl, anh, ma);
        }
        public int deleteSPBLL(string ma)
        {
            return hDAL.deleteSPDAL(ma);
        }
    }
}
