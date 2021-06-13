using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.MusicData;
using MusicApp.Songs.GetChannelsReport;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Songs
{
    [Collection("IntegrationTests")]
    public class GetChannnelsReportTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldGetYearsReport()
        {
            var songId = 5;
            var channelName = "test";
            var count = 10;
            var entities = CreateTestData(songId, channelName, count);
            await AddRangeAsync(entities);

            var result = await SendAsync(new GetChannelsReportQuery(songId));

            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(1);
            result.First().Name.Should().Be(channelName);
            result.First().Count.Should().Be(count);
        }

        private List<Emission> CreateTestData(int songId, string channelName, int count)
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
                RadioChannelId = 1,
                Name = channelName
            };

            var emissions = new List<Emission>();
            for (int i = 0; i < count; i++)
            {
                var emission = new Emission
                {
                    EmissionId = i + 1,
                    Song = song,
                    RadioChannel = radioChannel,
                };
                emissions.Add(emission);
            }

            return emissions;
        }
    }
}
