using Microsoft.EntityFrameworkCore;
using Module4PR3.Context;

namespace Module4PR3.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationContext _ctx;

        public Repository(ApplicationContext context)
        {
            _ctx = context;
        }

        public void GetSongArtistGenre()
        {
            Console.WriteLine("\n\nGet artists' name, songs' title and genre");

            var query = _ctx.ArtistSongs!
                .Join(
                _ctx.Artists!,
                asng => asng.ArtistId,
                a => a.Id,
                (asng, a) => new
                {
                    asng.SongId,
                    ArtistName = a.Name,
                })
                .Join(
                _ctx.Songs!,
                j => j.SongId,
                s => s.Id,
                (j, s) => new
                {
                    j.ArtistName,
                    SongTitle = s.Title,
                    s.GenreId,
                }).Join(
                _ctx.Genres!,
                j => j.GenreId,
                g => g.Id,
                (j, g) => new
                {
                    Artist = j.ArtistName,
                    Song = j.SongTitle,
                    Genre = g.Title,
                });

            var result = query.ToList();

            foreach (var raw in result)
            {
                Console.WriteLine($"Artist: {raw.Artist}; Song: {raw.Song}; Genre: {raw.Genre}.");
            }

            Console.WriteLine("\nSQL query:");
            Console.WriteLine(query.ToQueryString());
        }

        public void GetCountOfSongsInGenre()
        {
            Console.WriteLine("\n\nGet count of songs in genre");

            var query = _ctx.Genres!.Join(
                _ctx.Songs!,
                g => g.Id,
                s => s.GenreId,
                (g, s) => new
                {
                    GenreId = g.Id,
                    GenreTitle = g.Title,
                    SongId = s.Id,
                })
                .GroupBy(j => j.GenreId)
                .Select(g => new
                {
                    Genre = g.Max(j => j.GenreTitle),
                    SongCount = g.Count(),
                });

            var result = query.ToList();

            foreach (var raw in result)
            {
                Console.WriteLine($"Genre: {raw.Genre}; Count of songs: {raw.SongCount}.");
            }

            Console.WriteLine("\nSQL query:");
            Console.WriteLine(query.ToQueryString());
        }

        public void GetSongsWrittenBeforeYoungestArtistBirth()
        {
            Console.WriteLine("\n\nGet songs written before birth of the youngest artist");

            var query = _ctx.Songs!.Where(s => s.ReleasedDate < _ctx.Artists!.Max(a => a.DateOfBirth));

            var result = query.ToList();

            foreach (var raw in result)
            {
                Console.WriteLine($"Id: {raw.Id}; Title: {raw.Title}; Duration: {raw.Duration}; Released Date: {raw.ReleasedDate}.");
            }

            Console.WriteLine("\nSQL query:");
            Console.WriteLine(query.ToQueryString());
        }
    }
}
