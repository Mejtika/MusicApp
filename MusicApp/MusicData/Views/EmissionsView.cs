using System;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.MusicData.Views
{
    public class EmissionsView
    {
        [Key]
        public int EmissionId { get; set; }

        public string ChannelName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmittedOn { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

        public string SongTitle { get; set; }

        public int SongId { get; set; }
    }
}
