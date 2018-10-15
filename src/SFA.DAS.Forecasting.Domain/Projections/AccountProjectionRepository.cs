﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFA.DAS.Forecasting.Domain.Balance;
using SFA.DAS.Forecasting.Domain.Commitments;
using SFA.DAS.Forecasting.Domain.Levy.Services;
using SFA.DAS.Forecasting.Domain.Projections.Services;
using SFA.DAS.Forecasting.Models.Balance;
using SFA.DAS.Forecasting.Models.Projections;

namespace SFA.DAS.Forecasting.Domain.Projections
{
    public interface IAccountProjectionRepository
    {
        Task<AccountProjection> InitialiseProjection(long employerAccountId);
        Task Store(AccountProjection accountProjection);
        Task<IList<AccountProjectionModel>> Get(long employerAccountId);
    }

    public class AccountProjectionRepository : IAccountProjectionRepository
    {
        private readonly ICurrentBalanceRepository _currentBalanceRepository;
        private readonly ILevyDataSession _levyDataSession;
        private readonly IAccountProjectionDataSession _accountProjectionDataSession;

        public AccountProjectionRepository(ICurrentBalanceRepository currentBalanceRepository,
            ILevyDataSession levyDataSession, IAccountProjectionDataSession accountProjectionDataSession)
        {
            _currentBalanceRepository = currentBalanceRepository ?? throw new ArgumentNullException(nameof(currentBalanceRepository));
            _levyDataSession = levyDataSession ?? throw new ArgumentNullException(nameof(levyDataSession));
            _accountProjectionDataSession = accountProjectionDataSession ?? throw new ArgumentNullException(nameof(accountProjectionDataSession));
        }
        public async Task<IList<AccountProjectionModel>> Get(long employerAccountId)
        {
            var projections = await _accountProjectionDataSession.Get(employerAccountId);

            return !projections.Any() ? null : projections;
        }

        public async Task<AccountProjection> InitialiseProjection(long employerAccountId)
        {
            var levy = await _levyDataSession.GetLatestLevyAmount(employerAccountId);
            var balance = await _currentBalanceRepository.Get(employerAccountId);
            var commitments = balance.EmployerCommitments;

            return new AccountProjection(new Account(employerAccountId, balance.Amount, levy, balance.TransferAllowance, balance.TransferAllowance), commitments);
        }

        public async Task Store(AccountProjection accountProjection)
        {
            if (!accountProjection.Projections.Any())
                return;
            await _accountProjectionDataSession.DeleteAll(accountProjection.EmployerAccountId);
            await _accountProjectionDataSession.Store(accountProjection.Projections);
            await _accountProjectionDataSession.SaveChanges();
        }
    }
}