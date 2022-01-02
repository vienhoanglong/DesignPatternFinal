using QuanLiRapPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLiRapPhim.DAO
{
    public class VeDAO
    {
        public static List<Ve> GetListTicketsByShowTimes(string showTimesID)
        {
            List<Ve> listTicket = new List<Ve>();
            string query = "select * from Ve where idLichChieu = '" + showTimesID + "'";
            DataTable data = DataProvider.getInstance().ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ve ticket = new Ve(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }

        public static List<Ve> GetListTicketsBoughtByShowTimes(string showTimesID)
        {
            List<Ve> listTicket = new List<Ve>();
            string query = "select * from Ve where idLichChieu = '" + showTimesID + "' and TrangThai = 1";
            DataTable data = DataProvider.getInstance().ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ve ticket = new Ve(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }

        public static int CountToltalTicketByShowTime(string showTimesID)
        {
            string query = "Select count (id) from Ve where idLichChieu ='" + showTimesID + "'";
            return (int)DataProvider.getInstance().ExecuteScalar(query);
        }
        public static int CountTheNumberOfTicketsSoldByShowTime(string showTimesID)
        {
            string query = "Select count (id) from Ve where idLichChieu ='" + showTimesID + "' and TrangThai = 1 ";
            return (int)DataProvider.getInstance().ExecuteScalar(query);
        }
        public static int BuyTicket(string ticketID, int type, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, LoaiVe = "
                + type + ", TienBanVe =" + price + " where id = '" + ticketID + "'";
            return DataProvider.getInstance().ExecuteNonQuery(query);
        }
        public static int BuyTicket(string ticketID, int type, string customerID, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, LoaiVe = "+ type 
                + ", idKhachHang =N'" + customerID + "', TienBanVe =" + price +" where id = '" + ticketID + "'";
            return DataProvider.getInstance().ExecuteNonQuery(query);
        }

        public static int InsertTicketByShowTimes(string showTimesID, string seatName)
        {
            string query = "USP_InsertTicketByShowTimes @idlichChieu , @maGheNgoi";
            return DataProvider.getInstance().ExecuteNonQuery(query, new object[] { showTimesID, seatName });
        }

        public static int DeleteTicketsByShowTimes(string showTimesID)
        {
            string query = "USP_DeleteTicketsByShowTimes @idlichChieu";
            return DataProvider.getInstance().ExecuteNonQuery(query, new object[] { showTimesID });
        }
    }
}
