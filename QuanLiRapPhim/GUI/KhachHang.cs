using QuanLiRapPhim.DAO;
using QuanLiRapPhim.DTO;
using QuanLiRapPhim.Patterns.Builder;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        public DTO.KhachHang customer;

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DataTable data = KhachHangDAO.GetCustomerMember(txtCustomerID.Text, txtCustomerName.Text);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("ID hoặc Họ tên của Khách Hàng không chính xác!\nVui lòng nhập lại thông tin.");
                return;
            }
            DataRow row = data.Rows[0];
            customer = (DTO.KhachHang)new KhachHangBuilder()
                .setId(row["id"].ToString())
                .setAddress(row["DiaChi"].ToString())
                .setBirth(DateTime.Parse(row["NgaySinh"].ToString()))
                .setIdentityCard((int)row["CMND"])
                .setName(row["HoTen"].ToString())
                .setPhone(row["SDT"].ToString())
                .setPoint((int)row["DiemTichLuy"])
                .Build();
            DialogResult = DialogResult.OK;
        }
    }
}
