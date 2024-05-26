using Library.Core.Entities;

namespace Library.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> GetByNameAsync(string name);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
    }
}
