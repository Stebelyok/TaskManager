using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private User _currentAccount;
        public User CurrentAccount { 
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            } 
        }

        public event Action StateChanged;
    }
}
