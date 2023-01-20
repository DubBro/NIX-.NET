namespace Module3PR2Delegates
{
    internal class Program
    {
        public event Func<int, int, int>? SumEvent;

        public static void Main(string[] args)
        {
            var program = new Program();

            program.SumEvent += program.Sum;
            program.SumEvent += program.Sum;

            var result = program.SumEventFunc(program.SumEvent, 7, 16);

            Console.WriteLine(result);
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

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