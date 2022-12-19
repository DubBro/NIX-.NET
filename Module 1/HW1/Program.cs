using System;

namespace NIX_HW_Lec1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Taras";
            string surname = "Melnyk";
            int age = 20;
            int rubicon = 40;
            int yearsLeftto40 = rubicon - age;

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Time that left to the Rubicon ({rubicon} years): {yearsLeftto40}");
        }
    }
}
