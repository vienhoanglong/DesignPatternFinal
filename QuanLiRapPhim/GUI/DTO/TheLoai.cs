using System;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DTO
{
    public class TheLoai
    {

        public TheLoai(string iD, string name, string desc = null)
        {
            this.ID = iD;
            this.Name = name;
            this.Desc = desc;
        }

        public TheLoai(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenTheLoai"].ToString();
            if (row["MoTa"].ToString() != "")
                this.Desc = row["MoTa"].ToString();
            else
                this.Desc = "";
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }
}
