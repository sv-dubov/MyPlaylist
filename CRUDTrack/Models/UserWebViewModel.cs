using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDTrack.Models
{
    public class UserWebViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public ICollection<PlaylistWebViewModel> Playlists { get; set; }
    }
}