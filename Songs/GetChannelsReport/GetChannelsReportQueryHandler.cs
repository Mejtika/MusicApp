using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicApp.MusicData;

namespace MusicApp.Songs.GetChannelsReport
{
    public class GetChannelsReportQueryHandler : IRequestHandler<GetChannelsReportQuery, IReadOnlyList<ChannelReportDto>>
    {
        private readonly MusicDataDbContext _context;

        public GetChannelsReportQueryHandler(MusicDataDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ChannelReportDto>> Handle(GetChannelsReportQuery request, CancellationToken cancellationToken)
        {
            return await _context.CountByChannel
                .Where(x => x.SongId == request.SongId)
                .Select(x => new ChannelReportDto {Name = x.Name, Count = x.Count})
                .ToListAsync(cancellationToken); ;
        }
    }
}
