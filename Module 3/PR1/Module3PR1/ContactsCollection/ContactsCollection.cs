// <copyright file="ContactsCollection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR1.ContactsCollection
{
    using System.Collections;
    using System.Globalization;
    using Module3PR1.Contact.Interfaces;
    using Module3PR1.ContactsCollection.Interfaces;

    /// <summary>
    /// ContactsCollection class.
    /// </summary>
    public class ContactsCollection : IContactsCollection
    {
        private IContact[] contacts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsCollection"/> class.
        /// </summary>
        public ContactsCollection()
        {
            this.contacts = Array.Empty<IContact>();
        }

        /// <summary>
        /// Gets count of contatcts.
        /// </summary>
        public int Count
        {
            get
            {
                return this.contacts.Length;
            }
        }

        /// <summary>
        /// Gets contact by index.
        /// </summary>
        /// <param name="index">Index of the contact.</param>
        /// <returns>Contact.</returns>
        public IContact this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.contacts[index];
            }
        }

        /// <summary>
        /// Adds contact to the collection.
        /// </summary>
        /// <param name="contact">Contact.</param>
        public void Add(IContact contact)
        {
            if (this.Find(contact) != null)
            {
                throw new Exception("The contact with this name already exists.");
            }

            var tmpContacts = new IContact[this.Count + 1];

            for (int i = 0; i < this.Count; i++)
            {
                tmpContacts[i] = this.contacts[i];
            }

            tmpContacts[this.Count] = contact;

            this.contacts = tmpContacts;

            this.Sort();
        }

        /// <summary>
        /// Adds contact to the collection.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <param name="phoneNumber">Contact's number.</param>
        public void Add(string name, string phoneNumber)
        {
            this.Add(new Contact.Contact(name, phoneNumber));
        }

        /// <summary>
        /// Adds contact to the collection.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <param name="phoneNumber">Contact's number.</param>
        /// <param name="culture">Contact's culture.</param>
        public void Add(string name, string phoneNumber, CultureInfo culture)
        {
            this.Add(new Contact.Contact(name, phoneNumber, culture));
        }

        /// <summary>
        /// Deletes contact from the collection by name.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        public void Delete(string name)
        {
            if (this.Find(name) == null)
            {
                return;
            }

            int i = 0;

            for (; i < this.Count; i++)
            {
                if (this.contacts[i].Name == name)
                {
                    break;
                }
            }

            for (; i < this.Count - 1; i++)
            {
                this.contacts[i] = this.contacts[i + 1];
            }

            Array.Resize(ref this.contacts, this.Count - 1);
        }

        /// <summary>
        /// Deletes contact from the collection.
        /// </summary>
        /// <param name="contact">Contact.</param>
        public void Delete(IContact contact)
        {
            this.Delete(contact.Name);
        }

        /// <summary>
        /// Finds contact in the collection.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <returns>Contact if it was found or null if not.</returns>
        public IContact? Find(string name)
        {
            foreach (var contact in this.contacts)
            {
                if (name == contact.Name)
                {
                    return contact;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds contact in the collection.
        /// </summary>
        /// <param name="contact">Contact.</param>
        /// <returns>Contact if it was found or null if not.</returns>
        public IContact? Find(IContact contact)
        {
            return this.Find(contact.Name);
        }

        /// <summary>
        /// Shows all contacts on the console.
        /// </summary>
        public void ShowAll()
        {
            int i = 1;

            foreach (var contact in this)
            {
                Console.WriteLine($"{i}. {contact.Name} - {contact.PhoneNumber};");
                i++;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An System.Collections.IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator<IContact> GetEnumerator()
        {
            return new ContactsCollectionEnumerator(this.contacts);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An System.Collections.IEnumerator object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void Sort()
        {
            Array.Sort(this.contacts);
        }
    }
}
