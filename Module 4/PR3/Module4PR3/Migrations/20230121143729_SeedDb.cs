using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4PR3.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "DateOfBirth", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://www.instagram.com/skrillex/", "Skrillex", null },
                    { 2, new DateTime(1945, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bob Marley", null },
                    { 3, new DateTime(1978, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Damian Marley", null },
                    { 4, new DateTime(1972, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://www.instagram.com/eminem/", "Eminem", null },
                    { 5, new DateTime(1989, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://www.instagram.com/netskyofficial/", "Netsky", null },
                    { 6, new DateTime(1770, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Ludwig van Beethoven", null },
                    { 7, new DateTime(1973, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://www.instagram.com/acdc/", "AC-DC", null }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Dubstep" },
                    { 2, "Rap" },
                    { 3, "Rock" },
                    { 4, "Classic" },
                    { 5, "DrumNBass" },
                    { 6, "Reggae" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 4, 4, 0), 1, new DateTime(2010, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scary Monsters And Nice Sprites" },
                    { 2, new TimeSpan(0, 0, 4, 22, 0), 1, new DateTime(2011, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "First of the Year (Equinox)" },
                    { 3, new TimeSpan(0, 0, 3, 35, 0), 1, new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Make It Bun Dem" },
                    { 4, new TimeSpan(0, 0, 3, 31, 0), 6, new DateTime(1977, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamming" },
                    { 5, new TimeSpan(0, 0, 3, 33, 0), 6, new DateTime(2005, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to Jamrock" },
                    { 6, new TimeSpan(0, 0, 3, 42, 0), 2, new DateTime(2020, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Higher" },
                    { 7, new TimeSpan(0, 0, 4, 44, 0), 2, new DateTime(2000, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Real Slim Shady" },
                    { 8, new TimeSpan(0, 0, 5, 21, 0), 2, new DateTime(2000, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Under The Influence" },
                    { 9, new TimeSpan(0, 0, 5, 54, 0), 5, new DateTime(2010, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your Way" },
                    { 10, new TimeSpan(0, 0, 3, 50, 0), 5, new DateTime(2012, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Detonate" },
                    { 11, new TimeSpan(0, 0, 6, 52, 0), 4, new DateTime(1802, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moonlight Sonata (3rd Movement)" },
                    { 12, new TimeSpan(0, 0, 3, 6, 0), 3, new DateTime(2020, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shot In The Dark" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 3 },
                    { 3, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 6, 11 },
                    { 7, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "ArtistSong",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
