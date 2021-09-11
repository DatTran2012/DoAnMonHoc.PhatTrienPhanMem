using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL hdDAL = new HoaDonDAL();
        public HoaDonBLL()
        { }
        public DataTable getDataHDBLL()
        {
            return hdDAL.getDataHDDAL();
        }
        public DataTable GetDataByNgayLapBLL(string ngaylap)
        {
            return hdDAL.GetDataByNgayLapDAL(ngaylap);
        }
        public DataTable GetDataCTHDByMaHDBLL(string mahd)
        {
            return hdDAL.GetDataCTHDByMaHDDAL(mahd);
        }
    }
}
