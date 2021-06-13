using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.MusicData.Migrations
{
    public partial class AddCountByYearView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                CREATE OR ALTER VIEW [music].[vCountByYear] AS
                SELECT S.SongId, MONTH(E.EmittedOn) as month, YEAR(E.EmittedOn) AS year, COUNT(*) as count 
                FROM music.Emissions AS E
                JOIN music.Songs AS S ON E.SongId = S.SongId
                GROUP BY S.SongId, MONTH(E.EmittedOn), YEAR(E.EmittedOn)";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [music].[vCountByYear]");
        }
    }
}
