namespace Module3HW1
{
    public class List<T> : IList<T>
    {
        private T[] _list = Array.Empty<T>();

        public List()
        {
        }

        public int Count
        {
            get
            {
                return _list.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _list[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                _list[index] = value;
            }
        }

        public void Add(T item)
        {
            var tmpList = new T[Count + 1];

            for (int i = 0; i < Count; i++)
            {
                tmpList[i] = _list[i];
            }

            tmpList[Count] = item;

            _list = tmpList;
        }

        public void AddRange(T[] array)
        {
            var tmpList = new T[Count + array.Length];

            for (int i = 0; i < Count; i++)
            {
                tmpList[i] = _list[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                tmpList[Count + i] = array[i];
            }

            _list = tmpList;
        }

        public void AddRange(ICollection<T> collection)
        {
            var tmpArray = new T[collection.Count];

            collection.CopyTo(tmpArray, 0);

            AddRange(tmpArray);
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_list, item);

            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                return false;
            }

            for (int i = index; i < Count - 1; i++)
            {
                _list[i] = this[i + 1];
            }

            Array.Resize(ref _list, Count - 1);

            return true;
        }

        public void Sort()
        {
            Array.Sort(_list);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(_list);
        }
    }
}
