using Prpr.Database;
using Prpr.Models;
using Prpr.Filters.SubjectFilters;
using Microsoft.EntityFrameworkCore;
namespace Prpr.Interfaces.SubjectInterfaces
{
    public interface ISubjectService
    {
        public Task<Otsenka[]> GetSubjectByGroupAsync(SubjectGroupFilter filter, CancellationToken cancellationToken);
    }
    public class SubjectService : ISubjectService
    {
        private readonly Marks _dbContext;
        public SubjectService(Marks dbContext)
        {
           _dbContext = dbContext;
        }
        public Task<Otsenka[]> GetSubjectByGroupAsync(SubjectGroupFilter filter, CancellationToken cancellationToken = default)
        {
            
            var subjects = _dbContext.Set <Otsenka>().Where(w => w.Subject.SubjectId==filter.SubjectId).ToArrayAsync(cancellationToken);

            return subjects;

        }
    }
}