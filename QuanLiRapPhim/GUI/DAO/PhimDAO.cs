using QuanLiRapPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace QuanLiRapPhim.DAO
{
    public class PhimDAO
    {
        //ảnh -> byte[]
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        //byte[] -> ảnh
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static List<Phim> GetListMovieByDate(DateTime date)
        {
            List<Phim> listMovie = new List<Phim>();
            DataTable data = DataProvider.ExecuteQuery("select * from Phim where @Date <= NgayKetThuc", new object[] { date });
            foreach (DataRow row in data.Rows)
            {
                Phim movie = new Phim(row);
                listMovie.Add(movie);
            }
            return listMovie;
        }

        public static List<Phim> GetListMovie()
        {
            List<Phim> listMovie = new List<Phim>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM Phim");
            foreach (DataRow row in data.Rows)
            {
                Phim movie = new Phim(row);
                listMovie.Add(movie);
            }
            return listMovie;
        }

        public static DataTable GetMovie()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetMovie");
        }

        public static bool InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertMovie @id , @tenPhim , @moTa , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX , @apPhich ", new object[] { id, name, desc, length, startDate, endDate, productor, director, year, image});
            return result > 0;
        }

        public static bool UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_UpdateMovie @id , @tenPhim , @moTa , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX , @apPhich ", new object[] { id, name, desc, length, startDate, endDate, productor, director, year, image });
            return result > 0;
        }

        public static bool DeleteMovie(string id)
        {
			DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + id + "'");
			DataProvider.ExecuteNonQuery("DELETE dbo.DinhDangPhim WHERE idPhim = '" + id + "'");

			PhanLoaiPhimDAO.DeleteMovie_GenreByMovieID(id);
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.Phim WHERE id = '" + id + "'");
            return result > 0;
        }

        public static Phim GetMovieByID(string id)
        {
            Phim movie = null;
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.Phim WHERE id = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                movie = new Phim(item);
                return movie;
            }
            return movie;
        }
    }
}
