﻿using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SFA.DAS.Forecasting.AcceptanceTests.Services;
using SFA.DAS.Forecasting.Application.Levy.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Forecasting.AcceptanceTests.Levy.Steps
{
    [Binding]
    public class ProcessLevyEventCI_528Steps : StepsBase
    {
        private const long EmployerAccountId = 1111;
        private AzureTableService _azureTableService;


        [OneTimeSetUp]
        public void BeforeScenario()
        {
            _azureTableService = new AzureTableService(Config.AzureStorageConnectionString, Config.LevyDeclarationsTable);
            _azureTableService.EnsureExcists();
            _azureTableService.DeleteEntities(EmployerAccountId.ToString());
        }

        [OneTimeTearDown]
        public void AfterSecnario()
        {
            _azureTableService.DeleteEntities(EmployerAccountId.ToString());
            Thread.Sleep(1000);
        }
        
        [Given(@"levy credit events have been created")]
        public async Task GivenLevyCreditEventsHaveBeenCreated()
        {
            await PostData(ValidData());
        }

        [Given(@"all events with invalid data have been created")]
         public async Task WhenThereIsMissingEventData()
        {
            await PostData(InvalidData());
        }


        [Then(@"there are (.*) levy credit events stored")]
        public void ThenThereAreLevyCreditEventsStored(int expectedRecordsoBeSaved)
        {
            var _records = Do(() => _azureTableService?.GetRecords<LevyDeclarationEvent>(EmployerAccountId.ToString()), expectedRecordsoBeSaved, TimeSpan.FromMilliseconds(1000), 5);
            Assert.AreEqual(expectedRecordsoBeSaved, _records.Count(), message: $"Only {expectedRecordsoBeSaved} record should validate and be saved to the database");
        }

        [Then(@"all of the levy declarations  stored is correct")]
        public void ThenAllOfTheLevyDeclarationsStoredIsCorrect()
        {
            var _records = _azureTableService?.GetRecords<LevyDeclarationEvent>(EmployerAccountId.ToString())?.ToList();

            _records.Should().Contain(m => m.Amount == 301);
            _records.Should().Contain(m => m.Amount == 201);
            _records.Should().Contain(m => m.Amount == 101);
        }

        [Then(@"all the event with invalid data is not stored")]
        public void ThenAllTheEventWithInvalidDataIsNotStored()
        {
            var _records = _azureTableService?.GetRecords<LevyDeclarationEvent>(EmployerAccountId.ToString());

            Assert.AreEqual(0, _records.Count(m => m.EmployerAccountId.ToString().EndsWith("2")));
        }


        private IEnumerable<string> ValidData()
        {
            return
                new List<LevyDeclarationEvent> {
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = 101,
                        TransactionDate = DateTime.Now,
                        PayrollYear = "18/19",
                        PayrollMonth = 1,
                        Scheme = "Not sure"
                    },
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = 201,
                        TransactionDate = DateTime.Now.AddMonths(-12),
                        PayrollYear = "18/19",
                        PayrollMonth = 1,
                        Scheme = "Not sure"
                    },
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = 301,
                        TransactionDate = DateTime.Now.AddMonths(-15),
                        PayrollYear = "18/19",
                        PayrollMonth = 1,
                        Scheme = "Not sure"
                    }
                }
                .Select(m => JsonConvert.SerializeObject(m));
        }

        private IEnumerable<string> InvalidData()
        {
            return
                new List<LevyDeclarationEvent> {
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = 102,
                        TransactionDate = DateTime.Now,
                        PayrollYear = "17/18",
                        PayrollMonth = 1,
                        Scheme = ""
                    },
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = 202,
                        TransactionDate = DateTime.Now.AddMonths(-25).AddDays(-1),
                        PayrollYear = "16/17",
                        PayrollMonth = 1,
                        Scheme = "Not sure"
                    },
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = 303,
                        TransactionDate = DateTime.Now.AddMonths(-15),
                        PayrollYear = "01/01",
                        PayrollMonth = 1,
                        Scheme = "Not sure"
                    },
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = 501,
                        TransactionDate = DateTime.Now.AddMonths(-2),
                        PayrollYear = "17/18",
                        PayrollMonth = 1,
                        Scheme = "Not sure"
                    },
                    new LevyDeclarationEvent {
                        EmployerAccountId = EmployerAccountId,
                        Amount = -10,
                        TransactionDate = DateTime.Now.AddMonths(-2),
                        PayrollYear = "18/19",
                        PayrollMonth = 1,
                        Scheme = "Not sure"
                    }

                }
                .Select(m => JsonConvert.SerializeObject(m));
        }

        private async Task PostData(IEnumerable<string> events)
        {
            var client = new HttpClient();

            var url = Path.Combine(Config.FunctionBaseUrl, "LevyDeclarationEventHttpFunction");
            foreach (var item in events)
            {
                await client.PostAsync(url, new StringContent(item));
            }

            Thread.Sleep(2000);
        }

        public static IEnumerable<T> Do<T>(
            Func<IEnumerable<T>> action,
            int expectedCount,
            TimeSpan retryInterval,
            int maxAttemptCount = 3)
        {
            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                var a = action();
                if(a.Count() == expectedCount)
                {
                    return a;
                }
                Thread.Sleep(retryInterval);
            }
            return new List<T>();
        }
    }
}
