using AutoMapper;
using GenshinHub.Application.DTOs;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;

namespace GenshinHub.Application.Services;

public class CharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CharacterDto>> GetAllCharactersAsync()
    {
        var characters = await _characterRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CharacterDto>>(characters);
    }

    public async Task<CharacterDto?> GetCharacterByIdAsync(string id)
    {
        var character = await _characterRepository.GetByIdAsync(id);
        return character == null ? null : _mapper.Map<CharacterDto>(character);
    }

    public async Task<CharacterDto> CreateCharacterAsync(CreateCharacterDto createDto)
    {
        var character = _mapper.Map<Character>(createDto);
        await _characterRepository.CreateAsync(character);
        return _mapper.Map<CharacterDto>(character);
    }

    public async Task<bool> UpdateCharacterAsync(string id, CreateCharacterDto updateDto)
    {
        var existing = await _characterRepository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(updateDto, existing);
        await _characterRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteCharacterAsync(string id)
    {
        var existing = await _characterRepository.GetByIdAsync(id);
        if (existing == null) return false;

        await _characterRepository.DeleteAsync(id);
        return true;
    }
}