using PasswordManagement.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManagement.Api.Repositories.Interfaces
{
    public interface IPasswordCardRepository
    {
        Task<int> AddPasswordCardAsync(PasswordCard passwordCard);
        Task<List<PasswordCard>> GetPasswordCardsAsync(string name);
        Task<PasswordCard> GetPasswordCardAsync(int passwordCardId);
        Task<int> UpdatePasswordCardAsync(PasswordCard passwordCard);
    }
}
