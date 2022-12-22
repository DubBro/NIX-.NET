// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module1HW3
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[n];

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                numbers[i] = random.Next(1, 27);
            }

            Console.Write("Array with random numbers from 1 till 26: ");
            Show(numbers);

            Console.WriteLine();

            int[] evenNumbers = FindEven(numbers);
            int[] oddNumbers = FindOdd(numbers);

            Console.Write("Array with even numbers: ");
            Show(evenNumbers);

            Console.Write("Array with odd numbers: ");
            Show(oddNumbers);

            Console.WriteLine();

            char[] evenLetters = ReplaceNumbersWithLetters(evenNumbers);
            int countEvenUpperLetters = ReplaceLowerLettersWithUpper(ref evenLetters);

            char[] oddLetters = ReplaceNumbersWithLetters(oddNumbers);
            int countOddUpperLetters = ReplaceLowerLettersWithUpper(ref oddLetters);

            Console.Write("Array with even letters: ");
            Show(evenLetters);

            Console.Write("Array with odd letters: ");
            Show(oddLetters);

            Console.WriteLine();

            if (countEvenUpperLetters > countOddUpperLetters)
            {
                Console.WriteLine($"Array with even letters has more upper case letters ({countEvenUpperLetters}) than array with odd letters ({countOddUpperLetters}).");
            }
            else if (countEvenUpperLetters < countOddUpperLetters)
            {
                Console.WriteLine($"Array with odd letters has more upper case letters ({countOddUpperLetters}) than array with even letters ({countEvenUpperLetters}).");
            }
            else
            {
                Console.WriteLine($"Count of the upper case letters in both arrays is equal ({countOddUpperLetters}).");
            }
        }

        // Function that finds even numbers in the array of numbers,
        // creates and fills in other array with these even numbers,
        // and returns it
        private static int[] FindEven(int[] numbers)
        {
            int[] evenNumbers = new int[1];
            int j = 0; // Сounter for array `evenNumbers`

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    // If the array with even numbers is full, we change its size
                    if (evenNumbers[evenNumbers.Length - 1] != 0)
                    {
                        Array.Resize(ref evenNumbers, evenNumbers.Length + 1);
                    }

                    evenNumbers[j] = numbers[i];
                    j++;
                }
            }

            return evenNumbers;
        }

        // Function that finds odd numbers in the array of numbers,
        // creates and fills in other array with these odd numbers,
        // and returns it
        private static int[] FindOdd(int[] numbers)
        {
            int[] oddNumbers = new int[1];
            int j = 0; // Сounter for array `oddNumbers`

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    // If the array with odd numbers is full, we change its size
                    if (oddNumbers[oddNumbers.Length - 1] != 0)
                    {
                        Array.Resize(ref oddNumbers, oddNumbers.Length + 1);
                    }

                    oddNumbers[j] = numbers[i];
                    j++;
                }
            }

            return oddNumbers;
        }

        // Function that replaces number in the array with letter
        // by its sequence number in the alphabet
        // and returns new array of symbols (letters)
        private static char[] ReplaceNumbersWithLetters(int[] arrayNumbers)
        {
            char[] letters =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            };

            char[] arrayLetters = new char[arrayNumbers.Length];

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                arrayLetters[i] = letters[arrayNumbers[i] - 1];
            }

            return arrayLetters;
        }

        // Fucntion that replaces letters  (a, e, i, d, h, j) with (A, E, I, D, H, J)
        // and returns count of the upper case letters
        private static int ReplaceLowerLettersWithUpper(ref char[] letters)
        {
            int count = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                switch (letters[i])
                {
                    case 'a':
                        letters[i] = 'A';
                        count++;
                        break;
                    case 'e':
                        letters[i] = 'E';
                        count++;
                        break;
                    case 'i':
                        letters[i] = 'I';
                        count++;
                        break;
                    case 'd':
                        letters[i] = 'D';
                        count++;
                        break;
                    case 'h':
                        letters[i] = 'H';
                        count++;
                        break;
                    case 'j':
                        letters[i] = 'J';
                        count++;
                        break;
                }
            }

            return count;
        }

        // Function that shows array values on the console
        private static void Show<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.WriteLine(array[i] + ".");
                    return;
                }

                Console.Write(array[i] + ", ");
            }
        }
    }
}