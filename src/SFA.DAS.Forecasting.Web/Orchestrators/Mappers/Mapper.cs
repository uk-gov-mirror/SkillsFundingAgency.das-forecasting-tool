﻿using System.Collections.Generic;
using System.Linq;

using SFA.DAS.Forecasting.Domain.Entities;
using SFA.DAS.Forecasting.ReadModel.AccountProjections;
using SFA.DAS.Forecasting.Web.ViewModels;

namespace SFA.DAS.Forecasting.Web.Orchestrators.Mappers
{
    public class Mapper
    {
        public IEnumerable<BalanceItemViewModel> MapBalance(IEnumerable<AccountProjection> data)
        {
            return data.Select(x =>
                new BalanceItemViewModel
                {
                    Date = new System.DateTime(x.Year, x.Month, 1),
                    LevyCredit = x.FundsIn,
                    CostOfTraining = x.TotalCostOfTraning,
                    CompletionPayments = x.CompletionPayments,
                    ExpiredFunds = 0,
                    Balance = x.FutureFunds
                });
        }

        public ApprenticeshipViewModel MapApprenticeship(Apprenticeship apprenticeship)
        {
            return new ApprenticeshipViewModel
            {
                Name = $"{apprenticeship.FirstName} {apprenticeship.LastName}",
                StartDate = apprenticeship.StartDate,
                MonthlyPayment = apprenticeship.MonthlyPayment,
                TotalInstallments = apprenticeship.TotalInstallments,
                CompletionPayment = apprenticeship.CompletionPayment
            };
        }
    }
}