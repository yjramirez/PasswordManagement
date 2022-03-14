using PasswordManagement.Api.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManagement.Api.Resources
{
    public class ApiErrorResources : IApiErrorResources
    {
        public ApiError CannotSetId()
        {
            return new ApiError
            {
                Code = nameof(CannotSetId),
                Description = "Canot set ID when creating a new entity."
            };
        }
    }
}
