namespace UserManagement.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public required string PermissionName { get; set; }

        // Navigation property to roles
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }

}
