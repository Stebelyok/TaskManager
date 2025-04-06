using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;

namespace TaskManager.ViewModels
{
    public class CreateTaskViewModel : BaseViewModel
    {
        private string _title;
        private string _description;

        private readonly IAuthenticator _authenticator;

        public string Title
        {
            get => _title;
            set {
                _title = value;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CanCreate));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
                OnPropertyChanged(nameof(CanCreate));
            }
        }

        public User CurrentAccount => _authenticator.CurrentAccount;

        public bool CanCreate => true;

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand CreateTaskCommand { get; }

        public CreateTaskViewModel(IRenavigator homeRenavigator, ITodoTaskService todoTaskService, IAuthenticator authenticator)
        {
            _authenticator = authenticator;

            ErrorMessageViewModel = new MessageViewModel();

            CreateTaskCommand = new CreateTaskCommand(this, homeRenavigator, todoTaskService);
        }
    }
}
