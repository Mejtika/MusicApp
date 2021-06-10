using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.MusicData
{
    public class RadioChannel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RadioChannelId { get; set; }

        public string Name { get; set; }

        public decimal Mhz { get; set; }
    }
}