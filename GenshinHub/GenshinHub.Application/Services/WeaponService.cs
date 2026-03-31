using AutoMapper;
using GenshinHub.Application.DTOs;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;

namespace GenshinHub.Application.Services;

public class WeaponService
{
    private readonly IWeaponRepository _weaponRepository;
    private readonly IMapper _mapper;

    public WeaponService(IWeaponRepository weaponRepository, IMapper mapper)
    {
        _weaponRepository = weaponRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WeaponDto>> GetAllWeaponsAsync()
    {
        var weapons = await _weaponRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<WeaponDto>>(weapons);
    }

    public async Task<WeaponDto?> GetWeaponByIdAsync(string id)
    {
        var weapon = await _weaponRepository.GetByIdAsync(id);
        return weapon == null ? null : _mapper.Map<WeaponDto>(weapon);
    }

    public async Task<WeaponDto> CreateWeaponAsync(CreateWeaponDto createDto)
    {
        var weapon = _mapper.Map<Weapon>(createDto);
        await _weaponRepository.CreateAsync(weapon);
        return _mapper.Map<WeaponDto>(weapon);
    }

    public async Task<bool> UpdateWeaponAsync(string id, CreateWeaponDto updateDto)
    {
        var existing = await _weaponRepository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(updateDto, existing);
        await _weaponRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteWeaponAsync(string id)
    {
        var existing = await _weaponRepository.GetByIdAsync(id);
        if (existing == null) return false;

        await _weaponRepository.DeleteAsync(id);
        return true;
    }
}