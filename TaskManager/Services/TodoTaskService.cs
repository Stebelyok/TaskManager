using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private ITodoTaskRepository _todoTaskRepository;

        public TodoTaskService(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public async Task CreateAsync(long userId, CreateTodoTaskDto createTodoTaskDto)
        {
            TodoTask todo = new TodoTask()
            {
                Description = createTodoTaskDto.Description,
                Title = createTodoTaskDto.Title,
                UserId = userId,
            };

            await _todoTaskRepository.AddAsync(todo);
        }

        public async Task<List<TodoTaskDto>> GetAllAsync()
        {
            var tasks = await _todoTaskRepository.GetAllAsync();
            return tasks.Select(item => new TodoTaskDto() {
                Id = item.Id,
                Description = item.Description,
                Title = item.Title
            }).ToList();
        }

        public async Task<List<TodoTaskDto>> GetAllByUserAsync(long userId)
        {
            var tasks = await _todoTaskRepository.GetAllAsync();
            return tasks.Select(item => new TodoTaskDto()
            {
                Id = item.Id,
                Description = item.Description,
                Title = item.Title
            }).ToList();
        }

        public async Task DeleteAsync(long id)
        {
            if (!await _todoTaskRepository.ExistByIdAsync(id))
            {
                throw new EntityNotFoundException(string.Format(ExceptionMessages.TASK_NOT_FOUND, id));
            }
            await _todoTaskRepository.DeleteAsync(id);
        }
    }
}
