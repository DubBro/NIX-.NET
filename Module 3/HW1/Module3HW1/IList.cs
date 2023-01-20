namespace Module3HW1
{
    public interface IList<T>
    {
        public int Count { get; }
        public T this[int index] { get; set; }
        public void Add(T item);
        public void AddRange(T[] array);
        public void AddRange(ICollection<T> collection);
        public bool Remove(T item);
        public bool RemoveAt(int index);
        public void Sort();
        public IEnumerator<T> GetEnumerator();
    }
}
