// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR4
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">The array of the string arguments.</param>
        public static void Main(string[] args)
        {
            Starter starter = new Starter();

            Task[] tasks = { starter.RunAsync(), starter.RunAsync() };
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }
    }
}