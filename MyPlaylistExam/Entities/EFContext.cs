using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DefaultConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}