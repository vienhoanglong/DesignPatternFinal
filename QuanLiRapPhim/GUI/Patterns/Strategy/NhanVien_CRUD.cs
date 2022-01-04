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
    public class AddNV : AddMethod
    {
        public void add(ArrayList data)
        {
            if (NhanVienDAO.InsertStaff((string)data[0], (string)data[1],(DateTime) data[2], (string)data[3], (string)data[4], (int)data[5]))
            {
                MessageBox.Show("Thêm nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
        }
    }
    public class LoadNV : LoadMethod
    {
        public DataTable load()
        {
            return NhanVienDAO.GetListStaff();
        }
    }
    public class UpdateNV : UpdateMethod
    {
        public void update(ArrayList data)
        {
            if (NhanVienDAO.UpdateStaff((string)data[0], (string)data[1], (DateTime)data[2], (string)data[3], (string)data[4], (int)data[5]))
            {
                MessageBox.Show("Sửa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại");
            }
        }
    }
    public class DeleteNV : DeleteMethod
    {
        public void delete(string id)
        {
            if (NhanVienDAO.DeleteStaff(id))
            {
                MessageBox.Show("Xóa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
        }
    }
}
