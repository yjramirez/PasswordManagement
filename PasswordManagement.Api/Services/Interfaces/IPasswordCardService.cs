using PasswordManagement.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManagement.Api.Services.Interfaces
{
    public interface IPasswordCardService
    {
        Task<int> AddPasswordCardAsync(PasswordCardDto passwordCardDto);
        Task<List<PasswordCardDto>> GetPasswordCardsAsync(string name);
        Task<PasswordCardDto> GetPasswordCardAsync(int passwordCardId);
        Task<int> UpdatePasswordCardAsync(PasswordCardDto passwordCardDto);
    }
}
