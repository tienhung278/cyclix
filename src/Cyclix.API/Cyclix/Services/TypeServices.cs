using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class TypeServices : ITypeServices
{
    private readonly ITypeRepository _typeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TypeServices(IRepositoryManager repositoryManager)
    {
        _typeRepository = repositoryManager.TypeRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<TypeReadDto>> FindTypesAsync()
    {
        var types = await _typeRepository.FindAllAsync();
        return types.Select(t => new TypeReadDto(t)).ToList();
    }

    public async Task<TypeReadDto> FindTypeAsync(long id)
    {
        var type = await _typeRepository.FindByIdAsync(id);
        return new TypeReadDto(type);
    }

    public async Task<long> CreateTypeAsync(TypeWriteDto typeWriteDto)
    {
        var type = await _typeRepository.CreateAsync(typeWriteDto.ToType());
        await _unitOfWork.SaveChangesAsync();
        return type.Id;
    }

    public async Task UpdateTypeAsync(long id, TypeWriteDto typeWriteDto)
    {
        var type = await _typeRepository.FindByIdAsync(id);
        type.Name = typeWriteDto.Name;
        await _typeRepository.UpdateAsync(type);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTypeAsync(long id)
    {
        var type = await _typeRepository.FindByIdAsync(id);
        if (type == null)
        {
            throw new NullReferenceException();
        }
        await _typeRepository.DeleteAsync(type);
        await _unitOfWork.SaveChangesAsync();
    }
}