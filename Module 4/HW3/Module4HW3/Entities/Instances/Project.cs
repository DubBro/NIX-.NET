namespace Module4HW3.Entities.Instances
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public IList<EmployeeProject> EmployeeProjects { get; set; }
    }
}
