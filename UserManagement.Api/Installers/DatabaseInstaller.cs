using Microsoft.EntityFrameworkCore;
using UserManagement.Repository;

namespace UserManagement.Api.Installers
{
    public static class DatabaseInstaller
    {
        public static async Task InstallDatabaseAsync(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString(nameof(UserManagementDbContext));

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string for UserManagementDbContext is not configured.");
            }

            builder.Services.AddDbContext<UserManagementDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
