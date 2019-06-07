using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDTrack.Models
{
    public class PlaylistWebViewModel
    {
        public int Id { get; set; }
        public string NameList { get; set; }
        public int UserId { get; set; }
        public ICollection<TrackWebViewModel> Tracks { get; set; }
    }
}