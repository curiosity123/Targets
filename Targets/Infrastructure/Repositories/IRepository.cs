﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.Repositories
{
    public interface IRepository
    {
        User Get(Token token);
        void RegisterAccount(Token token);
        void SetNickName(Token token, string Nick);
        void DeleteAccount(Token token);

        void AddNewProject(Token token, string title, string description);
        void AddStep(Token token, Guid ProjectId, string stepTitle, string stepDescription);
        void EditProject(Token token, Guid ProjectId, string updatedTitle, string updatedDescription);
        void RemoveProject(Token token, Guid ProjectId);
        void EditStep(Token token, Guid ProjectId, Guid StepId, string updatedStepTitle, string updatedStepDescription);
        void RemoveStep(Token token, Guid ProjectId, Guid StepId);
        void SetStepStatus(Token token, Guid ProjectId, Guid StepId, bool isDone);
    }
}
