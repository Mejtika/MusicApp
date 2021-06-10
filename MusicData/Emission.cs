using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.MusicData
{
    public class Emission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmissionId { get; set; }

        public int RadioChannelId { get; set; }

        public RadioChannel RadioChannel { get; set; }

        public int SongId { get; set; }

        public Song Song { get; set; }

        public DateTime EmittedOn { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
