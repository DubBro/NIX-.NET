// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW1
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">string[] parameter.</param>
        public static void Main(string[] args)
        {
            IList<int> listInt = new List<int>();
            listInt.Add(2);
            listInt.Add(-4);
            listInt.Add(100);
            listInt.Add(-120);
            Show(listInt);

            IList<string> listString = new List<string>();
            listString.AddRange(new string[] { "Life", "is", "good", "but", "good", "life", "is", "even", "better" });
            Show(listString);

            Console.WriteLine();

            listInt.Sort();
            Show(listInt);

            listString.Sort();
            Show(listString);
        }

        /// <summary>
        /// Shows the list on the console.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="list">List of items.</param>
        public static void Show<T>(IList<T> list)
        {
            foreach (var item in list)
            {
                if (item.Equals(list[list.Count - 1]))
                {
                    Console.WriteLine(item + ".");
                }
                else
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}