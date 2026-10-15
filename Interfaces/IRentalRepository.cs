using System.Collections.Generic;
using System.Threading.Tasks;
using BookkeepingApp.Models;

namespace BookkeepingApp.Interfaces
{
    public interface IRentalRepository
    {
        // Creates a new rental record
        Task RentBookAsync(Rental rental);

        // Marks rental as returned and returns the calculated late fee (0 if on time)
        Task<decimal> ReturnBookAsync(string rentalId);

        // Fetches all books currently out on rent
        Task<List<Rental>> GetActiveRentalsAsync();
    }
}