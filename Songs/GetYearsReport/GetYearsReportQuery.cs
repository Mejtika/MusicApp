using System.Collections.Generic;
using MediatR;

namespace MusicApp.Songs.GetYearsReport
{
    public class GetYearsReportQuery : IRequest<IReadOnlyList<YearReportDto>>
    {
        public int SongId { get; }

        public GetYearsReportQuery(int songId)
        {
            SongId = songId;
        }
    }
}