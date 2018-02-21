﻿CREATE TABLE [dbo].[AccountProjection]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[EmployerAccountId] BIGINT NOT NULL,
    [ProjectionCreationDate] DATETIME NOT NULL,
    [ProjectionGenerationType] SMALLINT NOT NULL,
    [Month] SMALLINT NOT NULL,
    [Year] INT NOT NULL,
    [FundsIn] DECIMAL NOT NULL,
    [TotalCostOfTraining] DECIMAL NOT NULL,
    [CompletionPayments] DECIMAL NOT NULL,
    [FutureFunds] DECIMAL NOT NULL,
	[CoInvestmentEmployer] DECIMAL NOT NULL default(0),
	[CoInvestmentGovernment] DECIMAL NOT NULL default(0)
)
