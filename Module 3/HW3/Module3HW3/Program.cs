namespace Module3HW3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CreateFiles();

            Console.WriteLine(Task.Run(() => ReadAsync()).Result);
        }

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

        public static async Task<string> ReadAsync()
        {
            string hello = await ReadHelloAsync();
            string world = await ReadWorldAsync();

            return hello + " " + world;
        }

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