﻿using Microsoft.WindowsAzure.Storage.Table;

namespace SFA.DAS.Forecasting.Application.Levy.Services.Models
{
    public class TableEntry : TableEntity
    {
        public string Data { get; set; }
    }
}