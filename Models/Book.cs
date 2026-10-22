using System;

namespace BookkeepingApp.Models
{
    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }

        // New quantity tracking
        public int TotalCopies { get; set; } = 1;
        public int AvailableCopies { get; set; } = 1;

        // This calculates itself automatically now
        public bool IsAvailable => AvailableCopies > 0;

        public string CoverImagePath { get; set; }
    }
}