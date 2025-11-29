namespace UserManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }


        // Navigation property to roles
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
