// <copyright file="ContactsCollectionEnumerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR1.ContactsCollection
{
    using System.Collections;
    using Module3PR1.Contact.Interfaces;

    /// <summary>
    /// ContactsCollectionEnumerator class.
    /// </summary>
    public class ContactsCollectionEnumerator : IEnumerator<IContact>
    {
        private IContact[] contacts;
        private int position = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsCollectionEnumerator"/> class.
        /// </summary>
        /// <param name="contacts">Array of contacts.</param>
        public ContactsCollectionEnumerator(IContact[] contacts)
        {
            this.contacts = contacts;
        }

        /// <summary>
        ///  Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <returns>The element in the collection at the current position of the enumerator.</returns>
        public IContact Current
        {
            get
            {
                if (this.position < 0 || this.position >= this.contacts.Length)
                {
                    throw new InvalidOperationException();
                }

                return this.contacts[this.position];
            }
        }

        /// <summary>
        ///  Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        object IEnumerator.Current => throw new NotImplementedException();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element;
        /// false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (this.position < this.contacts.Length - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }
    }
}
