﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IUserRepository, UserRepository>();
                services.AddSingleton<ITodoTaskRepository, TodoTaskRepository>();

                services.AddSingleton<IAccountService, AccountService>();
                services.AddSingleton<IUserService, UserService>();
                services.AddSingleton<ITodoTaskService, TodoTaskService>();
                services.AddSingleton<IUserExportService, UserExportService>();
            });

            return host;
        }
    }
}
