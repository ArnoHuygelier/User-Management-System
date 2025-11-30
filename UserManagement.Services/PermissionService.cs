using UserManagement.Dto.Request;
using UserManagement.Dto.Result;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.Services.extensions;
using UserManagement.Services.Models;
using UserManagement.Services.Models.Extensions;

namespace UserManagement.Services
{
    public class PermissionService(UserManagementDbContext dbContext)
    {
        //Get
        public async Task<ServiceResult<PermissionResult>> Get(int id)
        {
            var permission = await dbContext.Permissions.FindAsync(id);

            if (permission == null)
            {
                return new ServiceResult<PermissionResult>().IdNotFound(id.ToString());
            }

            return new ServiceResult<PermissionResult>
            {
                Data = permission.ToPermissionResult()
            };
        }

        //Find
        public async Task<ServiceResult<List<PermissionResult>>> Find()
        {
            var permissions = await dbContext.Permissions.ToPermissionResultListAsync();

            if (permissions.Count == 0)
            {
                return new ServiceResult<List<PermissionResult>>().NoRecordsFound();
            }

            return new ServiceResult<List<PermissionResult>>
            {
                Data = permissions
            };
        }

        //Create
        public async Task<ServiceResult<PermissionResult>> Create(PermissionRequest request)
        {
            var permission = new Permission()
            {
                PermissionName = request.PermissionName
            };

            try
            {
                dbContext.Permissions.Add(permission);
                await dbContext.SaveChangesAsync();

                var createdPermission = await Get(permission.PermissionId);

                return createdPermission;
            }
            catch (Exception)
            {
                return new ServiceResult<PermissionResult>().CreateFailed();
            }
        }

        //Update
        public async Task<ServiceResult<PermissionResult>> Update(int id, PermissionRequest request)
        {
            var permission = await dbContext.Permissions.FindAsync(id);

            if (permission == null)
            {
                return new ServiceResult<PermissionResult>().IdNotFound(id.ToString());
            }

            permission.PermissionName = request.PermissionName;

            try
            {
                dbContext.Permissions.Update(permission);
                await dbContext.SaveChangesAsync();

                var updatedPermission = await Get(permission.PermissionId);

                return updatedPermission;
            }
            catch (Exception)
            {
                return new ServiceResult<PermissionResult>().UpdateFailed();
            }
        }

        //Delete
        public async Task<ServiceResult<bool>> Delete(int id)
        {
            var permission = await dbContext.Permissions.FindAsync(id);

            if (permission == null)
            {
                return new ServiceResult<bool>().IdNotFound(id.ToString());
            }

            try
            {
                dbContext.Permissions.Remove(permission);
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
