using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Infraestructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _dbContext;
        public LoanRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Loan loan)
        {
            await _dbContext.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Loan?> GetActiveByBookId(int bookId)
            => await _dbContext.Loans.SingleOrDefaultAsync(l => l.IdBook == bookId && l.Active == true);

        public async Task<List<Loan>> GetActivesByUserId(int userId)
            => await _dbContext.Loans.Where(l => l.IdUser == userId && l.Active == true).ToListAsync();

        public async Task<List<Loan>> GetAllAsync()
            => await _dbContext.Loans.ToListAsync();

        public async Task<List<Loan>> GetByBookIdAsync(int bookId)
            => await _dbContext.Loans.Where(l => l.IdBook == bookId).ToListAsync();

        public async Task<List<Loan>> GetByUserIdAsync(int userId)
             => await _dbContext.Loans.Where(l => l.IdUser == userId).ToListAsync();

        public async Task<Loan?> GetByIdAsync(int id)
            => await _dbContext.Loans.SingleOrDefaultAsync(l => l.Id == id);

        public async Task Update(Loan loan)
        {
            _dbContext.Entry(loan).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
