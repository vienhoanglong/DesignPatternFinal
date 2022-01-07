using QuanLiRapPhim.DTO;
using QuanLiRapPhim.Patterns.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DAO
{
    public class NhanVienDAO
    {
		public static NhanVien GetStaffByID(string id)
		{
			NhanVien staff = null;
			DataTable data = DataProvider.getInstance().ExecuteQuery("SELECT * FROM dbo.NhanVien WHERE id = '" + id + "'");
			foreach (DataRow item in data.Rows)
			{

    
                staff = (NhanVien)new NhanVienBuilder()
                    .setId(item["id"].ToString())
                    .setAddress(item["DiaChi"].ToString())
                    .setBirth(DateTime.Parse(item["NgaySinh"].ToString()))
                    .setIdentityCard(Int32.Parse(item["CMND"].ToString()))
                    .setName(item["HoTen"].ToString())
                    .setPhone(item["SDT"].ToString()).Build();
                return staff;

			}
			return staff;
		}

		public static List<NhanVien> GetStaff()
		{
			List<NhanVien> staffList = new List<NhanVien>();
			DataTable data = DataProvider.getInstance().ExecuteQuery("SELECT * FROM dbo.NhanVien");
			foreach (DataRow item in data.Rows)
			{
                NhanVien staff = (NhanVien)new NhanVienBuilder()
                    .setId(item["id"].ToString())
                    .setAddress(item["DiaChi"].ToString())
                    .setBirth(DateTime.Parse(item["NgaySinh"].ToString()))
                    .setIdentityCard(Int32.Parse(item["CMND"].ToString()))
                    .setName(item["HoTen"].ToString())
                    .setPhone(item["SDT"].ToString()).Build();
                staffList.Add(staff);
            }
			return staffList;
		}

        public static DataTable GetListStaff()
        {
            return DataProvider.getInstance().ExecuteQuery("EXEC USP_GetStaff");
        }

        public static bool InsertStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            int result = DataProvider.getInstance().ExecuteNonQuery("EXEC USP_InsertStaff @idStaff , @hoTen , @ngaySinh , @diaChi , @sdt , @cmnd ", new object[] { id, hoTen, ngaySinh, diaChi, sdt, cmnd });
            return result > 0;
        }

        public static bool UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            string command = string.Format("UPDATE dbo.NhanVien SET HoTen = N'{0}', NgaySinh = '{1}', DiaChi = N'{2}', SDT = '{3}', CMND = {4} WHERE id = '{5}'", hoTen, ngaySinh, diaChi, sdt, cmnd, id);
            int result = DataProvider.getInstance().ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteStaff(string id)
        {
            TaiKhoanDAO.DeleteAccountByIdStaff(id);
            int result = DataProvider.getInstance().ExecuteNonQuery("DELETE dbo.NhanVien WHERE id = '" + id + "'");
            return result > 0;
        }

        public static DataTable SearchStaffByName(string name)
        {
            
            DataTable data = DataProvider.getInstance().ExecuteQuery("EXEC USP_SearchStaff @hoTen", new object[] { name });
            
            return data;
        }
    }
}