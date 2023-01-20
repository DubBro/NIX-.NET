using System.Globalization;
using Module3PR1.Contact.Interfaces;

namespace Module3PR1.Contact
{
    public class Contact : IContact
    {
        private string _name;
        private string _phoneNumber;
        private CultureInfo _culture = new CultureInfo("en");

        public Contact(string name, string phoneNumber)
        {
            _name = name;
            _phoneNumber = phoneNumber;
        }

        public Contact(string name, string phoneNumber, CultureInfo culture)
            : this(name, phoneNumber)
        {
            _culture = culture;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
        }

        public int CompareTo(IContact? incomingcontact)
        {
            return string.Compare(Name, incomingcontact?.Name, _culture, CompareOptions.None);
        }
    }
}
