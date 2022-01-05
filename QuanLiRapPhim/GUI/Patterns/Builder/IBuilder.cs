using QuanLiRapPhim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Builder
{
    public interface IBuilder
    {
        IBuilder setId(string ID);
        IBuilder setName(string name);
        IBuilder setBirth(DateTime birth);
        IBuilder setAddress(string address);
        IBuilder setPhone(string phone);
        IBuilder setIdentityCard(int identityCard);
        IBuilder setPoint(int point);
        Human Build();
    }
    public class KhachHangBuilder : IBuilder
    {
        private string iD;
        private string name;
        private DateTime birth;
        private string address;
        private string phone;
        private int identityCard;
        private int point;
        public Human Build()
        {
            return new QuanLiRapPhim.DTO.KhachHang(iD, name, birth, address, phone, identityCard, point);
        }

        public IBuilder setAddress(string address)
        {
            this.address = address;
            return this;
        }

        public IBuilder setBirth(DateTime birth)
        {
            this.birth = birth;
            return this;
        }

        public IBuilder setId(string ID)
        {
            this.iD = ID;
            return this;
        }

        public IBuilder setIdentityCard(int identityCard)
        {
            this.identityCard = identityCard;
            return this;
        }

        public IBuilder setName(string name)
        {
            this.name = name;
            return this;
        }

        public IBuilder setPhone(string phone)
        {
            this.phone = phone;
            return this;
        }
        public IBuilder setPoint(int point)
        {
            this.point = point;
            return this;
        }
    }

    public class NhanVienBuilder : IBuilder
    {
        private string iD;
        private string name;
        private DateTime birth;
        private string address;
        private string phone;
        private int identityCard;
        
        public Human Build()
        {
            return new QuanLiRapPhim.DTO.NhanVien(iD, name, birth, address, phone, identityCard);
        }

        public IBuilder setAddress(string address)
        {
            this.address = address;
            return this;
        }

        public IBuilder setBirth(DateTime birth)
        {
            this.birth = birth;
            return this;
        }

        public IBuilder setId(string ID)
        {
            this.iD = ID;
            return this;
        }

        public IBuilder setIdentityCard(int identityCard)
        {
            this.identityCard = identityCard;
            return this;
        }

        public IBuilder setName(string name)
        {
            this.name = name;
            return this;
        }

        public IBuilder setPhone(string phone)
        {
            this.phone = phone;
            return this;
        }
        public IBuilder setPoint(int point)
        {
            return this;
        }

    }

}
