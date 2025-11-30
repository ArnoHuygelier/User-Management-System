
namespace UserManagement.Services.Models
{
    public class ServiceResult<TData> : ServiceResult
    {
        public ServiceResult(TData? data = default)
        {
            Data = data;
        }

        public TData? Data
        {
            get;
            set;
        }
    }
}
