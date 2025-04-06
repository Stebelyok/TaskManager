using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.Utils;

namespace TaskManager.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public AccountService(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<User> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user == null)
            {
                throw new EntityNotFoundException(string.Format(ExceptionMessages.USER_WITH_EMAIL_NOT_FOUND, loginDto.Email));
            }

            if (!PasswordEncoder.Verify(loginDto.Password, user.Password))
            {
                throw new AuthenticationException(ExceptionMessages.PASSWORD_NOT_MATCH);
            }

            return user;
        }

        public async Task<User> RegisterAsync(RegisterDto registerDto)
        {
            if (await _userRepository.ExistByEmailAsync(registerDto.Email))
            {
                throw new EntityExistException(
                    string.Format(ExceptionMessages.USER_EXIST_BY_EMAIL, registerDto.Email));
            }

            string hashedPassword = PasswordEncoder.Encode(registerDto.Password);

            User user = new User();
            user.Name = registerDto.Name;
            user.Email = registerDto.Email;
            user.Password = hashedPassword;

            await _userService.AddUserAsync(user);

            return user;
        }
    }
}
