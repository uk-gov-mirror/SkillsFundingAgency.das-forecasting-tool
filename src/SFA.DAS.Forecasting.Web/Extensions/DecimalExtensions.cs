﻿namespace SFA.DAS.Forecasting.Web.Extensions
{
    public static class DecimalExtensions
    {
        public static string FormatCost(this decimal value)
        {
            return $"£{value:n0}";
        }

        public static string FormatCost(this decimal? value)
        {
            return value.HasValue ? 
                $"£{value:n0}" : 
                null;
        }
    }
}