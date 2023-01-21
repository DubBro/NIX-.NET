namespace Module4PR3.Entities.Instances
{
    public class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramUrl { get; set; }
        public virtual IList<ArtistSong>? ArtistSongs { get; set; }
    }
}
