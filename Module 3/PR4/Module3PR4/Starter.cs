using System.Configuration;

namespace Module3PR4
{
    public class Starter
    {
        private Logger _logger;
        private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public Starter()
        {
            _logger = new Logger();
            _logger.NotifyBackupEvent += NotifyBackup;
        }

        public async Task RunAsync()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                for (int i = 1; i <= 50; i++)
                {
                    var log = $"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss:ffff")} : Log #{i};\n";
                    await _logger.WriteLogAsync(log, i);
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private bool NotifyBackup(int logCount)
        {
            int logRecordsCount = Convert.ToInt32(ConfigurationManager.AppSettings["logBackupRecordsCount"]);
            return logCount % logRecordsCount == 0;
        }
    }
}
