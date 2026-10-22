using System;

namespace BookkeepingApp.Models
{
    public class RentalHistory
    {
        public string HistoryId { get; set; } = Guid.NewGuid().ToString();
        public string RentalId { get; set; }
        public string BookId { get; set; }

        // Storing the title directly in history makes generating statistics much faster 
        // since we won't have to look up the book ID every time.
        public string BookTitle { get; set; }

        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public decimal FeeCollected { get; set; }
    }
}