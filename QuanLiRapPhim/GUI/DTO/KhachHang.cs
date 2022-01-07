using System;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DTO
{
    public class KhachHang : Human
    {
        public KhachHang(string iD, string name, DateTime birth, string address,
            string phone, int identityCard, int point)
        {
            this.ID = iD;
            this.Name = name;
            this.BirthDate = birth;
            this.Address = address;
            this.Phone = phone;
            this.IdentityCard = identityCard;
            this.Point = point;
        }

        
        public string ID { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int IdentityCard { get; set; }

        public int Point { get; set; }
    }
}
