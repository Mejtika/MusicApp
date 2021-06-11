using System.Collections.Generic;
using MediatR;

namespace MusicApp.Songs.GetChannelsReport
{
    public class GetChannelsReportQuery : IRequest<IReadOnlyList<ChannelReportDto>>
    {
        public int SongId { get; }

        public GetChannelsReportQuery(int songId)
        {
            SongId = songId;
        }
    }
}