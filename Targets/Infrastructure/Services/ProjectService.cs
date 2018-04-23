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

        IRepository repo;
        public ProjectService(IRepository _repo)
        {
            repo = _repo;
        }


        public void AddNewProject(Guid UserId, string Title, string Description)
        {
            repo.AddNewProject(UserId, Title,  Description);

        }

        public void EditProject(Guid UserId, string Title, string UpdatedTitle, string UpdatedDescription)
        {
            repo.EditProject(UserId, Title, UpdatedTitle, UpdatedDescription);
        }


        public void RemoveProject(Guid UserId, string Title)
        {
            repo.RemoveProject(UserId, Title);
        }
    }
}
