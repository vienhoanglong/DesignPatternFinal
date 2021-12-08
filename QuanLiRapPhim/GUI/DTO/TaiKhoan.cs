using System;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DTO
{
    public class TaiKhoan
    {
        public TaiKhoan(string userName, string staffID, int type, string password = null)
        {
            this.UserName = userName;
            this.Password = password;
            this.Type = type;
            this.StaffID = staffID;
        }

        public TaiKhoan(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.Password = row["Pass"].ToString();
            this.Type = (int)row["LoaiTK"];
            this.StaffID = row["idNV"].ToString();
        }


        public int Type { get; set; }

        public string Password { get; set; }

        public string StaffID { get; set; }

        public string UserName { get; set; }

    }
}
