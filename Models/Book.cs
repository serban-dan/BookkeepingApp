using System;
using System.Collections.Generic;
using System.Text;

namespace BookkeepingApp.Models
{
    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public bool IsAvailable { get; set; } = true;

        // Required for the Team Project feature (Local Media Storage)
        public string CoverImagePath { get; set; }
    }
}