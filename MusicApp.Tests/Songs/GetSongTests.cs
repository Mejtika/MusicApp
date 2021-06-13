using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MusicApp.MusicData;
using MusicApp.Songs.GetSong;
using Xunit;
using static MusicApp.Tests.TestsBase;

namespace MusicApp.Tests.Songs
{
    [Collection("IntegrationTests")]
    public class GetSongTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldGetCreatedSong()
        {
            var song = new Song
            {
                SongId = 1,
                Title = "test_title",
                Version = "test_version",
                Duration = new TimeSpan(0, 0, 5, 0),
                Artists = new List<Artist>()
            };

            await AddAsync(song);

            var result = await SendAsync(new GetSongQuery(song.SongId));

            result.Title.Should().Be(song.Title);
            result.Version.Should().Be(song.Version);
            result.Duration.Should().Be(song.Duration);
        }

        [Fact]
        public async Task ShouldGetSongWithSpecifiedId()
        {
            var requestedSong = new Song
            {
                SongId = 2,
                Title = "test_title2",
                Version = "test_version2",
                Duration = new TimeSpan(0, 0, 10, 10),
                Artists = new List<Artist>()
            };

            var songs = new List<Song>
            {
                new Song
                {
                    SongId = 1,
                    Title = "test_title",
                    Version = "test_version",
                    Duration = new TimeSpan(0, 0, 5, 5),
                    Artists = new List<Artist>()
                },
                requestedSong,
                new Song
                {
                    SongId = 3,
                    Title = "test_title3",
                    Version = "test_version3",
                    Duration = new TimeSpan(0, 0, 15, 15),
                    Artists = new List<Artist>()
                },
            };

            await AddRangeAsync(songs);

            var result = await SendAsync(new GetSongQuery(requestedSong.SongId));

            result.SongId.Should().Be(requestedSong.SongId);
            result.Title.Should().Be(requestedSong.Title);
            result.Version.Should().Be(requestedSong.Version);
            result.Duration.Should().Be(requestedSong.Duration);
        }
    }
}
