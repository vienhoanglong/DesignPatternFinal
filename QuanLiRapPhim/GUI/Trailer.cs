using QuanLiRapPhim.Patterns.State;
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
        MediaPlayer media;
        public Trailer()
        {
            InitializeComponent();
            media = new MediaPlayer(trailerVideo);
        }

        private void Trailer_Load(object sender, EventArgs e)
        {
            trailerVideo.uiMode = "none";
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Mp3 files, mp4 files (*.mp3, *.mp4) | *.mp*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Open";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in openFileDialog1.FileNames)
                {
                    media.tracks.addListTrackFileName(item);
                }
                foreach (var item in openFileDialog1.SafeFileNames)
                {
                    media.tracks.addListTrackName(item);
                    listVideo.Items.Add(item);
                }
            }
        }

        private void listVideo_DoubleClick(object sender, EventArgs e)
        {
            if(listVideo.SelectedIndex != -1)
            {
                int index = listVideo.SelectedIndex;
                media.tracks.setCurrentTrack(index);
                media.getState().onPlay();
                media.setState(new PlayingState(media.tracks));
                txtCurentTrack.Text = media.tracks.getTrackNameByIndex(index); 
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                trailerVideo.Ctlcontrols.stop();
                this.Close();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            txtCurentTrack.Text = media.tracks.getCurrentTrackName();
            listVideo.SelectedIndex = media.tracks.getCurrentTrackIndex();
            media.getState().onPlay();
            if (media.getState().isPlaying())
            {
                btnPlay.BackgroundImage = Properties.Resources.pause;
                media.setState(new PlayingState(media.getTracks()));
            }
            else
            {
                btnPlay.BackgroundImage = Properties.Resources.play;
                media.setState(new PauseState(media.getTracks()));
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnPlay.BackgroundImage = Properties.Resources.play;
            txtCurentTrack.Text = "";
            media.getState().onStop();
            listVideo.SelectedIndex = media.tracks.getCurrentTrackIndex();
            media.setState(new ReadyState(media.getTracks()));
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            media.getState().onPrev();
            txtCurentTrack.Text = media.tracks.getCurrentTrackName();
            listVideo.SelectedIndex = media.tracks.getCurrentTrackIndex();
            if (media.getState().isPlaying())
            {
                media.setState(new PlayingState(media.getTracks()));
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            media.getState().onNext();
            txtCurentTrack.Text = media.tracks.getCurrentTrackName();
            listVideo.SelectedIndex = media.tracks.getCurrentTrackIndex();
            if (media.getState().isPlaying())
            {
                media.setState(new PlayingState(media.getTracks()));
            }
        }
    }
}
