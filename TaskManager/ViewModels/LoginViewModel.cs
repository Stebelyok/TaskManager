using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;
using TaskManager.State.Sidebar;

namespace TaskManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        public bool CanLogin => !string.IsNullOrEmpty(Email) && 
            !string.IsNullOrEmpty(Password);

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator, ISidebarVisible sidebarVisible)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator, sidebarVisible);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}
