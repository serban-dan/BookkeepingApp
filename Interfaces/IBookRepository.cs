using BookkeepingApp.Models;
using BookkeepingApp.Models.BookkeepingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookkeepingApp.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> SearchBooksAsync(string query);
        Task AddBookAsync(Book book);
        Task<BookOrder> OrderMissingBookAsync(string title);

        // New methods for duplicate checking and quantity management
        Task<Book> GetBookByTitleAsync(string title);
        Task AddCopiesAsync(string bookId, int copiesToAdd);
    }
}