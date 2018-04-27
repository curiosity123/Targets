using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Infrastructure.Services
{
    public interface IProjectService
    {

        void AddNewProject(Token token, string Title, string Description);
        void EditProject(Token token, Guid ProjectId, string UpdatedTitle, string UpdatedDescription);
        void RemoveProject(Token token, Guid ProjectId);

    }
}
