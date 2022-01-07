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
        private List<string> listMusic = null;
        public Track()
        {
            listMusic = new List<string>();
            listMusic.Add("Track 1: Nơi này có Anh - Nguyễn Công Hậu 51800382");
            listMusic.Add("Track 2: Khu tao sống - Lê Hiền Lương 51800437");
            listMusic.Add("Track 3: Em của ngày hôm qua - Trần Hoàng Long 51800075");
            listMusic.Add("Track 4: Chúng ta của hiện tại - Viên Hoàng Long 51800433");
            listMusic.Add("Track 5: Mùa thu cho em - Huỳnh Thành Trung 51800145");
        }
        public List<string> getListMusic() { return listMusic; }
        public string getCurrentTrack() { return listMusic[currentTrackIndex]; }
        public string getTrackByIndex(int index) { return listMusic[index]; }
        public void nextTrack()
        {
            currentTrackIndex++;
            if (currentTrackIndex > listMusic.Count() - 1)
            {
                currentTrackIndex = 0;
            }
        }
        public void prevTrack()
        {
            currentTrackIndex--;
            if (currentTrackIndex < 0)
            {
                currentTrackIndex = listMusic.Count() - 1;
            }
        }
        public void reset()
        {
            currentTrackIndex = 0;
        }
    }
}
