using Microsoft.EntityFrameworkCore;

namespace MusicApp.MusicData.Views
{
    [Keyless]
    public class CountByChannel
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
