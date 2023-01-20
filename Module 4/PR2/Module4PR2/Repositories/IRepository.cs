using Module4PR2.Entities.Instances;

namespace Module4PR2.Repositories
{
    public interface IRepository
    {
        void GetLeftJoinProjectEmployeeprojectClient();
        void GetDiffTodayHiredDay();
        void UpdateClientProject(Client client, Project project);
        void InsertEmployeeWithTitleAndProject(Employee employee, Project project);
        void DeleteEmployee(int id);
        void GetTitleAndGroupEmployeeByTitle();
    }
}
