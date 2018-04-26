using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Infrastructure.Services
{
    public interface IProjectService
    {

        void AddNewProject(Guid UserId, string Title, string Description);
        void EditProject(Guid UserId, string Title, string UpdatedTitle, string UpdatedDescription);
        void RemoveProject(Guid UserId, string Title);

    }
}
