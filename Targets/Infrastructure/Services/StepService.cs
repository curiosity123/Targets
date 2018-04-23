using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Infrastructure.Services
{
    public class StepService : IStepService
    {
        public void AddStep(Guid UserId, string ProjectTitle, string StepTitle, string StepDescription)
        {
            throw new NotImplementedException();
        }

        public void EditStep(Guid UserId, string ProjectTitle, string StepTitle, string UpdatedStepTitle, string UpdatedStepDescription)
        {
            throw new NotImplementedException();
        }

        public void RemoveStep(Guid UserId, string ProjecttTitle, string StepTitle)
        {
            throw new NotImplementedException();
        }

        public void SetStepStatus(Guid UserId, bool IsDone)
        {
            throw new NotImplementedException();
        }
    }
}
