using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.IdentityData;
using MusicApp.MusicData;
using MusicApp.MusicData.Views;
using MusicApp.Users;
using MusicApp.Users.GetUsers;

namespace MusicApp.Songs.GetYearsReport
{
    public class GetYearsReportQueryHandler : IRequestHandler<GetYearsReportQuery, IReadOnlyList<YearReportDto>>
    {
        private readonly MusicDataDbContext _context;


        public GetYearsReportQueryHandler(MusicDataDbContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<YearReportDto>> Handle(GetYearsReportQuery request, CancellationToken cancellationToken)
        {
            var emissions = await _context.CountByYearView
                .Where(x => x.SongId == request.SongId)
                .ToListAsync(cancellationToken);

            if (emissions.Count is 0)
            {
                return new List<YearReportDto>().AsReadOnly();
            }

            var groupedByYear = GroupByYear(emissions);
            var yearReports = groupedByYear.Select(x => new YearReportDto { Year = x.Key, Months = x.Value }).ToList();
            var filledList = FillMissingYears(yearReports);
            return filledList.OrderBy(x => x.Year).ToImmutableList();
        }

        private static Dictionary<int, int[]> GroupByYear(List<CountByYearView> emissions)
        {
            return emissions
                .GroupBy(x => x.Year)
                .ToDictionary(group => group.Key, nestedGroup =>
                {
                    var months = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    foreach (var item in nestedGroup)
                    {
                        months[item.Month - 1] = item.Count;
                    }
                    return months;
                });
        }

        private static (int minYear, int maxYear) FindMinMax(List<YearReportDto> list) =>
            (list.Min(x => x.Year), list.Max(x => x.Year));

        private static List<YearReportDto> FillMissingYears(List<YearReportDto> list)
        {
            var (minYear, maxYear) = FindMinMax(list);
            for (int i = minYear; i < maxYear; i++)
            {
                if (!list.Exists(x => x.Year == i))
                {
                    list.Add(new YearReportDto { Year = i, Months = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } });
                }
            }

            return list;
        }
    }
}
