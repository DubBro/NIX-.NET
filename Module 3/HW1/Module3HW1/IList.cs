// <copyright file="IList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW1
{
    /// <summary>
    /// IList interface.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    public interface IList<T>
    {
        /// <summary>
        /// Gets count of items.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets or sets item value by its index.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>Item.</returns>
        public T this[int index] { get; set; }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">Item that will be added to the list.</param>
        public void Add(T item);

        /// <summary>
        /// Adds an array of items to the list.
        /// </summary>
        /// <param name="array">Items that will be added to the list.</param>
        public void AddRange(T[] array);

        /// <summary>
        /// Adds a collection of items to the list.
        /// </summary>
        /// <param name="collection">Items that will be added to the list.</param>
        public void AddRange(ICollection<T> collection);

        /// <summary>
        /// Removes first occurrence of the item.
        /// </summary>
        /// <param name="item">Item that will be removed.</param>
        /// <returns>true if item was removed or false if not.</returns>
        public bool Remove(T item);

        /// <summary>
        /// Removes first occurrence of the item by its index.
        /// </summary>
        /// <param name="index">Index of the item that will be removed.</param>
        /// <returns>true if item was removed or false if not.</returns>
        public bool RemoveAt(int index);

        /// <summary>
        /// Sorts the list.
        /// </summary>
        public void Sort();

        /// <summary>
        /// Gets an enumerator that iterates through the list.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator();
    }
}
