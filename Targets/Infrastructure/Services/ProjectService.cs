using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Interfaces;
using Targets.Infrastructure.Repositories;

namespace Targets.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {

        IUserRepository repo;
        public ProjectService(IUserRepository UsersRepository)
        {
            repo = UsersRepository;
        }


        public void AddNewProject(Guid UserId, string Title, string Description)
        {
            throw new NotImplementedException();
        }

        public void EditProject(Guid UserId, string Title, string UpdatedTitle, string UpdatedDescription)
        {
            throw new NotImplementedException();
        }

        public List<IProject> GetProjects(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public void RemoveProject(Guid UserId, string Title)
        {
            throw new NotImplementedException();
        }
    }
}
