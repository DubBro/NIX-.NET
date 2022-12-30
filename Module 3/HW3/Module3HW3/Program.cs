// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3HW3
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main fucntion.
        /// </summary>
        /// <param name="args">The array of the string arguments.</param>
        public static void Main(string[] args)
        {
            CreateFiles();

            Console.WriteLine(Task.Run(() => ReadAsync()).Result);
        }

        /// <summary>
        /// Reads the text from file asynchronously.
        /// </summary>
        /// <returns>The task.</returns>
        public static async Task<string> ReadHelloAsync()
        {
            string path = "Hello.txt";
            string text;

            using (StreamReader reader = new StreamReader(path))
            {
                text = await reader.ReadToEndAsync();
            }

            return text;
        }

        /// <summary>
        /// Reads the text from file asynchronously.
        /// </summary>
        /// <returns>The task.</returns>
        public static async Task<string> ReadWorldAsync()
        {
            string path = "World.txt";
            string text;

            using (StreamReader reader = new StreamReader(path))
            {
                text = await reader.ReadToEndAsync();
            }

            return text;
        }

        /// <summary>
        /// Calls functions that read the text from file asynchronously and returns its concatenation.
        /// </summary>
        /// <returns>The task.</returns>
        public static async Task<string> ReadAsync()
        {
            string hello = await ReadHelloAsync();
            string world = await ReadWorldAsync();

            return hello + " " + world;
        }

        /// <summary>
        /// Creates files to read text from them.
        /// </summary>
        public static void CreateFiles()
        {
            string helloPath = "Hello.txt";
            string worldPath = "World.txt";

            using (StreamWriter writer = new StreamWriter(helloPath, false))
            {
                writer.Write("Hello");
            }

            using (StreamWriter writer = new StreamWriter(worldPath, false))
            {
                writer.Write("World");
            }
        }
    }
}