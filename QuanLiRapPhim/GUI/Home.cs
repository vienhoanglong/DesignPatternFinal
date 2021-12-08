using QuanLiRapPhim.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class Home : Form
    {
        public Home(TaiKhoan acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;
        }

        private TaiKhoan loginAccount;

        public TaiKhoan LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        private void ChangeAccount(int type)
        {
            if (loginAccount.Type == 2) btnAdmin.Enabled = false;
            lblAccountInfo.Text += LoginAccount.UserName;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            BanQuanLi frm = new BanQuanLi();
            frm.ShowDialog();
            this.Show();
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            this.Hide();
            NVBanve frm = new NVBanve();
            frm.ShowDialog();
            this.Show();
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            DoiMK frm = new DoiMK(loginAccount);
            frm.ShowDialog();
            this.Show();
        }

        
    }
}