using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TaskManager.Services;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;
using TaskManager.State.Sidebar;
using TaskManager.ViewModels;
using TaskManager.ViewModels.Factories;

namespace TaskManager.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<HomeViewModel>();
                services.AddTransient<MainViewModel>();
                services.AddTransient<CreateTaskViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => CreateHomeViewModel(services));
                services.AddSingleton<CreateViewModel<CreateTaskViewModel>>(services => () => CreateTaskViewModel(services));
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));

                services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<CreateTaskViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            });

            return host;
        }

        private static CreateTaskViewModel CreateTaskViewModel(IServiceProvider services)
        {
            return new CreateTaskViewModel(
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ITodoTaskService>(),
                services.GetRequiredService<IAuthenticator>());
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                services.GetRequiredService<ViewModelDelegateRenavigator<CreateTaskViewModel>>(),
                services.GetRequiredService<ITodoTaskService>(),
                services.GetRequiredService<IAuthenticator>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>(),
                services.GetRequiredService<ISidebarVisible>());
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ISidebarVisible>());
        }
    }
}
