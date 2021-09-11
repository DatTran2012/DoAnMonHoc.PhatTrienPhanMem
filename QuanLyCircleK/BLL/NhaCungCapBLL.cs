using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class NhaCungCapBLL
    {
        NhaCungCapDAL nccDAL = new NhaCungCapDAL();
        public NhaCungCapBLL()
        { }
        public DataTable getDataNCCBLL()
        {
            return nccDAL.getDataNCCDAL();
        }
        public DataTable getDataNCCTheoMa(string ma)
        {
            return nccDAL.getDataNCCTheoMaDAL(ma);
        }
        public DataTable getDataNCCTheoTen(string ten)
        {
            return nccDAL.getDataNCCTheoTenDAL(ten);
        }
        public string createMaNCCTuDongBLL()
        {
            return nccDAL.createMaNCCTuDongDAL();
        }
        public int addNhaCungCapBLL(string ma, string ten, string dt, string dc, string mt)
        {
            return nccDAL.addNhaCungCapDAL(ma, ten, dt, dc, mt);
        }
        public int updateNCCBLL(string ten, string dt, string dc, string mt, string ma)
        {
            return nccDAL.updateNCCDAL(ten, dt, dc, mt, ma);
        }
        public int deleteNCCBLL(string ma)
        {
            return nccDAL.deleteNCCDAL(ma);
        }
        public int deleteHangTheoNCCBLL(string ma)
        {
            return nccDAL.deleteHangTheoNCCDAL(ma);
        
        }
        public int countHangMaNCCBLL(string ma)
        {
            return nccDAL.countHangMaNCCDAL(ma);
        }
    }
}
