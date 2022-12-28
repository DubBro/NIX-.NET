// <copyright file="Contact.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR1.Contact
{
    using System.Globalization;
    using Module3PR1.Contact.Interfaces;

    /// <summary>
    /// Contact class.
    /// </summary>
    public class Contact : IContact
    {
        private string name;
        private string phoneNumber;
        private CultureInfo culture = new CultureInfo("en");

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <param name="phoneNumber">>Contact's number.</param>
        public Contact(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <param name="phoneNumber">>Contact's number.</param>
        /// <param name="culture">>Contact's culture.</param>
        public Contact(string name, string phoneNumber, CultureInfo culture)
            : this(name, phoneNumber)
        {
            this.culture = culture;
        }

        /// <summary>
        /// Gets the name of the contact.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the phone number of the contact.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns
        /// an integer that indicates whether the current instance precedes, follows, or
        /// occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="incomingcontact">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared.
        /// The return value has these meanings:
        /// Value – Meaning
        /// Less than zero – This instance precedes other in the sort order.
        /// Zero – This instance occurs in the same position in the sort order as other.
        /// Greater than zero – This instance follows other in the sort order.
        /// </returns>
        public int CompareTo(IContact? incomingcontact)
        {
            return string.Compare(this.Name, incomingcontact?.Name, this.culture, CompareOptions.None);
        }
    }
}
