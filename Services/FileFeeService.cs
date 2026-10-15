using System;
using System.IO;
using BookkeepingApp.Interfaces;

namespace BookkeepingApp.Services
{
    public class FileFeeService : IFeeService
    {
        private readonly string _configFilePath = "config.txt";

        public decimal CalculateFee(DateTime dueDate, DateTime returnDate)
        {
            // No fee if returned on or before the due date
            if (returnDate.Date <= dueDate.Date)
            {
                return 0m;
            }

            decimal dailyFee = GetConfigValue("DailyFee", 2.50m);
            int daysLate = (returnDate.Date - dueDate.Date).Days;

            return daysLate * dailyFee;
        }

        public int GetOrderEtaDays()
        {
            return (int)GetConfigValue("OrderEtaDays", 7m);
        }

        // Helper method to read specific keys from the text file
        private decimal GetConfigValue(string key, decimal defaultValue)
        {
            if (!File.Exists(_configFilePath)) return defaultValue;

            string[] lines = File.ReadAllLines(_configFilePath);
            foreach (string line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length == 2 && parts[0].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    if (decimal.TryParse(parts[1].Trim(), out decimal value))
                    {
                        return value;
                    }
                }
            }

            return defaultValue;
        }
    }
}