namespace Module3HW2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FirstClass firstClass = new FirstClass();
            SecondClass secondClass = new SecondClass();

            firstClass.ShowDelegate(secondClass.Calc(firstClass.Pow, 5, 6)(7));
        }

        public static void Show(bool a)
        {
            Console.WriteLine(a);
        }
    }
}