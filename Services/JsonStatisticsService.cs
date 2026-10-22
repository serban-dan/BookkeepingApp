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
                TotalLateFeesCollected = 0m,
                Top5Books = new Dictionary<string, int>()
            };

            if (!File.Exists(_historyFile)) return stats;

            string json = await File.ReadAllTextAsync(_historyFile);
            if (string.IsNullOrWhiteSpace(json)) return stats;

            var history = JsonSerializer.Deserialize<List<RentalHistory>>(json);
            if (history == null || history.Count == 0) return stats;

            stats.TotalAllTimeRentals = history.Count;
            stats.TotalLateFeesCollected = history.Sum(h => h.FeeCollected);

            // Get the most popular single book
            var bookGroups = history.GroupBy(h => h.BookTitle).OrderByDescending(g => g.Count());
            var mostPopular = bookGroups.FirstOrDefault();

            if (mostPopular != null)
                stats.MostPopularBook = $"{mostPopular.Key} ({mostPopular.Count()} rentals)";

            // Populate the Top 5 for the chart
            stats.Top5Books = bookGroups.Take(5).ToDictionary(g => g.Key, g => g.Count());

            var busiestDay = history.GroupBy(h => h.RentDate.Date).OrderByDescending(g => g.Count()).FirstOrDefault();
            if (busiestDay != null)
                stats.BusiestRentalDay = $"{busiestDay.Key.ToShortDateString()} ({busiestDay.Count()} rentals)";

            return stats;
        }
    }
}