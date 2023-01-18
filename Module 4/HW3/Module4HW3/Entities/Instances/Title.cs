namespace Module4HW3.Entities.Instances
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
