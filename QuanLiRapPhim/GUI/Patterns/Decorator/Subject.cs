using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Decorator
{
    public abstract class ISubject
    {
        protected float giaBan { get; set; }
        protected int soLuong { get; set; }
        protected string loaiVe { get; set; }
        protected string viTriGhe { get; set; }
        protected string phim { get; set; }
        protected DateTime thoiGianChieu { get; set; }
        public abstract float cost();
        public void setGiaBan(float giaBan)
        {
            this.giaBan = giaBan;
        }
        public float getGiaBan()
        {
            return this.giaBan;
        }
        public int getSoLuong()
        {
            return this.soLuong;
        }
        public void setSoLuong(int soLuong)
        {
            this.soLuong = soLuong;
        }
        public string getLoaiVe()
        {
            return this.loaiVe;
        }
        public void setLoaiVe(string loaiVe)
        {
            this.loaiVe = loaiVe;
        }
        public string getViTriGhe()
        {
            return this.viTriGhe;
        }
        public void setViTriGhe(string viTriGhe)
        {
            this.viTriGhe = viTriGhe;
        }
        public string getPhim()
        {
            return this.phim;
        }
        public void setPhim(string phim)
        {
            this.phim = phim;
        }
        public DateTime getThoiGianChieu()
        {
            return this.thoiGianChieu;
        }
        public void setThoiGianChieu(DateTime thoiGianChieu)
        {
            this.thoiGianChieu = thoiGianChieu;
        }
    }
    public class VeXemPhim: ISubject
    {
        public VeXemPhim(string phim, DateTime thoiGianChieu)
        {
            this.phim = phim;
            this.thoiGianChieu = thoiGianChieu;
        }

        public override float cost()
        {
           return giaBan;
        }
    }
  
}
