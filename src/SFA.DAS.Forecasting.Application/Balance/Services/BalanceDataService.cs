﻿using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SFA.DAS.Forecasting.Application.Infrastructure.Configuration;
using SFA.DAS.Forecasting.Domain.Balance.Services;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Sql.Client;

namespace SFA.DAS.Forecasting.Application.Balance.Services
{
    public class BalanceDataService: BaseRepository, IBalanceDataService
    {
        public BalanceDataService(IApplicationConfiguration configuration, ILog logger) : base(configuration.DatabaseConnectionString, logger)
        {
        }

        public async Task<Models.Balance.Balance> Get(long employerAccountId)
        {
            return await WithConnection(async connection =>
             {
                 var parameters = new DynamicParameters();
                 parameters.Add("@employerAccountId", employerAccountId, DbType.Int64);

                 var sql = @"Select 
	                            [EmployerAccountId],
	                            [Amount],
	                            [BalancePeriod],
	                            [ReceivedDate]
                                From Balance
                                Where EmployerAccountId = @employerAccountId";

                 var balance = await connection.QueryAsync<Models.Balance.Balance>(
                     sql,
                     parameters,
                     commandType: CommandType.Text);
                 return balance.FirstOrDefault();
             });
        }

        public async Task Store(Models.Balance.Balance balance)
        {
            await WithConnection(async connection =>
            {
                var parameters = new DynamicParameters();
                parameters.Add("@employerAccountId", balance.EmployerAccountId, DbType.Int64);
                parameters.Add("@amount", balance.Amount, DbType.Decimal);
                parameters.Add("@balancePeriod", balance.BalancePeriod, DbType.DateTime);
                parameters.Add("@receivedDate", balance.ReceivedDate, DbType.DateTime);

                return await connection.ExecuteAsync(
                    @"MERGE Balance AS target 
                                    USING(SELECT @employerAccountId, @amount, @balancePeriod, @ReceivedDate) AS source (EmployerAccountId, Amount, BalancePeriod, ReceivedDate)
                                    ON (target.EmployerAccountId = source.EmployerAccountId)
                                    WHEN MATCHED THEN
                                        UPDATE SET Amount = source.Amount, 
                                            BalancePeriod = source.BalancePeriod, 
                                            ReceivedDate = source.ReceivedDate, 
                                    WHEN NOT MATCHED THEN
                                        INSERT(EmployerAccountId, Amount, BalancePeriod, ReceivedDate)
                                        VALUES(source.EmployerAccountId, source.Amount, source.BalancePeriod, source.ReceivedDate)",
                    parameters,
                    commandType: CommandType.Text);
            });
        }


    }
}