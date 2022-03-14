using PasswordManagement.Api.Models;
using PasswordManagement.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PasswordManagement.Api.Repositories
{
    public class PasswordCardRepository : IPasswordCardRepository
    {
        private readonly PasswordManagementContext _passwordManagementContext;

        public PasswordCardRepository(PasswordManagementContext passwordManagementContext)
        {
            _passwordManagementContext = passwordManagementContext;
        }

        public async Task<int> AddPasswordCardAsync(PasswordCard passwordCard)
        {
            _passwordManagementContext.PasswordCards.Add(passwordCard);

            await _passwordManagementContext.SaveChangesAsync();

            return passwordCard.Id;
        }

        public Task<List<PasswordCard>> GetPasswordCardsAsync(string name)
        {
            return _passwordManagementContext.PasswordCards
                    .Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.ToLower()))
                    .ToListAsync<PasswordCard>();

        }

        public Task<PasswordCard> GetPasswordCardAsync(int passwordCardId)
        {
            return _passwordManagementContext.PasswordCards
                    .Where(x => x.Id == passwordCardId)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
        }

        public async Task<int> UpdatePasswordCardAsync(PasswordCard passwordCard)
        {
            _passwordManagementContext.PasswordCards.Update(passwordCard);

            await _passwordManagementContext.SaveChangesAsync();

            return passwordCard.Id;
        }
    }
}
