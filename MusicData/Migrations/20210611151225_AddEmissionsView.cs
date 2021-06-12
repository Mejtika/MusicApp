using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.MusicData.Migrations
{
    public partial class AddEmissionsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                CREATE OR ALTER VIEW [music].[vEmissions] AS
                SELECT E.EmissionId, R.Name AS ChannelName, E.EmittedOn, E.Duration, S.Title AS SongTitle, S.SongId
                FROM music.Emissions AS E
                JOIN music.RadioChannels AS R ON E.RadioChannelId = R.RadioChannelId
                JOIN music.Songs AS S ON E.SongId = S.SongId";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [music].[vEmissions]");
        }
    }
}
