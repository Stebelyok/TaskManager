using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = "Host=localhost;Port=5432;Database=TaskManagerDb;Username=postgres;Password=491264224";
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseNpgsql(connectionString);

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(connectionString), ServiceLifetime.Singleton);
            });

            return host;
        }
    }
}
