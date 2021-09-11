using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class CaNhanBLL
    {
        CaNhanDAL cnDAL = new CaNhanDAL();
        public CaNhanBLL()
        {
        }
        public DataTable getDataMaNVTenNVBLL(string maNV)
        {
            return cnDAL.getDataNhanVienTheoMaDAL(maNV);
        }
        public int updateAnhBLL(byte[] anh, string ma)
        {
            return cnDAL.updateAnhDAL(anh, ma);
        }
        public string getMaKhauBLL(string ma)
        {
            return cnDAL.getMaKhauDAL(ma);
        }
        public int updatePWBLL(string mk, string ma)
        {
            return cnDAL.updatePWDAL(mk, ma);
        }
    }
}
