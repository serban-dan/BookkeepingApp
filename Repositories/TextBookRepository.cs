using BookkeepingApp.Interfaces;
using BookkeepingApp.Models;
using BookkeepingApp.Models.BookkeepingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookkeepingApp.Repositories
{
    public class TextBookRepository : IBookRepository
    {
        private readonly string _booksFile = "books.txt";
        private readonly string _ordersFile = "orders.txt";
        private readonly IFeeService _feeService;

        public TextBookRepository(IFeeService feeService)
        {
            _feeService = feeService;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = new List<Book>();

            if (!File.Exists(_booksFile))
                return books;

            var lines = await File.ReadAllLinesAsync(_booksFile);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 4)
                {
                    books.Add(new Book
                    {
                        Id = parts[0],
                        Title = parts[1],
                        IsAvailable = bool.Parse(parts[2]),
                        CoverImagePath = parts[3]
                    });
                }
            }

            return books;
        }

        public async Task<List<Book>> SearchBooksAsync(string query)
        {
            var allBooks = await GetAllBooksAsync();

            if (string.IsNullOrWhiteSpace(query))
                return allBooks;

            return allBooks
                .Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task AddBookAsync(Book book)
        {
            string line = $"{book.Id}|{book.Title}|{book.IsAvailable}|{book.CoverImagePath}{Environment.NewLine}";
            await File.AppendAllTextAsync(_booksFile, line);
        }

        public async Task<BookOrder> OrderMissingBookAsync(string title)
        {
            int etaDays = _feeService.GetOrderEtaDays();

            var order = new BookOrder
            {
                OrderId = Guid.NewGuid().ToString(),
                BookTitle = title,
                OrderDate = DateTime.Now,
                EstimatedArrival = DateTime.Now.AddDays(etaDays)
            };

            string line = $"{order.OrderId}|{order.BookTitle}|{order.OrderDate:O}|{order.EstimatedArrival:O}{Environment.NewLine}";
            await File.AppendAllTextAsync(_ordersFile, line);

            return order;
        }
    }
}