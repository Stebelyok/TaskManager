using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using TaskManager.Data;
using TaskManager.Services;
using TaskManager.ViewModels;
using TaskManager.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManager.Repositories;
using TaskManager.Models;
using TaskManager.State.Navigators;
using TaskManager.State.Authenticators;
using TaskManager.ViewModels.Factories;
using TaskManager.HostBuilders;

namespace TaskManager
{
    public partial class App : Application
    {
        public static IHost? _host { get; private set; }
        private static ILogger<App>? _logger;

        public App()
        {
            _host = CreateHostBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .Build();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .AddDbContext()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddViews();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                _host.Start();

                _logger = _host.Services.GetRequiredService<ILogger<App>>();
                _logger.LogInformation("Приложение запущено.");

                Window window = _host.Services.GetRequiredService<MainWindow>();
                window.Show();
                _logger.LogInformation("Главное окно успешно создано.");

                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical(ex, "Ошибка при запуске приложения!");
                MessageBox.Show("Произошла критическая ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _host?.Dispose();
        }

    }
}
