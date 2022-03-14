using PasswordManagement.Api.Helpers;
using System;

namespace PasswordManagement.Api.Resources
{
    public class PasswordCardServiceResources : IPasswordCardServiceResources
    {
        public ResourceMessage PasswordCardDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(PasswordCardDoesNotExist),
                Description = "PasswordCard with id {0} does not exist."
            };
        }
    }
}
