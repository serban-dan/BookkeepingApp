using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookkeepingApp.Interfaces;
using BookkeepingApp.Models;

namespace BookkeepingApp.Repositories
{
    public class JsonRentalRepository : IRentalRepository
    {
        private readonly string _rentalsFile = "rentals.json";
        private readonly string _booksFile = "books.json";
        private readonly IFeeService _feeService;
        private readonly JsonSerializerOptions _jsonOptions;

        public JsonRentalRepository(IFeeService feeService)
        {
            _feeService = feeService;
            _jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        }

        public async Task<List<Rental>> GetActiveRentalsAsync()
        {
            if (!File.Exists(_rentalsFile)) return new List<Rental>();

            string json = await File.ReadAllTextAsync(_rentalsFile);
            if (string.IsNullOrWhiteSpace(json)) return new List<Rental>();

            var allRentals = JsonSerializer.Deserialize<List<Rental>>(json, _jsonOptions) ?? new List<Rental>();

            // Only return rentals that have not been returned yet
            return allRentals.Where(r => !r.IsReturned).ToList();
        }

        public async Task RentBookAsync(Rental rental)
        {
            var rentals = new List<Rental>();
            if (File.Exists(_rentalsFile))
            {
                string json = await File.ReadAllTextAsync(_rentalsFile);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    rentals = JsonSerializer.Deserialize<List<Rental>>(json, _jsonOptions) ?? new List<Rental>();
                }
            }

            rentals.Add(rental);
            await File.WriteAllTextAsync(_rentalsFile, JsonSerializer.Serialize(rentals, _jsonOptions));

            await UpdateBookAvailabilityAsync(rental.BookId, false);
        }

        public async Task<decimal> ReturnBookAsync(string rentalId)
        {
            if (!File.Exists(_rentalsFile)) return 0m;

            string json = await File.ReadAllTextAsync(_rentalsFile);
            var rentals = JsonSerializer.Deserialize<List<Rental>>(json, _jsonOptions) ?? new List<Rental>();

            var rental = rentals.FirstOrDefault(r => r.RentalId == rentalId);
            if (rental == null) return 0m;

            rental.IsReturned = true;
            decimal fee = _feeService.CalculateFee(rental.DueDate, DateTime.Now);

            await File.WriteAllTextAsync(_rentalsFile, JsonSerializer.Serialize(rentals, _jsonOptions));
            await UpdateBookAvailabilityAsync(rental.BookId, true);

            return fee;
        }

        private async Task UpdateBookAvailabilityAsync(string bookId, bool isAvailable)
        {
            if (!File.Exists(_booksFile)) return;

            string json = await File.ReadAllTextAsync(_booksFile);
            if (string.IsNullOrWhiteSpace(json)) return;

            var books = JsonSerializer.Deserialize<List<Book>>(json, _jsonOptions);
            var book = books?.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                book.IsAvailable = isAvailable;
                await File.WriteAllTextAsync(_booksFile, JsonSerializer.Serialize(books, _jsonOptions));
            }
        }
    }
}