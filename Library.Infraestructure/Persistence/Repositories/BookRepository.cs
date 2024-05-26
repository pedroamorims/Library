using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infraestructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book); 
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Book>> GetAllAsync()
            => await _dbContext.Books.ToListAsync();
        public async Task<Book?> GetByIdAsync(int id) 
            => await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == id);
        public async Task<Book?> GetByNameAsync(string name)
            => await _dbContext.Books.SingleOrDefaultAsync(book => book.Title == name);
        public async Task UpdateAsync(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
