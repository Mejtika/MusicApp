using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using MusicApp.MusicData;
using MusicApp.Songs.GetChannelsReport;
using MusicApp.Songs.GetRanking;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Songs
{
    [Collection("IntegrationTests")]
    public class GetRankingTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldGetRankingOf100Places()
        {
            var entities = CreateTestData();
            await AddRangeAsync(entities);

            var result = await SendAsync(new GetRankingQuery());

            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(100);
        }

        private List<Emission> CreateTestData()
        {
            var maxDuration = new TimeSpan(0, 0, 5, 0);

            var artistsIds = 1;
            var artistsFaker = new Faker<Artist>()
                .RuleFor(a => a.ArtistId, f => artistsIds++)
                .RuleFor(a => a.Name, f => f.Name.FullName())
                .RuleFor(a => a.Pseudonym, f => f.Name.FirstName())
                .RuleFor(a => a.Born, f => f.Date.Past());

            var songsIds = 1;
            var songsFaker = new Faker<Song>()
                .RuleFor(s => s.Duration, f => f.Date.Timespan(maxDuration))
                .RuleFor(s => s.Title, f => f.Lorem.Word())
                .RuleFor(s => s.Version, f => f.Lorem.Word())
                .RuleFor(s => s.SongId, f => songsIds++);

            var channelsIds = 1;
            var channelsFaker = new Faker<RadioChannel>()
                .RuleFor(s => s.RadioChannelId, f => channelsIds++)
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.Mhz, f => f.Random.Decimal(70m, 120m));

            var artists = artistsFaker.Generate(1000);
            var songs = songsFaker.Generate(1000);
            var radioChannels = channelsFaker.Generate(100);

            for (int i = 0; i < 1000; i++)
            {
                songs[i].Artists = new List<Artist> { artists[i] };
            }

            var refDate = new DateTime(2021, 5, 25, 23, 59, 59);
            var emmisionsIds = 1;
            var emissionsFaker = new Faker<Emission>()
                .RuleFor(e => e.EmissionId, f => emmisionsIds++)
                .RuleFor(e => e.Duration, f => f.Date.Timespan(maxDuration))
                .RuleFor(e => e.EmittedOn, f => f.Date.Past(4, refDate))
                .RuleFor(e => e.Song, f => f.PickRandom(songs))
                .RuleFor(e => e.RadioChannel, f => f.PickRandom(radioChannels));

            var emissions = emissionsFaker.Generate(2000);
            return emissions;
        }
    }
}
