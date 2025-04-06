using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Dtos;
using TaskManager.Services;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;
using TaskManager.State.Sidebar;
using TaskManager.Views;

namespace TaskManager.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _name;
        private string _email;
        private string _password;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(Name) &&
            !string.IsNullOrEmpty(Password);

        public MessageViewModel ErrorMessageViewModel { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ViewLoginCommand { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public RegisterViewModel(IAuthenticator authenticator,
                                 IRenavigator registerRenavigator,
                                 IRenavigator loginRenavigator,
                                 ISidebarVisible sidebarVisible)
        {
            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator, sidebarVisible);
            ViewLoginCommand = new RenavigateCommand(loginRenavigator);
        }
    }
}
