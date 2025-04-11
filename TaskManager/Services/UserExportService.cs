using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserExportService : IUserExportService
    {
        public async Task ExportUserToJsonStringAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(currentDir, "user.json");

            string json = JsonSerializer.Serialize(user);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task<User> ReadUserFromJsonStringAsync()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user.json");

            if (!File.Exists(filePath))
                return null;

            await using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<User>(stream);
        }
    }
}
