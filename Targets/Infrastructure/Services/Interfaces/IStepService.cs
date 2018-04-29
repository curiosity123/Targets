using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Infrastructure.DTO;

namespace Targets.Infrastructure.Services
{
    public interface IStepService

    {

        void AddStep(Token token, Guid ProjectId, string StepTitle, string StepDescription);
        void RemoveStep(Token token, Guid ProjectId, Guid StepId);
        void EditStep(Token token, Guid ProjectId, Guid StepId, string UpdatedStepTitle, string UpdatedStepDescription);
        void SetStepStatus(Token token, Guid ProjectId, Guid StepId, bool IsDone);

    }
}
