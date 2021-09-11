using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class MainDAL
    {
        DANGNHAPTableAdapter daDN = new DANGNHAPTableAdapter();
        NHANVIENTableAdapter daNV = new NHANVIENTableAdapter();
        public MainDAL()
        {
        }
        public DataTable getPhanQuyenDAL(string ma)
        {
            return daDN.GetDataByMaNV(ma);
        }
        public DataTable getNamebyUserDAL(string ma)
        {
            return daNV.GetDataByMaNV(ma);
        }
    }
}
