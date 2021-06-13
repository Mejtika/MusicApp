using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.MusicData.Migrations
{
    public partial class AddRankingView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                CREATE OR ALTER VIEW [music].[vRanking] AS
                SELECT TOP(100) S.SongId, S.Title, COUNT(*) AS Count, ROW_NUMBER() OVER(Order By COUNT(*) DESC) AS Place
                FROM music.Emissions AS E 
                JOIN music.Songs AS S ON E.SongId = S.SongId
                GROUP BY S.SongId, S.Title, S.Version";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [music].[vRanking]");
        }
    }
}
