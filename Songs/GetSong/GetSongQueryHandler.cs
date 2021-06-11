using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicApp.MusicData;

namespace MusicApp.Songs.GetSong
{
    public class GetSongQueryHandler : IRequestHandler<GetSongQuery, SongDto>
    {
        private readonly MusicDataDbContext _context;

        public GetSongQueryHandler(MusicDataDbContext context)
        {
            _context = context;
        }

        public async Task<SongDto> Handle(GetSongQuery request, CancellationToken cancellationToken)
        {
            var song = await _context.Songs
                .Include(s => s.Artists)
                .SingleOrDefaultAsync(s => s.SongId == request.SongId, cancellationToken);

            var songDto = new SongDto
            {
                SongId = song.SongId,
                Title = song.Title,
                Version = song.Version,
                Duration = song.Duration,
                Artists = song.Artists.Select(a => new ArtistDto
                {
                    ArtistId = a.ArtistId,
                    Name = a.Name,
                    Pseudonym = a.Pseudonym,
                    Born = a.Born
                }).ToList()
            };

            return songDto;
        }
    }
}
