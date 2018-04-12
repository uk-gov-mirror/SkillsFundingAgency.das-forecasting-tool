﻿using System.Threading.Tasks;
using SFA.DAS.Forecasting.Web.ViewModels;

namespace SFA.DAS.Forecasting.Web.Orchestrators
{
    public interface IApprenticeshipOrchestrator
    {
        Task<ApprenticeshipAddViewModel> GetApprenticeshipAddSetup(string hashedAccountId, string estimationName);
    }
}