using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.State.Accounts
{
    public interface IAccountStore
    {
        User CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
