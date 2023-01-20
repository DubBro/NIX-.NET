using System.Text;

namespace Module3PR4
{
    public class Logger
    {
        private StringBuilder _log;

        public Logger()
        {
            _log = new StringBuilder();
        }

        public event Func<int, bool>? NotifyBackupEvent;

        public string Log
        {
            get
            {
                return _log.ToString();
            }

            private set
            {
                _log.Append(value);
            }
        }

        public async Task WriteLogAsync(string log, int count)
        {
            await Task.Run(() => Log = log);

            if (NotifyBackupEvent!(count))
            {
                await CreateBackupAsync();
            }
        }

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
                await writer.WriteAsync(_log);
            }
        }
    }
}
