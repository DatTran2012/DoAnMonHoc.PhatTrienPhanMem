using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class LoaiDAL
    {
        LOAIHANGTableAdapter daLH = new LOAIHANGTableAdapter();
        HANGTableAdapter daH = new HANGTableAdapter();
        public LoaiDAL()
        { 
        }
        public DataTable getAllLoaiDAL()
        {
            return daLH.GetData();
        }
        public DataTable getTheoMaDAL(string ma)
        {
            return daLH.GetDataByMaLH(ma);
        }
        public string createMaLoaiTuDongDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daLH.GetData().Rows.Count);
            foreach (DataRow row in daLH.GetData().Rows)
            {
                str.Add((string)row["MaLoaiHang"]);
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
                MaTD = "LH00" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD = "LH0" + max.ToString();
            }
            else
            {
                MaTD = "LH" + max.ToString();
            }
            return MaTD;
        }
        public int addLoaiHangDAL(string ma,string ten)
        {
            return daLH.InsertLoaiHang(ma, ten);
        }
        public int updateLoaiHangDAL(string ten,string ma)
        {
            return daLH.UpdateLoaiHang(ten, ma);
        }
        public int countHangMaLoaiDAL(string ma)
        {
            return daH.GetDataByMaLoai(ma).Rows.Count;
        }
        public int deleteHangTheoMaLoaiDAL(string ma)
        {
            return daH.DeleteTheoMaLoai(ma);
        }    
        public int deleteMaLoaiDAL(string ma)
        {
            return daLH.DeleteMaLoai(ma);
        }
    }
}
