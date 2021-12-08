using QuanLiRapPhim.DAO;
using QuanLiRapPhim.DTO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class NVBanve : Form
    {
        public NVBanve()
        {
            InitializeComponent();
            dtpThoiGian.Value = DateTime.Now;
            LoadMovie(dtpThoiGian.Value);
        }

        private void frmSeller_Load(object sender, EventArgs e)
        {
            LoadMovie(dtpThoiGian.Value);
            timer1.Start();
        }

        private void LoadMovie(DateTime date)
        {
            cboFilmName.DataSource = PhimDAO.GetListMovieByDate(date);
            cboFilmName.DisplayMember = "Name";
        }

        private void cboFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilmName.SelectedIndex != -1)
            {
                cboFormatFilm.DataSource = null;
                lvLichChieu.Items.Clear();
                Phim movie = cboFilmName.SelectedItem as Phim;
                cboFormatFilm.DataSource = DinhDangPhimDAO.GetListFormatMovieByMovie(movie.ID);
                cboFormatFilm.DisplayMember = "ScreenTypeName";
            }
        }

        private void cboFormatFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormatFilm.SelectedIndex != -1)
            {
                lvLichChieu.Items.Clear();
                DinhDangPhim format = cboFormatFilm.SelectedItem as DinhDangPhim;
                LoadListShowTimeByFilm(format.ID);
            }
        }

        private void LoadListShowTimeByFilm(string formatMovieID)
        {
            DataTable data = LichChieuDAO.GetListShowTimeByFormatMovie(formatMovieID, dtpThoiGian.Value);
   
            foreach (DataRow row in data.Rows)
            {
                ThoiGianChieu showTimes = new ThoiGianChieu(row);
                ListViewItem lvi = new ListViewItem("");
                lvi.SubItems.Add(showTimes.CinemaName);
                lvi.SubItems.Add(showTimes.MovieName);
                lvi.SubItems.Add(showTimes.Time.ToShortTimeString());
                lvi.Tag = showTimes;

                string statusShowTimes = VeDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.ID)
                    + "/" + VeDAO.CountToltalTicketByShowTime(showTimes.ID);

                lvi.SubItems.Add(statusShowTimes);

                float status = (float)VeDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.ID)
                    / VeDAO.CountToltalTicketByShowTime(showTimes.ID);

                //thêm ảnh status
                if (status == 1)
                    lvi.ImageIndex = 2;
                else if (status > 0.5f)
                    lvi.ImageIndex = 1;
                else lvi.ImageIndex = 0;

                lvLichChieu.Items.Add(lvi);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.OnLoad(null);
        }

        private void lvLichChieu_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                timer1.Stop();
                ThoiGianChieu showTimes = lvLichChieu.SelectedItems[0].Tag as ThoiGianChieu;
                Phim movie = cboFilmName.SelectedItem as Phim;
                BanVe frm = new BanVe(showTimes, movie);
                this.Hide();
                frm.ShowDialog();
                this.OnLoad(null);
                this.Show();
            }
        }

        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            LoadMovie(dtpThoiGian.Value);
        }
    }
}
