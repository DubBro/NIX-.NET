namespace Module3PR4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Starter starter = new Starter();

            Task[] tasks = { starter.RunAsync(), starter.RunAsync() };
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }
    }
}