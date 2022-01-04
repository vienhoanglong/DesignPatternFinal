using QuanLiRapPhim.frmAdminUserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiRapPhim.Patterns.Factory
{
    public enum FormType
    {
        QuanLi,
        NhanVien,
        KhachHang,
        TaiKhoan
    }
    class FormFactory
    {
        public static UserControl CreateForm(FormType type)
        {
            UserControl form = null;
            switch (type)
            {
                case FormType.QuanLi:
                    form = new QuanLi();
                    break;
                case FormType.NhanVien:
                    form = new NhanVien();
                    break;
                case FormType.KhachHang:
                    form = new frmAdminUserControls.KhachHang();
                    break;
                case FormType.TaiKhoan:
                    form = new TaiKhoan();
                    break;
            }
            return form;
        }
        
    }
}
