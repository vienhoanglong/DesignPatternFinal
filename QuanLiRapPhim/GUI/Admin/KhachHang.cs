using QuanLiRapPhim.DAO;
using System;
using System.Linq;
using System.Windows.Forms;
using QuanLiRapPhim.Patterns.Strategy;
using System.Collections;

namespace QuanLiRapPhim.frmAdminUserControls
{
    public partial class KhachHang : UserControl
    {
        private ObjectCRUD KH;
        readonly BindingSource customerList = new BindingSource();
        public KhachHang()
        {
            KH = new ObjectCRUD("KhachHang");
            InitializeComponent();
            LoadCustomer();
            txtCusPhone.setValidator(Patterns.Factory.ValidatorType.PHONE);
            txtCusName.setValidator(Patterns.Factory.ValidatorType.STRING);
            txtCusINumber.setValidator(Patterns.Factory.ValidatorType.ID);
            txtCusBirth.setValidator(Patterns.Factory.ValidatorType.DATE);

        }

        void LoadCustomer()
        {
            dtgvCustomer.DataSource = customerList;
            LoadCustomerList();
            AddCustomerBinding();
        }

        void LoadCustomerList()
        {
            customerList.DataSource = KH.load();
        }
        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        void AddCustomerBinding()
        {
            txtCusID.DataBindings.Add("Text", dtgvCustomer.DataSource, "Mã khách hàng", true, DataSourceUpdateMode.Never);
            txtCusName.DataBindings.Add("Text", dtgvCustomer.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            txtCusBirth.DataBindings.Add("Text", dtgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtCusAddress.DataBindings.Add("Text", dtgvCustomer.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtCusPhone.DataBindings.Add("Text", dtgvCustomer.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
            txtCusINumber.DataBindings.Add("Text", dtgvCustomer.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            nudPoint.DataBindings.Add("Value", dtgvCustomer.DataSource, "Điểm tích lũy", true, DataSourceUpdateMode.Never);
        }

        void InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            //if (KhachHangDAO.InsertCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd))
            //{
            //    MessageBox.Show("Thêm khách hàng thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Thêm khách hàng thất bại");
            //}
            ArrayList data = new ArrayList() { id, hoTen, ngaySinh, diaChi, sdt, cmnd };

            KH.add(data);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!validateInput()) return;

            string cusID = txtCusID.Text;
            string cusName = txtCusName.Text;
            DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            int cusINumber = Int32.Parse(txtCusINumber.Text);
            InsertCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber);
            LoadCustomerList();
        }

        void UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            //if (KhachHangDAO.UpdateCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd, point))
            //{
            //    MessageBox.Show("Sửa khách hàng thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Sửa khách hàng thất bại");
            //}
            ArrayList data = new ArrayList() { id, hoTen, ngaySinh, diaChi, sdt, cmnd, point };

            KH.update(data);
        }
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (!validateInput()) return;
            
            string cusID = txtCusID.Text;
            string cusName = txtCusName.Text;
            DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            int cusINumber = Int32.Parse(txtCusINumber.Text);
            int cusPoint = (int)nudPoint.Value;
            UpdateCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber, cusPoint);
            LoadCustomerList();
        }

        void DeleteCustomer(string id)
        {
            //if (KhachHangDAO.DeleteCustomer(id))
            //{
            //    MessageBox.Show("Xóa khách hàng thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Xóa khách hàng thất bại");
            //}
            KH.delete(id);
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string cusID = txtCusID.Text;
            DeleteCustomer(cusID);
            LoadCustomerList();
        }

        private void btnSearchCus_Click(object sender, EventArgs e)
        {
            string cusName = txtSearchCus.Text;
            customerList.DataSource = KhachHangDAO.SearchCustomerByName(cusName);
        }

		private void txtSearchCus_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchCus.PerformClick();
				e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
			}
		}
        
        public bool validateInput()
        {
            if (!txtCusName.Validate(txtCusName.Text))
            {
                MessageBox.Show("Invalid name!");
                return false;
            }
            if (!txtCusBirth.Validate(txtCusBirth.Text))
            {
                MessageBox.Show("Invalid date of birth!");
                return false;
            }
            if (!txtCusPhone.Validate(txtCusPhone.Text))
            {
                MessageBox.Show("Invalid phone number!");
                return false;
            }

            if (!txtCusINumber.Validate(txtCusINumber.Text))
            {
                MessageBox.Show("Invalid ID!");
                return false;
            }
            return true;
        }
	}
}
