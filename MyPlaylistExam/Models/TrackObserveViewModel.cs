using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Models
{
    public class TrackObserveViewModel : INotifyPropertyChanged
    {
        private string nameTrack;
        private string artist;
        private string genre;
        public int Id { get; set; }
        public int PlaylistId { get; set; }

        public string NameTrack
        {
            get { return this.nameTrack; }
            set
            {
                if (this.nameTrack != value)
                {
                    this.nameTrack = value;
                    this.NotifyPropertyChanged("NameTrack");
                }
            }
        }

        public string Artist
        {
            get { return this.artist; }
            set
            {
                if (this.artist != value)
                {
                    this.artist = value;
                    this.NotifyPropertyChanged("Artist");
                }
            }
        }

        public string Genre
        {
            get { return this.genre; }
            set
            {
                if (this.genre != value)
                {
                    this.genre = value;
                    this.NotifyPropertyChanged("Genre");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
