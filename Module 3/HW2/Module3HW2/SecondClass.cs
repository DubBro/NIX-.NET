// <copyright file="SecondClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW2
{
    /// <summary>
    /// SecondClass class.
    /// </summary>
    public class SecondClass
    {
        private int powResult;

        /// <summary>
        /// Calls the Pow() method of the FirstClass using delegate
        /// and returns the delegate of the method Result().
        /// </summary>
        /// <param name="powDelegate">The delegate of the method FirstClass.Pow().</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Secod number.</param>
        /// <returns>The delegate of the method Result().</returns>
        public Func<int, bool> Calc(Func<int, int, int> powDelegate, int a, int b)
        {
            this.powResult = powDelegate(a, b);

            Func<int, bool> resultDelegate = this.Result;

            return resultDelegate;
        }

        private bool Result(int a)
        {
            return this.powResult % a == 0;
        }
    }
}
