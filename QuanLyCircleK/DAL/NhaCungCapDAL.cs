using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class NhaCungCapDAL
    {
        NHACUNGCAPTableAdapter daNCC = new NHACUNGCAPTableAdapter();
        HANGTableAdapter daH = new HANGTableAdapter();
        public NhaCungCapDAL()
        { 
        }
        public DataTable getDataNCCDAL()
        {
            return daNCC.GetData();
        }
        public DataTable getDataNCCTheoMaDAL(string ma)
        {
            return daNCC.GetDataByMaNCC(ma);
        }
        public DataTable getDataNCCTheoTenDAL(string ten)
        {
            return daNCC.GetDataByTenNCC(ten);
        }
        public string createMaNCCTuDongDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daNCC.GetData().Rows.Count);
            foreach (DataRow row in daNCC.GetData().Rows)
            {
                str.Add((string)row["MaNCC"]);
            }
            List<int> lstInt = new List<int>(str.Count);
            for (int i = 0; i < str.Count; i++)
            {
                string s = str[i].Substring(str[i].Trim().Length - 3, 3);


                lstInt.Add(Int32.Parse(s));
            }
            int max = lstInt.Max();
            max++;
            if (max <= 9)
            {
                MaTD = "NCC00" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD = "NCC0" + max.ToString();
            }
            else
            {
                MaTD = "NCC" + max.ToString();
            }
            return MaTD;
        }
        public int addNhaCungCapDAL(string ma,string ten,string dt,string dc,string mt)
        {
            return daNCC.InsertNewNCC(ma, ten, dt, dc, mt);
        }
        public int updateNCCDAL(string ten,string dt,string dc,string mt,string ma)
        {
            return daNCC.UpdateNhaCC(ten, dt, dc, mt, ma);
        }
        public int deleteNCCDAL(string ma)
        {
            return daNCC.DeleteNhaCC(ma);
        }
        public int deleteHangTheoNCCDAL(string ma)
        {
            return daH.DeleteTheoMaNCC(ma);
        }
        public int countHangMaNCCDAL(string ma)
        {
            return daH.GetDataByMaNCC(ma).Rows.Count;
        }
    }
}
