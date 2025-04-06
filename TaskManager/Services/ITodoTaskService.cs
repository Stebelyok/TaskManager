using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;

namespace TaskManager.Services
{
    public interface ITodoTaskService
    {
        Task CreateAsync(long userId, CreateTodoTaskDto createTodoTaskDto);
        Task<List<TodoTaskDto>> GetAllAsync();
        Task<List<TodoTaskDto>> GetAllByUserAsync(long userId);
        Task DeleteAsync(long id);
    }
}
