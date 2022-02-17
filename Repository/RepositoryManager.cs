using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository? _companyRepository;
        private ITaskRepository? _employeeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IUserRepository User
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new UserRepository(_repositoryContext);
                return _companyRepository;
            }
        }
        public ITaskRepository Task
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new TaskRepository(_repositoryContext);
                return _employeeRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }

}
