using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class HoaDonDAL
    {
        HOADONTableAdapter daHD = new HOADONTableAdapter();
        CT_HOADONTableAdapter daCTHD = new CT_HOADONTableAdapter();
        public HoaDonDAL()
        {

        }
        public DataTable getDataHDDAL()
        {
            return daHD.GetData();
        }
        public DataTable GetDataByNgayLapDAL(string ngaylap)
        {
            return daHD.GetDataByNgayLap(ngaylap);
        }
        public DataTable GetDataCTHDByMaHDDAL(string mahd)
        {
            return daCTHD.GetDataByMaHD(mahd);
        }
    }
}
