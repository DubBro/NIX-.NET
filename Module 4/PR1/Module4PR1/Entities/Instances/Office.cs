namespace Module4PR1.Entities.Instances
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}