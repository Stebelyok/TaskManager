using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
    }
}
