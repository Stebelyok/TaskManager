using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.State.Accounts;
using TaskManager.State.Authenticators;
using TaskManager.State.Navigators;
using TaskManager.State.Sidebar;

namespace TaskManager.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
                services.AddSingleton<ISidebarVisible,  SidebarVisible>();
            });

            return host;
        }
    }
}
