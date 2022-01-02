using QuanLiRapPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DAO
{
    public class TheLoaiDAO
    {
        public static List<TheLoai> GetListGenre()
        {
            List<TheLoai> genreList = new List<TheLoai>();
            DataTable data = DataProvider.getInstance().ExecuteQuery("SELECT * FROM dbo.TheLoai");
            foreach (DataRow item in data.Rows)
            {
                TheLoai genre = new TheLoai(item);
                genreList.Add(genre);
            }
            return genreList;
        }

        public static DataTable GetGenre()
        {
            return DataProvider.getInstance().ExecuteQuery("SELECT id AS [Mã thể loại], TenTheLoai AS [Tên thể loại], MoTa AS [Mô tả] FROM dbo.TheLoai");
        }

        public static bool InsertGenre(string id, string name, string desc)
        {
            int result = DataProvider.getInstance().ExecuteNonQuery("EXEC USP_InsertGenre @idGenre , @ten , @moTa ", new object[] { id, name, desc });
            return result > 0;
        }

        public static bool UpdateGenre(string id, string name, string desc)
        {
            string command = string.Format("UPDATE dbo.TheLoai SET TenTheLoai = N'{0}', MoTa = N'{1}' WHERE id = '{2}'", name, desc, id);
            int result = DataProvider.getInstance().ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteGenre(string id)
        {
			DataProvider.getInstance().ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idTheLoai = '" + id + "'");

			int result = DataProvider.getInstance().ExecuteNonQuery("DELETE dbo.TheLoai WHERE id = '" + id + "'");
            return result > 0;
        }
    }
}
