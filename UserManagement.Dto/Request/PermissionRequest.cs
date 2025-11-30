using System.ComponentModel.DataAnnotations;

namespace UserManagement.Dto.Request
{
    public class PermissionRequest
    {
        [Required]
        [MaxLength(100)]
        public required string PermissionName { get; set; }
    }
}
