using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.State.Accounts;

namespace TaskManager.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAccountService _accountService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAccountService accountService, IAccountStore accountStore)
        {
            _accountService = accountService;
            _accountStore = accountStore;
        }


        public User CurrentAccount 
        { 
            get => _accountStore.CurrentAccount;
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task Login(LoginDto loginDto)
        {
            var user = await _accountService.LoginAsync(loginDto);
            CurrentAccount = user;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task Register(RegisterDto registerDto)
        {
            var user = await _accountService.RegisterAsync(registerDto);
            CurrentAccount = user;
        }
    }
}
