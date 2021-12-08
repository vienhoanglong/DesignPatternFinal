using QuanLiRapPhim.DAO;
using QuanLiRapPhim.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;//thư viện thay đổi vùng/quốc gia
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class BanVe : Form
    {
        readonly int SIZE = 30;//Size của ghế
        readonly int GAP = 7;//Khoảng cách giữa các ghế

        List<Ve> listSeat = new List<Ve>();

        //dùng lưu vết các Ghế đang chọn
        readonly List<Button> listSeatSelected = new List<Button>();

        float displayPrice = 0;//Hiện thị giá vé
        float ticketPrice = 0;//Lưu giá vé gốc
        float total = 0;//Tổng giá tiền
        float discount = 0;//Tiền được giảm
        float payment = 0;//Tiền phải trả
        int plusPoint = 0;//Số điểm tích lũy khi mua vé

        DTO.KhachHang customer;//lưu lại khách hàng thành viên

        readonly ThoiGianChieu Times;
        readonly Phim Movie;

        public BanVe(ThoiGianChieu showTimes, Phim movie)
        {
            InitializeComponent();

            Times = showTimes;
            Movie = movie;
        }

        private void frmTheatre_Load(object sender, EventArgs e)
        {
            ticketPrice = Times.TicketPrice;

            lblInformation.Text = "DIETY CINEMA | " + Times.CinemaName + " | " + Times.MovieName;
            lblTime.Text = Times.Time.ToShortDateString() + " | "
                + Times.Time.ToShortTimeString() + " - "
                + Times.Time.AddMinutes(Movie.Time).ToShortTimeString();
            if (Movie.Poster != null)
                picFilm.Image = PhimDAO.byteArrayToImage(Movie.Poster);

            rdoAdult.Checked = true;
            chkCustomer.Enabled = false;
            grpLoaiVe.Enabled = false;

            LoadDataCinema(Times.CinemaName);

            ShowOrHideLablePoint();

            listSeat = VeDAO.GetListTicketsByShowTimes(Times.ID);

            LoadChair(listSeat);
        }

        private void LoadDataCinema(string cinemaName)
        {
            PhongChieu cinema = PhongChieuDAO.GetCinemaByName(cinemaName);
            int Row = cinema.Row;
            int Column = cinema.SeatInRow;
            flpSeat.Size = new Size((SIZE + 20 + GAP) * Column, (SIZE + GAP) * Row);
        }

        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            //Đổi culture vùng quốc gia để đổi đơn vị tiền tệ 

            //Thread.CurrentThread.CurrentCulture = culture;
            //dùng thread để chuyển cả luồng đang chạy về vùng quốc gia đó

            lblTicketPrice.Text = displayPrice.ToString("c", culture);
            lblTotal.Text = total.ToString("c", culture);
            lblDiscount.Text = discount.ToString("c", culture);
            lblPayment.Text = payment.ToString("c", culture);

            //Đổi đơn vị tiền tệ
            //gán culture chỗ này thì chỉ có chỗ này sd culture này còn
            //lại sài mặc định
        }

        private void LoadChair(List<Ve> list)
        {
            flpSeat.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Button btnChair = new Button() { Width = SIZE + 20, Height = SIZE };
                btnChair.Text = list[i].SeatName;
                if (list[i].Status == 1)
                    btnChair.BackColor = Color.Red;
                else
                    btnChair.BackColor = Color.White;
                btnChair.Click += BtnSeat_Click;
                flpSeat.Controls.Add(btnChair);

                btnChair.Tag = list[i];
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnChair = sender as Button;
            if (btnChair.BackColor == Color.White)
            {
                grpLoaiVe.Enabled = true;
                rdoAdult.Checked = true;

                btnChair.BackColor = Color.Black;
                Ve ticket = btnChair.Tag as Ve;

                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total += ticketPrice;
                payment = total - discount;
                ticket.Type = 1;

                listSeatSelected.Add(btnChair);
                plusPoint++;
                lblPlusPoint.Text = plusPoint + "";
            }
            else if (btnChair.BackColor == Color.Yellow)
            {
                btnChair.BackColor = Color.White;
                Ve ticket = btnChair.Tag as Ve;

                total -= ticket.Price;
                payment = total - discount;
                ticket.Price = 0;
                displayPrice = ticket.Price;
                ticket.Type = 0;

                listSeatSelected.Remove(btnChair);
                plusPoint--;
                lblPlusPoint.Text = plusPoint + "";
                grpLoaiVe.Enabled = false;
            }
            else if (btnChair.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnChair.Text + "] đã có người mua");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                chkCustomer.Enabled = true;
            }
            else
            {
                chkCustomer.Enabled = false;
            }
        }

        //Dùng để ẩn hiện điểm tích lũy của khách hàng thành viên
        private void ShowOrHideLablePoint()
        {
            if (chkCustomer.Checked == true)
            {
                pnCustomer.Visible = true;
            }
            else
            {
                pnCustomer.Visible = false;
            }
        }
        private void RestoreDefault()
        {
            listSeatSelected.Clear();

            rdoAdult.Checked = true;
            grpLoaiVe.Enabled = false;
            chkCustomer.Checked = false;
            chkCustomer.Enabled = false;
            ShowOrHideLablePoint();
            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;
            LoadBill();
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán");
                return;
            }
            string message = "Bạn có chắc chắn mua những vé: \n";
            foreach (Button btn in listSeatSelected)
            {
                message += "[" + btn.Text + "] ";
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int ret = 0;
                if (chkCustomer.Checked == true)
                {
                    foreach (Button btn in listSeatSelected)
                    {
                        Ve ticket = btn.Tag as Ve;

                        ret += VeDAO.BuyTicket(ticket.ID, ticket.Type, customer.ID, ticket.Price);
                    }
					customer.Point += plusPoint;
					KhachHangDAO.UpdatePointCustomer(customer.ID, customer.Point);
                }
                else
                {
                    foreach (Button btn in listSeatSelected)
                    {
                        Ve ticket = btn.Tag as Ve;

                        ret += VeDAO.BuyTicket(ticket.ID, ticket.Type, ticket.Price);
                    }
                }
                if (ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Thanh toán vé thành công");
                }
            }
            RestoreDefault();
            this.OnLoad(new EventArgs());
        }

        private void rdoStudent_Click(object sender, EventArgs e)
        {
            if (rdoStudent.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ve ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ve;
                ticket.Type = 2;

                float oldPrice = ticket.Price;
                ticket.Price = 0.8f * ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }
        }
        private void rdoAdult_Click(object sender, EventArgs e)
        {
            if (rdoAdult.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ve ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ve;
                ticket.Type = 1;

                float oldPrice = ticket.Price;
                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }
        }
        private void rdoChild_Click(object sender, EventArgs e)
        {
            if (rdoChild.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ve ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ve;
                ticket.Type = 3;

                float oldPrice = ticket.Price;
                ticket.Price = 0.7f * ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }
        }

        private void chkCustomer_Click(object sender, EventArgs e)
        {
            if (chkCustomer.Checked == true)
            {
                KhachHang frm = new KhachHang();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    customer = frm.customer;
                    lblCustomerName.Text = customer.Name;
                    lblPoint.Text = customer.Point + "";
                    ShowOrHideLablePoint();
                }
                else
                {
                    chkCustomer.Checked = false;
                }
            }
            else
            {
                ShowOrHideLablePoint();
                customer = null;
            }
        }

        private void btnFreeTicket_Click(object sender, EventArgs e)
        {
            int freeVe = (int)numericFreeTickets.Value;
            if (freeVe <= 0) return;

            if (freeVe > listSeat.Count)
            {
                MessageBox.Show("Bạn chỉ được đổi tối đa [" + listSeatSelected.Count + "] vé ", "Thông báo");
                return;
            }
            int pointVe = freeVe * 99;
            if (customer.Point < pointVe)
            {
                MessageBox.Show("Không đủ điểm ", "Thông báo");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn dùng điểm thưởng để đổi [" + freeVe + "] vé không?",
                                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    customer.Point -= pointVe;
                    plusPoint -= freeVe;

                    if (KhachHangDAO.UpdatePointCustomer(customer.ID, customer.Point))
                    {
                        MessageBox.Show("Bạn đổi được [" + freeVe + "] vé thành công", "Thông báo");
                    }
                    lblPoint.Text = "" + customer.Point;
                    lblPlusPoint.Text = "" + plusPoint;

                    for (int i = 0; i < listSeatSelected.Count && freeVe > 0; i++)
                    {
                        Ve ticket = listSeatSelected[i].Tag as Ve;
                        if (ticket.Price != 0)
                        {
                            discount += ticket.Price;
                            ticket.Price = 0;
                            freeVe--;
                        }
                    }

                    payment = total - discount;
                    LoadBill();
                }
            }
        }

       
    }
}
