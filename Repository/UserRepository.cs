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
    public class UserRepository : RepositoryBase<UserInfo>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<UserInfo> GetAllUsers(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.userName)
             .ToList();
        public UserInfo? GetUser(Guid userId, bool trackChanges) =>
             FindByCondition(c => c.Id.Equals(userId), trackChanges)
             .SingleOrDefault();
        public void CreateUser(UserInfo user) => Create(user);

    }

}
