using System;

namespace NIX_HW_Lec2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[20];
            int[] B = new int[20];
            int i, j;
            i = j = 0;
            Random random = new Random();

            Console.WriteLine("Array \"A\":");
            for (; i < A.Length; i++)
            {
                A[i] = random.Next(2000);

                if (A[i] <= 888)
                {
                    B[j] = A[i];
                    j++;
                }

                Console.Write(A[i] + " ");
            }

            Console.WriteLine();

            // It was too easy to use Array.Sort(Array) and Array.Reverse(Array),
            // so I decided to create my own sorting fuction
            B = SortArrayInDescend(B);

            Console.WriteLine("Sorted array \"B\":");
            for (j = 0; j < B.Length; j++)
            {
                Console.Write(B[j] + " ");
            }

            Console.ReadKey();
        }

        // Function that sorts elements of array in descending order
        static int[] SortArrayInDescend(int[] arr)
        {
            int j;

            do
            {
                j = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        j++;
                    }
                }
            } while (j != 0);

            return arr;
        }
    }
}
