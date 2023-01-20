using System.Globalization;
using Module3PR1.ContactsCollection.Interfaces;

namespace Module3PR1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("uk");

            IContactsCollection contacts = new ContactsCollection.ContactsCollection();
            contacts.Add(new Contact.Contact("Тарас", "0934847322", culture));
            contacts.Add(new Contact.Contact("Коля", "4568387650", culture));
            contacts.Add(new Contact.Contact("Рома", "9837804914", culture));
            contacts.Add(new Contact.Contact("Мишко", "9837804914", culture));
            contacts.Add(new Contact.Contact("Adam", "7393469233"));
            contacts.Add(new Contact.Contact("Bob", "9830985678"));
            contacts.Add(new Contact.Contact("2Bob", "2876294287"));
            contacts.Add(new Contact.Contact("<)Bob", "2764624798"));

            contacts.ShowAll();

            Console.WriteLine();

            contacts.Delete("2Bob");

            contacts.ShowAll();
        }
    }
}