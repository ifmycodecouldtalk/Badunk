using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<UserInfo> GetAllUsers(bool trackChanges);
        UserInfo? GetUser(Guid userId, bool trackChanges);
        void CreateUser(UserInfo user);
    }

}
