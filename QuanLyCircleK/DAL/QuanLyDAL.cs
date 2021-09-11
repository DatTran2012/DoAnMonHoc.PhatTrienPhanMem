using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QuanLyCirleKTableAdapters;

namespace DAL
{
    public class QuanLyDAL
    {
        NHANVIENTableAdapter daNhanVien = new NHANVIENTableAdapter();
        DANGNHAPTableAdapter daDangNhap = new DANGNHAPTableAdapter();

        public QuanLyDAL()
        { }

        //Tạo mã nhân viên tự động tăng
        public string createMaNhanVienTuDongDAL()
        {
            string MaTD = "";
            List<string> str = new List<string>(daNhanVien.GetData().Rows.Count);
            foreach (DataRow row in daNhanVien.GetData().Rows)
            {
                str.Add((string)row["MaNV"]);
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
                MaTD = DateTime.Now.Year.ToString() + "00" + max.ToString();
            }
            else if (max <= 99)
            {
                MaTD = DateTime.Now.Year.ToString() + "0" + max.ToString();
            }
            else
            {
                MaTD = DateTime.Now.Year.ToString() + max.ToString();
            }
            return MaTD;
        }
        //get data all Nhân viên
        public DataTable getDataNhanVienDAL()
        {
            return daNhanVien.GetData();
        }
        //get data mã nhân viên tên nhân viên
        public DataTable getDataMaNVTenNVDAL()
        {
            return daNhanVien.GetDataMaNVTenNV();
        }
        //get data nhân viên theo mã
        public DataTable getDataNhanVienTheoMaDAL(string maNV)
        {
            return daNhanVien.GetDataByMaNV(maNV);
        }
        //get data nhân viên theo tên 
        public DataTable getDataNhanVienTheoTenDAL(string tenNV)
        {
            return daNhanVien.GetDataByTenNV(tenNV);
        }
        // get data nhân viên theo mã gần đúng
        public DataTable getDataNhanVienTheoMaGanDungDAL(string maNV)
        {
            return daNhanVien.GetDataByMaNVGanDung(maNV);
        }
        //Thêm mới nhân viên
        public int addNhanVienDAL(string ma, string ten, string ngaysinh, string gioitinh, string dt, string dc, string ngayvl, string chucvu, int tinhtrang, byte[] hinhanh)
        {
            return daNhanVien.InsertNhanVien(ma, ten, ngaysinh, gioitinh, dt, dc, ngayvl, chucvu, tinhtrang, hinhanh);
        }
        //Thêm mới tài khoản khi thêm mới 1 nv
        public int addAccountDAL(string ma, string mk, int pq, int tt)
        {
            return daDangNhap.InsertAccount(ma, mk, pq, tt);
        }
        //Xóa một nhân viên
        public int deleteNhanVienDAL(string ma)
        {
            return daNhanVien.DeleteNhanVien(ma);
        }
        //Xóa một account của nhân viên bị xóa
        public int deleteAccountDAL(string ma)
        {
            return daDangNhap.DeleteAccount(ma);
        }
        //update không hình ảnh
        public int updateNhanVienKhongAnhDAL(string ten, string ns, string gt, string sdt, string dc, string nvl, string cv, string ma)
        {
            return daNhanVien.UpdateKhongHinhAnh(ten, ns, gt, sdt, dc, nvl, cv, ma);
        }
        //update có hình ảnh
        public int updateNhanVienCoAnhDAL(string ten, string ns, string gt, string sdt, string dc, string nvl, string cv, byte[] ha, string ma)
        {
            return daNhanVien.UpdateHinhAnh(ten, ns, gt, sdt, dc, nvl, cv, ha, ma);
        }
        //Trả về password theo manv
        public string getMKByMaNVDAL(string ma)
        {
            string mk = "";
            List<string> str = new List<string>(daDangNhap.GetData().Rows.Count);
            foreach (DataRow row in daDangNhap.GetData().Rows)
            {
                str.Add((string)row["MatKhau"]);
            }
            mk = str[0].ToString();
            return mk;
        }
        
        //update phân quyền theo chức vụ
        public int updatePQTheoCVDAL(int pq,string ma,string mk)
        {
            return daDangNhap.UpdatePhanQuyenTheoChucVu(pq, ma,mk);
        }
    }
}
