﻿using System;
using AutoMoq;
using Moq;
using NUnit.Framework;
using SFA.DAS.EmployerFinance.Types.Models;
using SFA.DAS.Forecasting.Application.ExpiredFunds.Service;
using SFA.DAS.Forecasting.Domain.Levy;
using SFA.DAS.Forecasting.Domain.Levy.Services;
using SFA.DAS.Forecasting.Domain.Payments.Services;
using SFA.DAS.Forecasting.Models.Projections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;

namespace SFA.DAS.Forecasting.Application.UnitTests.ExpiredFunds
{

    [TestFixture]
    public class ExpiredFundsServiceTests
    {
        private AutoMoqer _moqer;
        private long employerAccountId = 12345;
        private IList<AccountProjectionModel> _accountProjectionModels;
        private IList<LevyPeriod> _netLevyTotals;
        private Dictionary<CalendarPeriod, decimal> _paymentTotals;

        private Dictionary<CalendarPeriod, decimal> _expiredFundsIn;
        private Dictionary<CalendarPeriod, decimal> _expiredFundsOut;

        [SetUp]
        public void SetUp()
        {
            _moqer = new AutoMoqer();

            //ProjectionModel

            _accountProjectionModels = new List<AccountProjectionModel>()
            {
                new AccountProjectionModel()
                {
                    EmployerAccountId = employerAccountId,
                    Month = 1,
                    Year = 2018,
                    LevyFundsIn = 1000,
                    FutureFunds = 200,
                    LevyFundedCompletionPayments = 0,
                    LevyFundedCostOfTraining = 800,
                    ProjectionGenerationType = ProjectionGenerationType.LevyDeclaration
                },
                new AccountProjectionModel()
                {
                    EmployerAccountId = employerAccountId,
                    Month =2,
                    Year = 2018,
                    LevyFundsIn = 1000,
                    FutureFunds = 700,
                    LevyFundedCompletionPayments = 0,
                    LevyFundedCostOfTraining = 500,
                    ProjectionGenerationType = ProjectionGenerationType.LevyDeclaration
                },
                new AccountProjectionModel()
                {
                    EmployerAccountId = employerAccountId,
                    Month = 3,
                    Year = 2018,
                    LevyFundsIn = 1000,
                    FutureFunds = -100,
                    LevyFundedCompletionPayments = 1000,
                    LevyFundedCostOfTraining = 800,
                    ProjectionGenerationType = ProjectionGenerationType.LevyDeclaration
                },

            };


            //NetLevyTotals Object

            _netLevyTotals = new List<LevyPeriod>
            {
                new LevyPeriod(12345, "2016", 1,DateTime.Parse("2016-01-01"), 1000m, null),
                new LevyPeriod(12345, "2017", 10,DateTime.Parse("2017-10-01"), 500m, null),
                new LevyPeriod(12345, "2017", 11,DateTime.Parse("2017-11-01"), 800m, null),
                new LevyPeriod(12345, "2017", 12,DateTime.Parse("2017-12-01"), 300m, null)
            };
            //Payments Object
            _paymentTotals = new Dictionary<CalendarPeriod, decimal>
            {
                {new CalendarPeriod(2016,1), 1000m  },
                {new CalendarPeriod(2017,10), 500m  },
                {new CalendarPeriod(2017,11), 800m  },
                {new CalendarPeriod(2017,12), 300m  },
            };
            //

            _expiredFundsIn = new Dictionary<CalendarPeriod, decimal>
            {
                {new CalendarPeriod(2018,1), 1000m  },
                {new CalendarPeriod(2018,2), 1000m  },
                {new CalendarPeriod(2018,3), 1000m  },
                { new CalendarPeriod(2016,1), 1000m  },
                {new CalendarPeriod(2017,10), 500m  },
                {new CalendarPeriod(2017,11), 800m  },
                {new CalendarPeriod(2017,12), 300m  }

            };

            _expiredFundsOut = new Dictionary<CalendarPeriod, decimal>
            {
                {new CalendarPeriod(2018,1), 800m  },
                {new CalendarPeriod(2018,2), 500m  },
                {new CalendarPeriod(2018,3), 1800m  },
                { new CalendarPeriod(2016,1), 1000m  },
                {new CalendarPeriod(2017,10), 500m  },
                {new CalendarPeriod(2017,11), 800m  },
                {new CalendarPeriod(2017,12), 300m  }

            };

        }

