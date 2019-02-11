﻿using System;
using SFA.DAS.EmployerFinance.Types.Models;
using SFA.DAS.Forecasting.Domain.Levy;
using SFA.DAS.Forecasting.Models.Projections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SFA.DAS.Forecasting.Application.Infrastructure.Telemetry;
using SFA.DAS.Forecasting.Domain.Levy.Services;
using SFA.DAS.Forecasting.Domain.Payments.Services;

namespace SFA.DAS.Forecasting.Application.ExpiredFunds.Service
{
    public interface IExpiredFundsService
    {
        Task<Dictionary<CalendarPeriod, decimal>> GetExpiringFunds(IList<AccountProjectionModel> projections, long employerAccountId);

        Dictionary<CalendarPeriod, decimal> GetExpiringFunds(IList<AccountProjectionModel> projections, IEnumerable<LevyPeriod> levyPeriodTotals, Dictionary<CalendarPeriod, decimal> paymentsTotals);
    }
    public class ExpiredFundsService : IExpiredFundsService
    {
        private readonly IExpiredFunds _expiredFunds;
        private readonly ILevyDataSession _levyDataSession;
        private readonly ITelemetry _telemetry;
        private readonly IEmployerPaymentDataSession _employerPaymentDataSession;

        public ExpiredFundsService(IExpiredFunds expiredFunds, ILevyDataSession levyDataSession, ITelemetry telemetry, IEmployerPaymentDataSession employerPaymentDataSession)
        {
            _expiredFunds = expiredFunds ?? throw new ArgumentNullException(nameof(expiredFunds));
            _levyDataSession = levyDataSession ?? throw new ArgumentNullException(nameof(levyDataSession));
            _telemetry = telemetry ?? throw new ArgumentNullException(nameof(telemetry));
            _employerPaymentDataSession = employerPaymentDataSession;
        }

        public Dictionary<CalendarPeriod, decimal> GetExpiringFunds(IList<AccountProjectionModel> projections, IEnumerable<LevyPeriod> levyPeriodTotals, Dictionary<CalendarPeriod,decimal> paymentsTotals)
        {
            var previousLevyTotals =
                levyPeriodTotals.ToDictionary(k => new CalendarPeriod(k.CalendarYear, k.CalendarMonth),
                    v => v.TotalNetLevyDeclared);


            var fundsIn = projections.ToDictionary(d => new CalendarPeriod(d.Year, d.Month), v => v.LevyFundsIn);
            
            var fundsOut = projections.ToDictionary(d => new CalendarPeriod(d.Year, d.Month),
                v => v.LevyFundedCostOfTraining + v.LevyFundedCompletionPayments);

            fundsIn = fundsIn.Concat(previousLevyTotals).GroupBy(g => g.Key).ToDictionary(t => t.Key, t => t.Last().Value);

            fundsOut = fundsOut.Concat(paymentsTotals).GroupBy(g => g.Key).ToDictionary(t => t.Key, t => t.Last().Value);

            var expiringFunds = _expiredFunds.GetExpiringFunds(fundsIn, fundsOut,null,24);
            return (Dictionary<CalendarPeriod, decimal>) expiringFunds;
        }

        public async Task<Dictionary<CalendarPeriod, decimal>> GetExpiringFunds(IList<AccountProjectionModel> projectionModels, long employerAccountId)
        {
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var netLevyTotal = await _levyDataSession.GetAllNetTotals(employerAccountId);
            var paymentsTotal = await _employerPaymentDataSession.GetPaymentTotals(employerAccountId);
            var expiringFunds = GetExpiringFunds(projectionModels, netLevyTotal, paymentsTotal);
            
            stopwatch.Stop();
            _telemetry.TrackDuration("GenerateExpiringFunds", stopwatch.Elapsed);

            return expiringFunds;
        }

    }
}
