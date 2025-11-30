using UserManagement.Dto.Result;
using UserManagement.Models;

namespace UserManagement.Services.extensions
{
    public static class RoleExtensions
    {
        public static RoleResult ToRoleResult(this Role role)
        {
            return new RoleResult
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };
        }

        public static async Task<List<RoleResult>> ToRoleResultListAsync(this IQueryable<Role> query)
        {
            return query.Select(role => role.ToRoleResult()).ToList();
        }
    }
}
