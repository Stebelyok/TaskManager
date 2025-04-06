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
using TaskManager.ViewModels;

namespace TaskManager.Commands
{
    public class CreateTaskCommand : AsyncCommandBase
    {
        private readonly CreateTaskViewModel _createTaskViewModel;
        private readonly IRenavigator _renavigator;
        private readonly ITodoTaskService _todoTaskService;

        public CreateTaskCommand(CreateTaskViewModel createTaskViewModel, IRenavigator renavigator, ITodoTaskService todoTaskService)
        {
            _createTaskViewModel = createTaskViewModel;
            _renavigator = renavigator;
            _todoTaskService = todoTaskService;

            _createTaskViewModel.PropertyChanged += CreateTaskModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _createTaskViewModel.CanCreate && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _createTaskViewModel.ErrorMessage = string.Empty;

            try
            {
                CreateTodoTaskDto dto = new CreateTodoTaskDto()
                {
                    Description = _createTaskViewModel.Description,
                    Title = _createTaskViewModel.Title,
                };

                var validator = new CreateTaskValidator();
                var result = await validator.ValidateAsync(dto);

                if (!result.IsValid)
                {
                    string message = string.Join("\n", result.Errors);
                    throw new ValidationException(message);
                }

                await _todoTaskService.CreateAsync(_createTaskViewModel.CurrentAccount.Id, dto);

                _renavigator.Renavigate();
            }
            catch (Exception ex)
            {
                _createTaskViewModel.ErrorMessage = ex.Message;
            }
        }

        private void CreateTaskModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
