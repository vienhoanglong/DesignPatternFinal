using QuanLiRapPhim.DAO;
using QuanLiRapPhim.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class DoiMK : Form
    {
        TaiKhoan loginAccount;

        public TaiKhoan LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public DoiMK(TaiKhoan account)
        {
            InitializeComponent();

            LoginAccount = account;
        }

        void ChangeAccount(TaiKhoan account)
        {
            txtStaffID.Text = account.StaffID.ToString();
            txtUsername.Text = account.UserName.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
