﻿using System.Threading.Tasks;
using SFA.DAS.Forecasting.Models.Commitments;

namespace SFA.DAS.Forecasting.Domain.Commitments.Services
{
    public interface ICommitmentsDataService
    {
        Task<EmployerCommitmentsModel> GetCurrentCommitments(long employerAccountId);
        Task<CommitmentModel> Get(long employerAccountId, long apprenticeshipId);
        Task Store(CommitmentModel commitment);
    }
}