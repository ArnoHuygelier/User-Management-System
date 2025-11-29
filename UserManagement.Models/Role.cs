namespace UserManagement.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }

        // Navigation property to users
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        // Navigation property to permissions
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }

}
