using BookkeepingApp.Interfaces;
using BookkeepingApp.Models;
using BookkeepingApp.Models.BookkeepingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookkeepingApp.Repositories
{
    public class JsonBookRepository : IBookRepository
    {
        private readonly string _booksFile = "books.json";
        private readonly string _ordersFile = "orders.json";
        private readonly IFeeService _feeService;
        private readonly JsonSerializerOptions _jsonOptions;

        public JsonBookRepository(IFeeService feeService)
        {
            _feeService = feeService;
            // WriteIndented makes the JSON file human-readable with line breaks
            _jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            if (!File.Exists(_booksFile)) return new List<Book>();

            string json = await File.ReadAllTextAsync(_booksFile);
            if (string.IsNullOrWhiteSpace(json)) return new List<Book>();

            return JsonSerializer.Deserialize<List<Book>>(json, _jsonOptions) ?? new List<Book>();
        }

        public async Task<List<Book>> SearchBooksAsync(string query)
        {
            var allBooks = await GetAllBooksAsync();
            if (string.IsNullOrWhiteSpace(query)) return allBooks;

            return allBooks.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public async Task AddBookAsync(Book book)
        {
            var books = await GetAllBooksAsync();

            // Maintain the sequential ID generation logic for standalone mode
            int maxId = 1000;
            if (books.Any())
            {
                maxId = books.Max(b => int.TryParse(b.Id, out int id) ? id : 1000);
            }
            book.Id = (maxId + 1).ToString();

            books.Add(book);

            string json = JsonSerializer.Serialize(books, _jsonOptions);
            await File.WriteAllTextAsync(_booksFile, json);
        }

        public async Task<BookOrder> OrderMissingBookAsync(string title)
        {
            var orders = new List<BookOrder>();
            if (File.Exists(_ordersFile))
            {
                string existingJson = await File.ReadAllTextAsync(_ordersFile);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    orders = JsonSerializer.Deserialize<List<BookOrder>>(existingJson, _jsonOptions) ?? new List<BookOrder>();
                }
            }

            var order = new BookOrder
            {
                OrderId = Guid.NewGuid().ToString(),
                BookTitle = title,
                OrderDate = DateTime.Now,
                EstimatedArrival = DateTime.Now.AddDays(_feeService.GetOrderEtaDays())
            };

            orders.Add(order);
            await File.WriteAllTextAsync(_ordersFile, JsonSerializer.Serialize(orders, _jsonOptions));

            return order;
        }
    }
}