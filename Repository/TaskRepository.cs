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
    }

}
