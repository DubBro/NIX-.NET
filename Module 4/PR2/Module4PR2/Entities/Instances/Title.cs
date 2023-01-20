namespace Module4PR2.Entities.Instances
{
    public class Title
    {
        public int TitleId { get; set; }
        public string? Name { get; set; }
        public virtual IList<Employee>? Employees { get; set; }
    }
}