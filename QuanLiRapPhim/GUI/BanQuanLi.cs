using QuanLiRapPhim.frmAdminUserControls;
using QuanLiRapPhim.Patterns.Factory;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class BanQuanLi : Form
    {
        
        public BanQuanLi()
        {
            InitializeComponent();
        }

        private void btnDataUC_Click(object sender, EventArgs e)
        {
            this.Text = "Dữ Liệu";
            pnAdmin.Controls.Clear();
            UserControl dataUc = FormFactory.CreateForm(FormType.QuanLi);
            pnAdmin.Controls.Add(dataUc);
        }

        private void btnStaffUC_Click(object sender, EventArgs e)
        {
            this.Text = "Nhân Viên";
            pnAdmin.Controls.Clear();
            UserControl staffUc = FormFactory.CreateForm(FormType.NhanVien);
            pnAdmin.Controls.Add(staffUc);
        }

        private void btnCustomerUC_Click(object sender, EventArgs e)
        {
            this.Text = "Khách Hàng";
            pnAdmin.Controls.Clear();
            UserControl customerUc = FormFactory.CreateForm(FormType.KhachHang);
            pnAdmin.Controls.Add(customerUc);
        }

        private void btnAccountUC_Click(object sender, EventArgs e)
        {
            this.Text = "Tài Khoản";
            pnAdmin.Controls.Clear();
            UserControl accountUc = FormFactory.CreateForm(FormType.TaiKhoan);
            pnAdmin.Controls.Add(accountUc);
        }
    }
}
