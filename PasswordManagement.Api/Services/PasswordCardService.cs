using AutoMapper;
using PasswordManagement.Api.Dtos;
using PasswordManagement.Api.ExceptionHandling;
using PasswordManagement.Api.Mappers;
using PasswordManagement.Api.Models;
using PasswordManagement.Api.Repositories.Interfaces;
using PasswordManagement.Api.Resources;
using PasswordManagement.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManagement.Api.Services
{
    public class PasswordCardService : IPasswordCardService
    {
        private readonly IPasswordCardRepository _passwordCardRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordCardServiceResources _passwordCardServiceResources;

        public PasswordCardService(
            IPasswordCardRepository passwordCardRepository,
            IMapper mapper,
            IPasswordCardServiceResources passwordCardServiceResources) 
        {
            _passwordCardRepository = passwordCardRepository;
            _mapper = mapper;
            _passwordCardServiceResources = passwordCardServiceResources;
        }

        public async Task<int> AddPasswordCardAsync(PasswordCardDto passwordCardDto)
        {
            var passwordCard = _mapper.Map<PasswordCard>(passwordCardDto);

            var added = await _passwordCardRepository.AddPasswordCardAsync(passwordCard);
            
            return added;
        }

        public async Task<List<PasswordCardDto>> GetPasswordCardsAsync(string name)
        {
            var passwordCars = await _passwordCardRepository.GetPasswordCardsAsync(name);
            
            var passwordCarsdDto = _mapper.Map<List<PasswordCardDto>>(passwordCars);
            
            return passwordCarsdDto;
        }

        public async Task<PasswordCardDto> GetPasswordCardAsync(int passwordCardId)
        {
            var passwordCard = await _passwordCardRepository.GetPasswordCardAsync(passwordCardId);

            if (passwordCard == null)
            {
                throw new UserFriendlyErrorPageException(string.Format(_passwordCardServiceResources.PasswordCardDoesNotExist().Description, passwordCardId));
            }

            var passwordCardDto = _mapper.Map<PasswordCardDto>(passwordCard);

            return passwordCardDto;
        }

        public Task<int> UpdatePasswordCardAsync(PasswordCardDto passwordCardDto)
        {
            var passwordCard = _mapper.Map<PasswordCard>(passwordCardDto);
            
            
            var updated = _passwordCardRepository.UpdatePasswordCardAsync(passwordCard);
            
            return updated;
        }
    }
}
