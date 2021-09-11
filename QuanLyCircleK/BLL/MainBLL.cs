using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class MainBLL
    {
        MainDAL mDAL = new MainDAL();
        public MainBLL()
        { }
        public DataTable getPhanQuyenBLL(string ma)
        {
            return mDAL.getPhanQuyenDAL(ma);
        }
        public DataTable getNamebyUserBLL(string ma)
        {
            return mDAL.getNamebyUserDAL(ma);
        }
    }
}
