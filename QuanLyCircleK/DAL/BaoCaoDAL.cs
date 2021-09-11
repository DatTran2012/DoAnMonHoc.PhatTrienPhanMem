using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class BaoCaoDAL
    {
        HOADONTableAdapter daHD = new HOADONTableAdapter();
        public BaoCaoDAL()
        { }
        public DataTable getThanhTienDAL(string ngaylap)
        {
            return daHD.GetDataByNgayLap(ngaylap);
        }
        public DataTable getThanhTienByMonthDAL(int ngaylap)
        {
            return daHD.GetDataByMonth(ngaylap);
        }
    }
}
