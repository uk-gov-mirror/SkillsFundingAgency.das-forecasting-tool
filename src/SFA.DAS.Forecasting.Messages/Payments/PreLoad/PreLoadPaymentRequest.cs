﻿using System.Collections.Generic;

namespace SFA.DAS.Forecasting.Messages.Payments.PreLoad
{
    public class PreLoadPaymentRequest
    {
        public IEnumerable<string> EmployerAccountIds { get; set; }

        public int PeriodYear { get; set; }

        public int PeriodMonth { get; set; }

        public string PeriodId { get; set; }

        public long? SubstitutionId { get; set; }
    }
}