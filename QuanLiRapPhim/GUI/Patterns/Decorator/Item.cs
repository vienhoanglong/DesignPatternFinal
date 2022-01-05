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
        protected ISubject subject;

        protected Item(ISubject subject, int soLuong)
        {
            this.soLuong = soLuong;
            this.subject = subject;
        }

        public override float cost()
        {
            return this.giaBan * this.soLuong + subject.cost();
        }
    }
    public class Bap : Item
    {
        private string loaiBap;
        public Bap(ISubject subject, string loaiBap, int soLuong) : base(subject, soLuong)
        {
            this.loaiBap = loaiBap;
            this.giaBan = 50000;
        }
    }
    public class Nuoc : Item
    {
        private string loaiNuoc;
        public Nuoc(ISubject subject, string loaiNuoc, int soLuong) : base(subject, soLuong)
        {
            this.loaiNuoc = loaiNuoc;
            this.giaBan = 50000;
        }
    }
   
}
