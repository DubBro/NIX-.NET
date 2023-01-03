// <copyright file="MessageBox.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR3
{
    /// <summary>
    /// MessageBox class.
    /// </summary>
    public class MessageBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBox"/> class.
        /// </summary>
        public MessageBox()
        {
            this.CloseEvent = (State s) => this.State = s;
        }

        private event Action<State> CloseEvent;

        /// <summary>
        /// Gets the state.
        /// </summary>
        public State State { get; private set; }

        /// <summary>
        /// Open function.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task OpenAsync()
        {
            Console.WriteLine("Window is opened.");

            await Task.Delay(3000);

            Console.WriteLine("Window was closed by user.");

            Random random = new Random();

            switch (random.Next(0, 2))
            {
                case 0:
                    await Task.Run(() => this.CloseEvent(State.Cancel));
                    break;
                case 1:
                    await Task.Run(() => this.CloseEvent(State.Ok));
                    break;
            }
        }
    }
}
