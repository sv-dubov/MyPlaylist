using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Entities
{
    [Table("tblTrack")]
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string NameTrack { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Artist { get; set; }
        [StringLength(maximumLength: 255)]
        public string Genre { get; set; }
        [ForeignKey("Playlists")]
        public int? PlaylistId { get; set; }
        public Playlist Playlists { get; set; }
    }
}
