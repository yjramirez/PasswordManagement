using PasswordManagement.Api.ExceptionHandling;

namespace PasswordManagement.Api.Resources
{
    public interface IApiErrorResources
    {
        ApiError CannotSetId();
    }
}
