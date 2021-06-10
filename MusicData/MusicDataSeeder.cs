using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using MusicApp.IdentityData;

namespace MusicApp.MusicData
{
    public class MusicDataSeeder
    {
        private readonly MusicDataDbContext _context;

        public MusicDataSeeder(MusicDataDbContext context)
        {
            _context = context;

        }

        public async Task SeedAsync()
        {
            if (await _context.Songs.AnyAsync())
            {
                return;
            }

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

            await _context.AddRangeAsync(radioChannels);
            await _context.AddRangeAsync(songs);
            await _context.AddRangeAsync(emissions);

            await _context.SaveChangesAsync();
        }
    }

    public class SetupMusicDataSeeder : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public SetupMusicDataSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<MusicDataSeeder>();

                await seeder.SeedAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}


