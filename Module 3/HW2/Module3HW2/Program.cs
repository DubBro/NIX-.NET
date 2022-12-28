// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW2
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main fucntion.
        /// </summary>
        /// <param name="args">The array of string arguments.</param>
        public static void Main(string[] args)
        {
            FirstClass firstClass = new FirstClass();
            SecondClass secondClass = new SecondClass();

            firstClass.ShowDelegate(secondClass.Calc(firstClass.Pow, 5, 6)(7));
        }

        /// <summary>
        /// Shows the result.
        /// </summary>
        /// <param name="a">Result.</param>
        public static void Show(bool a)
        {
            Console.WriteLine(a);
        }
    }
}