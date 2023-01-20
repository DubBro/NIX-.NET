using System.Collections;
using System.Globalization;
using Module3PR1.Contact.Interfaces;
using Module3PR1.ContactsCollection.Interfaces;

namespace Module3PR1.ContactsCollection
{
    public class ContactsCollection : IContactsCollection
    {
        private IContact[] _contacts;

        public ContactsCollection()
        {
            _contacts = Array.Empty<IContact>();
        }

        public int Count
        {
            get
            {
                return _contacts.Length;
            }
        }

        public IContact this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _contacts[index];
            }
        }

        public void Add(IContact contact)
        {
            if (Find(contact) != null)
            {
                throw new Exception("The contact with this name already exists.");
            }

            var tmpContacts = new IContact[Count + 1];

            for (int i = 0; i < Count; i++)
            {
                tmpContacts[i] = _contacts[i];
            }

            tmpContacts[Count] = contact;

            _contacts = tmpContacts;

            Sort();
        }

        public void Add(string name, string phoneNumber)
        {
            Add(new Contact.Contact(name, phoneNumber));
        }

        public void Add(string name, string phoneNumber, CultureInfo culture)
        {
            Add(new Contact.Contact(name, phoneNumber, culture));
        }

        public void Delete(string name)
        {
            if (Find(name) == null)
            {
                return;
            }

            int i = 0;

            for (; i < Count; i++)
            {
                if (_contacts[i].Name == name)
                {
                    break;
                }
            }

            for (; i < Count - 1; i++)
            {
                _contacts[i] = _contacts[i + 1];
            }

            Array.Resize(ref _contacts, Count - 1);
        }

        public void Delete(IContact contact)
        {
            Delete(contact.Name);
        }

        public IContact? Find(string name)
        {
            foreach (var contact in _contacts)
            {
                if (name == contact.Name)
                {
                    return contact;
                }
            }

            return null;
        }

        public IContact? Find(IContact contact)
        {
            return Find(contact.Name);
        }

        public void ShowAll()
        {
            int i = 1;

            foreach (var contact in this)
            {
                Console.WriteLine($"{i}. {contact.Name} - {contact.PhoneNumber};");
                i++;
            }
        }

        public IEnumerator<IContact> GetEnumerator()
        {
            return new ContactsCollectionEnumerator(_contacts);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void Sort()
        {
            Array.Sort(_contacts);
        }
    }
}
