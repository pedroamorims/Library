using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IWaitListRepository
    {
        Task<List<WaitList>> GetAllAsync();
        Task<List<WaitList>> GetAllActivesnotNotifiedWithUserByBookAsync(int bookId);
        Task<List<WaitList>> GetAllByUserAsync(int bookId);
        Task<WaitList?> GetByUserandBookAsync(int userId, int bookId);
        Task<WaitList?> GetActiveByUserandBookAsync(int userId, int bookId);
        Task AddAsync(WaitList waitList);    
        Task UpdateAsync(WaitList waitList);
        Task<List<WaitList>> GetAllAsyncWithUserandBook();




    }
}
