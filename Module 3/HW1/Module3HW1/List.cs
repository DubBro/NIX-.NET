// <copyright file="List.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW1
{
    /// <summary>
    /// List class.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    public class List<T> : IList<T>
    {
        private T[] list = Array.Empty<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="List{T}"/> class.
        /// </summary>
        public List()
        {
        }

        /// <summary>
        /// Gets count of items.
        /// </summary>
        public int Count
        {
            get
            {
                return this.list.Length;
            }
        }

        /// <summary>
        /// Gets or sets item value by its index.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>Item.</returns>
        /// <exception cref="IndexOutOfRangeException">Index is out of range.</exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.list[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.list[index] = value;
            }
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">Item that will be added to the list.</param>
        public void Add(T item)
        {
            var tmpList = new T[this.Count + 1];

            for (int i = 0; i < this.Count; i++)
            {
                tmpList[i] = this.list[i];
            }

            tmpList[this.Count] = item;

            this.list = tmpList;
        }

        /// <summary>
        /// Adds an array of items to the list.
        /// </summary>
        /// <param name="array">Items that will be added to the list.</param>
        public void AddRange(T[] array)
        {
            var tmpList = new T[this.Count + array.Length];

            for (int i = 0; i < this.Count; i++)
            {
                tmpList[i] = this.list[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                tmpList[this.Count + i] = array[i];
            }

            this.list = tmpList;
        }

        /// <summary>
        /// Adds a collection of items to the list.
        /// </summary>
        /// <param name="collection">Items that will be added to the list.</param>
        public void AddRange(ICollection<T> collection)
        {
            var tmpArray = new T[collection.Count];

            collection.CopyTo(tmpArray, 0);

            this.AddRange(tmpArray);
        }

        /// <summary>
        /// Removes first occurrence of the item.
        /// </summary>
        /// <param name="item">Item that will be removed.</param>
        /// <returns>true if item was removed or false if not.</returns>
        public bool Remove(T item)
        {
            int index = Array.IndexOf(this.list, item);

            return this.RemoveAt(index);
        }

        /// <summary>
        /// Removes first occurrence of the item by its index.
        /// </summary>
        /// <param name="index">Index of the item that will be removed.</param>
        /// <returns>true if item was removed or false if not.</returns>
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return false;
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.list[i] = this[i + 1];
            }

            Array.Resize(ref this.list, this.Count - 1);

            return true;
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        public void Sort()
        {
            Array.Sort(this.list);
        }

        /// <summary>
        /// Gets an enumerator that iterates through the list.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this.list);
        }
    }
}
