﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITodoTaskRepository : ICrudRepository<TodoTask>
    {
        Task<bool> ExistByIdAsync(long id);
    }
}
