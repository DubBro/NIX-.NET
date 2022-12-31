// <copyright file="IContactsCollection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR1.ContactsCollection.Interfaces
{
    using System.Globalization;
    using Module3PR1.Contact.Interfaces;

    /// <summary>
    /// IContactsCollection interface.
    /// </summary>
    public interface IContactsCollection : IEnumerable<IContact>
    {
        /// <summary>
        /// Gets count of contatcts.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets contact by index.
        /// </summary>
        /// <param name="index">Index of the contact.</param>
        /// <returns>Contact.</returns>
        public IContact this[int index] { get; }

        /// <summary>
        /// Adds contact to the collection.
        /// </summary>
        /// <param name="contact">Contact.</param>
        public void Add(IContact contact);

        /// <summary>
        /// Adds contact to the collection.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <param name="phoneNumber">Contact's number.</param>
        public void Add(string name, string phoneNumber);

        /// <summary>
        /// Adds contact to the collection.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <param name="phoneNumber">Contact's number.</param>
        /// <param name="culture">Contact's culture.</param>
        public void Add(string name, string phoneNumber, CultureInfo culture);

        /// <summary>
        /// Deletes contact from the collection by name.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        public void Delete(string name);

        /// <summary>
        /// Deletes contact from the collection.
        /// </summary>
        /// <param name="contact">Contact.</param>
        public void Delete(IContact contact);

        /// <summary>
        /// Finds contact in the collection.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <returns>Contact if it was found or null if not.</returns>
        public IContact? Find(string name);

        /// <summary>
        /// Finds contact in the collection.
        /// </summary>
        /// <param name="contact">Contact.</param>
        /// <returns>Contact if it was found or null if not.</returns>
        public IContact? Find(IContact contact);

        /// <summary>
        /// Shows all contacts on the console.
        /// </summary>
        public void ShowAll();
    }
}