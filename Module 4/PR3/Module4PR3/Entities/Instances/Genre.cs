namespace Module4PR3.Entities.Instances
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public virtual IList<Song>? Songs { get; set; }
    }
}
