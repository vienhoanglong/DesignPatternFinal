﻿using System;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DTO
{
    public class Ve
    {
        public Ve() { }

        public Ve(string iD, int type, string showTimesID, string seatName
            , string customerID, string promotionID, float price,
            int status)
        {
            this.ID = iD;
            this.Type = type;
            this.ShowTimesID = showTimesID;
            this.SeatName = seatName;
            this.CustomerID = customerID;
            PromotionID = promotionID;
            this.Status = status;
            this.Price = price;
        }

        public Ve(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Type = (int)row["LoaiVe"];
            this.ShowTimesID = row["idLichChieu"].ToString();
            this.SeatName = row["MaGheNgoi"].ToString();
            this.CustomerID = row["idKhachHang"].ToString();
            this.Status = (int)row["TrangThai"];
            if (row["TienBanVe"].ToString() == "")
                this.Price = 0;
            else
                this.Price = float.Parse(row["TienBanVe"].ToString());
        }

        public string ID { get; set; }

        public int Type { get; set; }

        public string ShowTimesID { get; set; }

        public string SeatName { get; set; }

        public string CustomerID { get; set; }
        public string PromotionID { get; }
        public float Price { get; set; }

        public int Status { get; set; }
    }
}
