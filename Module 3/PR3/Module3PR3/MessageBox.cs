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
            this.CloseEvent = this.CloseEventFunc;
        }

        private event Action<State> CloseEvent;

        /// <summary>
        /// Gets the state.
        /// </summary>
        public State State { get; private set; }

        /// <summary>
        /// Open function.
        /// </summary>
        public async void Open()
        {
            Random random = new Random();

            Console.WriteLine("Window is opened.");

            Thread.Sleep(3000);

            Console.WriteLine("Window was closed by user.");

            if (random.Next(0, 2) == 0)
            {
                await Task.Run(() => this.CloseEvent(State.Cancel));
            }
            else
            {
                await Task.Run(() => this.CloseEvent(State.Ok));
            }
        }

        private void CloseEventFunc(State state)
        {
            this.State = state;
        }
    }
}
