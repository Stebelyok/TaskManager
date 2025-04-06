using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task Register(RegisterDto registerDto);
        Task Login(LoginDto loginDto);
        void Logout();
    }
}
