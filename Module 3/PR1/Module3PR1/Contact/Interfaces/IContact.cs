namespace Module3PR1.Contact.Interfaces
{
    public interface IContact : IComparable<IContact>
    {
        public string Name { get; }
        public string PhoneNumber { get; }
    }
}
