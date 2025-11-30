namespace UserManagement.Dto.Result
{
    public class UserResult
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
    }
}
