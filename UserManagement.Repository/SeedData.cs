using UserManagement.Models;

namespace UserManagement.Repository
{
    public static class SeedData
    {
        // Static async method to seed data into the database
        public static async Task SeedDataAsync(UserManagementDbContext context)
        {
            // Add roles if they don't already exist
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { RoleName = "Admin" },
                    new Role { RoleName = "Manager" },
                    new Role { RoleName = "User" }
                );
                await context.SaveChangesAsync();
            }

            // Add permissions if they don't already exist
            if (!context.Permissions.Any())
            {
                context.Permissions.AddRange(
                    new Permission { PermissionName = "FullAccess" },
                    new Permission { PermissionName = "ManageUsers" },
                    new Permission { PermissionName = "ReadOnly" }
                );
                await context.SaveChangesAsync();
            }

            // Add users if they don't already exist
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { UserName = "AdminUser", Email = "admin@example.com" },
                    new User { UserName = "Manager1", Email = "manager1@example.com" },
                    new User { UserName = "Manager2", Email = "manager2@example.com" },
                    new User { UserName = "Manager3", Email = "manager3@example.com" },
                    new User { UserName = "Manager4", Email = "manager4@example.com" },
                    new User { UserName = "User1", Email = "user1@example.com" },
                    new User { UserName = "User2", Email = "user2@example.com" },
                    new User { UserName = "User3", Email = "user3@example.com" },
                    new User { UserName = "User4", Email = "user4@example.com" },
                    new User { UserName = "User5", Email = "user5@example.com" }
                );
                await context.SaveChangesAsync();
            }

            // Add roles to users if roles are not yet assigned
            if (!context.UserRoles.Any())
            {
                context.UserRoles.AddRange(
                    new UserRole { UserId = 1, RoleId = 1 }, // Admin
                    new UserRole { UserId = 2, RoleId = 2 }, // Manager
                    new UserRole { UserId = 3, RoleId = 2 }, // Manager
                    new UserRole { UserId = 4, RoleId = 2 }, // Manager
                    new UserRole { UserId = 5, RoleId = 2 }, // Manager
                    new UserRole { UserId = 6, RoleId = 3 }, // User
                    new UserRole { UserId = 7, RoleId = 3 }, // User
                    new UserRole { UserId = 8, RoleId = 3 }, // User
                    new UserRole { UserId = 9, RoleId = 3 }, // User
                    new UserRole { UserId = 10, RoleId = 3 } // User
                );
                await context.SaveChangesAsync();
            }

            // Add role-permissions if they are not yet assigned (e.g., for Admin role)
            if (!context.RolePermissions.Any())
            {
                context.RolePermissions.AddRange(
                    new RolePermission { RoleId = 1, PermissionId = 1 }, // Admin -> FullAccess
                    new RolePermission { RoleId = 2, PermissionId = 2 }, // Manager -> ManageUsers
                    new RolePermission { RoleId = 3, PermissionId = 3 }  // User -> ReadOnly
                );
                await context.SaveChangesAsync();
            }
        }
    }

}
