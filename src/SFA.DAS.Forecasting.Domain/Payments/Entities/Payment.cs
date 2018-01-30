﻿namespace SFA.DAS.Forecasting.Domain.Payments.Entities
{
	public class Payment
	{
		public string Id { get; set; }

		public string EmployerAccountId { get; set; }

		public long Ukprn { get; set; }

		public long ApprenticeshipId { get; set; }

		public decimal Amount { get; set; }
	}
}