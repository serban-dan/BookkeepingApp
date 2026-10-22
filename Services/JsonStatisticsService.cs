using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookkeepingApp.Models;

namespace BookkeepingApp.Services
{
    public class JsonStatisticsService
    {
        private readonly string _historyFile = "history.json";

        public async Task<StoreStatistics> GetStatisticsAsync()
        {
            var stats = new StoreStatistics
            {
                MostPopularBook = "N/A",
                BusiestRentalDay = "N/A",
                TotalAllTimeRentals = 0,
                TotalLateFeesCollected = 0m
            };

            if (!File.Exists(_historyFile)) return stats;

            string json = await File.ReadAllTextAsync(_historyFile);
            if (string.IsNullOrWhiteSpace(json)) return stats;

            var history = JsonSerializer.Deserialize<List<RentalHistory>>(json);
            if (history == null || !history.Any()) return stats;

            // 1. Total Rentals
            stats.TotalAllTimeRentals = history.Count;

            // 2. Total Fees
            stats.TotalLateFeesCollected = history.Sum(h => h.FeeCollected);

            // 3. Most Popular Book (Group by Title, order by highest count)
            var mostPopular = history
                .GroupBy(h => h.BookTitle)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (mostPopular != null)
                stats.MostPopularBook = $"{mostPopular.Key} ({mostPopular.Count()} rentals)";

            // 4. Busiest Day (Group by Date, order by highest count)
            var busiestDay = history
                .GroupBy(h => h.RentDate.Date)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (busiestDay != null)
                stats.BusiestRentalDay = $"{busiestDay.Key.ToShortDateString()} ({busiestDay.Count()} rentals)";

            return stats;
        }
    }
}