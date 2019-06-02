using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Entities
{
    [Table("tblPlaylist")]
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string NameList { get; set; }
        [ForeignKey("Users")]
        public int ? UserId { get; set; }
        public User Users { get; set; }
    }
}
