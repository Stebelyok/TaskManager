using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new EntityNotFoundException(string.Format(ExceptionMessages.USER_NOT_FOUND, id));
            }

            return user;
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }
    }
}
