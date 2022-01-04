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
    public class AddTK : AddMethod
    {
        public void add(ArrayList data)
        {
            if (TaiKhoanDAO.InsertAccount((string)data[0], (int)data[1], (string)data[2]))
            {
                MessageBox.Show("Thêm tài khoản thành công, mật khẩu mặc định : 1");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }
    }
    public class LoadTK : LoadMethod
    {
        public DataTable load()
        {
            return TaiKhoanDAO.GetAccountList();
        }
    }
    public class UpdateTK : UpdateMethod
    {
        public void update(ArrayList data)
        {
            if (TaiKhoanDAO.UpdateAccount((string)data[0], (int)data[1]))
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại");
            }
        }
    }
    public class DeleteTK : DeleteMethod
    {
        public void delete(string id)
        {
            if (TaiKhoanDAO.DeleteAccount(id))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
        }
    }
}
