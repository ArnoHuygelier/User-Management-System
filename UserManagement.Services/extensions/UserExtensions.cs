using UserManagement.Dto.Result;
using UserManagement.Models;

namespace UserManagement.Services.extensions
{
    public static class UserExtensions
    {
        public static UserResult ToUserResult(this User user)
        {
            return new UserResult
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public static async Task<List<UserResult>> ToUserResultListAsync(this IQueryable<User> query)
        {
            return query.Select(user => user.ToUserResult()).ToList();
        }
    }
}
