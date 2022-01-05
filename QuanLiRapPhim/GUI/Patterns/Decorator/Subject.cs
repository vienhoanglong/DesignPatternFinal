using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.Decorator
{
    public abstract class ISubject
    {
        protected float giaBan;
        protected int soLuong;
        public abstract float cost();
        public void setGiaBan(float giaBan)
        {
            this.giaBan = giaBan;
        }
        public void setSoLuong(int soLuong)
        {
            this.soLuong = soLuong;
        }
        public float getGiaBan() { return this.giaBan; }
        public int getSoLuong() { return this.soLuong; }
        
    }
    public class VeXemPhim : ISubject
    {
        private string loaiVe;
        private List<string> viTriGhe;
        private string phim;
        private DateTime thoiGianChieu;
        public VeXemPhim(string loaiVe, List<string> viTriGhe,string phim, DateTime thoiGianChieu)
        {
            this.loaiVe = loaiVe;
            this.viTriGhe = viTriGhe;
            this.phim = phim;
            this.thoiGianChieu = thoiGianChieu;
            this.setSoLuong( viTriGhe.Count);
            this.setGiaBan( 85000);
        }
        public VeXemPhim(string phim, DateTime thoiGianChieu)
        {
            this.loaiVe = "Adult";
            this.phim = phim;
            this.thoiGianChieu = thoiGianChieu;
            this.setGiaBan(85000);
            this.viTriGhe = new List<string>();
            
        }
        public override float cost()
        {
            return this.getGiaBan() * this.getSoLuong();
        }
        public void addGhe(string ghe)
        {
            if (!viTriGhe.Contains(ghe)) viTriGhe.Add(ghe);
            this.setSoLuong(viTriGhe.Count);
        }
        public void removeGhe(string ghe)
        {
            if (viTriGhe.Contains(ghe)) viTriGhe.Remove(ghe);
            this.setSoLuong(viTriGhe.Count);
        }
        public void setLoaiVe(string loaiVe)
        {
            this.loaiVe = loaiVe;
            if(loaiVe == "Adult") { this.setGiaBan(85000) ; }
            else if (loaiVe == "Student") this.setGiaBan(85000 * 0.8f);
            else if (loaiVe == "Child") this.setGiaBan(85000 * 0.7f);
        }
    }
    
    
}
