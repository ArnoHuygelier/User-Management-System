using UserManagement.Dto.Request;
using UserManagement.Dto.Result;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.Services.extensions;
using UserManagement.Services.Models;
using UserManagement.Services.Models.Extensions;

namespace UserManagement.Services
{
    public class UserService(UserManagementDbContext dbContext)
    {
        //Get
        public async Task<ServiceResult<UserResult>> Get(int id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return new ServiceResult<UserResult>().IdNotFound(id.ToString());
            }

            return new ServiceResult<UserResult>
            {
                Data = user.ToUserResult()
            };
        }

        //Find
        public async Task<ServiceResult<List<UserResult>>> Find()
        {
            var users = await dbContext.Users.ToUserResultListAsync();

            if (users.Count == 0)
            {
                return new ServiceResult<List<UserResult>>().NoRecordsFound();
            }

            return new ServiceResult<List<UserResult>>
            {
                Data = users
            };
        }

        //Create
        public async Task<ServiceResult<UserResult>> Create(UserRequest request)
        {
            var user = new User()
            {
                UserName = request.UserName,
                Email = request.Email
            };

            try
            {
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();

                var createdUser = await Get(user.UserId);

                return createdUser;
            }
            catch (Exception)
            {
                return new ServiceResult<UserResult>().CreateFailed();
            }
        }

        //Update
        public async Task<ServiceResult<UserResult>> Update(int id, UserRequest request)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return new ServiceResult<UserResult>().IdNotFound(id.ToString());
            }

            user.UserName = request.UserName;
            user.Email = request.Email;

            try
            {
                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();

                var updatedUser = await Get(user.UserId);

                return updatedUser;
            }
            catch (Exception)
            {
                return new ServiceResult<UserResult>().UpdateFailed();
            }
        }

        //Delete
        public async Task<ServiceResult<bool>> Delete(int id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return new ServiceResult<bool>().AlreadyRemoved();
            }

            try
            {
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();

                return new ServiceResult<bool>()
                {
                    Data = true
                };
            }
            catch (Exception)
            {
                return new ServiceResult<bool>().DeleteFailed();
            }
        }
    }
}
