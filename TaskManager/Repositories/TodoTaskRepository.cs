using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TodoTaskRepository : CrudRepository<TodoTask>, ITodoTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoTaskRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistByIdAsync(long id)
        {
            return await _context.TodoTasks.AnyAsync(x => x.Id == id);
        }

        public async Task<List<TodoTask>> GetAllByUserIdAsync(long userId)
        {
            return await _context.TodoTasks.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
