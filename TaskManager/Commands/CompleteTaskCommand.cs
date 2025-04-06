using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager.Commands
{
    public class CompleteTaskCommand : AsyncCommandBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly HomeViewModel _homeViewModel;

        public CompleteTaskCommand(HomeViewModel homeViewModel, ITodoTaskService todoTaskService)
        {
            _homeViewModel = homeViewModel;
            _todoTaskService = todoTaskService;

            _homeViewModel.PropertyChanged += CompleteTaskModel_PropertyChanged;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            _homeViewModel.ErrorMessage = string.Empty;

            try
            {
                if (parameter is long taskId)
                {
                    await _todoTaskService.DeleteAsync(taskId);

                    var taskToRemove = _homeViewModel.Tasks.FirstOrDefault(t => t.Id == taskId);
                    if (taskToRemove != null)
                    {
                        _homeViewModel.Tasks.Remove(taskToRemove);
                    }
                }
            }
            catch (Exception ex)
            {
                _homeViewModel.ErrorMessage = ex.Message;
            }
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        private void CompleteTaskModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
