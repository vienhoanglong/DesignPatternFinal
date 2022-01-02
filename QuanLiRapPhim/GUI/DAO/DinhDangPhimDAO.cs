using QuanLiRapPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DAO
{
    public class DinhDangPhimDAO
    {
        public static List<DinhDangPhim> GetListFormatMovieByMovie(string movieID)
        {
            List<DinhDangPhim> listFormat = new List<DinhDangPhim>();
            string query = "select d.id, p.TenPhim, m.TenMH " +
                "from Phim p, DinhDangPhim d, LoaiManHinh m " +
                "where p.id = d.idPhim and d.idLoaiManHinh = m.id "
                + "and p.id = '" + movieID + "'";
            DataTable data = DataProvider.getInstance().ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                DinhDangPhim format = new DinhDangPhim(row);
                listFormat.Add(format);
            }
            return listFormat;
        }

        public static DataTable GetFormatMovieByID(string movieID, string screenTypeID)
        {
            string query = "select d.id, p.TenPhim, m.TenMH " +
                "from Phim p, DinhDangPhim d, LoaiManHinh m " +
                "where p.id = d.idPhim and d.idLoaiManHinh = m.id "
                + "and p.id = '" + movieID + "' and m.id = '" + screenTypeID + "'";
            return DataProvider.getInstance().ExecuteQuery(query);
        }

        public static DinhDangPhim GetFormatMovieByName(string movieName, string screenTypeName)
        {
            string command = "SELECT DD.id, P.TenPhim, MH.TenMH " +
                                "FROM dbo.DinhDangPhim DD, dbo.Phim P, dbo.LoaiManHinh MH " +
                                "WHERE DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id AND P.TenPhim = N'" + movieName + "' AND MH.TENMH = N'" + screenTypeName + "'";
            DataTable data = DataProvider.getInstance().ExecuteQuery(command);
            return new DinhDangPhim(data.Rows[0]);
        }

        public static List<DinhDangPhim> GetFormatMovie()
        {
            List<DinhDangPhim> formatMovieList = new List<DinhDangPhim>();
            DataTable data = DataProvider.getInstance().ExecuteQuery("SELECT DD.id, P.TenPhim, MH.TenMH " +
                                                        "FROM dbo.DinhDangPhim DD, dbo.Phim P, dbo.LoaiManHinh MH " +
                                                        "WHERE DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id");
            foreach (DataRow item in data.Rows)
            {
                DinhDangPhim formatMovie = new DinhDangPhim(item);
                formatMovieList.Add(formatMovie);
            }
            return formatMovieList;
        }

        public static DataTable GetListFormatMovie()
        {
            return DataProvider.getInstance().ExecuteQuery("EXEC USP_GetListFormatMovie");
        }

        public static bool InsertFormatMovie(string id, string idMovie, string idScreen)
        {
            int result = DataProvider.getInstance().ExecuteNonQuery("EXEC USP_InsertFormatMovie @id , @idPhim , @idLoaiManHinh ", new object[] { id, idMovie, idScreen });
            return result > 0;
        }

        public static bool UpdateFormatMovie(string id, string idMovie, string idScreen)
        {
            string command = string.Format("UPDATE dbo.DinhDangPhim SET idPhim = '{0}', idLoaiManHinh = '{1}' WHERE id = '{2}'", idMovie, idScreen, id);
            int result = DataProvider.getInstance().ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteFormatMovie(string id)
        {
            DataProvider.getInstance().ExecuteNonQuery("DELETE dbo.LichChieu WHERE idDinhDang = '" + id + "'");

            int result = DataProvider.getInstance().ExecuteNonQuery("DELETE dbo.DinhDangPhim WHERE id = '" + id + "'");
            return result > 0;
        }
    }
}
