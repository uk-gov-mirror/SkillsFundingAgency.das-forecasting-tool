﻿using System;

namespace SFA.DAS.Forecasting.Levy.Application.Messages
{
    /// <summary>
    /// TODO: Temp event definition. this will be replaced by the actual Levy event published by the employer services.
    /// </summary>
    public class LevyDeclarationEvent
    {
        public string EmployerAccountId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Scheme { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}