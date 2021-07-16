using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson2
{
    class ContextMethods
    {
        MusicalCollection mc = null;
        public ContextMethods(MusicalCollection mc)
        {
            this.mc = mc;
        }
        public IQueryable<Track> GetTracksByAlbum(string album_name)
        {
            return mc.Tracks.Where(e=> e.Album.Name == album_name && e.Count_Listening == mc.Tracks.Average(el => el.Count_Listening));
        }
        public IQueryable<Track> GetTop3TrackByArtistByRating(string artist)
        {
            return mc.Tracks.Where(e => e.Album.Artist.Name == artist).OrderBy(e=> e.Rating).Take(3);
        }
        public Track FindTrack(string text)
        {
            return mc.Tracks.Where(e => e.Name.Contains(text) || e.Text.Contains(text)).First();
        }

    }
}
