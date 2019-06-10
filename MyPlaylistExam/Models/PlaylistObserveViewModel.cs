using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Models
{
    public class PlaylistObserveViewModel : INotifyPropertyChanged
    {
        private string nameList;
        public int Id { get; set; }
        public int UserId { get; set; }

        public string NameList
        {
            get { return this.nameList; }
            set
            {
                if (this.nameList != value)
                {
                    this.nameList = value;
                    this.NotifyPropertyChanged("NameList");
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
