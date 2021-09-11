using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class HangDAL
    {
        HANGTableAdapter daHang = new HANGTableAdapter();
        NHACUNGCAPTableAdapter daNCC = new NHACUNGCAPTableAdapter();
        LOAIHANGTableAdapter daLH = new LOAIHANGTableAdapter();
        public HangDAL()
        {
        }
        //load cbb
        public DataTable getAllNCCDAL()
        {
            return daNCC.GetData();
        }
        public DataTable getAllLHDAL()
        {
            return daLH.GetData();
        }
        public DataTable getAllHangDAL()
        {
            return daHang.GetData();
        }
        public DataTable getByMaHangDAL(string ma)
        {
            return daHang.GetDataByMaHang(ma);
        }
        public DataTable getByMaLoaiDAL(string ma)
        {
            return daHang.GetDataByMaLoai(ma);
        }
        public DataTable getByMaNCCDAL(string ma)
        {
            return daHang.GetDataByMaNCC(ma);
        }
        public DataTable getNhaCCByMaNCCDAL(string ma)
        {
            return daNCC.GetDataByMaNCC(ma);
        }
        public DataTable getLoaiHangByMaLoaiHangDAL(string ma)
        {
            return daLH.GetDataByMaLH(ma);
        }
        public string createMaSPTuDongDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daHang.GetData().Rows.Count);
            foreach (DataRow row in daHang.GetData().Rows)
            {
                str.Add((string)row["MaHang"]);
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
                MaTD = "SP000" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD =  "SP00" + max.ToString();
            }
            else if(max<=999)
            {
                MaTD = "SP0" + max.ToString();
            }
            else
            {
                MaTD = "SP" + max.ToString();
            }    
            return MaTD;
        }
        public int addNewSPDAL(string ma,string ten,string ml,string dvt,string dongia,string gianhap,string giamgia,string mancc,string mota,int sl,byte[] hinh)
        {
            return daHang.InsertNewSP(ma, ten, ml, dvt, dongia, gianhap, giamgia, mancc, mota, sl, hinh);
        }
        public int updateSPKhongAnhDAL( string ten, string ml, string dvt, string dongia, string gianhap, string giamgia, string mancc, string mota, int sl, string ma)
        {
            return daHang.UpdateSPKhongAnh(ten, ml, dvt, dongia, gianhap, giamgia, mancc, mota, sl, ma);
        }
        public int updateSPCoAnhDAL(string ten, string ml, string dvt, string dongia, string gianhap, string giamgia, string mancc, string mota, int sl,byte[] anh, string ma)
        {
            return daHang.UpdateSPCoAnh(ten, ml, dvt, dongia, gianhap, giamgia, mancc, mota, sl,anh, ma);
        }
        public int deleteSPDAL(string ma)
        {
            return daHang.DeleteSP(ma);
        }
    }
}
