using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.MusicData.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "music");

            migrationBuilder.CreateTable(
                name: "Artists",
                schema: "music",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pseudonym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Born = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "RadioChannels",
                schema: "music",
                columns: table => new
                {
                    RadioChannelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mhz = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioChannels", x => x.RadioChannelId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                schema: "music",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                schema: "music",
                columns: table => new
                {
                    ArtistsArtistId = table.Column<int>(type: "int", nullable: false),
                    SongsSongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistsArtistId, x.SongsSongId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalSchema: "music",
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Songs_SongsSongId",
                        column: x => x.SongsSongId,
                        principalSchema: "music",
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emissions",
                schema: "music",
                columns: table => new
                {
                    EmissionId = table.Column<int>(type: "int", nullable: false),
                    RadioChannelId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    EmittedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emissions", x => x.EmissionId);
                    table.ForeignKey(
                        name: "FK_Emissions_RadioChannels_RadioChannelId",
                        column: x => x.RadioChannelId,
                        principalSchema: "music",
                        principalTable: "RadioChannels",
                        principalColumn: "RadioChannelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emissions_Songs_SongId",
                        column: x => x.SongId,
                        principalSchema: "music",
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongsSongId",
                schema: "music",
                table: "ArtistSong",
                column: "SongsSongId");

            migrationBuilder.CreateIndex(
                name: "IX_Emissions_RadioChannelId",
                schema: "music",
                table: "Emissions",
                column: "RadioChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Emissions_SongId",
                schema: "music",
                table: "Emissions",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong",
                schema: "music");

            migrationBuilder.DropTable(
                name: "Emissions",
                schema: "music");

            migrationBuilder.DropTable(
                name: "Artists",
                schema: "music");

            migrationBuilder.DropTable(
                name: "RadioChannels",
                schema: "music");

            migrationBuilder.DropTable(
                name: "Songs",
                schema: "music");
        }
    }
}
