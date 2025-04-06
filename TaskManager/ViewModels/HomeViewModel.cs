using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Dtos;
using TaskManager.Services;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;

namespace TaskManager.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ITodoTaskService _todoTaskService;
        private readonly IAuthenticator _authenticator;

        private ObservableCollection<TodoTaskDto> _tasks;
        public ObservableCollection<TodoTaskDto> Tasks
        {
            get => _tasks;
            private set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand ViewCreateTaskCommand { get; }
        public ICommand CompleteTaskCommand { get; }

        public HomeViewModel(IRenavigator viewCreateTaskCommand, ITodoTaskService todoTaskService, IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            _todoTaskService = todoTaskService;

            ErrorMessageViewModel = new MessageViewModel();
            CompleteTaskCommand = new CompleteTaskCommand(this, todoTaskService);
            Tasks = new ObservableCollection<TodoTaskDto>();
            ViewCreateTaskCommand = new RenavigateCommand(viewCreateTaskCommand);

            LoadTasksAsync().ConfigureAwait(false);
        }

        private async Task LoadTasksAsync()
        {
            try
            {
                var tasks = await _todoTaskService.GetAllByUserAsync(_authenticator.CurrentAccount.Id);

                foreach (var task in tasks)
                {
                    Tasks.Add(task);
                }
            } 
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
