using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dtos;
using TaskManager.Dtos.Validations;
using TaskManager.Services;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;
using TaskManager.State.Sidebar;
using TaskManager.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;
        private readonly ISidebarVisible _sidebarVisible;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator, ISidebarVisible sidebarVisible)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;
            _sidebarVisible = sidebarVisible;

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                RegisterDto dto = new RegisterDto()
                {
                    Email = _registerViewModel.Email,
                    Name = _registerViewModel.Name,
                    Password = _registerViewModel.Password
                };

                var validator = new RegisterValidator();
                var result = await validator.ValidateAsync(dto);

                if (!result.IsValid)
                {
                    string message = string.Join("\n", result.Errors);
                    throw new ValidationException(message);
                }

                await _authenticator.Register(dto);

                _sidebarVisible.UpdateSidebarVisability(true);

                _registerRenavigator.Renavigate();
            }
            catch (Exception ex)
            {
                _registerViewModel.ErrorMessage = ex.Message;
            }
        }

        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
