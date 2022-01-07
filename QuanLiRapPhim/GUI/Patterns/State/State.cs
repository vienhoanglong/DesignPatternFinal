using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLiRapPhim.Patterns.State
{
    public abstract class State
    {
        protected Track tracks;
        protected bool playing = false;
        public State(Track tracks)
        {
            this.tracks = tracks;
        }
        public bool isPlaying() { return playing; }
        public abstract void onStop();

        public abstract void onPlay();

        public abstract void onNext();

        public abstract void onPrev();
    }
    class ReadyState : State
    {
        public ReadyState(Track tracks) : base(tracks)
        {
            playing = false;
        }
        public override void onPrev()
        {
            MessageBox.Show("Lock!");
        }

        public override void onNext()
        {

            MessageBox.Show("Lock!");
        }

        public override void onStop()
        {
            MessageBox.Show("Lock!");
        }

        public override void onPlay()
        {
            playing = true;
            tracks.mediaPlayer.URL = tracks.getCurrentTrack();
        }
    }
    class PlayingState : State
    {
        public PlayingState(Track tracks) : base(tracks)
        {
            playing = true;
        }
        public override void onNext()
        {
            playing = true;
            tracks.nextTrack();
            tracks.mediaPlayer.URL = tracks.getCurrentTrack();
        }

        public override void onStop()
        {
            playing = false;
            tracks.reset();
            tracks.mediaPlayer.Ctlcontrols.stop();
        }

        public override void onPlay()
        {
            playing = false;
            tracks.mediaPlayer.Ctlcontrols.pause();
        }

        public override void onPrev()
        {
            playing = true;
            tracks.prevTrack();
            tracks.mediaPlayer.URL = tracks.getCurrentTrack();
        }
    }
    class PauseState : State
    {
        public PauseState(Track tracks) : base(tracks)
        {
            playing = false;

        }
        public override void onNext()
        {
            playing = true;
            tracks.nextTrack();
            tracks.mediaPlayer.URL = tracks.getCurrentTrack();
        }

        public override void onStop()
        {
            playing = false;
            tracks.reset();
            tracks.mediaPlayer.Ctlcontrols.stop();
        }

        public override void onPlay()
        {
            playing = true;
            tracks.mediaPlayer.Ctlcontrols.play();
        }

        public override void onPrev()
        {
            playing = true;
            tracks.prevTrack();
            tracks.mediaPlayer.URL = tracks.getCurrentTrack();
        }
    }
}
