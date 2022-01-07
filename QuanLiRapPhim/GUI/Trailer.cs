using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiRapPhim
{
    public partial class Trailer : Form
    {
        public Trailer()
        {
            InitializeComponent();
        }

        private void Trailer_Load(object sender, EventArgs e)
        {
            trailerVideo.uiMode = "none";
        }
    }
}
