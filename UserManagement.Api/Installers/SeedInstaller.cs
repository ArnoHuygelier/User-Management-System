using UserManagement.Repository;

namespace UserManagement.Api.Installers
{
    public static class SeedInstaller
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<UserManagementDbContext>();

            if (dbContext is null)
            {
                throw new InvalidOperationException("Failed to retrieve UserManagementDbContext from service provider.");
            }
            else
            {
                await SeedData.SeedDataAsync(dbContext);
            }
        }
    }
}
