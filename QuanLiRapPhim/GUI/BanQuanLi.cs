using QuanLiRapPhim.frmAdminUserControls;
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
            QuanLi dataUC = new QuanLi();
            QuanLi dataUc = dataUC;
            dataUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(dataUc);
        }

        private void btnStaffUC_Click(object sender, EventArgs e)
        {
            this.Text = "Nhân Viên";
            pnAdmin.Controls.Clear();
            NhanVien staffUC = new NhanVien();
            NhanVien staffUc = staffUC;
            staffUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(staffUc);
        }

        private void btnCustomerUC_Click(object sender, EventArgs e)
        {
            this.Text = "Khách Hàng";
            pnAdmin.Controls.Clear();
            frmAdminUserControls.KhachHang customerUC = new frmAdminUserControls.KhachHang();
            frmAdminUserControls.KhachHang customerUc = customerUC;
            customerUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(customerUc);
        }

        private void btnAccountUC_Click(object sender, EventArgs e)
        {
            this.Text = "Tài Khoản";
            pnAdmin.Controls.Clear();
            TaiKhoan accountUc = new TaiKhoan
            {
                Dock = DockStyle.Fill
            };
            pnAdmin.Controls.Add(accountUc);
        }
    }
}
