﻿namespace SFA.DAS.Forecasting.Application.Payments.Messages
{
	public class EmployerPeriod
	{
		public long EmployerAccountId { get; set; }

		public int Month { get; set; }

		public int Year { get; set; }
	}
}