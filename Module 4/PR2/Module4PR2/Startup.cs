using Module4PR2.Context;
using Module4PR2.Entities.Instances;
using Module4PR2.Repositories;

namespace Module4PR2
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
            _repository.GetLeftJoinProjectEmployeeprojectClient();
            _repository.GetDiffTodayHiredDay();
            _repository.UpdateClientProject(
                new Client()
                {
                    ClientId = 1,
                    FirstName = "Bruce",
                    LastName = "Lee",
                    Email = "bruce@dragon.lee"
                },
                new Project()
                {
                    ProjectId = 1,
                    Name = "SoundCloud",
                    Budget = 600,
                    StartedDate = DateTime.ParseExact("19.01.2023", "d", null),
                    ClientId = 1
                });
            _repository.InsertEmployeeWithTitleAndProject(
                new Employee()
                {
                    FirstName = "Bjarne",
                    LastName = "Stroustrup",
                    HiredDate = DateTime.Today,
                    DateOfBirth = DateTime.ParseExact("30.12.1950", "d", null),
                    OfficeId = 1,
                    Title = new Title()
                    {
                        Name = "C++ Developer",
                    }
                },
                new Project()
                {
                    Name = "GTA5",
                    Budget = 900,
                    StartedDate = DateTime.Today,
                    ClientId = 1
                });
            _repository.DeleteEmployee(11);
            _repository.GetTitleAndGroupEmployeeByTitle();
        }
    }
}
