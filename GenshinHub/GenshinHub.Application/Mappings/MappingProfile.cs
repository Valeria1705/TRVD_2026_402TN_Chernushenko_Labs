using AutoMapper;
using GenshinHub.Application.DTOs;
using GenshinHub.Domain.Entities;

namespace GenshinHub.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Character, CharacterDto>().ReverseMap();
        CreateMap<CreateCharacterDto, Character>();
        CreateMap<CharacterMaterial, CharacterMaterialDto>().ReverseMap();

        CreateMap<User, UserDto>();
        CreateMap<UserProgress, UserProgressDto>();
        CreateMap<Talents, TalentsDto>();

        CreateMap<Weapon, WeaponDto>().ReverseMap();
        CreateMap<CreateWeaponDto, Weapon>();
        CreateMap<WeaponMaterial, WeaponMaterialDto>().ReverseMap();

        CreateMap<Material, MaterialDto>().ReverseMap();
        CreateMap<CreateMaterialDto, Material>();

        CreateMap<News, NewsDto>().ReverseMap();
        CreateMap<CreateNewsDto, News>();
    }
}