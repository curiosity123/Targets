using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Infrastructure.Services
{
    public interface IStepService

    {

        void AddStep(Guid UserId, string ProjectTitle, string StepTitle, string StepDescription);
        void RemoveStep(Guid UserId, string ProjecttTitle, string StepTitle);
        void EditStep(Guid UserId, string ProjectTitle, string StepTitle, string UpdatedStepTitle, string UpdatedStepDescription);
        void SetStepStatus(Guid UserId, string ProjecttTitle, string StepTitle, bool IsDone);

    }
}
