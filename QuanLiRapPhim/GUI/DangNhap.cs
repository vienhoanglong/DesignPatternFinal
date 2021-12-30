using QuanLiRapPhim.DAO;
using QuanLiRapPhim.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            string userName = txtUsername.Text;
            string passWord = txtPassword.Text;
            int result = Login(userName, passWord);
            if (result == 1)
            {
                TaiKhoan loginAccount = TaiKhoanDAO.GetAccountByUserName(userName);
                Home frm = new Home(loginAccount);
                this.Hide();
                frm.ShowDialog();
                this.Show();

            }
            else if (result == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo");
            }
            btnLogin.Enabled = true;
        }

        private int Login(string userName, string passWord)
        {
            return TaiKhoanDAO.Login(userName, passWord);
        }
    }
}
