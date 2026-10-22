using System.Collections.Generic;

namespace BookkeepingApp.Models
{
    public class StoreStatistics
    {
        public int TotalAllTimeRentals { get; set; }
        public decimal TotalLateFeesCollected { get; set; }
        public string MostPopularBook { get; set; }
        public string BusiestRentalDay { get; set; }

        // New dictionary to power the Bar Chart (Book Title -> Number of Rentals)
        public Dictionary<string, int> Top5Books { get; set; } = new Dictionary<string, int>();
    }
}