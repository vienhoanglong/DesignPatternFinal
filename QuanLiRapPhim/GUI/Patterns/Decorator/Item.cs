using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Decorator
{
    public enum ItemType
    {
        Bap,
        Nuoc
    }
    public abstract class Item : ISubject
    {
        protected ISubject subject { get; set; }
        protected Item(ISubject subject, int soLuong)
        {
            this.soLuong = soLuong;
            this.subject = subject;
        }
    }
    public class Bap : Item
    {
        public string loaiBap;
        public Bap(ISubject subject, string loaiBap, int soLuong) : base(subject, soLuong)
        {
            this.loaiBap = loaiBap;
            this.giaBan = 50000;
        }
        public override float cost()
        {
            return this.giaBan * this.soLuong + subject.cost();
        }
    }
    public class Nuoc : Item
    {
        public string loaiNuoc;
        public Nuoc(ISubject subject, string loaiNuoc, int soLuong) : base(subject, soLuong)
        {
            this.loaiNuoc = loaiNuoc;
            this.giaBan = 30000;
        }
        public override float cost()
        {
            return this.giaBan * this.soLuong + subject.cost();
        }
    }
   
}
