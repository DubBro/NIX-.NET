using System.Collections;

namespace Module3HW1
{
    public class ListEnumerator<T> : IEnumerator<T>
    {
        private T[] _list;
        private int _position = -1;

        public ListEnumerator(T[] list)
        {
            _list = list;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _list.Length)
                {
                    throw new InvalidOperationException();
                }

                return _list[_position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (_position < _list.Length - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
        }
    }
}
