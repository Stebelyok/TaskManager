﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModels;
using TaskManager.Views;

namespace TaskManager.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }
    }
}
