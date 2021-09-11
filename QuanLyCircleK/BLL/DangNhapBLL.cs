using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;


namespace BLL
{
    public class DangNhapBLL
    {
        DangNhapDAL dnDAL = new DangNhapDAL();
        public DangNhapBLL()
        {
        }
        public DataTable getDataMaNVTenNVBLL(string maNV)
        {
            return dnDAL.getDataDNTheoMaDAL(maNV);
        }
    }
}
