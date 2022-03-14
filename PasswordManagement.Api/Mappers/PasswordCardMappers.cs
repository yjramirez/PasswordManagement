using AutoMapper;
using PasswordManagement.Api.Dtos;
using System.Collections.Generic;

namespace PasswordManagement.Api.Mappers
{
    public static class PasswordCardMappers
    {
        static PasswordCardMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<PasswordCardMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static List<PasswordCardDto> ToModel(this List<PasswordCardDto> passwordCardDto)
        {
            return Mapper.Map<List<PasswordCardDto>>(passwordCardDto);
        }
    }
}
