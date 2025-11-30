using UserManagement.Dto.Result;
using UserManagement.Models;

namespace UserManagement.Services.extensions
{
    public static class PermissionExtensions
    {
        public static PermissionResult ToPermissionResult(this Permission permission)
        {
            return new PermissionResult
            {
                PermissionId = permission.PermissionId,
                PermissionName = permission.PermissionName
            };
        }

        public static async Task<List<PermissionResult>> ToPermissionResultListAsync(this IQueryable<Permission> query)
        {
            return query.Select(permission => permission.ToPermissionResult()).ToList();
        }
    }
}
