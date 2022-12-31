// <copyright file="IContact.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR1.Contact.Interfaces
{
    /// <summary>
    /// IContact interface.
    /// </summary>
    public interface IContact : IComparable<IContact>
    {
        /// <summary>
        /// Gets the name of the contact.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the phone number of the contact.
        /// </summary>
        public string PhoneNumber { get; }
    }
}
