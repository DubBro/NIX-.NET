namespace Module4PR2.Entities.Instances
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public virtual IList<EmployeeProject>? EmployeeProjects { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
    }
}