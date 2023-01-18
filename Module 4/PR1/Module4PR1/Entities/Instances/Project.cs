namespace Module4PR1.Entities.Instances
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public IList<EmployeeProject> EmployeeProjects { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}