using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.MusicData
{
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SongId { get; set; }

        public string Title { get; set; }

        public string Version { get; set; }

        public TimeSpan Duration { get; set; }

        public List<Artist> Artists { get; set; }
    }
}