        [Test]
        public async Task Get_Expired_Funds_By_AccountId_Retrieves_NetLevyTotals()
        {
            var sut = _moqer.Resolve<ExpiredFundsService>();
            var employerPaymentDataSession = _moqer.GetMock<IEmployerPaymentDataSession>();
            employerPaymentDataSession.Setup(s => s.GetPaymentTotals(12345)).ReturnsAsync(_paymentTotals);

            await sut.GetExpiringFunds(_accountProjectionModels, employerAccountId);

            var levyDataSession = _moqer.GetMock<ILevyDataSession>();
            levyDataSession.Verify(v => v.GetAllNetTotals(employerAccountId));
        }

        [Test]
        public async Task Get_Expired_Funds_By_AccountId_Retrieves_PaymentTotals()
        {
            var employerPaymentDataSession = _moqer.GetMock<IEmployerPaymentDataSession>();
            employerPaymentDataSession.Setup(s => s.GetPaymentTotals(12345)).ReturnsAsync(_paymentTotals);
            var sut = _moqer.Resolve<ExpiredFundsService>();
            
            await sut.GetExpiringFunds(_accountProjectionModels, employerAccountId);

            employerPaymentDataSession.Verify(v => v.GetPaymentTotals(employerAccountId));
        }

        [Test]
        public async Task Get_Expired_Funds_By_AccountId_Calculates_ExpiredFunds()
        {

            var employerPaymentDataSession = _moqer.GetMock<IEmployerPaymentDataSession>();
            employerPaymentDataSession.Setup(s => s.GetPaymentTotals(12345)).ReturnsAsync(_paymentTotals);

            var sut = _moqer.Resolve<ExpiredFundsService>();

            await sut.GetExpiringFunds(_accountProjectionModels, employerAccountId);

            var expiredFunds = _moqer.GetMock<IExpiredFunds>();
            expiredFunds.Verify(v => v.GetExpiringFunds(It.IsAny<Dictionary<CalendarPeriod, decimal>>(), It.IsAny<Dictionary<CalendarPeriod, decimal>>(), null, 24));
        }

        [Test]
        public void Get_Expired_Funds_Calculates_ExpiredFunds()
        {
            var sut = _moqer.Resolve<ExpiredFundsService>();
            var employerPaymentDataSession = _moqer.GetMock<IExpiredFunds>();

            IDictionary<CalendarPeriod, decimal> calledFundIn = null;
            IDictionary<CalendarPeriod, decimal> calledFundOut = null;
            IDictionary<CalendarPeriod, decimal> calledExpired = null;
            var calledMonths = 0;

            employerPaymentDataSession.Setup(s => s.GetExpiringFunds(It.IsAny<IDictionary<CalendarPeriod, decimal>>(), It.IsAny<IDictionary<CalendarPeriod, decimal>>(), null, 24))
                                        .Callback<IDictionary<CalendarPeriod, decimal>, IDictionary<CalendarPeriod, decimal>, IDictionary<CalendarPeriod, decimal>, int>(
                                                        (fundsIn, fundsOut, expired, months) =>
                                                        {
                                                            calledFundIn = fundsIn;
                                                            calledFundOut = fundsOut;
                                                            calledExpired = expired;
                                                            calledMonths = months;
                                                        });

            sut.GetExpiringFunds(_accountProjectionModels, _netLevyTotals, _paymentTotals);


            calledFundIn.ShouldAllBeEquivalentTo(_expiredFundsIn);    
            calledFundOut.ShouldAllBeEquivalentTo(_expiredFundsOut);
            calledExpired.ShouldAllBeEquivalentTo(calledExpired);
            calledMonths.Should().Be(24);

        }





    }
}