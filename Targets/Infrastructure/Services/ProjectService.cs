using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public void AddNewProject(Token token, string Title, string Description)
        {
            repo.AddNewProject(token, Title,  Description);

        }

        public void EditProject(Token token, Guid ProjectId, string UpdatedTitle, string UpdatedDescription)
        {
            repo.EditProject(token, ProjectId, UpdatedTitle, UpdatedDescription);
        }

        public void RemoveProject(Token token, Guid ProjectId)
        {
            repo.RemoveProject(token, ProjectId);
        }
    }
}
