namespace Module3PR2LINQ
{
    public class Contact
    {
        private string _name;
        private string _phoneNumber;

        public Contact(string name, string phoneNumber)
        {
            _name = name;
            _phoneNumber = phoneNumber;
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
    }
}
