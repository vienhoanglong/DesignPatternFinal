using QuanLiRapPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DAO
{
    public class PhanLoaiPhimDAO
    {
        public static List<TheLoai> GetListGenreByMovieID(string id)
        {
            List<TheLoai> genreList = new List<TheLoai>();
            DataTable data = DataProvider.ExecuteQuery("EXEC USP_GetListGenreByMovie @idPhim", new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                TheLoai genre = new TheLoai(item);
                genreList.Add(genre);
            }
            return genreList;
        }

        public static void InsertMovie_Genre(string movieID, List<TheLoai> genreList)
        {
            foreach (TheLoai item in genreList)
            {
                string command = string.Format("INSERT dbo.PhanLoaiPhim (idPhim, idTheLoai) VALUES  ('{0}','{1}')", movieID, item.ID);
                DataProvider.ExecuteNonQuery(command);
            }
        }

        public static void UpdateMovie_Genre(string movieID, List<TheLoai> genreList)
        //Idea : Delete all rows that contain movieID, then re-add all genre that have been chosen from CheckedListBox to 'PhanLoaiPhim' with movieID
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + movieID + "'");
            foreach (TheLoai item in genreList)
            {
                string command = string.Format("INSERT dbo.PhanLoaiPhim (idPhim, idTheLoai) VALUES  ('{0}','{1}')", movieID, item.ID);
                DataProvider.ExecuteNonQuery(command);
            }
        }

        public static void DeleteMovie_GenreByMovieID(string movieID)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + movieID + "'");
        }
    }
}
