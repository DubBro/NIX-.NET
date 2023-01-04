// <copyright file="Logger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR4
{
    using System.Text;

    /// <summary>
    /// Logger class.
    /// </summary>
    public class Logger
    {
        private StringBuilder log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.log = new StringBuilder();
        }

        /// <summary>
        /// Event that notifies when create backup.
        /// </summary>
        public event Func<int, bool>? NotifyBackupEvent;

        /// <summary>
        /// Gets the full list of the logs.
        /// </summary>
        public string Log
        {
            get
            {
                return this.log.ToString();
            }

            private set
            {
                this.log.Append(value);
            }
        }

        /// <summary>
        /// Writes the log to the logger and creates backup asynchronously.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="count">The count of the logs.</param>
        /// <returns>Task.</returns>
        public async Task WriteLogAsync(string log, int count)
        {
            await Task.Run(() => this.Log = log);

            if (this.NotifyBackupEvent(count))
            {
                await this.CreateBackupAsync();
            }
        }

        /// <summary>
        /// Creates backup of logs. Asynchronously creates a file with log records.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task CreateBackupAsync()
        {
            string backupDirectory = Directory.GetCurrentDirectory() + "/Backup/";
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            string filename = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss.ffff") + ".txt";
            string path = backupDirectory + filename;
            using (StreamWriter writer = new StreamWriter(path))
            {
                await writer.WriteAsync(this.log);
            }
        }
    }
}
