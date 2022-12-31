// <copyright file="Contact.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR2LINQ
{
    /// <summary>
    /// Contact class.
    /// </summary>
    public class Contact
    {
        private string name;
        private string phoneNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">Contact's name.</param>
        /// <param name="phoneNumber">Contact's phone number.</param>
        public Contact(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets contact's name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets contact's phone number.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
        }
    }
}
