using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infraestructure.Persistence.Repositories
{
    public class WaitListRepository : IWaitListRepository
    {
        private readonly LibraryDbContext _dbContext;
        public WaitListRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(WaitList waitList)
        {
            await _dbContext.AddAsync(waitList);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<WaitList>> GetAllAsync()
          => await _dbContext.WaitLists.ToListAsync();

        public async Task<List<WaitList>> GetAllByBookAsync(int bookId)
          => await _dbContext.WaitLists.Where(w => w.IdBook == bookId).ToListAsync();

        public async Task<List<WaitList>> GetAllByUserAsync(int userId)
          => await _dbContext.WaitLists.Where(w => w.IdUser == userId).ToListAsync();

        public async Task<WaitList?> GetByUserandBookAsync(int userId, int bookId)
          => await _dbContext.WaitLists.SingleOrDefaultAsync(w => w.IdUser == userId && w.IdBook == bookId);

        public async Task<WaitList?> GetActiveByUserandBookAsync(int userId, int bookId)
         => await _dbContext.WaitLists.SingleOrDefaultAsync(w => w.IdUser == userId && w.IdBook == bookId && w.Active == true);
        public async Task UpdateAsync(WaitList waitList)
        {
            _dbContext.Entry(waitList).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
