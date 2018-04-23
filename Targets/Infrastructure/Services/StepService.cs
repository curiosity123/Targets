using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Infrastructure.Repositories;

namespace Targets.Infrastructure.Services
{
    public class StepService : IStepService
    {

        IRepository repo;
        public StepService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddStep(Guid UserId, string ProjectTitle, string StepTitle, string StepDescription)
        {
            repo.AddStep(UserId, ProjectTitle, StepTitle, StepDescription);
        }

        public void EditStep(Guid UserId, string ProjectTitle, string StepTitle, string UpdatedStepTitle, string UpdatedStepDescription)
        {
            repo.EditStep(UserId, ProjectTitle, StepTitle, UpdatedStepTitle, UpdatedStepDescription);
        }

        public void RemoveStep(Guid UserId, string ProjecttTitle, string StepTitle)
        {
            repo.RemoveStep(UserId, ProjecttTitle, StepTitle);
        }

        public void SetStepStatus(Guid UserId, string ProjecttTitle, string StepTitle, bool IsDone)
        {
            repo.SetStepStatus(UserId, ProjecttTitle, StepTitle, IsDone);
        }
    }
}
