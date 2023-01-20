namespace Module3PR3
{
    public class MessageBox
    {
        public MessageBox()
        {
            CloseEvent = (State s) => State = s;
        }

        private event Action<State> CloseEvent;

        public State State { get; private set; }

        public async Task OpenAsync()
        {
            Console.WriteLine("Window is opened.");

            await Task.Delay(3000);

            Console.WriteLine("Window was closed by user.");

            Random random = new Random();

            switch (random.Next(0, 2))
            {
                case 0:
                    await Task.Run(() => CloseEvent(State.Cancel));
                    break;
                case 1:
                    await Task.Run(() => CloseEvent(State.Ok));
                    break;
            }
        }
    }
}
