using Microsoft.EntityFrameworkCore;

namespace MusicApp.MusicData.Views
{
    [Keyless]
    public class CountByYear
    {
        public int SongId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }
}
