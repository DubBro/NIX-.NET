// <copyright file="Starter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Module3PR4
{
    using System.Configuration;

    /// <summary>
    /// Starter class.
    /// </summary>
    public class Starter
    {
        private Logger logger;
        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="Starter"/> class.
        /// </summary>
        public Starter()
        {
            this.logger = new Logger();
            this.logger.NotifyBackupEvent += this.NotifyBackup;
        }

        /// <summary>
        /// Starts asynchronous writing the logs.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task RunAsync()
        {
            await this.semaphoreSlim.WaitAsync();
            try
            {
                for (int i = 1; i <= 50; i++)
                {
                    var log = $"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss:ffff")} : Log #{i};\n";
                    await this.logger.WriteLogAsync(log, i);
                }
            }
            finally
            {
                this.semaphoreSlim.Release();
            }
        }

        private bool NotifyBackup(int logCount)
        {
            int logRecordsCount = Convert.ToInt32(ConfigurationManager.AppSettings["logBackupRecordsCount"]);
            return logCount % logRecordsCount == 0;
        }
    }
}
