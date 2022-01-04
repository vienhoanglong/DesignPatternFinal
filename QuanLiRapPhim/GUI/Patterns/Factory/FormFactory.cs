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
                    form.Dock = DockStyle.Fill;
                    break;
                case FormType.NhanVien:
                    form = new NhanVien();
                    form.Dock = DockStyle.Fill;
                    break;
                case FormType.KhachHang:
                    form = new frmAdminUserControls.KhachHang();
                    form.Dock = DockStyle.Fill;
                    break;
                case FormType.TaiKhoan:
                    form = new TaiKhoan();
                    form.Dock = DockStyle.Fill;
                    break;
            }
            return form;
        }
        
    }
}
