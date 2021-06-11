using Microsoft.EntityFrameworkCore;
using MusicApp.MusicData.Views;

namespace MusicApp.MusicData
{
    public class MusicDataDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Emission> Emissions { get; set; }

        public DbSet<RadioChannel> RadioChannels { get; set; }

        public DbSet<CountByYear> CountByYear { get; set; }

        public DbSet<CountByChannel> CountByChannel { get; set; }

        public MusicDataDbContext(DbContextOptions<MusicDataDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("music");

            modelBuilder
                .Entity<CountByYear>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("vCountByYear");
                });

            modelBuilder
                .Entity<CountByChannel>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("vCountByChannel");
                });
        }
    }
}
