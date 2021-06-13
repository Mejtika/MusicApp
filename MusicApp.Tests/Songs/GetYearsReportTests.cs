using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.MusicData;
using MusicApp.Songs.GetYearsReport;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Songs
{
    [Collection("IntegrationTests")]
    public class GetYearsReportTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldGetYearsReport()
        {
            var songId = 5;
            var entities = CreateTestData(songId);
            await AddRangeAsync(entities);

            var result = await SendAsync(new GetYearsReportQuery(songId));

            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task ShouldGetReportWithFilledYears()
        {
            var expectedYears = new int[] { 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022 };
            var songId = 5;
            var entities = CreateTestData(songId);
            await AddRangeAsync(entities);

            var result = await SendAsync(new GetYearsReportQuery(songId));

            var years = result.Select(x => x.Year).ToList();
            years.Should().Equal(expectedYears);
        }

        private List<Emission> CreateTestData(int songId)
        {
            var song = new Song
            {
                SongId = songId,
                Title = "test_title",
                Version = "test_version",
                Duration = new TimeSpan(0, 0, 5, 0),
                Artists = new List<Artist>()
            };

            var radioChannel = new RadioChannel
            {
                RadioChannelId = songId,
                Name = "test",
            };

            var dates = new List<DateTime>
            {
                new DateTime(2015, 5, 5, 5, 5, 5),
                new DateTime(2017, 5, 5, 5, 5, 5),
                new DateTime(2018, 5, 5, 5, 5, 5),
                new DateTime(2020, 5, 5, 5, 5, 5),
                new DateTime(2022, 5, 5, 5, 5, 5)
            };

            var emissions = new List<Emission>();
            for (int i = 0; i < 5; i++)
            {
                var emission = new Emission
                {
                    EmissionId = i + 1,
                    Song = song,
                    RadioChannel = radioChannel,
                    EmittedOn = dates[i],

                };
                emissions.Add(emission);
            }

            return emissions;
        }
    }
}
