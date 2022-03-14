using AutoMapper;
using PasswordManagement.Api.Dtos;
using PasswordManagement.Api.Models;

namespace PasswordManagement.Api.Mappers
{
    public class PasswordCardMapperProfile : Profile
    {
        public PasswordCardMapperProfile()
        {
            CreateMap<PasswordCard, PasswordCardDto>().ReverseMap();
        }
    }
}
