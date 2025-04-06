using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;
using TaskManager.Dtos.Validations;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;
using TaskManager.State.Sidebar;
using TaskManager.ViewModels;

namespace TaskManager.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        private readonly ISidebarVisible _sidebarVisible;

        public LoginCommand(LoginViewModel loginViewModel,
                            IAuthenticator authenticator,
                            IRenavigator renavigator,
                            ISidebarVisible sidebarVisible)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
            _sidebarVisible = sidebarVisible;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                LoginDto dto = new LoginDto()
                {
                    Email = _loginViewModel.Email,
                    Password = _loginViewModel.Password
                };

                var validator = new LoginValidator();
                var result = await validator.ValidateAsync(dto);

                if (!result.IsValid)
                {
                    string message = string.Join("\n", result.Errors);
                    throw new ValidationException(message);
                }

                await _authenticator.Login(dto);

                _renavigator.Renavigate();

                _sidebarVisible.UpdateSidebarVisability(true);
            }
            catch (Exception ex)
            {
                _loginViewModel.ErrorMessage = ex.Message;
            }
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
