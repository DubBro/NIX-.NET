namespace Module3HW1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IList<int> listInt = new List<int>();
            listInt.Add(2);
            listInt.Add(-4);
            listInt.Add(100);
            listInt.Add(-120);
            Show(listInt);

            IList<string> listString = new List<string>();
            listString.AddRange(new string[] { "Life", "is", "good", "but", "good", "life", "is", "even", "better" });
            Show(listString);

            Console.WriteLine();

            listInt.Sort();
            Show(listInt);

            listString.Sort();
            Show(listString);
        }

        public static void Show<T>(IList<T> list)
        {
            foreach (var item in list)
            {
                if (item!.Equals(list[list.Count - 1]))
                {
                    Console.WriteLine(item + ".");
                }
                else
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}