namespace Module4PR3.Entities.Instances
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual IList<ArtistSong>? ArtistSongs { get; set; }
    }
}
