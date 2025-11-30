using UserManagement.Services;

namespace UserManagement.Api.Installers
{
    public static class ServiceInstaller
    {
        public static void InstallServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<RoleService>();
            builder.Services.AddScoped<PermissionService>();
        }
    }
}
