namespace Module3PR3
{
    public static class Runner
    {
        private static MessageBox messageBox = new MessageBox();

        public static void Start()
        {
            var task = messageBox.OpenAsync();
            Task.WhenAll(task).GetAwaiter().GetResult();

            if (messageBox.State == State.Ok)
            {
                Console.WriteLine("Ok - operation was confirmed.");
            }
            else if (messageBox.State == State.Cancel)
            {
                Console.WriteLine("Cancel - operation was rejected.");
            }
        }
    }
}
