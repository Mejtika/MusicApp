using System.Collections.Generic;
using MediatR;
using MusicApp.MusicData.Views;

namespace MusicApp.Songs.GetRanking
{
    public class GetRankingQuery : IRequest<IReadOnlyList<RankingView>>
    {
    }
}
