using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.State.Navigators;
using static TaskManager.State.Navigators.INavigator;

namespace TaskManager.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public ViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
                                CreateViewModel<RegisterViewModel> createRegisterViewModel,
                                CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createRegisterViewModel = createRegisterViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Register:
                    return _createRegisterViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
