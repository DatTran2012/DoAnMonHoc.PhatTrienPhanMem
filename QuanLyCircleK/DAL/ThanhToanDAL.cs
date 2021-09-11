using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class ThanhToanDAL
    {
        HOADONTableAdapter daHD = new HOADONTableAdapter();
        CT_HOADONTableAdapter daCTHD = new CT_HOADONTableAdapter();
        HANGTableAdapter daH = new HANGTableAdapter();
        KHACHHANGTableAdapter daKH = new KHACHHANGTableAdapter();
        public ThanhToanDAL()
        { }
        public string createMaHDTuDongDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daHD.GetData().Rows.Count);
            foreach (DataRow row in daHD.GetData().Rows)
            {
                str.Add((string)row["MaHD"]);
            }
            List<int> lstInt = new List<int>(str.Count);
            for (int i = 0; i < str.Count; i++)
            {
                string s = str[i].Substring(str[i].Trim().Length - 5, 5);


                lstInt.Add(Int32.Parse(s));
            }
            int max = lstInt.Max();
            max++;
            if (max <= 9)
            {
                MaTD =  "HD00000" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD = "HD0000" + max.ToString();
            }
            else if(max<=999)
            {
                MaTD = "HD000" + max.ToString();
            }
            else if(max<=9999)
            {
                MaTD =  "HD00" + max.ToString();
            }
            else if (max <= 99999)
            {
                MaTD = "HD0" + max.ToString();
            }
            else
            {
                MaTD = "HD" + max.ToString();
            }
            return MaTD;
        }
        public DataTable getHangByMaHangDAL(string ma)
        {
            return daH.GetDataByMaHang(ma);
        }
        public int addHoaDonKhongMaKHDAL(string mahd,string ngaylap,string manv,string makh)
        {
            return daHD.InsertKhongMaKH(mahd, ngaylap, manv, makh);
        }
        public int addCTHDDAL(string hd,string h,int sl,string dongia,string giagia,string thanhtien)
        {
            return daCTHD.InsertCTHD(hd, h, sl, dongia, giagia, thanhtien);
        }    
        public int updateSLDAL(int sl,string masp)
        {
            return daH.UpdateSL(sl, masp);
        }
        public int updateThanhTienHDDAL(string thanhtien, string mahd)
        {
            return daHD.UpdateThanhTienHD(thanhtien, mahd);
        }
        public DataTable getHDByMaHDDAL( string mahd)
        {
            return daHD.GetDataByMaHD(mahd);
        }
        public DataTable getDiemTL(string maKH)
        {
            return daKH.GetDataByMaKH(maKH);
        }
    }
}
