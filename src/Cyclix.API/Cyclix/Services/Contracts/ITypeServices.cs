using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface ITypeServices
{
    Task<IReadOnlyList<TypeReadDto>> FindTypesAsync();
    Task<TypeReadDto> FindTypeAsync(long id);
    Task<long> CreateTypeAsync(TypeWriteDto typeWriteDto);
    Task UpdateTypeAsync(long id, TypeWriteDto typeWriteDto);
    Task DeleteTypeAsync(long id);
}