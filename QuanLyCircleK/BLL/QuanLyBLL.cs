using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class QuanLyBLL
    {
        QuanLyDAL qlDAL = new QuanLyDAL();

        public QuanLyBLL()
        { }
        //tạo mã tđ
        public string createMaNhanVienTuDongBLL()
        {
            return qlDAL.createMaNhanVienTuDongDAL();
        }
        //lấy all data NV
        public DataTable getDataNhanVienBLL()
        {
            return qlDAL.getDataNhanVienDAL();
        }
        //lấy mã + tên
        public DataTable getDataMaNVTenNVBLL()
        {
            return qlDAL.getDataMaNVTenNVDAL();
        }
        //lấy all data NV theo mã
        public DataTable getDataNhanVienTheoMaBLL(string maNV)
        {
            return qlDAL.getDataNhanVienTheoMaDAL(maNV);
        }
        //lấy all data NV theo tên
        public DataTable getDataNhanVienTheoTenBLL(string tenNV)
        {
            return qlDAL.getDataNhanVienTheoTenDAL(tenNV);
        }
        //lấy all data NV theo mã gần đúng
        public DataTable getDataNhanVienTheoMaGanDungBLL(string maNV)
        {
            return qlDAL.getDataNhanVienTheoMaGanDungDAL(maNV);
        }
        //thêm nv mới
        public int addNhanVienBLL(string ma, string ten, string ngaysinh, string gioitinh, string dt, string dc, string ngayvl, string chucvu, int tinhtrang, byte[] hinhanh)
        {
            return qlDAL.addNhanVienDAL(ma, ten, ngaysinh, gioitinh, dt, dc, ngayvl, chucvu, tinhtrang, hinhanh);
        }
        //thêm acc mới
        public int addAccountBLL(string ma, string mk, int pq, int tt)
        {
            return qlDAL.addAccountDAL(ma, mk, pq, tt);
        }
        //Xóa nhân viên
        public int deleteNhanVienBLL(string ma)
        {
            return qlDAL.deleteNhanVienDAL(ma);
        }
        //Xóa acc
        public int deleteAccountBLL(string ma)
        {
            return qlDAL.deleteAccountDAL(ma);
        }
        //update ko hình ảnh
        public int updateNhanVienKhongAnhBLL(string ten, string ns, string gt, string sdt, string dc, string nvl, string cv, string ma)
        {
            return qlDAL.updateNhanVienKhongAnhDAL(ten, ns, gt, sdt, dc, nvl, cv, ma);
        }
        //update có hình ảnh
        public int updateNhanVienCoAnhBLL(string ten, string ns, string gt, string sdt, string dc, string nvl, string cv, byte[] ha, string ma)
        {
            return qlDAL.updateNhanVienCoAnhDAL(ten, ns, gt, sdt, dc, nvl, cv, ha, ma);
        }
        //get mk by manv
        public string getMKByMaNVBLL(string ma)
        {
            return (qlDAL.getMKByMaNVDAL(ma));
        }
        //update phân quyền theo chức vụ
        public int updatePQTheoCVBLL(int pq, string ma, string mk)
        {
            return qlDAL.updatePQTheoCVDAL(pq, ma, mk);
        }
    }
}
