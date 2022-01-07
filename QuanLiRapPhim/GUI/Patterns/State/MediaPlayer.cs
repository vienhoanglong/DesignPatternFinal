using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.State
{
    public class MediaPlayer
    {
        private State state;
        public Track tracks;
        public MediaPlayer(AxWMPLib.AxWindowsMediaPlayer mediaPlayer)
        {
            tracks = new Track( mediaPlayer);
            this.setState(new ReadyState(tracks));
        }
        public void setState(State state)
        {
            this.state = state;
        }
        public State getState()
        {
            return state;
        }
        public Track getTracks()
        {
            return tracks;
        }
        public void onPlay()
        {
            state.onPlay();
        }
        public void onStop()
        {
            state.onStop();
        }
        public void onNext()
        {
            state.onNext();
        }
        public void onPrev()
        {
            state.onPrev();
        }
    }
}
