using QuanLiRapPhim.DAO;
using QuanLiRapPhim.Patterns.Strategy;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim.frmAdminUserControls
{
    public partial class NhanVien : UserControl
    {
        private ObjectCRUD NV;
        readonly BindingSource staffList = new BindingSource();

        public NhanVien()
        {
            NV = new ObjectCRUD("NhanVien");
            InitializeComponent();
            LoadStaff();
            txtStaffPhone.setValidator(Patterns.Factory.ValidatorType.PHONE);
            txtStaffName.setValidator(Patterns.Factory.ValidatorType.STRING);
            txtStaffINumber.setValidator(Patterns.Factory.ValidatorType.ID);
            txtStaffBirth.setValidator(Patterns.Factory.ValidatorType.DATE);

        }

        public NhanVien(BindingSource staffList)
        {
            this.staffList = staffList;
        }

        void LoadStaff()
        {
            dtgvStaff.DataSource = staffList;
            LoadStaffList();
            AddStaffBinding();
        }

        void LoadStaffList()
        {
            staffList.DataSource = NV.load();
        }

        private void btnShowStaff_Click(object sender, EventArgs e)
        {
            LoadStaffList();
        }
        void AddStaffBinding()
        {
            txtStaffId.DataBindings.Add("Text", dtgvStaff.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never);
            txtStaffName.DataBindings.Add("Text", dtgvStaff.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            txtStaffBirth.DataBindings.Add("Text", dtgvStaff.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtStaffAddress.DataBindings.Add("Text", dtgvStaff.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtStaffPhone.DataBindings.Add("Text", dtgvStaff.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
            txtStaffINumber.DataBindings.Add("Text", dtgvStaff.DataSource, "CMND", true, DataSourceUpdateMode.Never);

        }


        //Thêm Staff
        void AddStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
           
            ArrayList data = new ArrayList() { id, hoTen, ngaySinh, diaChi, sdt, cmnd };

            NV.add(data);
        }
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (!validateInput()) return;
            string staffId = txtStaffId.Text;
            string staffName = txtStaffName.Text;
            DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            int staffINumber = Int32.Parse(txtStaffINumber.Text);
            AddStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
            LoadStaffList();
        }

        //Sửa Staff
        void UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            
            ArrayList data = new ArrayList() { id, hoTen, ngaySinh, diaChi, sdt, cmnd };

            NV.update(data);
        }
        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            if (!validateInput()) return;
            string staffId = txtStaffId.Text;
            string staffName = txtStaffName.Text;
            DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            int staffINumber = Int32.Parse(txtStaffINumber.Text);
            UpdateStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
            LoadStaffList();
        }

        //Xóa Staff
        void DeleteStaff(string id)
        {

            NV.delete(id);
        }
        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            string staffId = txtStaffId.Text;
            DeleteStaff(staffId);
            LoadStaffList();
        }

        //Tìm kiếm Staff
        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
            string staffName = txtSearchStaff.Text;
            DataTable staffSearchList = NhanVienDAO.SearchStaffByName(staffName);
            staffList.DataSource = staffSearchList;
        }

        private void txtSearchStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchStaff.PerformClick();
                e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
            }
        }

        public bool validateInput()
        {
            if (!txtStaffName.Validate(txtStaffName.Text))
            {
                MessageBox.Show("Invalid name!");
                return false;
            }
            if (!txtStaffBirth.Validate(txtStaffBirth.Text))
            {
                MessageBox.Show("Invalid date of birth!");
                return false;
            }
            if (!txtStaffPhone.Validate(txtStaffPhone.Text))
            {
                MessageBox.Show("Invalid phone number!");
                return false;
            }

            if (!txtStaffINumber.Validate(txtStaffINumber.Text))
            {
                MessageBox.Show("Invalid ID!");
                return false;
            }
            return true;
        }
    }
}
