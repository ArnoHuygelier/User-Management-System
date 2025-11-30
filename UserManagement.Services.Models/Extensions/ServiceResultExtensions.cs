namespace UserManagement.Services.Models.Extensions
{
    public static class ServiceResultExtensions
    {
        public static T AlreadyRemoved<T>(this T serviceResult)
            where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "AlreadyRemoved",
                    Description = "Entity was already removed.",
                    Type = ServiceMessageType.Warning
                });

            return serviceResult;
        }

        public static T IdNotFound<T>(this T serviceResult, string id)
        where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "NotFound",
                    Description = $"entity with id: {id} is not found.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }

        public static T NoRecordsFound<T>(this T serviceResult)
            where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "NoRecordsFound",
                    Description = "No records were found matching the specified criteria. Please try again.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }

        public static T CreateFailed<T>(this T serviceResult)
        where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "CreateFailed",
                    Description = "The creation of the requested item failed.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }

        public static T UpdateFailed<T>(this T serviceResult)
        where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "UpdateFailed",
                    Description = "The update of the requested item failed.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }

        public static T DeleteFailed<T>(this T serviceResult)
        where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "DeleteFailed",
                    Description = "The deletion of the requested item failed. Please verify the item exists and try again.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }

        public static T NotFound<T>(this T serviceResult, string entity)
            where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "NotFound",
                    Description = $"{entity} is not found.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }

        public static T Required<T>(this T serviceResult, string propertyName)
            where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "Required",
                    PropertyName = propertyName,
                    Description = $"{propertyName} is required.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }

        public static T NoContent<T>(this T serviceResult)
            where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "NoContent",
                    Description = "There is no content",
                    Type = ServiceMessageType.Info
                });

            return serviceResult;
        }

        public static T Unauthorized<T>(this T serviceResult)
            where T : ServiceResult
        {
            serviceResult.Messages.Add(
                new ServiceMessage()
                {
                    Code = "Unauthorized",
                    Description = "You are not allowed to perform this action.",
                    Type = ServiceMessageType.Error
                });

            return serviceResult;
        }
    }
}
