// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR2Delegates
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The event.
        /// </summary>
        public event Func<int, int, int>? SumEvent;

        /// <summary>
        /// Main fucntion.
        /// </summary>
        /// <param name="args">The array of the string arguments.</param>
        public static void Main(string[] args)
        {
            var program = new Program();

            program.SumEvent += program.Sum;
            program.SumEvent += program.Sum;

            var result = program.SumEventFunc(program.SumEvent, 7, 16);

            Console.WriteLine(result);
        }

        /// <summary>
        /// The function that counts the sum of 2 numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The sum of 2 numbers.</returns>
        public int Sum(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Counts the sum of the results of the delegate methods.
        /// </summary>
        /// <param name="sumEvent">Delegate.</param>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The sum of the results of the methods that are located in the delegate.</returns>
        public int SumEventFunc(Func<int, int, int> sumEvent, int a, int b)
        {
            int result = 0;

            try
            {
                foreach (var item in sumEvent.GetInvocationList())
                {
                    result += Convert.ToInt32(item.DynamicInvoke(a, b));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

            return result;
        }
    }
}