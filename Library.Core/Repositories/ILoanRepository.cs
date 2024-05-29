using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int id);
        Task<List<Loan>> GetByBookIdAsync(int bookId);
        Task<List<Loan>> GetAllAsyncWithUserandBook();
        Task<Loan?> GetActiveByBookId(int bookId);
        Task<List<Loan>> GetByUserIdAsync(int userId);
        Task<List<Loan>> GetActivesByUserId(int userId);
        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
    }
}
