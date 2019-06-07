using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Models
{
    public class TrackViewModel
    {
        public int Id { get; set; }
        public string NameTrack { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int PlaylistId { get; set; }
    }
}
