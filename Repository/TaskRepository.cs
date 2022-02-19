using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TaskRepository : RepositoryBase<Entities.Models.Task>, ITaskRepository
    {
        public TaskRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public void CreateTaskForUser(Guid userId, Entities.Models.Task task)
        {
            task.UserId = userId;
            Create(task);
        }
        public IEnumerable<Entities.Models.Task> GetTasks(Guid companyId, bool trackChanges) =>
             FindByCondition(e => e.UserId.Equals(companyId), trackChanges)
             .OrderBy(e => e.Name);

    }

}
