using Prpr.Database;
using Prpr.Models;
using Prpr.Filters.StudentFilters;
using Microsoft.EntityFrameworkCore;

namespace Prpr.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }
    public class StudentService : IStudentService
    {
        private Marks _dbContext;
        public StudentService(Marks dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
            return students;
        }
    }
}