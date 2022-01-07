using QuanLiRapPhim.Patterns.Builder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DAO
{
    public class KhachHangDAO
    {
        public static KhachHang GetCusByID(string id)
        {
            KhachHang customer = null;
            DataTable data = DataProvider.getInstance().ExecuteQuery("SELECT * FROM dbo.KhachHang WHERE id = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                IBuilder builder = new KhachHangBuilder()
                    .setId(item["id"].ToString())
                    .setAddress(item["DiaChi"].ToString())
                    .setBirth(DateTime.Parse(item["NgaySinh"].ToString()))
                    .setIdentityCard(Int32.Parse(item["CMND"].ToString()))
                    .setName(item["HoTen"].ToString())
                    .setPhone(item["SDT"].ToString())
                    .setPoint((Int32.Parse(item["DiemTichLuy"].ToString())));
                customer = (KhachHang)builder.Build();
                return customer;
            }
            return customer;
        }

        public static List<KhachHang> GetStaff()
        {
            List<KhachHang> cusList = new List<KhachHang>();
            DataTable data = DataProvider.getInstance().ExecuteQuery("SELECT * FROM dbo.KhachHang");
            foreach (DataRow item in data.Rows)
            {
                KhachHang customer = (KhachHang)new KhachHangBuilder()
                    .setId(item["id"].ToString())
                    .setAddress(item["DiaChi"].ToString())
                    .setBirth(DateTime.Parse(item["NgaySinh"].ToString()))
                    .setIdentityCard(Int32.Parse(item["CMND"].ToString()))
                    .setName(item["HoTen"].ToString())
                    .setPhone(item["SDT"].ToString())
                    .setPoint((Int32.Parse(item["DiemTichLuy"].ToString()))).Build();
                cusList.Add(customer);
            }
            return cusList;
        }
        public static DataTable GetCustomerMember(string customerID, string name)
        {
            string query = "Select * from KhachHang where id = '" + customerID + "' and HoTen = N'" + name + "'";
            return DataProvider.getInstance().ExecuteQuery(query);
        }

        public static DataTable GetListCustomer()
        {
            return DataProvider.getInstance().ExecuteQuery("EXEC USP_GetCustomer");
        }

        public static bool InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            int result = DataProvider.getInstance().ExecuteNonQuery("EXEC USP_InsertCustomer @idCus , @hoTen , @ngaySinh , @diaChi , @sdt , @cmnd ", new object[] { id, hoTen, ngaySinh, diaChi, sdt, cmnd });
            return result > 0;
        }

        public static bool UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            string command = string.Format("UPDATE dbo.KhachHang SET HoTen = N'{0}', NgaySinh = '{1}', DiaChi = N'{2}', SDT = '{3}', CMND = {4}, DiemTichLuy = {5} WHERE id = '{6}'", hoTen, ngaySinh, diaChi, sdt, cmnd, point, id);
            int result = DataProvider.getInstance().ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool UpdatePointCustomer(string id, int point)
        {
            string command = string.Format("UPDATE dbo.KhachHang SET  DiemTichLuy = {0} WHERE id = '{1}'", point, id);
            int result = DataProvider.getInstance().ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteCustomer(string id)
        {
            int result = DataProvider.getInstance().ExecuteNonQuery("DELETE dbo.KhachHang WHERE id = '" + id + "'");
            return result > 0;
        }

        public static DataTable SearchCustomerByName(string name)
        {
            return DataProvider.getInstance().ExecuteQuery("EXEC USP_SearchCustomer @hoTen", new object[] { name });
        }
      
    }
}
