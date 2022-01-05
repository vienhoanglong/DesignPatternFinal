using QuanLiRapPhim.DTO;
using QuanLiRapPhim.Patterns.Proxy;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class Home : Form
    {
        private UserService service;
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
            if (loginAccount.Type == 2) 
            { 
                //btnAdmin.Enabled = false;
                service = new UserServiceProxy("User service", "user");
            }
            else
            {
                service = new UserServiceProxy("User service", "admin");

            }
            lblAccountInfo.Text += LoginAccount.UserName;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                service.loadBanQuanLy();
                this.Hide();
                BanQuanLi frm = new BanQuanLi();
                frm.ShowDialog();
                this.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            service.loadBanVe();
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