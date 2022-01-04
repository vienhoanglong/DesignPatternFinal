using QuanLiRapPhim.DAO;
using QuanLiRapPhim.DTO;
using QuanLiRapPhim.Patterns.Strategy;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim.frmAdminUserControls
{
    public partial class TaiKhoan : UserControl
    {
        private ObjectCRUD TK;
        readonly BindingSource accountList = new BindingSource();

        public TaiKhoan()
        {
            TK = new ObjectCRUD("TaiKhoan");
            InitializeComponent();
            LoadAccount();
        }

        void LoadAccount()
        {
            dtgvAccount.DataSource = accountList;
            LoadAccountList();
            AddAccountBinding();
        }
        void LoadAccountList()
        {
            accountList.DataSource = TK.load();
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        void AddAccountBinding()
        {
            txtUsername.DataBindings.Add("Text", dtgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never);
            nudAccountType.DataBindings.Add("Value", dtgvAccount.DataSource, "Loại tài khoản", true, DataSourceUpdateMode.Never);
            LoadStaffIntoComboBox(cboStaffID_Account);
        }
        void LoadStaffIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = NhanVienDAO.GetStaff();
            cbo.DisplayMember = "ID";
            cbo.ValueMember = "ID";
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string staffID = (string)dtgvAccount.SelectedCells[0].OwningRow.Cells["Mã nhân viên"].Value;
            DTO.NhanVien staff = NhanVienDAO.GetStaffByID(staffID);

            if (staff == null)
                return;

            cboStaffID_Account.SelectedItem = staff;

            int index = -1;
            int i = 0;
            foreach (DTO.NhanVien item in cboStaffID_Account.Items)
            {
                if (item.ID == staff.ID)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cboStaffID_Account.SelectedIndex = index;
        }
        private void cboStaffID_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboStaffID_Account.SelectedItem is DTO.NhanVien staff))
                return;
            txtStaffName_Account.Text = staff.Name;
        }

        void InsertAccount(string username, int accountType, string idStaff)
        {
            //if (TaiKhoanDAO.InsertAccount(username, accountType, idStaff))
            //{
            //    MessageBox.Show("Thêm tài khoản thành công, mật khẩu mặc định : 1");
            //}
            //else
            //{
            //    MessageBox.Show("Thêm tài khoản thất bại");
            //}
            ArrayList data = new ArrayList() { username, accountType, idStaff };

            TK.add(data);
        }
        private void btnInsertAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            int accountType = (int)nudAccountType.Value;
            string staffID = cboStaffID_Account.SelectedValue.ToString();
            InsertAccount(username, accountType, staffID);
            LoadAccountList();
        }

        void UpdateAccount(string username, int accountType)
        {
            //if (TaiKhoanDAO.UpdateAccount(username, accountType))
            //{
            //    MessageBox.Show("Sửa tài khoản thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Sửa tài khoản thất bại");
            //}

            ArrayList data = new ArrayList() { username, accountType };

            TK.update(data);
        }
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            int accountType = (int)nudAccountType.Value;
            UpdateAccount(username, accountType);
            LoadAccountList();
        }

        void DeleteAccount(string username)
        {
            //if (TaiKhoanDAO.DeleteAccount(username))
            //{
            //    MessageBox.Show("Xóa tài khoản thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Xóa tài khoản thất bại");
            //}
            TK.delete(username);
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            DeleteAccount(username);
            LoadAccountList();
        }

        void ResetPassword(string username)
        {
            if (TaiKhoanDAO.ResetPassword(username))
            {
                MessageBox.Show("Reset mật khẩu thành công, mật khẩu mặc định : 1");
            }
            else
            {
                MessageBox.Show("Reset mật khẩu thất bại");
            }
        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            ResetPassword(username);
            LoadAccountList();
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            string staffName = txtSearchAccount.Text;
            accountList.DataSource = TaiKhoanDAO.SearchAccountByStaffName(staffName);
        }

		private void txtSearchAccount_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchAccount.PerformClick();
				e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
			}
		}

       
    }
}
