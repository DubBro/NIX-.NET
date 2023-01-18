namespace Module4PR1.Entities.Instances
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}