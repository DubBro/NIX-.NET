namespace Module4PR2.Entities.Instances
{
    public class Client
    {
        public int ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public virtual IList<Project>? Projects { get; set; }
    }
}