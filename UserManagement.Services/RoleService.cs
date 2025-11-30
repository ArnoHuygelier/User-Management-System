using UserManagement.Dto.Request;
using UserManagement.Dto.Result;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.Services.extensions;
using UserManagement.Services.Models;
using UserManagement.Services.Models.Extensions;

namespace UserManagement.Services
{
    public class RoleService(UserManagementDbContext dbContext)
    {
        //Get
        public async Task<ServiceResult<RoleResult>> Get(int id)
        {
            var role = await dbContext.Roles.FindAsync(id);

            if (role == null)
            {
                return new ServiceResult<RoleResult>().IdNotFound(id.ToString());
            }

            return new ServiceResult<RoleResult>
            {
                Data = role.ToRoleResult()
            };
        }

        //Find
        public async Task<ServiceResult<List<RoleResult>>> Find()
        {
            var roles = await dbContext.Roles.ToRoleResultListAsync();

            if (roles.Count == 0)
            {
                return new ServiceResult<List<RoleResult>>().NoRecordsFound();
            }

            return new ServiceResult<List<RoleResult>>
            {
                Data = roles
            };
        }

        //Create
        public async Task<ServiceResult<RoleResult>> Create(RoleRequest request)
        {
            var role = new Role()
            {
                RoleName = request.RoleName
            };

            try
            {
                dbContext.Roles.Add(role);
                await dbContext.SaveChangesAsync();

                var createdRole = await Get(role.RoleId);

                return createdRole;
            }
            catch (Exception)
            {
                return new ServiceResult<RoleResult>().CreateFailed();
            }
        }

        //Update
        public async Task<ServiceResult<RoleResult>> Update(int id, RoleRequest request)
        {
            var role = await dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return new ServiceResult<RoleResult>().IdNotFound(id.ToString());
            }

            role.RoleName = request.RoleName;

            try
            {
                dbContext.Roles.Update(role);
                await dbContext.SaveChangesAsync();

                var updatedRole = await Get(role.RoleId);

                return updatedRole;
            }
            catch (Exception)
            {
                return new ServiceResult<RoleResult>().UpdateFailed();
            }
        }

        //Delete
        public async Task<ServiceResult<bool>> Delete(int id)
        {
            var role = await dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return new ServiceResult<bool>().AlreadyRemoved();
            }

            try
            {
                dbContext.Roles.Remove(role);
                await dbContext.SaveChangesAsync();

                return new ServiceResult<bool>
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
