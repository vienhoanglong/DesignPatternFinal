using System;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DTO
{
    public class PhanLoaiPhim
    {
        public PhanLoaiPhim(string movieID, string genre)
        {
            this.MovieID = movieID;
            this.Genre = genre;
        }

        public PhanLoaiPhim(DataRow row)
        {
            this.MovieID = row["idPhim"].ToString();
            this.Genre = row["idTheLoai"].ToString();
        }

        public string MovieID { get; set; }

        public string Genre { get; set; }
    }
}
