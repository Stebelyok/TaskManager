using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private IUserExportService _userExportService;

        public AccountStore(IUserExportService userExportService)
        {
            _userExportService = userExportService;
        }

        private User _currentAccount;
        public User CurrentAccount { 
            get
            {
                if (_currentAccount != null)
                {
                    return _currentAccount;
                }

                var task = Task.Run(async () => await _userExportService.ReadUserFromJsonStringAsync());
                return task.Result;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            } 
        }

        public event Action StateChanged;
    }
}
