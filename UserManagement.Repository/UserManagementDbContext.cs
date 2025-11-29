using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });
        }

        public async Task Seed()
        {
            // Add Roles
            var adminRole = new Role { RoleName = "Admin" };
            var managerRole = new Role { RoleName = "Manager" };
            var userRole = new Role { RoleName = "User" };

            await Roles.AddRangeAsync(adminRole, managerRole, userRole);

            // Add Permissions
            var readPermission = new Permission { PermissionName = "Read" };
            var writePermission = new Permission { PermissionName = "Write" };

            await Permissions.AddRangeAsync(readPermission, writePermission);

            // Add some RolePermissions
            await RolePermissions.AddRangeAsync(
                new RolePermission { RoleId = adminRole.RoleId, PermissionId = readPermission.PermissionId },
                new RolePermission { RoleId = adminRole.RoleId, PermissionId = writePermission.PermissionId }
            );
            await SaveChangesAsync();
        }
    }
}
