using Microsoft.EntityFrameworkCore;
using Module4PR2.Context;
using Module4PR2.Entities.Instances;

namespace Module4PR2.Repositories
{
    public class Repository : IRepository
    {
        private ApplicationContext _ctx;

        public Repository(ApplicationContext context)
        {
            _ctx = context;
        }

        public void GetLeftJoinProjectEmployeeprojectClient()
        {
            Console.WriteLine("\nLeft join of 3 tables(`Project`, `EmployeeProject`, `Client`)");

            var query = from p in _ctx.Projects
                    join ep in _ctx.EmployeeProjects! on p.ProjectId equals ep.ProjectId into jointable
                    from r in jointable.DefaultIfEmpty()
                    join c in _ctx.Clients! on p.ClientId equals c.ClientId
                    select new
                    {
                        p.ProjectId,
                        ProjectName = p.Name,
                        ProjectBudget = p.Budget,
                        ProjectStartedDate = p.StartedDate,
                        r.EmployeeProjectId,
                        EmployeeProjectRate = r.Rate,
                        EmployeeProjectStartedDate = r.StartedDate,
                        c.ClientId,
                        ClientFullName = c.FirstName + " " + c.LastName,
                        ClientEmail = c.Email,
                    };

            var result = query.ToList();
        }

        public void GetDiffTodayHiredDay()
        {
            Console.WriteLine("\nDifference between today and `Employee.HiredDate`");

            var query = _ctx.Employees!.Select(e => new
            {
                DiffHiredDay = EF.Functions.DateDiffDay(e.HiredDate, DateTime.Today)
            });

            var result = query.ToList();
        }

        public void UpdateClientProject(Client client, Project project)
        {
            Console.WriteLine("\nUpdate 2 tables (`Client`, `Project`) in one transaction");

            var transaction = _ctx.Database.BeginTransaction();

            try
            {
                _ctx.Clients!.Update(client);
                _ctx.Projects!.Update(project);

                _ctx.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        public void InsertEmployeeWithTitleAndProject(Employee employee, Project project)
        {
            Console.WriteLine("\nInsert `Employee` with `Title` and `Project`");

            var transaction = _ctx.Database.BeginTransaction();

            try
            {
                _ctx.Employees!.Add(employee);
                _ctx.Projects!.Add(project);

                _ctx.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteEmployee(int id)
        {
            Console.WriteLine("\nDelete `Employee`");

            var transaction = _ctx.Database.BeginTransaction();

            try
            {
                var employee = _ctx.Employees!.Find(id);
                if (employee != null)
                {
                    _ctx.Employees.Remove(employee);
                }

                _ctx.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        public void GetTitleAndGroupEmployeeByTitle()
        {
            Console.WriteLine("\nGroup `Employee` by `Title` and return `Title.Name` which does not include symbol `a`");

            var query = _ctx.Employees!.Join(
                _ctx.Titles!,
                e => e.TitleId,
                t => t.TitleId,
                (e, t) => new
                {
                    e.EmployeeId,
                    TitleName = t.Name,
                    e.TitleId
                })
                .Where(j => !j.TitleName!.Contains("a"))
                .GroupBy(j => j.TitleId)
                .Select(g => new
                {
                    TitleName = g.Max(j => j.TitleName)
                });

            var result = query.ToList();
        }
    }
}
