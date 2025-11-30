using System.ComponentModel.DataAnnotations;

namespace UserManagement.Dto.Request
{
    public class UserRequest
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Email { get; set; }
    }
}
