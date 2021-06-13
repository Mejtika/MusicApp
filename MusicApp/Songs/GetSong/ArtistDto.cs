using System;

namespace MusicApp.Songs.GetSong
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public DateTime Born { get; set; }
    }
}