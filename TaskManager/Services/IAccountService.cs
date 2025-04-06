using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IAccountService
    {
        Task<User> LoginAsync(LoginDto loginDto);
        Task<User> RegisterAsync(RegisterDto registerDto);
    }
}
