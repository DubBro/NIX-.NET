using System;

namespace NIX_HW_Lec2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int[] array;
            int count = 0;
            Random random = new Random();

            for (;;)
            {
                Console.Write("Enter the size of the array (integer only): ");
                var inputSize = Console.ReadLine();

                if (int.TryParse(inputSize, out n))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"ERROR: {inputSize} is not an integer. Try again");
                    continue;
                }
            }

            array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-200, 200);

                if (array[i] >= -100 && array[i] <= 100)
                {
                    count++;
                }

                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"The count of elements contained in the range from -100 to 100: {count}");

            Console.ReadKey();
        }
    }
}
