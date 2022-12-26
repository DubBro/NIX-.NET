// <copyright file="ListEnumerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW1
{
    using System.Collections;

    /// <summary>
    /// ListEnumerator class.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    public class ListEnumerator<T> : IEnumerator<T>
    {
        private T[] list;
        private int position = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListEnumerator{T}"/> class.
        /// </summary>
        /// <param name="list">The array of the items.</param>
        public ListEnumerator(T[] list)
        {
            this.list = list;
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <returns>The element in the collection at the current position of the enumerator.</returns>
        public T Current
        {
            get
            {
                if (this.position == -1 || this.position >= this.list.Length)
                {
                    throw new InvalidOperationException();
                }

                return this.list[this.position];
            }
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <returns>The element in the collection at the current position of the enumerator.</returns>
        object IEnumerator.Current => throw new NotImplementedException();

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element;
        /// false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (this.position < this.list.Length - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
