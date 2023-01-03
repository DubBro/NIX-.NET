// <copyright file="Runner.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR3
{
    /// <summary>
    /// Runner class.
    /// </summary>
    public static class Runner
    {
        private static MessageBox messageBox = new MessageBox();

        /// <summary>
        /// Starts the program.
        /// </summary>
        public static void Start()
        {
            var task = messageBox.OpenAsync();
            Task.WhenAll(task).GetAwaiter().GetResult();

            if (messageBox.State == State.Ok)
            {
                Console.WriteLine("Ok - operation was confirmed.");
            }
            else if (messageBox.State == State.Cancel)
            {
                Console.WriteLine("Cancel - operation was rejected.");
            }
        }
    }
}
