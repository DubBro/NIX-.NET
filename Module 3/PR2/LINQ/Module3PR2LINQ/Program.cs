// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR2LINQ
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">The array of string arguments.</param>
        public static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();

            contacts.Add(new Contact("Damien", "47239235"));
            contacts.Add(new Contact("Big Bob", "382932335"));
            contacts.Add(new Contact("123Jiji", "046923439"));
            contacts.Add(new Contact("$$Luckyman$$", "0888888888"));
            contacts.Add(new Contact("Андрійко", "345729324"));
            contacts.Add(new Contact("Онуфрій", "246389344"));

            var result = contacts.OrderBy(c => c.Name).ToList();
            Show(result);

            var result1 = result.First();
            Console.WriteLine(result1.Name + " - " + result1.PhoneNumber + '\n');

            result = contacts.Where(c => c.Name.Contains('і')).ToList();
            Show(result);

            result = contacts.OrderBy(c => c.Name).Reverse().ToList();
            Show(result);

            result = contacts.OrderByDescending(c => c.Name).ToList();
            Show(result);

            if (contacts.Any(c => c.PhoneNumber.Count() >= 10))
            {
                var r = contacts.Union(contacts.Where(c => c.PhoneNumber.Count() == 10)).ToList();
                Show(r);

                r = r.Concat(r.Where(c => c.PhoneNumber.Count() == 10)).ToList();
                Show(r);

                r = r.Distinct().ToList();
                Show(r);
            }
        }

        private static void Show(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Name} - {contact.PhoneNumber}");
            }

            Console.WriteLine();
        }
    }
}