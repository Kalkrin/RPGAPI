using AutoMapper;
using RolePlayingGameAPI.Dtos.Character;
using RolePlayingGameAPI.Models;

namespace RolePlayingGameAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }

    }
}