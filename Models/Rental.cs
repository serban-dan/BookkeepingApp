using System;

namespace BookkeepingApp.Models
{
    public class Rental
    {
        public string RentalId { get; set; } = Guid.NewGuid().ToString();
        public string BookId { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; } = false;
    }
}