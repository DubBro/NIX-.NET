// <copyright file="FirstClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW2
{
    /// <summary>
    /// FirstClass class.
    /// </summary>
    public class FirstClass
    {
        /// <summary>
        /// The delegate of the method Program.Show().
        /// </summary>
        private Action<bool> showDelegate = Program.Show;

        /// <summary>
        /// Gets The delegate of the method Program.Show().
        /// </summary>
        public Action<bool> ShowDelegate
        {
            get { return this.showDelegate; }
        }

        /// <summary>
        /// Multiplies 2 numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The result of multiplying numbers.</returns>
        public int Pow(int a, int b)
        {
            return a * b;
        }
    }
}
