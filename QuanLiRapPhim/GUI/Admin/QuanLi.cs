using QuanLiRapPhim.frmAdminUserControls.DataUserControl;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiRapPhim.frmAdminUserControls
{
    public partial class QuanLi : UserControl
    {
        public QuanLi()
        {
            InitializeComponent();
        }
        private void btnGenreUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnGenreUC.Height;
            SidePanel.Top = btnGenreUC.Top;
            pnData.Controls.Clear();
            TheLoai genreUc = new TheLoai
            {
                Dock = DockStyle.Fill
            };
            pnData.Controls.Add(genreUc);
        }

        private void btnMovieUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMovieUC.Height;
            SidePanel.Top = btnMovieUC.Top;
            pnData.Controls.Clear();
            Phim movieUc = new Phim
            {
                Dock = DockStyle.Fill
            };
            pnData.Controls.Add(movieUc);
        }

   
    }
}
