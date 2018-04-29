using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Infrastructure.DTO;
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

        public void AddStep(Token token, Guid ProjectId, string StepTitle, string StepDescription)
        {
            repo.AddStep(token, ProjectId, StepTitle, StepDescription);
        }

        public void EditStep(Token token, Guid ProjectId, Guid StepId, string UpdatedStepTitle, string UpdatedStepDescription)
        {
            repo.EditStep(token, ProjectId, StepId, UpdatedStepTitle, UpdatedStepDescription);
        }

        public void RemoveStep(Token token, Guid ProjectId, Guid StepId)
        {
            repo.RemoveStep(token, ProjectId, StepId);
        }

        public void SetStepStatus(Token token, Guid ProjectId, Guid StepId, bool IsDone)
        {
            repo.SetStepStatus(token, ProjectId, StepId, IsDone);
        }
    }
}
