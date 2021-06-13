using System;
using System.Collections.Generic;

namespace MusicApp.Songs.GetSong
{
    public class SongDto
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public string Version { get; set; }

        public TimeSpan Duration { get; set; }

        public List<ArtistDto> Artists { get; set; }
    }
}