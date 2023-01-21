using Module4PR3.Context;
using Module4PR3.Repositories;

namespace Module4PR3
{
    public class Startup
    {
        private ApplicationContext _context;
        private IRepository _repository;

        public Startup()
        {
            _context = new ApplicationContext();
            _repository = new Repository(_context);
        }

        public void Run()
        {
            _repository.GetSongArtistGenre();
            _repository.GetCountOfSongsInGenre();
            _repository.GetSongsWrittenBeforeYoungestArtistBirth();
        }
    }
}
