using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.MusicData
{
    public class Artist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public DateTime Born { get; set; }

        public List<Song> Songs { get; set; }
    }
}