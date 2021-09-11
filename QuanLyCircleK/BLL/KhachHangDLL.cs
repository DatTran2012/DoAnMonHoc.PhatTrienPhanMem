using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class KhachHangDLL
    {
        KhachHangDAL khDAL = new KhachHangDAL();
        public KhachHangDLL() { }
        public DataTable getAllKHBLL()
        {
            return khDAL.getAllKHDAL();
        }
        public DataTable getKHByMaKHBLLL(string ma)
        {
            return khDAL.getKHByMaKHDAL(ma);
        }
        public string createMaKHTuDongBLL()
        {
            return khDAL.createMaKHTuDongDAL();
        }
        public int addNewKHBLL(string ma, string ten, string dt, int tt, int diem)
        {
            return khDAL.addNewKHDAL(ma, ten, dt, tt, diem);
        }
        public int updateKHBLL(string ten, string dt, string ma)
        {
            return khDAL.updateKHDAL(ten, dt, ma);
        }
        public int countHDofKHDAL(string ma)
        {
            return khDAL.countHDofKHDAL(ma);
        }
        public int updateMaKHBLL( string hd)
        {
            return khDAL.updateMaKHDAL(hd);
        }
        public DataTable getHDByMAHDBLL(string ma)
        {
            return khDAL.getHDByMAHDBLL(ma);
        }
        public int deleteKhachHangBLL(string ma)
        {
            return khDAL.deleteKhachHangDAL(ma);
        }
    }
}
