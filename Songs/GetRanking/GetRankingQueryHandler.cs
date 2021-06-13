using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicApp.MusicData;
using MusicApp.MusicData.Views;

namespace MusicApp.Songs.GetRanking
{
    public class GetRankingQueryHandler : IRequestHandler<GetRankingQuery,IReadOnlyList<RankingView>>
    {
        private readonly MusicDataDbContext _context;

        public GetRankingQueryHandler(MusicDataDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<RankingView>> Handle(GetRankingQuery request, CancellationToken cancellationToken)
        {
            return await _context.RankingView.ToListAsync(cancellationToken);
        }
    }
}