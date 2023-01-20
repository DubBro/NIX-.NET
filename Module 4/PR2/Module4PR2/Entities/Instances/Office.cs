namespace Module4PR2.Entities.Instances
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public virtual IList<Employee>? Employees { get; set; }
    }
}