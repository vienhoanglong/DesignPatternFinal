using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiRapPhim.Patterns.State
{
    public class Track
    {
        private int currentTrackIndex;
        private List<string> listTrackName = null;
        private List<string> listTrackFileName = null;
        public AxWMPLib.AxWindowsMediaPlayer mediaPlayer = null;
        public Track(AxWMPLib.AxWindowsMediaPlayer mediaPlayer)
        {
            listTrackName = new List<string>();
            listTrackFileName = new List<string>();
            this.mediaPlayer = mediaPlayer;
        }
        public void addListTrackName (string trackName)
        {
            listTrackName.Add(trackName);
        }
        public void addListTrackFileName(string trackFlieName)
        {
            listTrackFileName.Add(trackFlieName);
        }
        public int getCurrentTrackIndex() { return currentTrackIndex; }
        public List<string> getListTrackName() { return listTrackName; }
        public List<string> getListTrackFileName() { return listTrackFileName; }
        public string getCurrentTrack() { return listTrackFileName[currentTrackIndex]; }
        public void setCurrentTrack(int index) { this.currentTrackIndex = index; }
        public string getCurrentTrackName() { return listTrackName[currentTrackIndex]; }
        public string getTrackByIndex(int index) { return listTrackFileName[index]; }
        public string getTrackNameByIndex(int index) { return listTrackName[index]; }
        public void nextTrack()
        {
            currentTrackIndex++;
            if (currentTrackIndex > listTrackFileName.Count() - 1)
            {
                currentTrackIndex = 0;
            }
        }
        public void prevTrack()
        {
            currentTrackIndex--;
            if (currentTrackIndex < 0)
            {
                currentTrackIndex = listTrackFileName.Count() - 1;
            }
        }
        public void reset()
        {
            currentTrackIndex = 0;
        }
    }
}
