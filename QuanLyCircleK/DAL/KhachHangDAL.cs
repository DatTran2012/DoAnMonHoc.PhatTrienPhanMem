using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QuanLyCirleKTableAdapters;
using System.Data;

namespace DAL
{
    public class KhachHangDAL
    {
        KHACHHANGTableAdapter daKH = new KHACHHANGTableAdapter();
        HOADONTableAdapter daHD = new HOADONTableAdapter();
        public KhachHangDAL()
        { 
        }
        public DataTable getAllKHDAL()
        {
            return daKH.GetData();
        }
        public DataTable getKHByMaKHDAL(string ma)
        {
            return daKH.GetDataByMaKH(ma);
        }
        public string createMaKHTuDongDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daKH.GetData().Rows.Count);
            foreach (DataRow row in daKH.GetData().Rows)
            {
                str.Add((string)row["MaKH"]);
            }
            List<int> lstInt = new List<int>(str.Count);
            for (int i = 0; i < str.Count; i++)
            {
                string s = str[i].Substring(str[i].Trim().Length - 4, 4);


                lstInt.Add(Int32.Parse(s));
            }
            int max = lstInt.Max();
            max++;
            if (max <= 9)
            {
                MaTD = "KH000" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD = "KH00" + max.ToString();
            }
            else if (max <= 999)
            {
                MaTD = "KH0" + max.ToString();
            }
            else
            {
                MaTD = "KH" + max.ToString();
            }
            return MaTD;
        }
        public int addNewKHDAL(string ma,string ten,string dt,int tt,int diem)
        {
            return daKH.InsertNewKH(ma, ten, dt, tt, diem);
        }
        public int updateKHDAL(string ten, string dt, string ma)
        {
            return daKH.UpdateKH( ten, dt, ma);
        }
        public int countHDofKHDAL(string ma)
        {
            return daHD.GetDataByMaKH(ma).Rows.Count;
        }
        public DataTable getHDByMAHDBLL(string ma)
        {
            return daHD.GetDataByMaKH(ma);
        }
        public int updateMaKHDAL(string hd)
        {
            return daHD.UpdateMaKH( hd);
        }
        public int deleteKhachHangDAL(string ma)
        {
            return daKH.DeleteKhachHang(ma);
        }
    }
}
