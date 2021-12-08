using System;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DTO
{
    public class DinhDangPhim
    {
        public DinhDangPhim(string iD, string movieName, string screenTypeName)
        {
            this.ID = iD;
            this.MovieName = movieName;
            this.ScreenTypeName = screenTypeName;
        }

        public DinhDangPhim(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.MovieName = row["TenPhim"].ToString();
            this.ScreenTypeName = row["TenMH"].ToString();
        }

        public string ID { get; set; }

        public string MovieName { get; set; }

        public string ScreenTypeName { get; set; }
    }
}
