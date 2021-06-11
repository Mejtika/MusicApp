using MediatR;

namespace MusicApp.Songs.GetSong
{
    public class GetSongQuery : IRequest<SongDto>
    {
        public int SongId { get; }

        public GetSongQuery(int songId)
        {
            SongId = songId;
        }
    }
}
