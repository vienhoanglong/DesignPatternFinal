using QuanLiRapPhim.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLiRapPhim.Patterns.Strategy
{
    public class AddMV : AddMethod
    {
        public void add(ArrayList data)
        {
            if (PhimDAO.InsertMovie((string)data[0], (string)data[1], (string)data[2], (float)data[3], (DateTime)data[4], (DateTime)data[5], (string)data[6], (string)data[7], (int)data[8], (byte[])data[9]))
            {
                MessageBox.Show("Thêm phim thành công");
            }
            else
            {
                MessageBox.Show("Thêm phim thất bại");
            }
        }
    }
    public class LoadMV : LoadMethod
    {
        public DataTable load()
        {
            return PhimDAO.GetMovie();
        }
    }
    public class UpdateMV : UpdateMethod
    {
        public void update(ArrayList data)
        {
            if (PhimDAO.UpdateMovie((string)data[0], (string)data[1], (string)data[2], (float)data[3], (DateTime)data[4], (DateTime)data[5], (string)data[6], (string)data[7], (int)data[8], (byte[])data[9]))
            {
                MessageBox.Show("Sửa phim thành công");
            }
            else
            {
                MessageBox.Show("Sửa phim thất bại");
            }
        }
    }
    public class DeleteMV : DeleteMethod
    {
        public void delete(string id)
        {
            if (PhimDAO.DeleteMovie(id))
            {
                MessageBox.Show("Xóa phim thành công");
            }
            else
            {
                MessageBox.Show("Xóa phim thất bại");
            }
        }
    }
}
