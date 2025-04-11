using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IUserExportService
    {
        Task ExportUserToJsonStringAsync(User user);
        Task<User> ReadUserFromJsonStringAsync();
    }
}
