using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDTrack.Models
{
    public class TrackWebViewModel
    {
        public int Id { get; set; }
        public string NameTrack { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int PlaylistId { get; set; }
        public PlaylistWebViewModel PlaylistWeb { get; set; }
    }
}