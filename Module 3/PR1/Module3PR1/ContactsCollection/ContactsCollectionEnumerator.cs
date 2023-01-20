using System.Collections;
using Module3PR1.Contact.Interfaces;

namespace Module3PR1.ContactsCollection
{
    public class ContactsCollectionEnumerator : IEnumerator<IContact>
    {
        private IContact[] _contacts;
        private int _position = -1;

        public ContactsCollectionEnumerator(IContact[] contacts)
        {
            _contacts = contacts;
        }

        public IContact Current
        {
            get
            {
                if (_position < 0 || _position >= _contacts.Length)
                {
                    throw new InvalidOperationException();
                }

                return _contacts[_position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_position < _contacts.Length - 1)
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
    }
}
