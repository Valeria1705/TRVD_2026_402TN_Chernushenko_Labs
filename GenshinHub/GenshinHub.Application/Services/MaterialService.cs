using AutoMapper;
using GenshinHub.Application.DTOs;
using GenshinHub.Domain.Entities;
using GenshinHub.Domain.Interfaces;

namespace GenshinHub.Application.Services;

public class MaterialService
{
    private readonly IMaterialRepository _materialRepository;
    private readonly IMapper _mapper;

    public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
    {
        _materialRepository = materialRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MaterialDto>> GetAllMaterialsAsync()
    {
        var materials = await _materialRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MaterialDto>>(materials);
    }

    public async Task<MaterialDto?> GetMaterialByIdAsync(string id)
    {
        var material = await _materialRepository.GetByIdAsync(id);
        return material == null ? null : _mapper.Map<MaterialDto>(material);
    }

    public async Task<MaterialDto> CreateMaterialAsync(CreateMaterialDto createDto)
    {
        var material = _mapper.Map<Material>(createDto);
        await _materialRepository.CreateAsync(material);
        return _mapper.Map<MaterialDto>(material);
    }

    public async Task<bool> UpdateMaterialAsync(string id, CreateMaterialDto updateDto)
    {
        var existing = await _materialRepository.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(updateDto, existing);
        await _materialRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteMaterialAsync(string id)
    {
        var existing = await _materialRepository.GetByIdAsync(id);
        if (existing == null) return false;

        await _materialRepository.DeleteAsync(id);
        return true;
    }
}