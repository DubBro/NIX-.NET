using System.Globalization;
using Module3PR1.Contact.Interfaces;

namespace Module3PR1.ContactsCollection.Interfaces
{
    public interface IContactsCollection : IEnumerable<IContact>
    {
        public int Count { get; }
        public IContact this[int index] { get; }
        public void Add(IContact contact);
        public void Add(string name, string phoneNumber);
        public void Add(string name, string phoneNumber, CultureInfo culture);
        public void Delete(string name);
        public void Delete(IContact contact);
        public IContact? Find(string name);
        public IContact? Find(IContact contact);
        public void ShowAll();
    }
}