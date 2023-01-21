namespace Module4PR3.Entities.Instances
{
    public class ArtistSong
    {
        public int? ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
        public int? SongId { get; set; }
        public virtual Song? Song { get; set; }
    }
}
