using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Entities
{
    [Table("tblUserPL")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Password { get; set; }
        [StringLength(maximumLength: 255)]
        public string Image { get; set; }
    }
}