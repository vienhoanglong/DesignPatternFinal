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
    public class AddKH : AddMethod
    {
        public void add(ArrayList data)
        {

            if (KhachHangDAO.InsertCustomer((string)data[0], (string)data[1], (DateTime)data[2], (string)data[3], (string)data[4], (int)data[5]))
            {
                MessageBox.Show("Thêm khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại");
            }
        }
    }
    public class LoadKH : LoadMethod
    {
        public DataTable load()
        {
            return KhachHangDAO.GetListCustomer();
        }
    }
    public class UpdateKH : UpdateMethod
    {
        public void update(ArrayList data)
        {
            if (KhachHangDAO.UpdateCustomer((string)data[0], (string)data[1], (DateTime)data[2], (string)data[3], (string)data[4], (int)data[5], (int)data[6]))
            {
                MessageBox.Show("Sửa khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại");
            }
        }
    }
    public class DeleteKH : DeleteMethod
    {
        public void delete(string id)
        {
            if (KhachHangDAO.DeleteCustomer(id))
            {
                MessageBox.Show("Xóa khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại");
            }
        }
    }
}
