using Microsoft.EntityFrameworkCore;

namespace MusicApp.MusicData.Views
{
    [Keyless]
    public class CountByYearView
    {
        public int SongId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }
}
