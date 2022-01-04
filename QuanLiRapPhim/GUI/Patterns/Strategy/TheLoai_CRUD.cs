using QuanLiRapPhim.DAO;
using QuanLiRapPhim.Patterns.Strategy;
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
    public class AddTL : AddMethod
    {
        public void add(ArrayList data)
        {
            if (TheLoaiDAO.InsertGenre((string)data[0], (string)data[1], (string)data[2]))
            {
                MessageBox.Show("Thêm thể loại thành công");
            }
            else
            {
                MessageBox.Show("Thêm thể loại thất bại");
            }
        }
    }
    public class LoadTL : LoadMethod
    {
        public DataTable load()
        {
            return TheLoaiDAO.GetGenre();
        }
    }
    public class UpdateTL : UpdateMethod
    {
        public void update(ArrayList data)
        {
            if (TheLoaiDAO.UpdateGenre((string)data[0], (string)data[1], (string)data[2]))
            {
                MessageBox.Show("Sửa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Sửa thể loại thất bại");
            }
        }
    }
    public class DeleteTL : DeleteMethod
    {
        public void delete(string id)
        {
            if (TheLoaiDAO.DeleteGenre(id))
            {
                MessageBox.Show("Xóa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Xóa thể loại thất bại");
            }
        }
    }
}


