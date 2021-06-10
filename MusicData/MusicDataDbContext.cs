using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.MusicData
{
    public class MusicDataDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Emission> Emissions { get; set; }


        public DbSet<RadioChannel> RadioChannels { get; set; }

        public MusicDataDbContext(DbContextOptions<MusicDataDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("music");
        }
    }
}
