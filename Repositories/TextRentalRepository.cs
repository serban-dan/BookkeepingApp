using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookkeepingApp.Interfaces;
using BookkeepingApp.Models;

namespace BookkeepingApp.Repositories
{
    public class TextRentalRepository : IRentalRepository
    {
        private readonly string _rentalsFile = "rentals.txt";
        private readonly string _booksFile = "books.txt";
        private readonly IFeeService _feeService;

        public TextRentalRepository(IFeeService feeService)
        {
            _feeService = feeService;
        }

        public async Task<List<Rental>> GetActiveRentalsAsync()
        {
            var rentals = new List<Rental>();

            if (!File.Exists(_rentalsFile))
                return rentals;

            var lines = await File.ReadAllLinesAsync(_rentalsFile);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 6)
                {
                    bool isReturned = bool.Parse(parts[5]);

                    if (!isReturned)
                    {
                        rentals.Add(new Rental
                        {
                            RentalId = parts[0],
                            BookId = parts[1],
                            CustomerName = parts[2],
                            RentDate = DateTime.Parse(parts[3]),
                            DueDate = DateTime.Parse(parts[4]),
                            IsReturned = isReturned
                        });
                    }
                }
            }

            return rentals;
        }

        public async Task RentBookAsync(Rental rental)
        {
            // 1. Save the rental record
            string line = $"{rental.RentalId}|{rental.BookId}|{rental.CustomerName}|{rental.RentDate:O}|{rental.DueDate:O}|{rental.IsReturned}{Environment.NewLine}";
            await File.AppendAllTextAsync(_rentalsFile, line);

            // 2. Mark the book as unavailable in books.txt
            await UpdateBookAvailabilityAsync(rental.BookId, false);
        }

        public async Task<decimal> ReturnBookAsync(string rentalId)
        {
            if (!File.Exists(_rentalsFile)) return 0m;

            var lines = (await File.ReadAllLinesAsync(_rentalsFile)).ToList();
            decimal feeToCharge = 0m;
            string bookId = null;

            // 1. Find the rental, calculate fee, and mark as returned
            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split('|');
                if (parts[0] == rentalId)
                {
                    bookId = parts[1];
                    DateTime dueDate = DateTime.Parse(parts[4]);

                    feeToCharge = _feeService.CalculateFee(dueDate, DateTime.Now);

                    // Rebuild the line with IsReturned = true
                    lines[i] = $"{parts[0]}|{parts[1]}|{parts[2]}|{parts[3]}|{parts[4]}|true";
                    break;
                }
            }

            // 2. Save the updated rentals file
            await File.WriteAllLinesAsync(_rentalsFile, lines);

            // 3. Mark the book as available again
            if (bookId != null)
            {
                await UpdateBookAvailabilityAsync(bookId, true);
            }

            return feeToCharge;
        }

        // Helper method to rewrite books.txt with the updated availability status
        private async Task UpdateBookAvailabilityAsync(string bookId, bool isAvailable)
        {
            if (!File.Exists(_booksFile)) return;

            var lines = (await File.ReadAllLinesAsync(_booksFile)).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split('|');
                if (parts[0] == bookId)
                {
                    lines[i] = $"{parts[0]}|{parts[1]}|{isAvailable}|{parts[3]}";
                    break;
                }
            }

            await File.WriteAllLinesAsync(_booksFile, lines);
        }
    }
}