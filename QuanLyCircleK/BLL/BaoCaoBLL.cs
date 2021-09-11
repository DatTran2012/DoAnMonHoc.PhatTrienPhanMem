using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{

    public class BaoCaoBLL
    {
        BaoCaoDAL bcDAL = new BaoCaoDAL();
        public BaoCaoBLL()
        { }
        public DataTable getThanhTienBLL(string ngaylap)
        {
            return bcDAL.getThanhTienDAL(ngaylap);
        }
        public DataTable getThanhTienByMonthBLL(int ngaylap)
        {
            return bcDAL.getThanhTienByMonthDAL(ngaylap);
        }
    }
}
