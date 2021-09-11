using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class LoaiBLL
    {
        LoaiDAL lhDAL = new LoaiDAL();
        public LoaiBLL()
        { }
        public DataTable getAllLoaiBLL()
        {
            return lhDAL.getAllLoaiDAL();
        }
        public DataTable getTheoMaBLL(string ma)
        {
            return lhDAL.getTheoMaDAL(ma);
        }
        public string createMaLoaiTuDongBLL()
        {
            return lhDAL.createMaLoaiTuDongDAL();
        }
        public int addLoaiHangBLL(string ma, string ten)
        {
            return lhDAL.addLoaiHangDAL(ma, ten);        
        }
        public int updateLoaiHangBLL(string ten, string ma)
        {
            return lhDAL.updateLoaiHangDAL(ten, ma);
        }
        public int countHangMaLoaiBLL(string ma)
        {
            return lhDAL.countHangMaLoaiDAL(ma);
        }
        public int deleteHangTheoMaLoaiBLL(string ma)
        {
            return lhDAL.deleteHangTheoMaLoaiDAL(ma);
        }
        public int deleteMaLoaiBLL(string ma)
        {
            return lhDAL.deleteMaLoaiDAL(ma);
        }
    }
}
