using System.ComponentModel.DataAnnotations;

namespace UserManagement.Dto.Request
{
    public class RoleRequest
    {
        [Required]
        [MaxLength(100)]
        public required string RoleName { get; set; }
    }
}
