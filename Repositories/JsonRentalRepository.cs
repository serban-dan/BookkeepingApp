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

        private readonly string _historyFile = "history.json";
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

            return JsonSerializer.Deserialize<List<Rental>>(json, _jsonOptions) ?? new List<Rental>();
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

            await UpdateBookQuantityAsync(rental.BookId, -1);
        }

        private async Task UpdateBookQuantityAsync(string bookId, int quantityChange)
        {
            if (!File.Exists(_booksFile)) return;

            string json = await File.ReadAllTextAsync(_booksFile);
            if (string.IsNullOrWhiteSpace(json)) return;

            var books = JsonSerializer.Deserialize<List<Book>>(json, _jsonOptions);
            var book = books?.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                // Rent Testing Overflow check: prevent dropping below 0
                if (book.AvailableCopies + quantityChange < 0)
                {
                    throw new InvalidOperationException("Cannot rent this book. 0 copies available.");
                }

                book.AvailableCopies += quantityChange;
                await File.WriteAllTextAsync(_booksFile, JsonSerializer.Serialize(books, _jsonOptions));
            }
        }

        public async Task<decimal> ReturnBookAsync(string rentalId)
        {
            if (!File.Exists(_rentalsFile)) return 0m;

            string json = await File.ReadAllTextAsync(_rentalsFile);
            var rentals = JsonSerializer.Deserialize<List<Rental>>(json, _jsonOptions) ?? new List<Rental>();

            var rental = rentals.FirstOrDefault(r => r.RentalId == rentalId);
            if (rental == null) return 0m;

            // 1. Calculate Fee
            decimal fee = _feeService.CalculateFee(rental.DueDate, DateTime.Now);

            // 2. Remove from active rentals and save rentals.json
            rentals.Remove(rental);
            await File.WriteAllTextAsync(_rentalsFile, JsonSerializer.Serialize(rentals, _jsonOptions));

            // 3. Update Book Quantity and grab the Book Title for the history log
            string bookTitle = "Unknown Book";
            if (File.Exists(_booksFile))
            {
                string bookJson = await File.ReadAllTextAsync(_booksFile);
                var books = JsonSerializer.Deserialize<List<Book>>(bookJson, _jsonOptions);
                var book = books?.FirstOrDefault(b => b.Id == rental.BookId);

                if (book != null)
                {
                    bookTitle = book.Title;
                    book.AvailableCopies += 1; // Add the copy back to inventory
                    await File.WriteAllTextAsync(_booksFile, JsonSerializer.Serialize(books, _jsonOptions));
                }
            }

            // 4. Archive into history.json
            var historyList = new List<RentalHistory>();
            if (File.Exists(_historyFile))
            {
                string histJson = await File.ReadAllTextAsync(_historyFile);
                if (!string.IsNullOrWhiteSpace(histJson))
                {
                    historyList = JsonSerializer.Deserialize<List<RentalHistory>>(histJson, _jsonOptions) ?? new List<RentalHistory>();
                }
            }

            historyList.Add(new RentalHistory
            {
                HistoryId = Guid.NewGuid().ToString(),
                RentalId = rental.RentalId,
                BookId = rental.BookId,
                BookTitle = bookTitle,
                CustomerName = rental.CustomerName,
                RentDate = rental.RentDate,
                DueDate = rental.DueDate,
                ReturnedDate = DateTime.Now,
                FeeCollected = fee
            });

            await File.WriteAllTextAsync(_historyFile, JsonSerializer.Serialize(historyList, _jsonOptions));

            return fee;
        }
    }
}