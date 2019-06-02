using MyPlaylistExam.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDTrack.Controllers
{
    public class TrackController : ApiController
    {
        //SqlConnection con = new SqlConnection(@"Data Source = SLIMBOYFAT-ПК; Initial Catalog = MyPlaylist; Integrated Security = True");

        private EFContext db = new EFContext();

        //This method will return All tracks' list  
        public IEnumerable<Track> Get()
        {
            return db.Tracks.ToList();
        }

        //This method will return a single Track against id  
        public Track Get(int id)
        {
            Track track = db.Tracks.Find(id);
            return track;
        }

        //This method will add a new Track  
        public void POST(Track track)
        {
            db.Tracks.Add(track);
            db.SaveChanges();
        }

        //This method to Update a Track  
        public void PUT(int id, Track track)
        {
            var track1 = db.Tracks.Find(id);
            track1.NameTrack = track.NameTrack;
            track1.Artist = track.Artist;
            track1.Genre = track.Genre;
            track1.PlaylistId = track.PlaylistId;
            db.Entry(track1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //This method will delete a track  
        public string Delete(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
            db.SaveChanges();
            return "Track Deleted";
        }
    }
}
