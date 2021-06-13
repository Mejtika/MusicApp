using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.MusicData.Migrations
{
    public partial class AddCountByChannelView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                CREATE OR ALTER VIEW [music].[vCountByChannel] AS
                SELECT S.SongId, R.Name, COUNT(*) as count
                FROM music.Emissions AS E
                JOIN music.Songs AS S ON E.SongId = S.SongId
                JOIN music.RadioChannels AS R ON E.RadioChannelId = R.RadioChannelId
                GROUP BY S.SongId, R.Name";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [music].[vCountByChannel]");
        }
    }
}
