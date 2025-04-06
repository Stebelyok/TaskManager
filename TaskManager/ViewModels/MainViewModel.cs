using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TaskManager.Commands;
using TaskManager.Models;
using TaskManager.State.Accounts;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;
using TaskManager.State.Sidebar;
using TaskManager.ViewModels.Factories;
using TaskManager.Views;
using static TaskManager.State.Navigators.INavigator;

namespace TaskManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        private readonly ISidebarVisible _sidebarVisible;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public bool IsSidebarVisible => _sidebarVisible.IsSidebarVisible;
        public User CurrentAccount => _authenticator.CurrentAccount;
        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator, ISidebarVisible sidebarVisible)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _sidebarVisible = sidebarVisible;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;
            _sidebarVisible.StateChanged += SidebarVisible_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);

            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void SidebarVisible_StateChanged()
        {
            OnPropertyChanged(nameof(IsSidebarVisible));
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(CurrentAccount));
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;
            _authenticator.StateChanged -= Authenticator_StateChanged;
            _sidebarVisible.StateChanged -= SidebarVisible_StateChanged;

            base.Dispose();
        }
    }
}
