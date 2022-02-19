using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITaskRepository
    {
        IEnumerable<Entities.Models.Task> GetTasks(Guid userId, bool trackChanges);
        void CreateTaskForUser(Guid userId, Entities.Models.Task task);
    }
}
