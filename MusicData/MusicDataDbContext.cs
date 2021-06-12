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

        public DbSet<CountByYearView> CountByYearView { get; set; }

        public DbSet<CountByChannelView> CountByChannelView { get; set; }

        public DbSet<EmissionsView> EmissionsView { get; set; }

        public MusicDataDbContext(DbContextOptions<MusicDataDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("music");

            modelBuilder
                .Entity<CountByYearView>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("vCountByYear");
                });

            modelBuilder
                .Entity<CountByChannelView>(eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("vCountByChannel");
                });

            modelBuilder
                .Entity<EmissionsView>(eb =>
                {
                    eb.HasKey(e => e.EmissionId);
                    eb.ToView("vEmissions");
                });
        }
    }
}
